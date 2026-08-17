# Project Coverage State

Project:
./4_Operation/Graphic/src/Alis.Core.Graphic.csproj

Test project:
./4_Operation/Graphic/test/Alis.Core.Graphic.Test.csproj

Status:
COMPLETED

Agent:
covertall-agent-physic-001 (measurement only, no lock held)

Started:
2026-08-17T11:30:00Z

Last update:
2026-08-17T11:45:00Z

Initial coverage:
71.72% lines (5138/7164)

Current coverage:
71.72%

Tests before:
1559 passed, 613 skipped (platform-gated)

Tests after:
unchanged

Files modified:
- none

Coverage work:
- Full baseline measured via coverlet. All 12 files with coverage gaps are
  native platform implementations that cannot be exercised in this
  environment:
  - Platforms/Osx/Native/MacOpenGLContext.cs (0%), MacWindow.cs (0%),
    MacNativePlatform.cs (51.7%): ObjC P/Invoke, need a real window server.
  - Platforms/Web/* (WebAssemblyGameExamples 17.4%, WebAssemblyGameContext
    50%, WebAssemblyPlatformIntegration 54.6%, WebAssemblyPlatform 74.4%,
    EmscriptenWeb 82.2%, WebAssemblyDisplayManager 91%, WebAssemblyConfiguration
    92.2%): EGL/emscripten JS interop, need a browser/JS runtime.
  - OpenGL/Constructs/GLShader.cs (75%) and GLShaderProgram.cs (72.9%):
    constructor/link paths require a live GL context (aborts test host).
- The 613 skipped tests are the platform-gated ones.

Remaining opportunities:
- none within unit-test scope; all gaps require native display/GL/JS runtime.

Last commit:
none

Attempts:
1
