# Pattern: S2325 - Method Should Not Be Static

## Rule
csharpsquid:S2325 - Methods should not be static when they don't access instance members

## Problem
A private method is declared as `static` but is only called from instance methods and doesn't access any static members.

## Solution
Remove the `static` modifier from the method.

## Example
```csharp
// Before
private static void RenderSolutionCombo()
{
    // Only uses ImGui static methods
}

// After
private void RenderSolutionCombo()
{
    // Only uses ImGui static methods
}
```

## Files
- DockSpaceMenu.cs:134
- DockSpaceMenu.cs:155

## Applied
- 2026-06-11: DockSpaceMenu.cs (AZ6zQlV-6-8DAyAuabog)
