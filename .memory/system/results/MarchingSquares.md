# MarchingSquares.cs

- **File**: `4_Operation/Physic/src/Common/TextureTools/MarchingSquares.cs`
- **Coverage Before**: 79.9% (SonarCloud); 81.5% local
- **Coverage After**: 81.5% (405/497 lines — verified ceiling, matches prior session)
- **Tests Added**: 0 (existing MarchingSquares/CxFastList suites cover all reachable surface)
- **Uncovered Lines**: 92 — scan-line merge machinery (CombineScanLines/CanCombine/MergePolygons): ProcessCell writes only `Ps[x, 0]` (hardcoded row 0), so the merge loop reads nulls for all y >= 1; dead code
- **Status**: BLOCKED_BY_PRODUCTION_CODE
