# PRD: 3D Pose-to-Animation App

## Overview
An application that lets users upload a rigged 3D model with textures, set beginning/middle/end poses via intuitive preview panes and drag-and-drop limb controls, and automatically generates natural in-between animation. Users can loop animations and export in multiple formats.

## Goals
- Enable non-experts to create simple, natural-looking animations from a few poses
- Provide fast, interactive pose editing with clear visual feedback
- Support common model and texture formats used by creators
- Offer looping and multiple export options for sharing or downstream use

## Non-Goals
- Full DCC suite feature parity (e.g., Blender/Maya-level rigging/graph editors)
- Advanced simulation (cloth, physics, fluid)
- Procedural animation authoring beyond basic interpolation and constraints
- Server-side rendering farm or online asset storage (unless clarified)

## Target Users
- Indie creators, designers, and game devs prototyping quick animations
- Educators/students learning posing and keyframing basics
- Social/video creators needing short looped motions

## Use Cases
- Import a rigged character, set 3 poses, export a seamless looped idle animation
- Pose a product or creature for a short turntable + subtle motion
- Make a GIF/WebM of a waving character for social media

## Functional Requirements
1) Model & Texture Import (Must)
- Accept rigged models: glTF/glb (preferred), FBX (if rigged), OBJ+MTL (treated as static unless separately rigged)
- Accept textures: baseColor/albedo, normal, roughness/metallic, AO, emission
- Validate rig presence (skeleton/bones) and report if model is not rigged
- Texture assignment UI with drag-and-drop, auto-map by filename where possible

2) Viewport & Previews (Must)
- Single main 3D viewport with orbit/pan/zoom, grid, and lighting presets
- Optional split panes for Begin, Middle, End pose previews with synced camera
- Gizmos for translate/rotate (and scale if applicable); pose on bones and/or mesh controls

3) Pose Editing (Must)
- Select bones/controls from hierarchy panel or in-viewport picking
- Drag-and-drop limbs/parts with constraints to maintain plausible ranges
- FK/IK toggle per limb where supported by rig
- Save/restore named poses; copy/paste pose between keyframes

4) Keyframes & Timeline (Must)
- Begin, Middle, End keyframes on a simple timeline with durations per segment
- Easing controls per segment (linear, ease-in/out, cubic, custom curve)
- Global playback controls: play/stop, scrub, loop toggle

5) Automatic In-Betweens (Must)
- Interpolate transforms per bone between keyframes with quaternion-aware rotation blending
- Optional trajectory smoothing and foot/contact stabilization
- Constraint-aware blending to reduce artifacts

6) Looping (Must)
- Loop toggle ensuring first/last frames align; option to auto-adjust end keyframe to match start
- Preview loop count and timing

7) Export (Must/Should)
- Animation data export: glTF/glb with baked animation clips (Must)
- Video export: MP4/WebM with configurable duration, fps, resolution, background (Should)
- Image sequence/GIF export for short loops (Should)
- JSON pose/animation preset export/import (Could)

8) Project Management (Should)
- New/Open/Save project files bundling model, textures refs, and keyframes
- Autosave and undo/redo stack

9) Guidance & Error Handling (Must)
- Clear warnings for missing rig, incompatible formats, or texture mismatches
- Tooltips/help for first-time users

## Non-Functional Requirements
- Performance: interactive 60 FPS target on mid-tier hardware; responsive UI under typical asset sizes (<50 MB models)
- Compatibility: modern desktop browsers (WebGL2/WebGPU) or desktop app; clarify platform choice
- Accessibility: keyboard navigation for selection and playback; color-contrast compliant UI
- Reliability: no data loss on crashes (autosave frequency configurable)
- Privacy/Security: all processing local by default; no uploads without explicit consent

## Assumptions
- Primary platform is a browser-based app using modern GPU APIs; offline/desktop build is a stretch goal
- Users predominantly import rigged models (auto-rigging is out of scope)
- Three-keyframe workflow is the primary path; additional keyframes may be a future enhancement
- Export video is client-side rendering

## Success Metrics
- Time-to-first-export: <10 minutes for a new user with a ready rig
- Smooth playback and scrubbing with typical assets
- >80% of validation users successfully export a looped animation on first attempt

## Milestones
1) MVP: import rig + set 3 poses + interpolate + looped glTF export
2) Quality: constraints/FK-IK, pose library, easing curves
3) Exports: MP4/WebM/GIF, image sequences, JSON presets
4) Polish: autosave, undo/redo, multi-pane previews, help

## Risks
- Rig variety and inconsistent bone naming
- Performance on large meshes or complex materials
- Cross-browser video encoding constraints

## Open Questions
1) Platform: web app, desktop (Electron), or both?
2) Minimum format support: is FBX a hard requirement, or can we launch with glTF/glb only?
3) Are non-rigged models acceptable with a basic posing rig, or should we block them?
4) Video export specifics: required codecs/containers, transparency needs (alpha)?
5) Max asset size and performance targets for the initial release?
6) Do we need audio sync or soundtrack for exports?
7) Should we allow more than three keyframes in v1?
8) Desired export presets (e.g., social platform sizes, game engine compatibility)?
