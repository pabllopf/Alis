# Issue AZ7PZo8YIRleBA2bjxWx

- Rule: csharpsquid:S3776
- Severity: CRITICAL
- File: 4_Operation/Ecs/generator/ComponentUpdateTypeRegistryGenerator.cs
- Line: 226
- Message: Refactor this method to reduce its Cognitive Complexity from 21 to the 15 allowed.
- Status: Fixed
- Fixed At: 2026-06-16

## Code Snippet

```csharp
foreach (INamedTypeSymbol potentialInterface in componentTypeSymbol.AllInterfaces)
{
    ct.ThrowIfCancellationRequested();
    if (!potentialInterface.IsOrExtendsIComponentBase()) continue;
    needsRegistering = true;
    if (potentialInterface.IsSpecialComponentInterface())
    {
        string name = potentialInterface.ToString();
        if (name != RegistryHelpers.FullyQualifiedTargetInterfaceName)
            flags |= name switch { ... };
        else
            @interface ??= potentialInterface;
    }
    else if (potentialInterface.IsAlisComponentInterface())
    {
        @interface = potentialInterface;
        if (@interface.TypeArguments.Length != 0)
            for (...) genericArguments[i] = ...;
    }
}
```

## Fix

Extracted `ProcessSpecialComponentInterface` and `ProcessAlisComponentInterface` helper methods to flatten nesting and reduce cognitive complexity from 21 to below 15.
