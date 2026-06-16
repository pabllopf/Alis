# Issue AZ7PZpH4IRleBA2bjxW5

- Rule: csharpsquid:S1192
- Severity: MINOR
- File: 6_Ideation/Data/generator/HelperMethodsGenerator.cs
- Line: 46
- Message: Define a constant instead of using this literal '            }' 7 times.
- Status: Fixed

## Fix

Replaced all inline `"            }"` block end literals with the existing `BlockEnd` constant.
