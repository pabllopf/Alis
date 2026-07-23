# Issue: AZ-Blp3oiLjI1diOPXKQ

- Rule: csharpsquid:S3776
- File: 4_Operation/Physic/src/Common/Decomposition/FlipcodeDecomposer.cs
- Line: 55
- Severity: CRITICAL
- Message: Refactor this method to reduce its Cognitive Complexity from 17 to the 15 allowed.
- Status: RESOLVED

## Resolution

Replaced three boundary-check `if` statements with modulo operations (`% nv`), reducing cognitive complexity below the threshold.
