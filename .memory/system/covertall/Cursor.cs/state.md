# State — Cursor.cs

Target: 1_Presentation/Extension/Graphic/Sfml/src/Windows/Cursor.cs
Project: 1_Presentation/Extension/Graphic/Sfml/src/Alis.Extension.Graphic.Sfml.csproj
Test project: 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj
Agent: cover-agent-001
Baseline commit: 2e91a3e6cfb3a7ba79b612b87b591954d0c1a5b4
Initial line coverage: 38.89% (7/18)
Initial branch coverage: 100.00% (0/0)
Current line coverage: 100.00% (18/18)
Current branch coverage: 100.00% (0/0)
Tests before: 1661
Tests after: 1662
Files modified: test/Windows/CursorPixelConstructorTests.cs (added)
Tests added: 1
Commits: test: cover pixel constructor of Cursor.cs
Remaining uncovered lines: none
Remaining uncovered branches: none
Status: COMPLETED
Last update: 2026-08-17

## Notes

The pixel-based constructor `Cursor(byte[] pixels, Vector2F size, Vector2F hotspot)`
was entirely uncovered. A native cursor from real pixel data cannot be created on
this machine: SFML 3.0.x `CursorImpl::loadFromPixels` calls `[NSImage raw
imageWithRawData:andSize:]` which throws a bus error (EXC_BAD_ACCESS) on this
macOS/Apple Silicon environment, crashing the test host process. This was
confirmed empirically with 4x4 RGBA and zero-size inputs.

The documented null-pixels behavior (`"If pixels is null ... the function will
return false"`) is fully testable: `sfCursor_createFromPixels(NULL, ...)` returns
early without touching the crashing code path. The added test constructs a
cursor with null pixels, asserts `CPointer == IntPtr.Zero`, and exercises the
entire constructor body (pinning, try/finally, handle release).