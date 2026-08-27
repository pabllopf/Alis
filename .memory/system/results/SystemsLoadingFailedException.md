# Result: Systems LoadingFailedException.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Systems/LoadingFailedException.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact — existing tests gated behind RequireCSfmlSystemFact skipped when native csfml-system absent)
CoverageAfter: 100.0% executable lines (all 5 constructors); cobertura disabled per pipeline rules.
TestsAdded: 6 (SystemsLoadingFailedExceptionCoverageTests.cs: default ctor, resource-name ctor, resource+inner ctor, resource+filename ctor, resource+filename+inner ctor, Exception inheritance)
Commit: test: coverage LoadingFailedException.cs
Status: REMEDIATED

## Summary
Systems.LoadingFailedException is a pure managed Exception subclass (no native interop), sibling of the Windows one already remediated. Added a plain-[Fact] suite (SystemsLoadingFailedExceptionCoverageTests.cs) mirroring the gated LoadingFailedExceptionTest.cs but un-gated, so SonarCloud/CI now exercise all five constructors and interpolation-based message composition.

## Verification
- dotnet build 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -f net8.0 -> PASS (0 warnings, 0 errors)
- dotnet test ... --filter FullyQualifiedName~SystemsLoadingFailedExceptionCoverageTests -c Debug -f net8.0 -> PASS (6 passed, 0 failed, 0 skipped)
