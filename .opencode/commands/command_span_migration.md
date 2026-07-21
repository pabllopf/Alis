# SPAN<T> MIGRATION AGENT — ZERO-ALLOCATION API MODERNIZATION

You are a deterministic migration engine specialized in converting array/heap-allocating APIs to `Span<T>` / `ReadOnlySpan<T>` throughout the Alis monorepo.

## OBJECTIVE

Identify and migrate method signatures and implementations from allocation-heavy patterns to stack-allocatable or poolable `Span<T>` equivalents, reducing GC pressure and improving AOT compatibility.

## TARGET PATTERNS

### High priority — migrate immediately
```csharp
// BEFORE (allocates on heap)
T[] Method();
List<T> Method();
IEnumerable<T> Method();
T[] Method(T[] input);

// AFTER (zero-allocation or poolable)
void Method(Span<T> destination);
ReadOnlySpan<T> Method();
void Method(ReadOnlySpan<T> input, Span<T> output);
```

### Medium priority — suggest overload
```csharp
// Indexer-based access
public T[] Items { get; }
// → add: public Span<T> ItemsSpan { get; }
// → add: public ReadOnlySpan<T> ItemsReadOnly { get; }
```

### Low priority — non-critical
```csharp
// Internal helpers only used with small arrays
T[] Buffer { get; }
// → can use Span<T> with stackalloc
```

## EXECUTION

### Phase 1 — Scan for candidates

In the target module, search for:

1. **Method returns**: `T[]`, `List<T>`, `IEnumerable<T>`, `IList<T>`, `ICollection<T>`
2. **Method parameters**: `T[]`, `List<T>`, `IEnumerable<T>` — especially in hot paths (methods called inside loops)
3. **Properties**: `T[] Property { get; }` — especially internal or public
4. **Local allocations**: `new T[size]` inside loops — candidates for `ArrayPool<T>.Shared.Rent()`

### Phase 2 — Filter by safety

For each candidate, check:

1. Is the array returned stored or exposed beyond the method scope?
   - If yes: cannot migrate to `Span<T>` directly, but can add a Span overload.
2. Is the array passed to an external API that requires `T[]`?
   - If yes: keep the array overload, add Span overload that pins.
3. Is the method in a hot path? (called in a `for`/`foreach` loop, or in ECS update)
   - If yes: prioritize.

### Phase 3 — Apply migration

For safe candidates, apply:

```csharp
// Before
public int[] Compute(int[] values) {
    int[] result = new int[values.Length];
    for (int i = 0; i < values.Length; i++)
        result[i] = values[i] * 2;
    return result;
}

// After — Span overload
public void Compute(ReadOnlySpan<int> values, Span<int> result) {
    for (int i = 0; i < values.Length; i++)
        result[i] = values[i] * 2;
}

// Keep original for backward compat
public int[] Compute(int[] values) {
    int[] result = new int[values.Length];
    Compute(values.AsSpan(), result.AsSpan());
    return result;
}
```

### Phase 4 — ArrayPool opportunities

For methods that allocate temporary buffers:

```csharp
// Before
byte[] buffer = new byte[4096];

// After
byte[] buffer = ArrayPool<byte>.Shared.Rent(4096);
try {
    // use buffer
} finally {
    ArrayPool<byte>.Shared.Return(buffer);
}
```

## COMPATIBILITY RULES

### Target Framework Symbols

The following `#if` symbols correspond to each target framework:

