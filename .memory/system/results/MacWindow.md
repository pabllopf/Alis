# Coverage Worker Result
File: 4_Operation/Graphic/src/Platforms/Osx/Native/MacWindow.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 0.0% (0/94 lines executable in this environment; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: BLOCKED_BY_NATIVE
Details:
- MacWindow.cs is an internal AppKit NSWindow wrapper (objc_msgSend calls: alloc/initWithContentRect, setTitle, center, show/hide, isVisible, frame readback). All 94 lines sit behind the MacWindow ctor which requires a live NSWindow.
- The repo supplies MacWindowExecutionTests + StartupHook/MacWindowBootstrap that create the window on the true process main thread via DOTNET_STARTUP_HOOKS (+ ALIS_MACWINDOW_HOOK=1). Two environment blockers prevent running it here:
  1) The test assembly output (bin/Debug/osx-x64/lib) is PE machine = x64 (file: "x86-64 Mono/.Net assembly"). The arm64 dotnet test driver aborts at startup-hook load: "The assembly architecture is not compatible with the current process architecture." DOTNET_ReadyToRun=0 does not change it.
  2) No x64 (Rosetta) .NET is installed (`arch -x86_64 dotnet` -> Bad CPU type in executable), so a matching testhost cannot be spawned.
- Attempted instead: direct construction from a xunit worker thread after ObjectiveCInterop.NSApplicationLoad(). Result: window created fine for ctor/size/title, but Show->IsVisible false and GetFrame raised AccessViolationException; a full run aborted the test host ("Serie de pruebas anulada"). Confirms AppKit main-thread requirement stated in StartupHook.cs. Probe tests reverted.
- Not coverable without a main-thread hook in a matching-arch shell. Requires production-side fix or x64 Rosetta runtime.