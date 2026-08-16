File:
pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/GearJoint.cs

CoverageBefore:
99.7% (SonarCloud)

CoverageAfter:
100.0% (line-rate 1.0 and branch-rate 1.0 measured locally via coverlet on the GearJoint filter; both previously uncovered branches — the zero-mass false paths of `_mass > 0.0f ? 1.0f / _mass : 0.0f` at line 413 and `if (mass > 0.0f)` at line 561 — are now exercised by zero inverse-mass/inertia bodies)

TestsAdded:
2 (GearJointLatestCoverageTests.cs: InitVelocityConstraints_WithZeroMassBodies_ShouldKeepMassZero, SolvePositionConstraints_WithZeroMassBodies_ShouldReturnTrue)

Commit:
test: coverage GearJoint.cs

Status:
COMPLETE
