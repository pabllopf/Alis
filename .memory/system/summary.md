# Coverage Remediation Summary

File: 4_Operation/Ecs/src/GameObject.cs
CoverageBefore: 47.3% (SonarCloud), 48.8% (local coverlet)
CoverageAfter: 91.3% (local coverlet, 1776/1946)
TestsAdded: 28 (GameObjectMultiArityAddRemoveTests.cs)
Commit: test: GameObject.cs
Status: COMPLETED
File: 4_Operation/Ecs/src/Redifinition/BitOperations.cs
CoverageBefore: 31.0%
CoverageAfter: 100.0% (local coverlet 58/58)
TestsAdded: 3
Commit: test: BitOperations.cs
Status: COMPLETED
File: 1_Presentation/Extension/Graphic/Glfw/src/GlfwNative.cs (+ NativeWindow.cs)
CoverageBefore: 1.9% / 3.5%
CoverageAfter: unchanged on CI (main-thread bootstrap blocked); gate fix applied
TestsAdded: 0
Commit: test: GlfwNative.cs
Status: COMPLETED (gate fix) / BLOCKED_BY_CI_BOOTSTRAP (full CI coverage)
File: 1_Presentation/Extension/Updater/src/UpdateManager.cs
CoverageBefore: 89.8%
CoverageAfter: 92.8% (local coverlet; residual lines platform/heavy/unreachable)
TestsAdded: 1 (zip compression-ratio rejection)
Commit: test: UpdateManager.cs
Status: COMPLETED
File: 4_Operation/Ecs/src/Updating/Runners/Update.cs
CoverageBefore: 95.1%
CoverageAfter: 95.1% (arity-8 full Run already covered; range Run BLOCKED_BY_PRODUCTION_API)
TestsAdded: 1 (UpdateAllClassesTest arity-8 full run)
Commit: test: Update.cs
Status: COMPLETED (behavioral) / BLOCKED (arity-8 range Run)
File: 1_Presentation/Extension/Graphic/Ui/src/** (ImGuiP7, ImPlot, ImNodes, ImDrawListPtr, ImGuiP3, ...)
CoverageBefore: ~0-25% per file (native-gated, all tests skipped)
CoverageAfter: 95.8% total (22144/23118, local coverlet)
TestsAdded: 0 (existing 10,358 tests now run instead of skipping)
Commit: test: ImGuiP7.cs
Status: COMPLETED
