# MarchingSquares.cs

- **File**: `4_Operation/Physic/src/Common/TextureTools/MarchingSquares.cs`
- **Coverage Before**: 81.5%
- **Coverage After**: ~81.6% (CxFastList edge cases: Erase-on-empty, Find-on-empty, FindDefault full-scan)
- **Tests Added**: 5 (CxFastListEdgeCaseTests.cs)
- **Uncovered Lines**: scan-line merge machinery (CombineScanLines/CanCombine/MergePolygons) — unreachable: ProcessCell writes only `Ps[x, 0]` (hardcoded row 0), so the merge loop reads nulls for all `y >= 1`
- **Status**: BLOCKED_BY_PRODUCTION_CODE (dead code in production)

# CxFastListEdgeCaseTests.cs

- **File**: `4_Operation/Physic/test/Common/TextureTools/CxFastListEdgeCaseTests.cs`
- **Tests**: 5 (Find on empty, FindDefault null/no-null, Erase on empty, Erase with prev node)
- **Status**: COMPLETED
