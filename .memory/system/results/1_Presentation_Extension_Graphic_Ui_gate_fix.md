# Ui (ImGui/ImPlot/ImNodes) Native Gate Fix — 2026-09-16

## Files
- 1_Presentation/Extension/Graphic/Ui/test/Attributes/RequireCImguiSystemFactAttribute.cs
- 1_Presentation/Extension/Graphic/Ui/test/Attributes/RequireImNodesSystemFactAttribute.cs

## Change
Added the bare `{name}.dylib` candidate so the redistributed
`runtimes/osx-x64|arm64/native/cimgui.dylib` in the test output directory is found. The bundled
`cimgui.dylib` is a universal binary depending only on /usr/lib/libc++.1.dylib and libSystem.B.dylib,
so it loads on CI (macos-15-intel) exactly like the Sdl2/Glfw bundled libs. Before this fix the
gate only probed `cimgui`, `libcimgui`, `libcimgui.dylib` — never `cimgui.dylib` — so every
cimgui-gated test skipped on every platform.

## Verified
- Ui test project: 10358 passed, 14 skipped (only legitimate WindowsOnly/LinuxOnly platform-exclusive
  tests and inverted ImNodes-unavailable tests).
- Local coverlet: Ui/src total 95.8% (22144/23118). Highlights:
  - ImGuiP7.cs 0.6% -> 93.5%
  - ImPlot.cs 16.3% -> 95.8%
  - Extras/Node/ImNodes.cs 3.3% -> 88.2%
  - ImDrawListPtr.cs 7.0% -> 100%
  - ImGuiP3.cs 11.6% -> 98.0%
  - ImGui.cs 25.1% -> 98.0%
  - ImFontPtr.cs 43.8% -> 100%
  - ImGuiIO.cs 100% (2016/2016)

## Status
COMPLETED — biggest single CI-coverage unlock of the remediation effort.

Residual Ui gaps (require new tests): ImGuiIOPtr 89.1%, ImPlotP2 84.1%, ImPlotP1 64.2%,
ImPlotP8 84.9%, ImGuiP8 93.4%, ImNodes 88.2%.
