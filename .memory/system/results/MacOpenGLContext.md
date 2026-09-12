# MacOpenGLContext.cs

## File
4_Operation/Graphic/src/Platforms/Osx/Native/MacOpenGLContext.cs

## Coverage (SonarCloud, master)
- Line: 0.0%, Uncovered Lines: 33 (SonarCloud master)

## Local verification
- `dotnet test --filter FullyQualifiedName~MacOpenGLContext` on
  Alis.Core.Graphic.Test: execution facts pass (MacOpenGLContextExecutionTests
  exercise main-thread NSOpenGLContext lifecycle via the StartupHook bootstrap).

## Analysis
SonarCloud runs on Linux, so `#if osx*` code is never compiled there and its
coverage stays at 0% by definition. Locally the class surface is exercised by the
existing execution tests gated to macOS main thread.

## Outcome
No new tests required (tests already exist; coverage is platform-gated).
