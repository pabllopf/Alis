# Issue AZ7PZpH4IRleBA2bjxW1

- Rule: csharpsquid:S1192
- Severity: MINOR
- File: 6_Ideation/Data/generator/HelperMethodsGenerator.cs
- Line: 40
- Message: Define a constant instead of using this literal '        /// </summary>' 8 times.
- Status: Fixed

## Fix

Replaced all inline `"        /// </summary>"` literals with the existing `XmlSummaryEnd` constant.
