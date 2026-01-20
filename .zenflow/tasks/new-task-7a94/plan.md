# Full SDD workflow

## Configuration
- **Artifacts Path**: {@artifacts_path} → `.zenflow/tasks/{task_id}`

---

## Workflow Steps

### [x] Step: Requirements
<!-- chat-id: d99e8608-cd8d-461c-9d05-2af61c99bd9b -->

Create a Product Requirements Document (PRD) based on the feature description.

1. Review existing codebase to understand current architecture and patterns
2. Analyze the feature definition and identify unclear aspects
3. Ask the user for clarifications on aspects that significantly impact scope or user experience
4. Make reasonable decisions for minor details based on context and conventions
5. If user can't clarify, make a decision, state the assumption, and continue

Save the PRD to `{@artifacts_path}/requirements.md`.

### [x] Step: Technical Specification
<!-- chat-id: 7ad0fc3b-6a08-4916-9776-122bbc6948ad -->

Create a technical specification based on the PRD in `{@artifacts_path}/requirements.md`.

1. Review existing codebase architecture and identify reusable components
2. Define the implementation approach

Save to `{@artifacts_path}/spec.md` with:
- Technical context (language, dependencies)
- Implementation approach referencing existing code patterns
- Source code structure changes
- Data model / API / interface changes
- Delivery phases (incremental, testable milestones)
- Verification approach using project lint/test commands

### [x] Step: Planning
<!-- chat-id: 63a8aa6e-7670-452e-a635-aa3072cbab2c -->

Create a detailed implementation plan based on `{@artifacts_path}/spec.md`.

1. Break down the work into concrete tasks
2. Each task should reference relevant contracts and include verification steps
3. Replace the Implementation step below with the planned tasks

Rule of thumb for step size: each step should represent a coherent unit of work (e.g., implement a component, add an API endpoint, write tests for a module). Avoid steps that are too granular (single function) or too broad (entire feature).

If the feature is trivial and doesn't warrant full specification, update this workflow to remove unnecessary steps and explain the reasoning to the user.

Save to `{@artifacts_path}/plan.md`.

### [ ] Task: Project Bootstrap
<!-- chat-id: 31d82a64-8409-43db-afa3-a6a1b32270a6 -->
- Create Vite React TS app skeleton; add TypeScript config, ESLint + Prettier, Vitest, React Testing Library, Playwright
- Add dependencies: three, @react-three/fiber, @react-three/drei, zustand, immer, zod, jszip, gifenc or gif.js
- Scripts: build, dev, lint, typecheck, test, e2e
- Verify: run `dev` boots app; `lint` passes; `typecheck` passes; `test` runs zero tests

### [ ] Task: Base Types & Schemas
- Add `src/types/{model.ts,pose.ts,project.ts}` per spec interfaces
- Add zod schemas for Project and settings; export TypeScript types
- Verify: typecheck succeeds; unit test compiles types

### [ ] Task: State Store
- Implement `src/state/store.ts` with model, poses, keyframes, playback, UI state; use Zustand + Immer
- Add `src/state/selectors.ts` for memoized selectors
- Verify: unit tests for reducers/actions; time travel sanity (undo placeholder)

### [ ] Task: Model Loading & Validation
- Implement `src/three/loaders/modelLoader.ts` supporting GLTF/GLB primary; FBX/OBJ best-effort
- Detect rig: SkinnedMesh + Skeleton; build bone map; texture auto-mapping by filename suffix
- Verify: load sample glTF rigs; warn on non-rigged; detect bones and show counts

### [ ] Task: Viewport & Scene
- Implement `src/three/canvas/Scene.tsx` with R3F Canvas, OrbitControls, studio lighting, grid helpers
- Add `src/components/Viewport.tsx` mounting the scene and overlays
- Verify: 60 FPS idle with empty scene; camera controls functional

### [ ] Task: Import UI
- Implement `src/components/ImportDialog.tsx` with drag-and-drop and file picker; show validations
- Wire to loader; set model into store
- Verify: drop a GLB and see the model in the viewport; errors surface in Notifications

### [ ] Task: Skeleton Visualization & Selection
- Add SkeletonHelper toggle; implement `src/components/HierarchyTree.tsx` to browse/select bones
- Highlight selected bone in scene
- Verify: selecting bones highlights and updates inspector

