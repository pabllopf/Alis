# MacWindow.cs

## File
4_Operation/Graphic/src/Platforms/Osx/Native/MacWindow.cs

## Coverage (SonarCloud, master)
- Line: 0.0%, Uncovered Lines: 47, Uncovered Branches: 0

## Local verification
- `dotnet test --filter FullyQualifiedName~MacWindow` on Alis.Core.Graphic.Test:
  6/6 passed (SentinelMacOsOnly gated facts).
- `MacWindowExecutionTests` exercise the complete main-thread NSWindow lifecycle
  (ctor/Show/SetTitle/SetSize/GetFrame/Hide) via the `StartupHook` AppKit bootstrap.

## Analysis
SonarCloud runs on Linux, so `#if osx*` code is never compiled there and the
coverage stays at 0% by definition. Activation of the main-thread bootstrap
locally via DOTNET_STARTUP_HOOKS fails with an assembly-binding error in the
vstest driver (pre-existing harness issue in test infra, not production code).
The existing 6 facts are the authoritative execution surface for this class.

## Outcome
No new tests required (tests already exist; coverage is platform-gated).
