File: 1_Presentation/Extension/Graphic/Ui/src/ImGuiP3.cs
CoverageBefore: 11.7%
CoverageAfter: 98.0%
TestsAdded: 36
Commit: test: coverage ImGuiP3.cs
Status: COMPLETED
Notes:
- Full local coverlet (full Ui suite): 436/445 executable lines hit (98.0%).
- 9 residual uncovered lines are EndTabItem (235–237), EndDragDropSource (155–157), EndDragDropTarget (163–165).
- EndDragDropSource and EndDragDropTarget abort the host via `Assertion failed: (g.DragDropActive)` in imgui.cpp — require an active interactive drag payload which cannot be established headless.
- EndTabItem (paired with BeginTabBar/BeginTabItem) aborts the host when the BeginTabItem–EndTabItem–EndTabBar cycle completes inside a framed window — reproducible in isolation.
- CoverageBefore 11.7% is the SonarCloud CI figure; locally all [RequireCImguiSystemFact] tests run when the bundled cimgui loads, yielding 98.0%.
- 36 safe context-only headless tests added in ImGuiP3CoverageTests.cs exercising color math, font metrics, cursor/viewport getters, key/mouse state, allocator queries, and boundary string-return wrappers.
