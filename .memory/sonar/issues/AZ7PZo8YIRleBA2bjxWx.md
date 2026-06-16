# Issue: AZ7PZo8YIRleBA2bjxWx

- Rule: csharpsquid:S3776
- Severity: CRITICAL
- File: ComponentUpdateTypeRegistryGenerator.cs
- Line: 226
- Message: Refactor this method to reduce its Cognitive Complexity from 21 to the 15 allowed.
- Status: FIXED

## Fix

Extracted the foreach loop body into `InspectSingleInterface` method to reduce cognitive complexity of `InspectComponentInterfaces` from 21 to 1.

## Commit

a8123d754
