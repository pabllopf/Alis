# State

Target:
4_Operation/Physic/src/Dynamics/ContactManager.cs

Project:
4_Operation/Physic/src/Alis.Core.Physic.csproj

Test project:
4_Operation/Physic/test/Alis.Core.Physic.Test.csproj

Agent:
covertall-contact-04FCA094-81A5-43C5-AC37-6027065939CF

Baseline commit:
2e91a3e6cfb3a7ba79b612b87b591954d0c1a5b4

Initial line coverage:
76.3% (261/342)

Initial branch coverage:
77.9% (109/140)

Current line coverage:
98.6% (348/353)

Current branch coverage:
97.9% (141/144)

Tests before:
4102 passing in Physic test project

Tests after:
4115 passing (13 new ContactManagerMultiCoreCoverageTests added)

Files modified:
4_Operation/Physic/test/Dynamics/ContactManagerMultiCoreCoverageTests.cs (added)

Tests added:
- CollideMultiCore_WithOverlappingContacts_UpdatesAllContacts
- CollideMultiCore_WithSeparatedContacts_DestroysThem
- CollideMultiCore_WithDisabledBody_KeepsContact
- CollideMultiCore_WithDisabledBodyA_KeepsContact
- CollideMultiCore_WithFilterFlaggedContact_DestroysIt
- CollideMultiCore_WithSleepingBodies_KeepsContact
- Collide_WithDisabledBodyA_ReturnsNextContact
- Collide_WithDisabledBodyB_ReturnsNextContact
- UpdateContactWithLock_WhenLockOrdersAreEqual_ThrowsInvalidOperationException
- UpdateContactWithLock_WhenBodyALocked_RetriesAndCompletes
- UpdateContactWithLock_WhenBodyBLocked_RetriesAndCompletes
- UpdateContactWithLock_WhenBodyALockOrderGreaterThanBodyB_SwapsLockOrder
- UpdateContactWithLock_WhenLockHeldBeyondTimeout_ThrowsInvalidOperationException

Commits:
test: cover multi-core and disabled-body paths of ContactManager.cs

Remaining uncovered lines:
AddPair L181-182 (Contact.Create returns-null path; gated on private
ReturnNullOverride flag in Contact.cs:48 which is never set)

Collide L329-331 (multi-core gate; CollideMultithreadThreshold is a readonly
field fixed to int.MaxValue at line 56 with no other writer, and ContactCount
is an int, so ContactCount > int.MaxValue can never be true)

Remaining uncovered branches:
AddPair L180 off=165 path=0 (null-contact return)
Collide L328 off=13 path=0 and off=28 path=0 (multi-core threshold gate true-path)

Status:
BLOCKED

Last update:
2026-08-17T00:00:00Z