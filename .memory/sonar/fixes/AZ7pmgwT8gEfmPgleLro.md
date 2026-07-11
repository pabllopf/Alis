# Fix: AZ7pmgwT8gEfmPgleLro

## Pattern
S3928 ArgumentNullException with non-parameter name → InvalidOperationException

## Change
```diff
- throw new ArgumentNullException(nameof(_rooms));
+ throw new InvalidOperationException("_rooms cannot be null.");
```

## File
DungeonData.cs:155
