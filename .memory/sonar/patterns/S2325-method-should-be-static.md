# Pattern: S2325 - Make method static

## Rule
csharpsquid:S2325

## Condition
A method does not access instance data (this, instance fields, instance methods).

## Fix
Add `static` keyword to the method declaration.

## Safety
Always safe when the method body only references local variables, parameters, static members, or types.

## Example
```csharp
// Before
private void MyMethod() { }

// After
private static void MyMethod() { }
```
