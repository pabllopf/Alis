# Result: GLShaderProgram.cs

File: `4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgram.cs`
CoverageBefore: 52.5% (SonarCloud; stale artifact)
CoverageAfter: 69.9% (116/166, local coverlet)
TestsAdded: 0 (already remediated in commit 7c2ea51dc)
Commit: test: coverage GLShaderProgram.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

GLShaderProgram.cs is the OpenGL shader-program construct (32 complexity / 197 LOC). Committed
suite (GLShaderProgramTest + coverage/remaining tests) covers 116/166 lines (69.9%) in this
environment.

## Remaining uncovered (50) — BLOCKED_BY_PRODUCTION_CODE

All constructor bodies (77-98, 134-147), GetParams loops (176-207), GetUniformLocation /
GetAttributeLocation (325-337) call real GL functions (GlCreateProgram/GlAttachShader/
GlGetProgramiv/GlUseProgram/...). These require a live GL context which is unavailable in the
test host/CI. Existing tests verify the constructors throw without GL.

## Verification

- `dotnet test Alis.Core.Graphic.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~GLShaderProgram"`: 112 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): 116/166 = 69.9%.
