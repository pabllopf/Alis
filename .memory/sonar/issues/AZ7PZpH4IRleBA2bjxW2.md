# Issue AZ7PZpH4IRleBA2bjxW2

- Rule: csharpsquid:S1192
- Severity: MINOR
- File: 6_Ideation/Data/generator/HelperMethodsGenerator.cs
- Line: 43
- Message: Define a constant instead of using this literal '        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]' 8 times.
- Status: Fixed

## Fix

Replaced all inline `ExcludeFromCodeCoverage` attribute literals with the existing `ExcludeFromCodeCoverage` constant.
