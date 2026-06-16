# Issue AZ7PZpH4IRleBA2bjxW4

- Rule: csharpsquid:S1192
- Severity: MINOR
- File: 6_Ideation/Data/generator/HelperMethodsGenerator.cs
- Line: 45
- Message: Define a constant instead of using this literal '            {' 7 times.
- Status: Fixed

## Fix

Replaced all inline `"            {"` block start literals with the existing `BlockStart` constant.
