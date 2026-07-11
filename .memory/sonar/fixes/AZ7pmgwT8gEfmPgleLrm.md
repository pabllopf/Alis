# Fix: AZ7pmgwT8gEfmPgleLrm

## Pattern
S3928 ArgumentNullException with non-parameter name → InvalidOperationException

## Change
```diff
- throw new ArgumentNullException(nameof(_board));
+ throw new InvalidOperationException("_board cannot be null.");
```

## File
DungeonData.cs:145
