# Pattern: Making Private Methods Testable via Internal Visibility

## When to Use
When a method is `private` but contains testable logic (no external dependencies) and needs to be tested for coverage.

## Requirements
- Source project must have `InternalsVisibleTo` for the test assembly (e.g., `<InternalsVisibleTo Include="$(AssemblyName).Test"/>`)
- Change must be minimal: `private` → `internal` only

## When NOT to Use
- When method requires infrastructure (OpenGL, network, filesystem) — use integration tests or Moq instead
- When method is implementation detail likely to change — test through public API instead

## Example
```csharp
// Before
private static bool IsSpriteVisible(...)

// After  
internal static bool IsSpriteVisible(...)
```
