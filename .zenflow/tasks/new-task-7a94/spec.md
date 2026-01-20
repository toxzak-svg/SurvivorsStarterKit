# Technical Specification: 3D Pose-to-Animation App

## Technical Context
- Platform: Browser-first SPA; optional desktop via Electron as a follow-up
- Language: TypeScript
- Build Tool: Vite
- UI Framework: React 18
- 3D Stack: three, @react-three/fiber (R3F), @react-three/drei
- State: Zustand (lightweight, reactive store) + Immer
- Validation/Schema: zod (project/preset files)
- File Handling: browser File System Access API when available; fallback to in-memory + downloads
- Encoding/Export:
  - GLTF/GLB: three/examples/jsm/exporters/GLTFExporter
  - Video: MediaRecorder API (WebM VP8/VP9 where available), feature-detect MP4 support
  - Image Sequence/GIF: offscreen canvas frames → PNG sequence (JSZip) and optional GIF encoder (gifenc or gif.js)
  - JSON presets: project schema via zod
- Loaders: GLTFLoader (primary), FBXLoader (best-effort), OBJLoader + MTLLoader (static)
- Controls/Helpers: OrbitControls, TransformControls, SkeletonHelper, grid helpers, CameraControls (drei)
- Testing: Vitest (unit), React Testing Library (components), Playwright (E2E happy-path flows)
- Lint/Format: ESLint + @typescript-eslint + Prettier
- Accessibility: Radix UI primitives or headless components for focus management and keyboard support

Assumptions resolving PRD open questions
- Platform: ship web first; evaluate Electron packaging post-MVP
- Format support: launch with glTF/GLB as required; FBX best-effort; OBJ treated as static
- Non‑rigged models: loadable with warning; posing/animation disabled; allow basic transform-only turntable export
- Video: prioritize WebM; expose MP4 only if `MediaRecorder.isTypeSupported('video/mp4')` returns true; no alpha in v1
- Asset size: soft limit 50 MB with warnings; block >200 MB to avoid OOM
- Audio: not in v1
- Keyframes: exactly three (Begin/Middle/End) in v1; architecture supports N keyframes later

## Implementation Approach

Core principles
- All processing local; no network I/O
- Keep GPU work on a single WebGL2 context; avoid redundant scene graphs
- Pose state is bone‑centric, using quaternions for rotations and constrained translation for root
- Interpolation uses quaternion slerp and cubic Hermite for smooth parameter curves; constraints clamp to joint limits

Subsystems
1) Import & Validation
- Accept files via drag‑and‑drop and file picker; detect type by magic bytes and extension
- Parse via GLTFLoader; if FBX/OBJ, use corresponding loaders; unwrap textures and assign to PBR materials
- Validate presence of `SkinnedMesh` and `Skeleton`; build bone map (name → Bone ref) and detect standard limbs by heuristics (e.g., regex on names)
- Texture auto‑mapping by filename suffix (basecolor/albedo, normal, roughness, metallic, ao, emissive)

2) Viewport & Previews
- Single R3F <Canvas> with OrbitControls; lighting presets (studio/three‑point/neutral)
- Optional split preview panes: render three subviews (Begin/Middle/End) by reusing the same scene with pose overrides at render time
- Display SkeletonHelper toggle; highlight selected bone; gizmos via TransformControls attached to bone or IK effector

3) Pose Editing (FK/IK)
- Selection via hierarchy tree or picking; maintain active selection and current mode (FK/IK)
- FK: directly modify bone quaternion (and root position) with TransformControls; clamp via per‑bone joint limits
- IK: limb chains defined per rig (e.g., shoulder→elbow→wrist, hip→knee→ankle)
  - Implement FABRIK or CCD solver operating on temporary copies, then write back to bone rotations
  - Effector drag using pointer raycast to a draggable target; solve each frame while dragging

4) Timeline & Keyframes
- Minimal timeline with three keyframe slots; editable segment durations and easing (linear, ease‑in, ease‑out, ease‑in‑out, cubic Bezier)
- Store poses per keyframe; copy/paste/rename poses; playback controls (play/pause/scrub/loop)
- Loop alignment: when loop is enabled, auto‑snap End to Start with blend tolerance

5) In‑Between Generation
- For each bone channel: slerp rotations; lerp/clamped root translation; support cubic Hermite per‑segment easing
- Constraint‑aware pass: enforce joint limits after interpolation; optional foot contact stabilization (pin ankle height during stance window)
- Trajectory smoothing: optional low‑pass filter on root path

6) Export
- GLTF/GLB: bake sampled keyframes into a single AnimationClip on the model; export as GLB with embedded textures
- Video: render at requested fps to an offscreen canvas; record via MediaRecorder to WebM; show compatibility note for MP4
- Image sequence: render frames and zip as PNGs; optional GIF encoding for short loops
- JSON: export/import project with model path refs and serialized keyframes/poses (no binary embed)

