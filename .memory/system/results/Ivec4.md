# Result: Ivec4.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Ivec4.cs`
CoverageBefore: 0.0% (SonarCloud, stale artifact)
CoverageAfter: 100.0% (12/12, local coverlet, Ivec4-filtered run)
TestsAdded: 0 (already covered by committed Ivec4Test.cs / Ivec4RemainingCoverageTests.cs)
Commit: test: coverage Ivec4.cs
Status: ALREADY_REMEDIATED

## Summary

Ivec4.cs is a pure managed value-type struct (2 constructors, 26 LOC) representing a GLSL
ivec4. It has an int-coordinate constructor and a Color-based constructor that copies the
R/G/B/A byte components.

The committed `Ivec4Test.cs` (2 tests, `[RequireCSfmlSystemFact]`) and
`Ivec4RemainingCoverageTests.cs` (2 tests, `[RequireCSfmlWindowsFact]`) both exercise every
line of both constructors. The SonarCloud 0.0% is a stale artifact (tests not yet uploaded);
local coverlet on the Ivec4-filtered run reports 100.0% (12/12 instrumented lines, both
constructors fully hit).

No native interop is involved; the struct is fully deterministic and testable without
producing code changes.

## Verification

- Ivec4-filtered run: all passing (net8.0).
- Local coverlet: Ivec4.cs 100.0% (12/12 lines).
