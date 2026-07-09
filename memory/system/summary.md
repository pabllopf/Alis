# Coverage Remediation Summary

| Timestamp | File | Coverage Before | Coverage After (est.) | Estimated Gain | Commit | Status |
|-----------|------|----------------|----------------------|----------------|--------|--------|
| 2026-07-09 18:00:30 | BoxCollider.cs | 39.3% | ~48-51% | +9-12% | 4cf43dccfebf8b546cd8f936c62768c261cace50 | Completed |
| 2026-07-09 18:04:10 | AudioVideoWriter.cs | 56.3% | ~63% | +6-8% | 4cf43dccfebf8b546cd8f936c62768c261cace50 | Completed |
| 2026-07-09 18:04:10 | BrowserPlayer.cs | 59.1% | ~66-69% | +7-10% | 4cf43dccfebf8b546cd8f936c62768c261cace50 | Completed |

## Test File Created
- `BoxColliderRemainingCoverageTests.cs` at `/Users/pabllopf/repositorios/Alis/2_Application/Alis/test/Core/Ecs/Components/Collider/BoxColliderRemainingCoverageTests.cs`

## Methods Newly Covered
- OnStart full body-creation path (Dynamic + Static)
- OnStart called twice (body replacement)
- OnUpdate full path (body-to-Transform sync)
- OnUpdate after manual body replacement
- Body property lifecycle
- BoxColliderSettings record `with` expression
- AutoTilling property independence
