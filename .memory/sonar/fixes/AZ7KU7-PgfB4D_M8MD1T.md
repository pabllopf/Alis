# Fix AZ7KU7-PgfB4D_M8MD1T

- Rule: csharpsquid:S3776
- Strategy: Extract Method + Simplify Conditional
- Pattern: S3776_ExtractMethod (applied same pattern as AZ7PZo8YIRleBA2bjxWx)

## Changes

- Extracted `AddMiscFlags` local function → private static method with parameters
- Extracted `GetContainingTypes` local function → private static method with parameter
- Extracted compound boolean expression `(nestTypes.Length != 0 && !isAcc) || flags.HasFlag(IsGeneric)` into local variable `requiresSelfInit`
