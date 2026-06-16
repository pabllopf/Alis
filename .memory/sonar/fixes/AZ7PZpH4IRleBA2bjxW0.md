# Fix AZ7PZpH4IRleBA2bjxW0

- Rule: csharpsquid:S1192
- Strategy: Replace inline literal with existing class constant
- Pattern: S1192_UseConstant

## Changes

Replaced `"        /// <summary>"` inline in 7 methods with `XmlSummary` constant.