7) Project Management
- Project file format (JSON): includes metadata, relative asset paths, keyframes, easing, loop settings; autosave to IndexedDB
- Undo/redo stack: command pattern over store mutations; history bounded to prevent memory leaks

## Source Code Structure
- src/main.tsx – app bootstrap, providers
- src/app/App.tsx – shell layout, routing
- src/state/store.ts – Zustand store (model, poses, keyframes, playback, UI)
- src/state/selectors.ts – memoized selectors
- src/types/
  - model.ts – ModelAsset, BoneRef, SkeletonInfo
  - pose.ts – Pose, BonePose, Keyframe, Easing
  - project.ts – Project schema and persistence types
- src/three/canvas/Scene.tsx – R3F scene, lights, grid, controls
- src/three/loaders/modelLoader.ts – file detection, loaders, texture assignment
- src/three/ik/solver.ts – FABRIK/CCD implementation and chain definitions
- src/three/animation/interpolators.ts – slerp/lerp, cubic curves, constraint pass
- src/three/animation/looping.ts – loop alignment and end→start snapping
- src/three/exporters/
  - gltfExport.ts – GLB with baked AnimationClip
  - videoExport.ts – MediaRecorder capture pipeline
  - imageSequenceExport.ts – PNG sequence + zip
  - jsonExport.ts – project import/export
- src/components/
  - Viewport.tsx – main viewport
  - PreviewPanes.tsx – Begin/Middle/End multi‑view
  - Timeline.tsx – three keyframes, durations, easing, scrubber
  - PosePanel.tsx – save/load/copy poses, FK/IK toggle
  - HierarchyTree.tsx – skeleton tree, selection
  - Inspector.tsx – transform inputs, constraints, limits
  - ImportDialog.tsx – file drop/picker, validations
  - TextureAssignPanel.tsx – texture slots, drag‑and‑drop
  - PlaybackControls.tsx – play/stop/loop/fps
  - Notifications.tsx – warnings/errors
- src/lib/constraints/jointLimits.ts – default human‑like limits; extensible per bone
- src/utils/format.ts, math.ts – helpers
- public/ – static assets, icons

## Data Model / Interfaces
- ModelAsset
  - id, name, scene, skeleton, bones: Map<string, BoneRef>
  - materials/textures metadata
- Pose
  - root: { position: vec3, rotation: quat }
  - bones: Record<boneId, { rotation: quat }>
- Keyframe
  - id, time, poseId, easing: { type: 'linear'|'easeIn'|'easeOut'|'easeInOut'|'cubic', cubic?: [p0x,p0y,p1x,p1y] }
- AnimationSettings
  - durationMs, segmentDurations: [begin→middle, middle→end], fps, loop: boolean
- Project
  - id, title, modelRef, textures, keyframes: [begin,middle,end], settings, constraintsProfile

## Delivery Phases
1) MVP Import & Viewport
- glTF/GLB import, skeleton detection, viewport with controls, basic warnings
- Verify: import sample rigs; SkeletonHelper visible; 60 FPS idle

2) Posing (FK) + Keyframes
- TransformControls on bones; save/restore poses; three keyframe slots; basic playback
- Verify: create three poses and scrub; confirm per‑bone values change

3) Interpolation & Looping
- Slerp/lerp with easing; loop alignment; constraint pass
- Verify: playback smoothness; end≈start when loop enabled

4) IK Dragging
- Implement FABRIK/CCD for arms/legs; effector drag; per‑limb FK/IK toggle
- Verify: drag wrist/ankle targets; minimal joint limit violations

5) Export
- GLB with baked clip; WebM capture; PNG sequence; JSON project
- Verify: re‑import GLB into app/three viewer; play captured video; open ZIP

6) Quality & Polish
- Multi‑pane previews; pose library; autosave; undo/redo; tooltips; accessibility passes
- Verify: keyboard navigation and ARIA roles in critical UI; recovery after reload

## Verification Approach
- Scripts (to be added):
  - typecheck: tsc --noEmit
  - lint: eslint "src/**/*.{ts,tsx}"
  - test: vitest run
  - e2e: playwright test --project=chromium
- Unit tests: interpolators, IK solver edge cases, loop alignment
- Component tests: Timeline interactions, PosePanel actions
- E2E: import→pose→playback→export (GLB/WebM)
- Performance: ensure render loop stays ≤16 ms on reference rig; memoize selectors and suspend heavy work off main thread when possible (e.g., encode in worker)
- Compatibility: feature-detect MediaRecorder types; fallback messaging for unsupported codecs

## Risks & Mitigations
- Rig name variance: heuristics + user‑mappable bone groups
- Browser video constraints: default to WebM; document MP4 availability per browser
- Large assets: soft/hard size caps, async loader with progress, texture downscaling option
