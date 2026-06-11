# Pattern: S3776 - Extract combo/menu body to reduce cognitive complexity

## Rule
csharpsquid:S3776 - Cognitive Complexity of methods should not be too high

## Pattern
When a method contains a large inline ImGui combo/menu body with many conditional items, extract the entire combo body into a separate private method.

## Before
```csharp
public void Render()
{
    if (ImGui.BeginCombo("##Plus", "..."))
    {
        if (ImGui.Selectable("Item1")) { }
        if (ImGui.Selectable("Item2")) { }
        // ... 30+ items
        ImGui.EndCombo();
    }
}
```

## After
```csharp
public void Render()
{
    if (ImGui.BeginCombo("##Plus", "..."))
    {
        RenderPlusMenu();
        ImGui.EndCombo();
    }
}

private void RenderPlusMenu()
{
    if (ImGui.Selectable("Item1")) { }
    if (ImGui.Selectable("Item2")) { }
    // ... 30+ items
}
```

## Cognitive Complexity Impact
Reduces parent method complexity by eliminating nesting level + repeated conditionals.
