# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Windows/Mouse.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 70.0% (28/40 lines, existing committed suite; verified via XPlat Code Coverage)
TestsAdded: 0 (attempted SetPosition_WithoutWindow_MovesCursor; reverted)
Commit: (none)
Status: PARTIAL_BLOCKED_BY_NATIVE
Details:
- Missed lines: 125-127 (SetPosition(Vector2F) single-arg overload body) and 145-147 (null-window else branch of SetPosition(Vector2F, Window)).
- Both paths inevitably invoke `sfMouse_setPosition(position, IntPtr.Zero)` with a null reference window. All other Mouse code (GetPosition, IsButtonPressed, window-relative SetPosition via MockMouseWindow) is covered.
- A probe test calling the single-arg overload with a null-relativeTo crashed the dotnet test host immediately ("Serie de pruebas anulada"), so the null-window native path is not executable in this environment -> CSFML 3.0 null-window mouse call is unstable on macOS. Existing suite remains green (63/63 Mouse tests pass, run not aborted when the probe is absent).
- The pre-existing SetPosition_WithoutNativeLibrary_Throws test also targets this path but only executes when CSFML is unloadable.