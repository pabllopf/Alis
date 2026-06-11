# Pattern: S2933 - Field Never Assigned

## Rule
csharpsquid:S2933 - Fields should be assigned in the constructor

## Problem
A `readonly` field is declared but never assigned, always using default value.

## Solution
1. Remove `readonly` modifier
2. Remove `= null!` initialization
3. Remove `#pragma warning disable/restore CS0649`
4. Add assignment in constructor or initialization method

## Example
```csharp
// Before
#pragma warning disable CS0649
private readonly INativePlatform platform = null!;
#pragma warning restore CS0649

// After
private INativePlatform platform;

// In Run() or constructor
platform = GetPlatform();
```

## Files
- Engine.cs:185

## Applied
- 2026-06-11: Engine.cs (AZ6zQlWZ6-8DAyAuaboi)
