# Result: ImGuiViewport.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiViewport.cs`
CoverageBefore: 11.8% (SonarCloud; existing tests skipped)
CoverageAfter: 100.0% (local coverlet, line/branch 1.0)
TestsAdded: 18 (ImGuiViewportExecutionTests.cs)
Commit: test: coverage ImGuiViewport.cs
Status: REMEDIATED

## Summary

ImGuiViewport.cs is a `public struct` of 17 pure managed auto-properties (Id, Flags, Pos, Size,
WorkPos, WorkSize, DpiScale, ParentViewportId, DrawData, RendererUserData, PlatformUserData,
PlatformHandle, PlatformHandleRaw, PlatformWindowCreated, PlatformRequestMove/Resize/Close).
Every member is a managed getter/setter with no native interop.

SonarCloud reported 11.8% because the pre-existing `ImGuiViewportTest.cs` and
`ImGuiViewportRemainingCoverageTests.cs` classes annotate every test with the custom
`[RequireCImguiSystemFact]` attribute, which skips when the native `cimgui` library cannot be
resolved by name via `NativeLibrary.TryLoad`; on this host they skip.

A new `ImGuiViewportExecutionTests.cs` class uses plain `[Fact]` attributes (always run) to
exercise a set/get round-trip for each of the 17 properties and asserts a default instance is
all-zero. This covers every getter and setter.

## Verification

- ImGuiViewportExecutionTests filter (net8.0, Debug): 18 passed, 0 failed, 0 skipped.
- Coverlet cobertura: `ImGuiViewport` class line-rate=1, branch-rate=1; 17 getters/setters covered.
