# Project Coverage State

Target:
4_Operation/Physic/src/Common/TextureTools/MarchingSquares.cs

Project:
4_Operation/Physic/src/Alis.Core.Physic.csproj

Test project:
4_Operation/Physic/test/Alis.Core.Physic.Test.csproj

Agent:
covertall-msq

Baseline commit:
d94a5b5a09839ec1cae1b645f088c11d1990dbeb

Initial line coverage:
82.90% local (SonarCloud reported 81.7%)

Initial branch coverage:
78.33% local

Current line coverage:
99.40% (494/497)

Current branch coverage:
98.33% (177/180)

Tests before:
4126

Tests after:
4132

Files modified:
- 4_Operation/Physic/src/Common/TextureTools/MarchingSquares.cs (regression defect fix: ProcessCell hard-coded grid row 0 for both MarchSquare fs sampling and ps table writes; restored original per-row indexing from the initial commit — this was introduced by the S3776 parameter-reduction refactor)
- 4_Operation/Physic/test/Common/TextureTools/MarchingSquaresCellPatternCoverageTests.cs (6 new tests)

Tests added:
- DetectSquares_WithSolidBlockAndCombine_MergesIntoSinglePolygon
- DetectSquares_WithIsolatedCellDiagonalAndCombine_KeepsPolygonsSeparated
- DetectSquares_WithInterpolatedEdgeVertex_ProducesLerpedPoint
- DetectSquares_WithSharedDegenerateEdge_UsesMidInterpolation
- DetectSquares_WithWideSolidBlockAndCombine_MergesIntoSinglePolygon
- DetectSquares_WithScatteredSamplesAndCombine_MergesAdjacentScanLines

Commits:
see git log (test: cover combine merge pipeline of MarchingSquares.cs)

Remaining uncovered lines:
- 308-310 (HasValidStart == false early-continue in CombineScanLines)

Remaining uncovered branches:
- (307,'0') — same HasValidStart false path
- (345,'1') — CanCombine short-circuit `(u.Key & 3) == 0` evaluated true

Status:
BLOCKED (5 residual points documented unreachable; see attempts/003.md)

Last update:
2026-09-12