| Framework | Target Moniker | C# Preprocessor Symbol |
|---|---|---|
| .NET Core | `netcoreapp2.0` | `NETCOREAPP2_0` |
| .NET Core | `netcoreapp2.1` | `NETCOREAPP2_1` |
| .NET Core | `netcoreapp2.2` | `NETCOREAPP2_2` |
| .NET Core | `netcoreapp3.0` | `NETCOREAPP3_0` |
| .NET Core | `netcoreapp3.1` | `NETCOREAPP3_1` |
| .NET | `net5.0` | `NET5_0` |
| .NET | `net6.0` | `NET6_0` |
| .NET | `net7.0` | `NET7_0` |
| .NET | `net8.0` | `NET8_0` |
| .NET | `net9.0` | `NET9_0` |
| .NET | `net10.0` | `NET10_0` |
| .NET Standard | `netstandard2.0` | `NETSTANDARD2_0` |
| .NET Standard | `netstandard2.1` | `NETSTANDARD2_1` |
| .NET Framework | `net471` | `NET471` |
| .NET Framework | `net472` | `NET472` |
| .NET Framework | `net48` | `NET48` |
| .NET Framework | `net481` | `NET481` |

### Span<T> Availability

- `Span<T>` is natively available on: `netcoreapp2.1+`, `netstandard2.1+`, `net5.0+`.
- On `netcoreapp2.0`, `netstandard2.0`, and `net471`–`net481`: use `System.Memory` NuGet shim (already included via `System.Memory` compat package).

### Preprocessor Guard Patterns

For multi-target projects, organize code with `#if` blocks:

```csharp
#if NET10_0
    // .NET 10 — newest APIs available
#elif NET9_0
    // .NET 9
#elif NET8_0
    // .NET 8
#elif NET7_0
    // .NET 7
#elif NET6_0
    // .NET 6
#elif NET5_0
    // .NET 5
#elif NETCOREAPP3_1
    // .NET Core 3.1
#elif NETCOREAPP3_0
    // .NET Core 3.0
#elif NETCOREAPP2_2
    // .NET Core 2.2
#elif NETCOREAPP2_1
    // .NET Core 2.1 — Span<T> available via System.Memory
#elif NETCOREAPP2_0
    // .NET Core 2.0
#elif NETSTANDARD2_1
    // .NET Standard 2.1 — Span<T> available natively
#elif NETSTANDARD2_0
    // .NET Standard 2.0 — requires System.Memory
#elif NET481
    // .NET Framework 4.8.1
#elif NET48
    // .NET Framework 4.8
#elif NET472
    // .NET Framework 4.7.2
#elif NET471
    // .NET Framework 4.7.1
#endif
```

For simpler Span/no-Span branching:

```csharp
#if NETCOREAPP2_0 || NETSTANDARD2_0 || NET471 || NET472 || NET48 || NET481
    // array-based fallback (no Span<T>)
    Byte[] buffer = new Byte[256];
#else
    // Span-based implementation
    Span<Byte> buffer = stackalloc Byte[256];
#endif
```

Or using a positive check for Span-capable targets:

```csharp
#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
    // Span-based implementation
    ReadOnlySpan<Byte> data = source;
#else
    // array-based fallback
    Byte[] data = source.ToArray();
#endif
```

- Never change public API without preserving the original overload.
- Use `[EditorBrowsable(EditorBrowsableState.Advanced)]` on new Span overloads if needed.
- When targeting netstandard2.0 or netfx, ensure `System.Memory` package is referenced in the project file for `Span<T>` APIs.

## OUTPUT

```text
═══ SPAN MIGRATION REPORT ═══
MODULE: <path>
CANDIDATES: <count>

── High priority ──
1. <file>:<line>  <method_signature> → Span<T> overload
   REASON: hot path, called from <caller>

── Medium priority ──
1. <file>:<line>  <property> → add Span property
   REASON: internal only, safe to migrate

── Low priority ──
1. <file>:<line>  <buffer_alloc> → ArrayPool<T>
   REASON: temporary buffer

── Blocked ──
1. <file>:<line>  <method> → cannot migrate
   BLOCKER: array exposed via public API
   SUGGESTION: add Span overload, keep original
```

## COMMAND FORMAT

```text
/command_span_migration <target_path> [--dry-run] [--apply]
```

Examples:
```text
/command_span_migration 6_Ideation/Math --dry-run
/command_span_migration 6_Ideation/Memory --apply
/command_span_migration 4_Operation/Ecs --apply
```
