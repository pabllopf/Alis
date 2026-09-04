# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Windows/Touch.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 100.0% (16/16 lines, existing suite + 1 new test; verified via XPlat Code Coverage)
TestsAdded: 1 (TouchTest.cs: GetPosition_WithWindow_DelegatesToWindow + MockTouchWindow)
Commit: (none)
Status: COVERED
Details:
- Missed lines were 72-73 (the relativeTo != null branch of GetPosition(finger, Window) dispatching to window.InternalGetTouchPosition).
- Added a MockTouchWindow (subclass of Window built on (IntPtr.Zero, 0)) overriding the virtual InternalGetTouchPosition(uint) to intercept without any native call; Touch.GetPosition(3, window) returns the mock vector and asserts delegation.
- Full Sfml project suite: 1865/1865 green.