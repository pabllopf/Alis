# Project Coverage State

Project:
./1_Presentation/Extension/Graphic/Ui/src/Alis.Extension.Graphic.Ui.csproj

Test project:
./1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj

Status:
PARTIAL

Agent:
covertall-agent-002 (Ui)

Started:
2026-08-24T21:08:00Z

Last update:
2026-08-24T21:40:00Z

Initial coverage:
1.66% (192/11559 lines) with cimgui.dylib NOT loadable from Debug test bin
94.02% (10868/11559 lines) after restoring the libcimgui.dylib symlink that
Release builds get automatically (native library present = prior 94.54% env).

Current coverage:
94.87% line (10966/11559), 86.38% branch (444/514)

Tests before:
7529

Tests after:
7535

Files modified:
- test/Extras/GuizMo/ImGuizMoContextCoverageTests.cs (added framed context
  execution tests: BeginFrame/SetDrawList/SetId, DrawGrid/ViewManipulate,
  Manipulate, ShowDemoWindow)
- test/ImGuiP6ExecutionTests.cs (added LogToFile overloads and
  LoadIniSettingsFromDisk)

Coverage work:
- Root cause of the 10.9%/1.66% SonarCloud/local baseline: the Debug test bin
  was missing the `libcimgui.dylib` symlink that Release gets via the build,
  so `RequireCImguiSystemFact` skipped ~7310 of 7529 tests. Restoring the
  symlink made the native library loadable, tests ran, and coverage jumped to
  94.02% (matching the prior agent's 94.54% measurement).
- ImGuizMo.cs: 40.9% -> 98.0%. Added a CreateFramedContext helper and four
  execution tests that run BeginFrame, SetDrawList(), SetDrawList(ImDrawList),
  SetId, SetGizmoSizeClipSpace, DrawGrid, ViewManipulate, Manipulate and
  ShowDemoWindow inside a real ImGui frame with a window scope.
  DrawCubes.cs body remains uncovered: the managed DllImport declares
  `float view` by value while native expects `float*` — a marshalling hazard
  that aborts the host (same class as ImPlot AddColormap). BLOCKED.
- ImGuiP6.cs: added LogToFile()/LogToFile(int)/LogToFile(int,string) and
  LoadIniSettingsFromDisk execution tests; 97.8% now. Remaining uncovered:
  InputInt3 (DllImport EntryPoint `_igInputInt3` does not exist; native symbol
  is `igInputInt3`, so the call always throws EntryPointNotFoundException) and
  ListBox (nested byte[][] marshalling throws MarshalDirectiveException before
  the native call). Both BLOCKED production marshalling issues.
- Verified and marked BLOCKED (native-abort hazards / unreachable):
  * ImPlotP1.cs (50%, 120 lines): DragLineX/Y, DragPoint, DragRect,
    AddColormap, BeginSubplots, ColormapSlider, ColormapScale wrappers pass
    Vector4F/Vector2F by value where native expects pointers, or pass
    `ref double`/`ref float` where native expects values. Calling any of them
    aborts the test host (confirmed empirically).
  * ImPlotP2.cs (84%): GetPlotLimits/GetPlotSelection abort because the
    ImAxis enum layout mismatches this cimgui build (Y-axis index out of
    bounds assertion). IsSubplotsHovered/EndSubplots abort too.
  * ImNodes.cs (83%): LoadEditorStateFromIniFile/SaveEditorStateToIniFile/
    EditorContextFree abort the host (confirmed empirically).
  * ImGuiP5.cs (82%): BeginTabItem (bool* vs value), CheckboxFlags
    (int*/uint* vs value), CollapsingHeader(ref bool), ColorEdit3/Picker3/4
    (struct by value vs pointer), AcceptDragDropPayload (native asserts
    g.DragDropActive). All abort the host (confirmed empirically).
  * ImPlot.cs (88%): PlotStems, SetupAxisTicks/SetupAxisLinks/SetNextAxisLinks
    use ImAxis or ref-by-value params -> abort hazard.
  * ImGuiP7.cs: Selectable(ref bool), PlotHistogram/PlotLines (ref float by
    value), SetAllocatorFunctions (would null native allocators), SetDragDropPayload
    (asserts drag-drop active).
  * ImGuiP4.cs: InputText byte[]/ref string overloads pass IntPtr.Zero buffer
    -> native dereference hazard. IntPtr overloads already covered.
  * ImGuiP1.cs: DragFloat4 (Vector4F by value vs pointer).
  * ImGuiP8.cs + ImGui.cs: SliderFloat4 same hazard.
  * ImGuiIOPtr.cs: KeysData/MouseClickedPos/MouseDragMaxDistanceAbs getters
    always throw ArgumentException because Marshal.OffsetOf<ImGuiIo> cannot
    find a field named "KeysData" (the struct exposes KeysData0..9). The loop
    body is unreachable without a production field-name change. BLOCKED.
  * ImFontAtlasPtr.cs: GetTexDataAsAlpha8/Rgba32 `out byte[]` overloads abort
    the host (native returns a raw pointer the runtime cannot marshal to a
    managed byte[]).
  * ImGuiP3.cs: EndDragDropSource/Target/TabItem need active drag-drop/tab
    scopes; native asserts without them.
  * ImGuiStyle.cs: get/set_Item default cases (lines 589/656) are unreachable
    because the bounds guard already throws for out-of-range indices.
  * PlotPieChart (ImPlotP9/P11) and PlotBarGroups (ImPlotP2) native call lines
    are unreachable: nested byte[][] marshalling throws
    MarshalDirectiveException before the call executes.

Remaining opportunities:
- All remaining uncovered lines (593) require either a production marshalling
  fix, an ImAxis enum layout fix, or are unreachable defensive default cases.
  No further meaningful test-only coverage is technically possible without
  modifying production code (forbidden by the task).

Last commit:
e381906bb (ImGuiP6), def1d59f9 (ImGuizMo)

Attempts:
2