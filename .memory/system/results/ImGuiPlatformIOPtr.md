# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Ui/src/ImGuiPlatformIOPtr.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 100.0% (58/58 lines, existing committed suite; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: ALREADY_COVERED_LOCALLY
Details:
- ImGuiPlatformIOPtr.cs wraps the ImGui platform IO state (mouse position/wheel/down/clicked buttons, display size, framerate, delta time, clipboard callbacks, host-user data).
- Existing committed suite (ImGuiPlatformIOPtrTests.cs) executes the accessors inside a live ImGui context, 58/58 lines hit.
- SonarCloud 0% is the CI no-native-lib artifact; no new tests needed.