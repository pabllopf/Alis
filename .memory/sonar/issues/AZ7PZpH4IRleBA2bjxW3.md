# Issue AZ7PZpH4IRleBA2bjxW3

- Rule: csharpsquid:S1192
- Severity: MINOR
- File: 6_Ideation/Data/generator/HelperMethodsGenerator.cs
- Line: 44
- Message: Define a constant instead of using this literal '        {' 8 times.
- Status: Fixed

## Fix

Replaced all inline `"        {"` method body start literals with the existing `MethodBodyStart` constant.
