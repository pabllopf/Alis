# Project Coverage State

Target:
4_Operation/Physic/src/Dynamics/ContactManager.cs

Project:
4_Operation/Physic/src/Alis.Core.Physic.csproj

Test project:
4_Operation/Physic/test/Alis.Core.Physic.Test.csproj

Agent:
covertall-cm

Baseline commit:
f76bd863b9e1a9e1e23df6ed60c74d832ea7f723

Initial line coverage:
76.3% (attempt 001) / 98.5% at session start

Initial branch coverage:
77.9% (attempt 001) / 97.8% at session start

Current line coverage:
100.00% (342/342)

Current branch coverage:
100.00% (140/140)

Tests before:
4115

Tests after:
4126

Files modified:
- 4_Operation/Physic/src/Dynamics/Contacts/Contact.cs (ReturnNullOverride test hook made internal — was private and never settable despite doc-comment declaring it a test hook)
- 4_Operation/Physic/src/Dynamics/ContactManager.cs (CollideMultithreadThreshold made settable (readonly → mutable); a public readonly int.MaxValue field made the documented configurable multi-core threshold unreachable, blocking Collide()'s multi-core branch)
- 4_Operation/Physic/test/Dynamics/ContactManagerMultiCoreCoverageTests.cs (2 new tests)

Tests added:
- AddPair_WhenContactCreateReturnsNull_DoesNotInsertContact
- Collide_WhenContactCountExceedsMultithreadThreshold_UsesMultiCorePipeline

Commits:
see git log

Remaining uncovered lines:
none

Remaining uncovered branches:
none

Status:
COMPLETED

Last update:
2026-09-12
