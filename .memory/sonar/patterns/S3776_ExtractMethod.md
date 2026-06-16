# Pattern: S3776 - Extract Method for Cognitive Complexity

## Trigger

Cognitive Complexity > 15 (S3776 on csharpsquid)

## Strategy

Identify deeply nested branches inside a control flow structure (foreach, for, while). Extract each major branch into its own helper method.

## Rules

- Extracted method should be `private static`
- Use `ref` parameters for modification of caller locals
- Keep extraction focused: one branch = one method
- Never change behavior or return types

## Example

Before: foreach with nested if/elseif each containing if/switch/for
After: foreach with extracted method calls, each branch flattened
