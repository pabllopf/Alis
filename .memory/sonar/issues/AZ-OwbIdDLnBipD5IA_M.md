# Issue: AZ-OwbIdDLnBipD5IA_M

- Rule: csharpsquid:S2486
- File: 4_Operation/Physic/src/Collisions/Collision.cs
- Line: 1098
- Severity: MINOR
- Message: Handle the exception or explain in a comment why it can be ignored.
- Status: RESOLVED

## Resolution

Removed the empty catch block. The finally block ensures `tempPolygonB.ReturnBuffers()` is always called. Exceptions now propagate naturally instead of being silently swallowed.