### [ ] Task: Pose Editing (FK)
- Add TransformControls bound to selected bone; clamp rotations by `lib/constraints/jointLimits.ts`
- Root translation allowed; other bones rotation-only
- Verify: rotate limb bones and observe updates; joint limits enforced

### [ ] Task: Pose Persistence
- Define `Pose` capture/apply utilities in `src/types/pose.ts` helpers
- Save/restore poses in store; copy/paste between keyframes
- Verify: create pose A/B/C and switch reliably; values stable across switches

### [ ] Task: Timeline & Keyframes
- Implement `src/components/Timeline.tsx` with three fixed slots (Begin/Middle/End), durations, easing per segment
- Scrubbing and play/pause/loop in `src/components/PlaybackControls.tsx`
- Verify: scrub timeline and see pose blending (temporary linear)

### [ ] Task: Interpolators & Constraint Pass
- Implement `src/three/animation/interpolators.ts` for quaternion slerp, root lerp, cubic easing
- Constraint-aware pass to clamp post-interpolation
- Verify: unit tests for slerp accuracy and easing curves; visual smooth playback

### [ ] Task: Loop Alignment
- Implement `src/three/animation/looping.ts` to snap End to Start with blend tolerance when loop is enabled
- Verify: with loop on, End≈Start; visual seam-free cycle

### [ ] Task: IK Solver Core
- Implement FABRIK or CCD in `src/three/ik/solver.ts`; define limb chains and limits
- Verify: unit tests on simple chains converge within tolerance; no NaNs

### [ ] Task: IK UI & Effector Drag
- Add draggable effectors for wrist/ankle; raycast targets; per-limb FK/IK toggle in `PosePanel`
- Solve during drag; write back bone rotations
- Verify: drag wrist target and watch arm follow; joint limits respected

### [ ] Task: Multi-Pane Previews
- Implement `src/components/PreviewPanes.tsx` rendering Begin/Middle/End subviews via shared scene with pose overrides
- Verify: three panes render different keyframe poses; performance acceptable

### [ ] Task: Export — GLB
- Implement `src/three/exporters/gltfExport.ts` baking sampled keyframes into one AnimationClip; export GLB
- Verify: re-import exported GLB and play clip correctly

### [ ] Task: Export — Video
- Implement `src/three/exporters/videoExport.ts` using offscreen canvas + MediaRecorder; WebM VP8/VP9; feature-detect MP4
- Verify: produce playable WebM at chosen fps; fallback messaging for unsupported types

### [ ] Task: Export — Image Sequence & GIF
- Implement `src/three/exporters/imageSequenceExport.ts` to render PNG frames and zip via JSZip; optional GIF via gifenc
- Verify: ZIP opens with correct frame count; optional GIF animates as expected

### [ ] Task: Export — Project JSON
- Implement `src/three/exporters/jsonExport.ts` for save/load project (paths, poses, keyframes, settings)
- Verify: save project, reload page, load project and recover state

### [ ] Task: Project Persistence & Autosave
- Implement IndexedDB storage; autosave on changes; recent projects list
- Verify: refresh recovery; storage quotas handled with warnings

### [ ] Task: Undo/Redo
- Implement command pattern over store mutations with bounded history
- Verify: Ctrl+Z/Ctrl+Y revert/apply edits for pose and timeline changes

### [ ] Task: Accessibility & Keyboard
- Use Radix/headless primitives for focus; shortcuts for play/pause, next/prev keyframe, reset view
- Verify: tab order sensible; ARIA roles on dialogs and lists; keyboard-only flow works

### [ ] Task: Unit Tests
- Interpolators, IK edge cases, loop alignment, store reducers
- Verify: vitest suite green; coverage for math utilities

### [ ] Task: Component Tests
- Timeline interactions, PosePanel actions, ImportDialog validations
- Verify: React Testing Library tests pass and are stable

### [ ] Task: E2E Flow
- Playwright test: import → create three poses → play/loop → export GLB/WebM
- Verify: e2e passes in Chromium CI

### [ ] Task: Performance Budget
- Audit renders; memoize selectors; ensure ≤16 ms/frame idle with reference rig; offload encoding to worker if needed
- Verify: FPS overlay and profiling meet targets
