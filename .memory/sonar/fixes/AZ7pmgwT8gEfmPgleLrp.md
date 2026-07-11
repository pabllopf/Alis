# Fix: AZ7pmgwT8gEfmPgleLrp

## Pattern
S3928 ArgumentNullException with non-parameter name → InvalidOperationException

## Change
```diff
- throw new ArgumentNullException(nameof(_corridors));
+ throw new InvalidOperationException("_corridors cannot be null.");
```

## File
DungeonData.cs:160
