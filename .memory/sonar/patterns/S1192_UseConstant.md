# Pattern: S1192 - Use Constant for Repeated Literal

## Trigger

S1192 "Define a constant instead of using this literal"

## Strategy

Find all occurrences of the repeated string literal in the file. If a constant already exists referencing it, replace all inline usages. If no constant exists, add one.

## Rules

- Constant should be `private const string` at the top of the class
- Naming: PascalCase describing the literal content
- Replace ALL inline occurrences, not just the threshold
