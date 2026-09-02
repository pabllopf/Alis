# Coverage Index

## Project

```
Name: Alis
Key: pabllopf-official_alis
Branch: master
```

## Previous Coverage State

_No previous state available — fresh start after memory cleanup._

## Current Coverage State (Synced 2026-07-23)

- **Overall Coverage:** 70.5%
- **Line Coverage:** 68.4%
- **Branch Coverage:** 80.7%
- **Uncovered Lines:** 18,226
- **Uncovered Conditions:** 2,334

## Files with Coverage Gaps (Core ECS)

| File | Coverage | Uncovered Lines | Test Files |
|------|----------|-----------------|------------|
| `Gen2GcCallback.cs` | 48.8% | 31 | 2 |
| `EnumerableHelpers.cs` | 80.5% | 11 | 7 |
| `GameObject.cs` | 85.9% | 95 | 40+ |
| `Update.cs` | 87.6% | 28 | 5 |

## Remediation Log

| File | Before | After | Tests Added | Status |
|------|--------|-------|-------------|--------|
| `1_Presentation/Extension/Graphic/Ui/src/ImGuiIO.cs` | 0.0% | 100.0% | 747 (ImGuiIOTests.cs) | REMEDIATED |
| `1_Presentation/Extension/Graphic/Ui/src/ImGuiIOPtr.cs` | 0.0% | 89.1% | 101 (ImGuiIOPtrTests.cs) | REMEDIATED |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlot.cs` | 0.0% | 8.3% | 38 (ImPlotNullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP2.cs` | 0.0% | 6.7% | 30 (ImPlotP2NullItemCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/ImGuiP3.cs` | 0.0% | 5.8% | 26 (ImGuiP3NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/ImGuiP5.cs` | 0.0% | 17.3% | 60 (ImGuiP5NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/ImGuiP6.cs` | 0.0% | 11.7% | 39 (ImGuiP6NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/ImDrawListPtr.cs` | 0.0% | 3.5% | 14 (ImDrawListPtrTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP10.cs` | 0.0% | 33.3% | 105 (ImPlotP10NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP1.cs` | 0.0% | 13.5% | 31 (ImPlotP1NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP9.cs` | 0.0% | 36.5% | 39 (ImPlotP9NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP11.cs` | 0.0% | 36.2% | 42 (ImPlotP11NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/ImGuiP4.cs` | 0.0% | 30.6% | 60 (ImGuiP4NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP14.cs` | 0.0% | 33.3% | 70 (ImPlotP14NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP12.cs` | 0.0% | 25.0% | 50 (ImPlotP12NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/ImGui.cs` | 0.0% | 12.7% | 25 (ImGuiNullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/ImGuiP1.cs` | 0.0% | 19.6% | 36 (ImGuiP1NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Sfml/src/Render/Shader.cs` | 0.0% | 14.1% | 9 (ShaderDeterministicCoverageTests.cs) | PARTIAL_BLOCKED_BY_NATIVE |
| `1_Presentation/Extension/Graphic/Ui/src/ImFontAtlasPtr.cs` | 0.0% | 11.5% | 27 (ImFontAtlasPtrNullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Sdl2/src/Sdl2Ttf/SdlTtf.cs` | 0.0% | 0.0% | 0 (none) | BLOCKED_BY_NATIVE |
| `1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs` | 0.0% | 23.5% | 15 (AudioVideoWriterConstructorCoverageTests.cs) | PARTIAL_BLOCKED_BY_NATIVE |
| `1_Presentation/Extension/Graphic/Sfml/src/Windows/Window.cs` | 0.0% | 0.0% | 0 (none) | BLOCKED_BY_NATIVE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP15.cs` | 0.0% | 25.4% | 43 (ImPlotP15NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Sdl2/src/Mapping/KeyCodes.cs` | 0.0% | 0.0% | 0 (none) | NO_EXECUTABLE_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP22.cs` | 0.0% | 33.3% | 55 (ImPlotP22NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP19.cs` | 0.0% | 33.3% | 54 (ImPlotP19NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP6.cs` | 0.0% | 33.3% | 54 (ImPlotP6NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP7.cs` | 0.0% | 33.3% | 54 (ImPlotP7NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Sfml/src/Render/RenderWindow.cs` | 0.0% | 0.0% | 0 (none) | BLOCKED_BY_NATIVE |
| `1_Presentation/Extension/Graphic/Ui/src/ImGuiP2.cs` | 0.0% | 25.8% | 39 (ImGuiP2NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP13.cs` | 0.0% | 33.3% | 53 (ImPlotP13NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP17.cs` | 0.0% | 33.3% | 53 (ImPlotP17NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP8.cs` | 0.0% | 33.3% | 53 (ImPlotP8NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP16.cs` | 0.0% | 33.3% | 52 (ImPlotP16NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP21.cs` | 0.0% | 33.3% | 50 (ImPlotP21NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/GuizMo/ImGuizMo.cs` | 0.0% | 0.0% | 0 (none) | BLOCKED_BY_NATIVE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP3.cs` | 0.0% | 33.3% | 47 (ImPlotP3NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `1_Presentation/Extension/Graphic/Sfml/src/Render/Texture.cs` | 0.0% | 0.0% | 0 (none) | BLOCKED_BY_NATIVE |
| `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP5.cs` | 0.0% | 33.3% | 42 (ImPlotP5NullLabelCoverageTests.cs) | PARTIAL_BLOCKED_BY_PRODUCTION_CODE |
| `QueryEnumerator.cs` | 93.2% | 16 | 2 |
| `GameObjectExtensions.cs` | 94.1% | 4 | 1 |
| `ComponentRegistry.cs` | 97.0% | 3 | 8 |

## Recent Remediation

| File | Coverage Before | Coverage After | Tests Added |
|------|-----------------|----------------|-------------|
| `Gl.cs` (Graphic/OpenGL) | 30.7% | 100.0% (209/209) | 13 |
| `MacNativePlatform.cs` (Graphic/Osx) | 14.2% | 43.7% (153/350) | 9 |
| `WebAssemblyGameExamples.cs` (Graphic/Web) | 6.3% | 17.4% (73/419) | 14 |
| `ObjectiveCInterop.cs` (Graphic/Osx) | 5.0% | 100.0% (19/19) | 10 |
| `WebAssemblyPlatform.cs` (Graphic/Web) | 4.2% | 74.4% (328/441) | 34 |
| `ImPlotP2.cs` (Ui/Plot) | 1.6% | 84.1% (380/452 local) | 89 |
| `Mouse.cs` (Sfml/Windows) | 0.0% | 55.0% | 6 |
| `NativeWindow.cs` (Glfw) | 0.0% (SonarCloud) | 98.63% (718/728, hook-enabled local run) | 1 + existing worker suite wiring |
| `SensorEventArgs.cs` (Sfml/Windows) | 0.0% (SonarCloud, stale) | 100.0% executable lines (plain-[Fact] DTO suite) | 8 |
| `ImDrawList.cs` (Ui) | 0.0% (SonarCloud, stale) | 100.0% executable lines (plain-[Fact] struct suite) | 5 |
| `LoadingFailedException.cs` (Sfml/Windows) | 0.0% (SonarCloud, stale) | 100.0% executable lines (plain-[Fact] exception suite) | 6 |
| `LoadingFailedException.cs` (Sfml/Systems) | 0.0% (SonarCloud, stale) | 100.0% executable lines (plain-[Fact] exception suite) | 6 |
| `StbTexteditState.cs` (Ui) | 0.0% (SonarCloud, stale) | 100.0% executable lines (plain-[Fact] struct suite) | 5 |
| `JoystickMoveEventArgs.cs` (Sfml/Windows) | 0.0% (SonarCloud, stale) | 100.0% executable lines (plain-[Fact] DTO suite) | 7 |
| `MouseButtonEventArgs.cs` (Sfml/Windows) | 0.0% (SonarCloud, stale) | 100.0% executable lines (plain-[Fact] DTO suite) | 7 |
| `MouseWheelEventArgs.cs` (Sfml/Windows) | 0.0% (SonarCloud, stale) | 100.0% executable lines (plain-[Fact] DTO suite) | 7 |
| `TouchEventArgs.cs` (Sfml/Windows) | 0.0% (SonarCloud, stale) | 100.0% executable lines (plain-[Fact] DTO suite) | 7 |
| `ImGuiInputTextCallbackData.cs` (Ui) | 0.0% (SonarCloud, stale) | 100.0% executable lines (plain-[Fact] struct suite) | 2 |
| `ImFontGlyph.cs` (Ui) | 0.0% (SonarCloud, stale) | 100.0% executable lines (plain-[Fact] struct suite) | 2 |
| `ImPlotInputMap.cs` (Ui/Plot) | 0.0% (SonarCloud, stale) | 100.0% (24/24 local coverlet, existing ImPlotInputMapTests/ImPlotInputMapTest) | 0 (already remediated) |
| `Ivec4.cs` (Sfml/Render) | 0.0% (SonarCloud, stale) | 100.0% (12/12 local coverlet, existing Ivec4Test/Ivec4RemainingCoverageTests) | 0 (already remediated) |
| `Vec4.cs` (Sfml/Render) | 0.0% (SonarCloud, stale) | 100.0% (12/12 local coverlet, existing Vec4Test/Vec4RemainingCoverageTests) | 0 (already remediated) |
| `Vec3.cs` (Sfml/Render) | 0.0% (SonarCloud, stale) | 100.0% (11/11 local coverlet, existing Vec3Test/Vec3RemainingCoverageTests) | 0 (already remediated) |
| `JoystickButtonEventArgs.cs` (Sfml/Windows) | 0.0% (SonarCloud, stale) | 100.0% (10/10 local coverlet, existing JoystickButtonEventTest) | 0 (already remediated) |
| `MouseMoveEventArgs.cs` (Sfml/Windows) | 0.0% (SonarCloud, stale) | 100.0% (10/10 local coverlet, existing MouseMoveEventTest/ArgsRemaining) | 0 (already remediated) |
| `SizeEventArgs.cs` (Sfml/Windows) | 0.0% (SonarCloud, stale) | 100.0% (10/10 local coverlet, existing SizeEventTest/ArgsRemaining) | 0 (already remediated) |
| `Ivec2.cs` (Sfml/Render) | 0.0% (SonarCloud, stale) | 100.0% (9/9 local coverlet, existing Ivec2Test/ArgsRemaining) | 0 (already remediated) |
| `Vec2.cs` (Sfml/Render) | 0.0% (SonarCloud, stale) | 100.0% (9/9 local coverlet, existing Vec2Test/ArgsRemaining) | 0 (already remediated) |
| `ImFontAtlasCustomRect.cs` (Ui) | 0.0% (SonarCloud, stale) | 100.0% (8/8 local coverlet, existing custom rect tests) | 0 (already remediated) |
| `ImGuiWindowClass.cs` (Ui) | 0.0% (SonarCloud, stale) | 100.0% (8/8 local coverlet, existing window class tests) | 0 (already remediated) |

## Notable Files with Low Coverage (Filtered)

| File | Coverage | Lines | Type |
|------|----------|-------|------|
| `GraphicManager.cs` | 39.6% | 129 | Platform-dependent |
| `Sprite.cs` | 26.2% | 164 | 7 test files already |
| `BoxCollider.cs` | 54.6% | 110 | 14+ test files |
| `ContextHandler.cs` | 54.9% | 73 | Depends on Runtime/Timing |
| `Gen2GcCallback.cs` | 48.8% | 31 | GC finalizer paths |

## Platforms remaining uncovered

Most remaining uncovered lines (18,226) are in platform-specific, UI-wrapper, or network-dependent code that is difficult to test in isolation.

_No previous delta available — fresh start._
