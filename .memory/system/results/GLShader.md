# Result: GLShader.cs

File: `4_Operation/Graphic/src/OpenGL/Constructs/GLShader.cs`
CoverageBefore: 55.6% (SonarCloud; stale artifact)
CoverageAfter: 75.0% (24/32, local coverlet)
TestsAdded: 0 (already remediated in commit 9c1504180)
Commit: test: coverage GLShader.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

GLShader.cs is the OpenGL shader construct (11 complexity / 46 LOC). Committed tests cover the
uninitialized-instance, Dispose, and finalizer paths: 24/32 lines (75.0%) locally.

## Remaining uncovered (8) — BLOCKED_BY_PRODUCTION_CODE

- 53-60 — constructor GL calls (GlCreateShader, compile): require a live GL context.
- 94-95 — ReleaseUnmanagedResources with a non-zero ID: same GL-context requirement.

## Verification

- `dotnet test Alis.Core.Graphic.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~GLShader"`: 141 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): 24/32 = 75.0%.
