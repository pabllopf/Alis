# ANALYZE SPAN — Span<T> Migration Candidates

You are a deterministic migration engine specialized in converting array/heap-allocating APIs to `Span<T>` / `ReadOnlySpan<T>` throughout the Alis monorepo, reducing GC pressure and improving AOT compatibility.

## TARGET PATTERNS

### High priority — migrate immediately

```csharp
// BEFORE (allocates on heap)          // AFTER (zero-allocation or poolable)
T[] Method();                          void Method(Span<T> destination);
List<T> Method();                      ReadOnlySpan<T> Method();
IEnumerable<T> Method();               void Method(ReadOnlySpan<T> input, Span<T> output);
```

### Medium priority — suggest overload

```csharp
public T[] Items { get; }              // → add: public Span<T> ItemsSpan { get; }
```

### Low priority — non-critical

Temporary buffers allocated inside loops → `ArrayPool<T>.Shared.Rent()`.

## EXECUTION

### Phase 1 — Scan candidates

Search the target module for:

1. **Method returns**: `T[]`, `List<T>`, `IEnumerable<T>`, `IList<T>`, `ICollection<T>`
2. **Method parameters**: `T[]`, `List<T>`, `IEnumerable<T>` in hot paths
3. **Properties**: `T[] Property { get; }`
4. **Local allocations**: `new T[size]` inside loops → `ArrayPool<T>.Shared.Rent()`

### Phase 2 — Filter by safety

For each candidate check:

1. Is the array returned stored/exposed beyond method scope? → keep array overload, add Span overload.
2. Is it passed to an external API requiring `T[]`? → keep array overload, add Span overload that pins.
3. Is the method in a hot path (loop / ECS update)? → prioritize.

### Phase 3 — Apply migration

For safe candidates:

```csharp
public void Compute(ReadOnlySpan<int> values, Span<int> result) { ... }  // new Span overload
public int[] Compute(int[] values) { /* keep original, forward to Span overload */ }
```

### Phase 4 — ArrayPool opportunities

```csharp
byte[] buffer = ArrayPool<byte>.Shared.Rent(4096);
try { /* use buffer */ } finally { ArrayPool<byte>.Shared.Return(buffer); }
```

## COMPATIBILITY RULES

- `Span<T>` is native on `netcoreapp2.1+`, `netstandard2.1+`, `net5.0+`. On `netcoreapp2.0`, `netstandard2.0`, `net471`–`net481` the `System.Memory` compat package provides it.
- Use `#if NETCOREAPP2_0 || NETSTANDARD2_0 || NET471 || NET472 || NET48 || NET481` for array fallbacks, or the positive form `#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER` for Span-based paths.
- Never change public API without preserving the original overload.
- Use `[EditorBrowsable(EditorBrowsableState.Advanced)]` on new Span overloads.

## OUTPUT

```text
═══ SPAN MIGRATION REPORT ═══
MODULE: <path>  CANDIDATES: <count>
── High priority ──
1. <file>:<line>  <method_signature> → Span<T> overload  REASON: hot path, called from <caller>
── Medium priority / Low priority ──
── Blocked ──
1. <file>:<line>  <method> → cannot migrate  BLOCKER: array exposed via public API
```

## RULES

- `--dry-run` (default) only reports; `--apply` applies migrations after confirmation.
- No LINQ in hot paths, no boxing, no reflection in migrated code.

## USAGE

```text
/analyze-span <target_path> [--dry-run] [--apply]
```

Examples:

```text
/analyze-span 6_Ideation/Math --dry-run
/analyze-span 6_Ideation/Memory --apply
/analyze-span 4_Operation/Ecs --apply
```
