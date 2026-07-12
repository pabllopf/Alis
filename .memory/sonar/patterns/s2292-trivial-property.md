# Pattern: S2292 — Trivial Property

## Rule
Properties with trivial get/set backing field access should be auto-implemented.

## Fix
1. Remove backing field
2. Convert property to auto-implemented `{ get; set; }`
3. Redirect all field references to property

## Example
```csharp
// Before
private IPlayer player = new Player();
internal IPlayer PlayerForTest { get => player; set => player = value; }

// After
internal IPlayer PlayerForTest { get; set; } = new Player();
```

## File
`AZ9WLQR9b3Yg5Wvlzs0z`

