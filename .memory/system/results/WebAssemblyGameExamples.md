# Result: WebAssemblyGameExamples.cs

File: `4_Operation/Graphic/src/Platforms/Web/WebAssemblyGameExamples.cs`
CoverageBefore: 11.1% (SonarCloud; stale artifact)
CoverageAfter: 17.4% (73/419, local coverlet)
TestsAdded: 0 (already remediated in commit 94f2b490a)
Commit: test: coverage WebAssemblyGameExamples.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

WebAssemblyGameExamples.cs is the WASM game-example surface. Committed suite
(WebAssemblyGameExamplesTests/Remaining/Safe) reaches 73/419 lines (17.4%); the remaining 346
lines are unreachable on a non-browser host (require running WASM runtime / EGL).

## Verification

- `dotnet test Alis.Core.Graphic.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~WebAssemblyGameExamples"`: 34 passed, 78 skipped, 0 failed.
- Local coverlet (XPlat Code Coverage, cobertura): 73/419 = 17.4%, identical to the committed
  result.
