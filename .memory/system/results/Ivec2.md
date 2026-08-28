# Result: Ivec2.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Ivec2.cs`
CoverageBefore: 0.0% (SonarCloud, stale artifact)
CoverageAfter: 100.0% (9/9, local coverlet, Ivec2-filtered run)
TestsAdded: 0 (already covered by committed Ivec2Test.cs + Ivec2RemainingCoverageTests.cs)
Commit: test: coverage Ivec2.cs
Status: ALREADY_REMEDIATED

## Summary

Ivec2.cs is a small sequential-layout struct (7 LOC of logic) holding two float fields `X`
and `Y`, with an `(int, int)` constructor, a `Vector2F` constructor, and an implicit cast
operator from `Vector2F`.

The committed `Ivec2Test.cs` (3 tests, `[RequireCSfmlSystemFact]`) and
`Ivec2RemainingCoverageTests.cs` (3 tests, `[RequireCSfmlWindowsFact]`) exercise every
member: both constructors and the implicit cast. Local coverlet on the Ivec2-filtered run
reports 100.0% (9/9 instrumented lines). The SonarCloud 0.0% is a stale artifact (tests not
yet uploaded).

## Verification

- Ivec2-filtered run: 6 passed / 0 failed (net8.0).
- Local coverlet: Ivec2.cs 100.0% (9/9 lines).
