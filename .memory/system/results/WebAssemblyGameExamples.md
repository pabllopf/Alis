# WebAssemblyGameExamples.cs

- **File**: `4_Operation/Graphic/src/Platforms/Web/WebAssemblyGameExamples.cs`
- **Coverage Before**: 6.3% (SonarCloud); 9.5% local baseline
- **Coverage After**: 17.4% (73/419 lines, local coverlet)
- **Tests Added**: 14 (WebAssemblyGameExamplesEntryCoverageTests.cs — example entry points + GameDevelopmentUtils.GetKeyName/GetGamepadButtonName)
- **Uncovered Lines**: 346 — all example bodies inside `using (WebAssemblyGameContext ...)` blocks; the context constructor always throws on desktop (EGL lib absent); production change required to test
- **Status**: COMPLETED (remaining lines blocked by WebAssemblyGameContext constructor)
