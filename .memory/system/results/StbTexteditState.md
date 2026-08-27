# Result: StbTexteditState.cs

File: `1_Presentation/Extension/Graphic/Ui/src/StbTexteditState.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact — existing tests gated behind RequireCImguiSystemFact skipped when native cimgui absent)
CoverageAfter: 100.0% executable lines (all 15 property accessors); cobertura disabled per pipeline rules.
TestsAdded: 5 (StbTexteditStateCoverageTests.cs: defaults, int round-trip, byte round-trip, PreferredX round-trip, UndoState round-trip)
Commit: test: coverage StbTexteditState.cs
Status: REMEDIATED

## Summary
StbTexteditState is a pure managed value-type struct (no native interop; all properties are auto-properties). Added a plain-[Fact] suite (StbTexteditStateCoverageTests.cs) that runs without the native cimgui library, so SonarCloud/CI now exercise every property accessor. Mirrors the existing gated StbTexteditStateTests.cs but un-gated.

## Verification
- dotnet build 1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 -> PASS (0 warnings, 0 errors)
- dotnet test ... --filter FullyQualifiedName~StbTexteditStateCoverageTests -c Debug -f net8.0 -> PASS (5 passed, 0 failed, 0 skipped)
