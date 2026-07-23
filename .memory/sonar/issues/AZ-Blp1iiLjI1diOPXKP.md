# Issue: AZ-Blp1iiLjI1diOPXKP

- Rule: csharpsquid:S2223
- File: 4_Operation/Physic/src/Dynamics/Contacts/Contact.cs
- Line: 48
- Severity: CRITICAL
- Message: Change the visibility of 'ReturnNullOverride' or make it 'const' or 'readonly'.
- Status: RESOLVED

## Resolution

Changed visibility from `internal` to `private`. The field is a test hook only set via reflection (with `BindingFlags.NonPublic`), so `private` is appropriate.
