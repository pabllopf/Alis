# coverage-008: Body.cs Physics

## Task
Cover remaining uncovered paths in `Body.cs` (4_Operation/Physic/src/Dynamics/Body.cs)

## Commit
Not yet committed

## File Modified
- `4_Operation/Physic/test/Dynamics/BodyCoverage008Test.cs` (NEW - 15 tests)

## Methods Covered
1. `SynchronizeTransform()` — Xf updated from Sweep state (internal)
2. `Advance(float)` — CCD sweep advance with alpha interpolation (internal)
3. `LocalCenter` setter on Dynamic body (with and without world)
4. `ApplyForce(ref, ref)` on Static body — non-dynamic guard false branch
5. `ApplyForce(Vector2F, Vector2F)` on Static body — non-dynamic guard false branch
6. `ApplyLinearImpulse(ref, ref)` on Static body — non-dynamic guard false branch
7. `ApplyLinearImpulse(Vector2F, Vector2F)` on Static body — non-dynamic guard false branch
8. `ApplyLinearImpulse(ref, ref)` on Kinematic body — non-dynamic guard false branch
9. `ResetMassData` zero-density fixture skip path
10. `ResetMassData` zero-mass else path (mass forced to 1.0)
11. `ResetMassData` zero-inertia / fixed-rotation else path
12. `Inertia` setter zero-value guard (early return)
13. `Sweep` field assignment

## Coverage Delta
- 15 tests added
- All previously passing tests still pass (2846/2861, 15 skipped)
- Expected uncovered lines reduced from 54 to ~27 (estimated)
