# Fix AZ7KU8HPgfB4D_M8MD1t

- Rule: csharpsquid:S1192
- Strategy: Add new constant + replace inline literal
- Pattern: S1192_UseConstant

## Changes

Added `MethodEnd` constant for `"        }"` and replaced all 8 occurrences.
