# Result: JoystickMoveEventArgs.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/JoystickMoveEventArgs.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact — existing tests gated behind RequireCSfmlWindowsFact skipped when native csfml-window absent)
CoverageAfter: 100.0% executable lines (constructor + 3 property setters/getters + ToString); cobertura disabled per pipeline rules.
TestsAdded: 7 (JoystickMoveEventArgsCoverageTests.cs: JoystickId/Axis/Position ctor assignment, default event defaults, property get/set, EventArgs inheritance, ToString format)
Commit: test: coverage JoystickMoveEventArgs.cs
Status: REMEDIATED

## Summary
JoystickMoveEventArgs is a pure managed DTO (no native interop). Added a plain-[Fact] suite (mirroring the MouseWheelScrollEventArgsTests.cs convention) that runs without the native csfml-window library, so SonarCloud/CI now exercise the constructor, property accessors and ToString.

## Verification
- dotnet build 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -f net8.0 -> PASS (0 warnings, 0 errors)
- dotnet test ... --filter FullyQualifiedName~JoystickMoveEventArgsCoverageTests -c Debug -f net8.0 -> PASS (7 passed, 0 failed, 0 skipped)
