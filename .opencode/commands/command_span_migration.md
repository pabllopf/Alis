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

- `Span<T>` is available on: `netcoreapp2.1+`, `netstandard2.1+`, `net5.0+`, `net6.0+`, `net8.0+`, `net10.0+`.
- On `netstandard2.0` and `net461`: use `System.Memory` NuGet shim (already included via `System.Memory` compat package).
- For multi-target projects, use `#if`:
  ```csharp
  #if NETSTANDARD2_0 || NET461
      // array-based fallback
  #else
      // Span-based implementation
  #endif
  ```
- Never change public API without preserving the original overload.
- Use `[EditorBrowsable(EditorBrowsableState.Advanced)]` on new Span overloads if needed.

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
