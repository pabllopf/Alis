# Pattern: S1144 — Conditionally-Compiled Unused Field

## Rule

csharpsquid:S1144 — Unused private member

## Problem Signature

A private field appears unused because it's only referenced inside `#else` branches of `#if` conditional compilation. SonarCloud analyzes on a specific TFM where the `#else` branch is compiled out, making the field appear unused. However, removing it outright would break older TFMs.

## Reusable Transformation

1. Identify the `#if` directive that controls the usage scope
2. Wrap the field declaration in the negated condition: `#if !<SYMBOL>`
3. Include the XML doc comment inside the guard too
4. Verify build on all TFMs (both with and without the symbol)

## Example

```csharp
// Before: field used only in #else branch
private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

#if NET6_0_OR_GREATER
    Span<byte> buffer = stackalloc byte[4];
    RandomNumberGenerator.Fill(buffer);
#else
    byte[] buffer = new byte[4];
    Rng.GetBytes(buffer);
#endif

// After: field declaration Matches usage scope
#if !NET6_0_OR_GREATER
    private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();
#endif

#if NET6_0_OR_GREATER
    // ...
#else
    // Rng still available here
#endif
```

## Applicable Rules

- S1144 (Unused private member) when member is conditionally compiled