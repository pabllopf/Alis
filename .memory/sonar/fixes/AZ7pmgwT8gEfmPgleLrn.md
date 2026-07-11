# Fix: AZ7pmgwT8gEfmPgleLrn

## Pattern
S3928 ArgumentException with non-parameter name → InvalidOperationException

## Change
```diff
- throw new ArgumentException("Board dimensions must be greater than zero.", nameof(_board));
+ throw new InvalidOperationException("Board dimensions must be greater than zero.");
```

## File
DungeonData.cs:150
