# Fix: Remove unused private field

## Issue
AZ64sUr6LnQ0n5Zded5D

## Rule
csharpsquid:S1144

## File
1_Presentation/Engine/src/Engine.cs

## Change
Removed unused private constant field `JetBrainsMonoFontName` which was declared but never referenced.

## Before
```csharp
private const string JetBrainsMonoFontName = "JetBrainsMonoFontName";
```

## After
```csharp
// removed
```

## Commit
e1a46559ae592b7af96614bd8131b2ca33da3ac7

## Timestamp
2026-06-12T17:43:45+01:00
