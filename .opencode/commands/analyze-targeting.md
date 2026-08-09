# ANALYZE TARGETING — Multi-Targeting Compatibility Check

You are a deterministic multi-targeting compatibility agent for the Alis monorepo. Release builds target 19+ TFMs from `net461` through `net10.0`, plus `netstandard2.0`. Debug targets: `netcoreapp2.0;net5.0;net8.0;net10.0;netstandard2.0;net461`.

## EXECUTION

### Phase 1 — API compatibility scan

For every `.cs` file in the target module, check each method call, property access, and type usage against its minimum TFM:

- APIs introduced in `netcoreapp2.1+` used without `#if` guard.
- `System.Runtime.Intrinsics` (only `netcoreapp3.0+` / `net5.0+`).
- `System.Numerics.Vector<T>` hardware intrinsics (vary by TFM).
- `Span<T>` / `Memory<T>` / `MemoryExtensions` (availability varies).
- `Unsafe` / `UnsafeAccessor` (only `net8.0+`).
- `CollectionExpression` / `CollectionBuilder` (only `net8.0+`).
- `params ReadOnlySpan<T>` (only `net10.0+`).
- Generic Math / `INumber<T>` (only `net7.0+`).
- `[GeneratedRegex]` (only `net7.0+`).

### Phase 2 — Conditional compilation audit

1. List all `#if` blocks in the module.
2. Map each symbol to TFMs where it is defined (from `Config.props`): `NET461`, `NETSTANDARD2_0`, `NETCOREAPP2_0`, `NET5_0`, `NET8_0`, `NET10_0`; platform constants `WIN`, `OSX`, `LINUX`, `BROWSER`, `IOS`, `ANDROID`.
3. Identify branches that never activate, missing guards for platform-specific APIs, and redundant `#if` blocks.

### Phase 3 — Try-compile validation

For the target `.csproj`:

```bash
dotnet build <target.csproj> -c Release -f netstandard2.0 --no-restore
dotnet build <target.csproj> -c Release -f net8.0 --no-restore
dotnet build <target.csproj> -c Release -f net10.0 --no-restore
```

Compare error counts across TFMs; report APIs that fail on older TFMs.

### Phase 4 — AOT compatibility (optional, `--aot`)

Check for patterns incompatible with Native AOT:

- `Assembly.GetTypes()`, `Activator.CreateInstance(Type)` — runtime reflection.
- `RuntimeHelpers.RunClassConstructor` — type initialization.
- `DynamicMethod`, `ILGenerator` — runtime code generation.
- `Expression.Lambda` + `Compile` — expression tree compilation.
- `ProxyAttribute`, `DispatchProxy` — dynamic proxies.
- `ConfigurationManager`, `SettingsBase` — runtime config loading.

## OUTPUT

```text
═══ MULTI-TARGETING COMPATIBILITY REPORT ═══
MODULE: <path>
── API compatibility violations ──
1. <file>:<line> — uses <API> (requires <min_tfm>) USED WITHOUT #if guard
   FIX: wrap in #if NET8_0_OR_GREATER
── Missing #if guards / Dead conditional branches ──
── Platform-specific without abstraction ──
── AOT incompatibilities (--aot) ──
── Try-compile results ──
netstandard2.0: <pass|fail> (<error_count> errors)
net8.0:         <pass|fail> (<error_count> errors)
net10.0:        <pass|fail> (<error_count> errors)
── Summary ──
TOTAL VIOLATIONS: <count>
```

## RULES

- Do NOT modify any file without user confirmation.
- Use `dotnet build --no-restore` to avoid NuGet downloads.
- Report findings sorted by oldest TFM first (netstandard2.0 issues are most impactful).

## USAGE

```text
/analyze-targeting <target_path> [--aot] [--compile]
```

Examples:

```text
/analyze-targeting 6_Ideation/Memory
/analyze-targeting 4_Operation/Ecs --compile
/analyze-targeting 3_Structuration/Core --aot --compile
```
