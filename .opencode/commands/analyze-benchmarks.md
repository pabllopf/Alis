# ANALYZE BENCHMARKS — Benchmark Coverage Gaps

You are a deterministic benchmark coverage analyzer for the Alis monorepo. The project has a single official benchmark project at `1_Presentation/Benchmark/src/Alis.Benchmark.csproj`.

## EXECUTION

### Phase 1 — Discover existing benchmarks

1. Read `1_Presentation/Benchmark/src/Alis.Benchmark.csproj` to find all benchmark files.
2. List all benchmark classes and their `[Benchmark]` methods.
3. Build a mapping: `module → benchmark methods`.

### Phase 2 — Identify hot paths without benchmarks

Search for the following patterns across the target module:

1. **ECS systems**: methods in `4_Operation/Ecs/` called every frame (`IUpdateSystem`, `IRunSystem`, `IFixedUpdateSystem`).
2. **Math primitives**: `Vector2/3/4`, `Matrix4x4`, `Quaternion` operations in `6_Ideation/Math/`.
3. **Memory operations**: Allocate, Copy, Free in `6_Ideation/Memory/`.
4. **Serialization**: Serialize/Deserialize in `6_Ideation/Data/`.
5. **Graphic operations**: Draw calls, buffer updates in `4_Operation/Graphic/`.
6. **Audio processing**: Mix, Convert, Resample in `4_Operation/Audio/`.
7. **Physics**: Collision detection, broadphase, narrowphase in `4_Operation/Physic/`.

### Phase 3 — Prioritize gaps

Score each gap:

| Factor | Weight |
|--------|--------|
| Called per frame (in ECS update loop) | +10 |
| Allocation-heavy | +8 |
| O(n²) or higher complexity | +7 |
| Virtual/interface dispatch in hot path | +5 |
| Uses LINQ in loop | +4 |
| Uses reflection | +3 |
| Already partially benchmarked | -3 |

### Phase 4 — Generate benchmark proposals

For each high-priority gap, propose a benchmark method with variants (`_SmallInput`, `_LargeInput`, allocation-aware). Use `BenchmarkDotNet` attributes only (`[Benchmark]`, `[BenchmarkCategory]`, `[Params]`).

## OUTPUT

```text
═══ BENCHMARK COVERAGE REPORT ═══
MODULE: <path>
EXISTING BENCHMARKS: <count>
IDENTIFIED GAPS: <count>
── High priority (score >= 15) ──
1. <Module>.<Method> — called per frame, score: <n>  LOCATION: <file>:<line>
   SUGGESTION: add to <ExistingBenchmarkFile>.cs
── Medium priority (score 8-14) / Low priority (score < 8) ──
── Benchmark code to add (high priority) ──
<generated benchmark>
```

## RULES

- Do NOT modify benchmark files without user confirmation.
- Do NOT add NuGet package references — BenchmarkDotNet is already referenced.
- Verify the benchmark compiles before presenting it.

## USAGE

```text
/analyze-benchmarks <target_path>
```

Examples:

```text
/analyze-benchmarks 6_Ideation/Math
/analyze-benchmarks 4_Operation/Ecs
/analyze-benchmarks --all
```
