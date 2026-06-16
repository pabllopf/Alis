# Fix AZ7PZo8YIRleBA2bjxWx

- Rule: csharpsquid:S3776
- Strategy: Extract Method
- Pattern: ExtractMethod_ComplexBranch_ToHelper

## Changes

- Extracted `ProcessSpecialComponentInterface` from `InspectComponentInterfaces` foreach body
- Extracted `ProcessAlisComponentInterface` from `InspectComponentInterfaces` foreach body
- Both extracted methods take `ref` parameters for out-vars
- Cognitive complexity reduced: 21 → ~4
