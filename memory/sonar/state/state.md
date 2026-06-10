# SonarCloud Distributed Maintainability Remediation — State

## Status
- **Phase**: processing
- **Started**: 2026-06-10
- **Worker**: worker-mac-2
- **Total Issues**: 296
- **Previously Processed**: ~50 (from prior worker-mac-1 session)
- **Fixed This Session**: 9 files
- **Remaining**: ~238

## Completed This Session
| File | Issues Fixed | Commit |
|------|-------------|--------|
| BottomMenu.cs | 10 S125 | 2e8231b05 |
| InspectorWindow.cs | 7 S125 | cf8a49f8a |
| SceneWindow.cs | 5 S125 | 873b45eff |
| SettingsWindow.cs | 2 S125 + 1 S1144 | 587c61e4c |
| TopMenuAction.cs | 2 S125 + 4 S1144 | 2a78fa8ae |
| TopMenuMac.cs | 1 S125 | 72a551f90 |
| ImGuizmoDemo.cs | 1 S125 | ccd18e53f |
| DockSpaceMenu.cs | 1 S125 | 8886839c8 |
| ProjectWindow.cs | 1 S125 | 68425314b |

## Priority Order
1. ~~S125 — Remove commented out code (MAJOR, highest volume)~~ ✅ DONE
2. S1481 — Remove unused local variables (MINOR)
3. S1144 — Remove unused private methods/fields (MAJOR)
4. S2933 — Make readonly (MAJOR)
5. S2325 — Make static (MINOR)
6. S108 — Empty if/else blocks (MAJOR)
7. S1075 — Hardcoded paths (MINOR)
8. S2696 — Static field access (CRITICAL)
9. S3776 — Cognitive complexity (CRITICAL)
10. S3881 — Dispose pattern (MAJOR)

## Locks
| Issue ID | Worker | Acquired | Released |
|----------|--------|----------|----------|

## Progress
| Phase | Status |
|-------|--------|
| Memory structure | ✅ created |
| Issues loaded | ✅ synced from cache |
| S125 fixes | ✅ 9 files committed |
| S1481/S1144 fixes | ⏳ next |
| Issues committed | 9/296 |
