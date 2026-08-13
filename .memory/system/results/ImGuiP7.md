# ImGuiP7.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP7.cs`
- **Coverage Before**: 0.6% (1/486)
- **Coverage After**: 85.68% (419/489)
- **Tests Added**: 10 (ImGuiP7ExecutionTests.cs, macOS-only, real native cimgui execution)
- **Uncovered Lines**: PlotHistogram (7), PlotLines (7) — float passed by value where native expects float* (SIGSEGV); Selectable ref bool (3) — bool by value where native expects bool*; SetDragDropPayload (2) — native crash; SetAllocatorFunctions (2) — host hang (freed-context garbage deref)
- **Status**: COMPLETED
