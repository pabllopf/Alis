# Touch.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Touch.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 75% (6/8, local — 22 existing tests pass)
- **Tests Added**: 0 (probe removed — Window(IntPtr) with invalid handle aborts host: "Cannot import this Window Handle")
- **Uncovered Lines**: 72-73 — GetPosition non-null window branch: requires live main-thread NSWindow reference (hook worker disposes it before tests). Production/threading constraint.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
