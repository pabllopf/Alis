# ANALYZE GENERATORS — Source Generator Audit

You are a deterministic source generator audit engine for the Alis monorepo. The project has 9+ Roslyn source generators across all layers, targeting `netstandard2.0` and consumed as `OutputItemType="Analyzer"`.

## EXECUTION

### Phase 1 — Generator discovery

For the target module, locate:

1. `generator/` directory with `.csproj` targeting `netstandard2.0`.
2. Files containing `[Generator]` attribute.
3. Base class: `ISourceGenerator` (legacy) or `IIncrementalGenerator` (modern).
4. All syntax provider filters.

### Phase 2 — Incremental pipeline analysis

For `IIncrementalGenerator` implementations:

1. Map the pipeline: `Initialize → pipeline steps → RegisterSourceOutput`.
2. Verify all steps use functional operators (`Select`, `Where`, `Combine`, `Collect`), no side effects in transformations, value-type equality (`IEquatable<T>` / `record struct`), and cached intermediate results.
3. Flag: `SelectMany` without caching, missing equality implementations, side-effectful delegates.

### Phase 3 — AOT safety (anti-pattern check)

FORBIDDEN in generator code:

```csharp
var assembly = Assembly.Load(bytes);          // runtime codegen
var method = new DynamicMethod(...);
File.ReadAllText(path);                       // filesystem access
Directory.GetFiles(dir);
```

Allowed: `compilation.SyntaxTrees`, `SemanticModel.GetDeclaredSymbol()`, `attributeData.ConstructorArguments`, `Diagnostic.Create()`.

### Phase 4 — Output validation

1. Produces valid C# (compile a consuming project).
2. Uses `global::` prefix for type references (required for AOT).
3. Deterministic output (same input → same output) and stable file names (no GUIDs).
4. Handles: empty compilation, syntax errors, duplicate attribute usage, nested types, generic types.

### Phase 5 — Test coverage (if test project exists)

Check for `CSharpGeneratorDriver.Create` compilation-based tests covering minimal/typical/multiple/nested/generic/syntax-error inputs and snapshot tests.

## OUTPUT

```text
═══ SOURCE GENERATOR AUDIT REPORT ═══
GENERATOR: <name>  LOCATION: <path>  TYPE: <IIncrementalGenerator | ISourceGenerator>
── Pipeline analysis ──
Steps: <count>  AOT-safe: <yes|no>  Incremental: <yes|no>
── Anti-patterns found ──
1. <file>:<line> — <pattern> — <risk>
── Output quality ──
Valid C# / Deterministic / global:: prefix / empty input / syntax errors: <yes|no>
── Test coverage ──
Test project: <path>  Tests: <count>
── Recommendations ──
1. <recommendation>
```

## RULES

- Do NOT modify any file without user confirmation.
- Non-deterministic generator output (same input → different output across runs) is CRITICAL.
- Generators must be referenced as `<ProjectReference ... OutputItemType="Analyzer" ReferenceOutputAssembly="false" />`.

## USAGE

```text
/analyze-generators <target_generator_path>
```

Examples:

```text
/analyze-generators 6_Ideation/Data/generator
/analyze-generators 2_Application/Alis/generator
/analyze-generators 4_Operation/Ecs/generator
```
