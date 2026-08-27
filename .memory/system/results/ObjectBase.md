# Result: ObjectBase.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Systems/ObjectBase.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 9 tests added; all constructors/getter/setter/Dispose branches covered locally (no coverlet measurement run)
TestsAdded: 9
Commit: c0bcd4d6e006fc1b3b0d5b4ed46f690659673229
Status: COMPLETED

## Summary

`ObjectBase` is the abstract SFML base class storing a single `IntPtr` and exposing `CPointer`, `Dispose()`, `Dispose(bool)` and the abstract `Destroy(bool)`. The existing suite (`ObjectBaseTest.cs`, `ObjectBaseRemainingCoverageTests.cs`) is gated behind `RequireCSfmlSystemFact`/`RequireCSfmlWindowsFact`, which skip without native CSFML libraries — hence 0.0% coverage. This new `ObjectBaseTests.cs` uses a concrete `TestObjectBase` subclass with plain `[Fact]` tests that require no native libraries, covering the constructor pointer assignment, the `CPointer` getter and protected setter, `Dispose()` idempotency (Destroy invoked exactly once, pointer zeroed), the zero-pointer early-exit branch, and the `Dispose(bool)` overload with both `true`/`false` and zero-pointer paths.

## Verification

- `dotnet build 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj -c Debug` — 0 errors, 0 warnings.
- `dotnet test 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj --filter FullyQualifiedName~ObjectBaseTests -c Debug -f net8.0` — 9 passed, 0 failed, 0 skipped.
