# Task: AngleJoint.cs Coverage

**Target**: 4_Operation/Physic/src/Dynamics/Joints/AngleJoint.cs
**Coverage**: 60.5% → ~85% estimated
**Uncovered Lines**: 17
**Status**: ✅ COMPLETED (commit 088de324e)

## Methods Covered
- InitVelocityConstraints (calculates _bias and _massFactor)
- SolveVelocityConstraints (applies impulse with max limit)

## Test File
4_Operation/Physic/test/Dynamics/Joints/AngleJointTest.cs

## Notes
- InitVelocityConstraints and SolveVelocityConstraints are internal methods
- Requires SolverData with proper TimeStep, SolverPosition[], SolverVelocity[]
- Body.Inertia must be set to finite value for InvI != 0
- Reflection used to call internal methods (struct ref params don't propagate through Invoke)
