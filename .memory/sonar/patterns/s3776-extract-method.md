# Pattern: S3776 — Extract Method for Cognitive Complexity

## When to Use
When a method exceeds the allowed Cognitive Complexity of 15.

## Solution
Extract the body of complex loops or conditional blocks into separate private methods with clear names. This flattens the nesting and reduces the per-method complexity score.

## Example
- Before: `foreach` with nested `if/else if` inside a single method
- After: Move loop body to `InspectSingleInterface()` and replace with a single method call
