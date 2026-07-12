# Pattern: S2292 — Auto-Implemented Property Replacing Backing Field

## Rule

csharpsquid:S2292 — Make this an auto-implemented property and remove its backing field

## Problem Signature

A property has a simple get/set passthrough to a private backing field. The field is also referenced directly in other members of the same type.

## Reusable Transformation

1. Replace the manual property with an auto-implemented property
2. Move the initializer from the field to the property
3. Remove the private backing field
4. Replace all direct field references with the property name throughout the type
5. Verify test files still work (they likely use the property setter for dependency injection)

## Example

```csharp
// Before
private IPlayer player = new Player();
internal IPlayer PlayerForTest { get => player; set => player = value; }
public bool IsPlaying => player.Playing;

// After
internal IPlayer PlayerForTest { get; set; } = new Player();
public bool IsPlaying => PlayerForTest.Playing;
```

## Applicable Rules

- S2292 (Auto-implemented property)
- S2376 (Write-only property — related)