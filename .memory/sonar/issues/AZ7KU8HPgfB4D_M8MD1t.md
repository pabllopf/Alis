# Issue AZ7KU8HPgfB4D_M8MD1t

- Rule: csharpsquid:S1192
- Severity: MINOR
- File: 6_Ideation/Data/generator/HelperMethodsGenerator.cs
- Line: 101
- Message: Define a constant instead of using this literal '        }' 8 times.
- Status: Fixed

## Fix

Added new `MethodEnd` constant for `"        }"` and replaced all method closing braces with it.
