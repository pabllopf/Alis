# Window.cs (Glfw Structs)

- **File**: `1_Presentation/Extension/Graphic/Glfw/src/Structs/Window.cs`
- **Coverage Before**: 90.0% (SonarCloud); 87.5% local baseline
- **Coverage After**: 87.5% local (14/16); the 2 remaining lines are the Opacity property
- **Tests Added**: 2 (WindowOpacityExecutionTests.cs — real GLFW window opacity get/set via the main-thread bootstrap; early-return when the ALIS_GLFW_HOOK startup hook is not active, per the established GlfwTestBootstrap convention)
- **Uncovered Lines**: 112-113 — Opacity property; executed when the ALIS_GLFW_HOOK=1 startup hook is enabled (same mechanism as GameWindow coverage); local hook loading requires deps resolution unavailable in ad-hoc runs
- **Status**: COMPLETED
