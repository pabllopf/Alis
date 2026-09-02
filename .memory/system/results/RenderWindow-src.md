# Result: RenderWindow.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/RenderWindow.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 0.0% (unchanged)
TestsAdded: 0 (none — no deterministic managed logic)
Commit: test: coverage RenderWindow.cs
Status: BLOCKED_BY_NATIVE

## Summary

RenderWindow.cs is a pure native-boundary SFML wrapper (91 direct `[DllImport]` P/Invoke calls:
`sfRenderWindow_*`, `sfMouse_*`, `sfTouch_*`, `sfKeyboard_*`). Every public method is either a one-line
native call or a constructor that chains to a native creation call.

- Ctors `(mode, title)`, `(mode,title,style)` chain via `this(...)`; the terminal ctor calls
  `sfRenderWindow_createUnicode` unconditionally.
- `(IntPtr handle)` / `(IntPtr handle, settings)` ctor passes to `sfRenderWindow_createFromHandle`.
- All rendering/state/mouse/touch/icon methods are direct native calls.

No deterministic managed logic exists to cover. String arguments (title) are passed straight through the
P/Invoke boundary, so the null-probe pattern (which works on ImGui because the string is marshaled via
`Encoding.UTF8.GetBytes` at the call site and throws managed-side) is NOT applicable — a null string
passes through to native and segfaults (verified empirically for SFML/SDL with a libc strlen(null) probe,
exit 139). Calling native render-window methods with no real native context also risks native crashes.
Deterministic coverage would require a running native CSfml context (non-deterministic in CI).

## Remaining uncovered (BLOCKED_BY_NATIVE)

All method bodies in the file.

## Verification

- No test file generated (record-only task).
- Full project build: unaffected.
- Local coverlet: no new coverage (0.0%).