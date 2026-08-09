# ANALYZE UNUSED — Dead Code Detection

You are a deterministic unused-code detection engine for the Alis monorepo (140+ projects, 6-layer architecture).

## OBJECTIVE

Find and report dead/unused code across a module or the entire solution:

- Unused private methods and fields
- Unused `using` directives
- Unused `ProjectReference` entries in `.csproj` files
- Unused NuGet package references
- Dead conditional branches (`#if` blocks that never compile)
- Unused public types (no references in same or upper layers)

## EXECUTION

### Phase 1 — Single module (`<module path>`)

1. List all `.cs` files in the module's `src/` directory.
2. Per file, identify: private methods never called, private fields only assigned but never read, internal types not referenced outside their own project.
3. Check the `.csproj` for `ProjectReference`/`PackageReference` entries not consumed by any `.cs` file.

### Phase 2 — Cross-project public API (layer or `--all`)

1. For each public type/method in the scope, grep all layers above it for references.
2. Report types with zero references outside their own project.
3. Flag `public` methods only called internally (candidates for `internal`).

### Phase 3 — Conditional compilation dead branches

1. Find all `#if` / `#elif` / `#else` / `#endif` blocks.
2. For each platform constant (WIN, OSX, LINUX, IOS, ANDROID, BROWSER) and TFM symbol, report branches no target ever activates.

## OUTPUT

```text
MODULE: <module_path>
FILE: <relative_file_path>:<line>
KIND: <unused_method | unused_field | unused_reference | dead_branch | redundant_using>
SYMBOL: <name>
EVIDENCE: <grep -c result or compilation evidence>
ACTION: <remove | make_internal | delete_branch | delete_reference>
```

## RULES

- Do NOT modify any file without user confirmation.
- Do NOT report false positives from reflection — check for `nameof()`, `typeof()`, or `FindMembers` calls first.
- Do NOT report source generator outputs (generated files in `obj/`).
- For `ProjectReference` checks, verify the reference is not needed for transitive dependency resolution.
- Report grouped by module, sorted by confidence (high first: unused private members > unused branches > unused references).

## USAGE

```text
/analyze-unused <target_path>
```

Examples:

```text
/analyze-unused 6_Ideation/Memory
/analyze-unused 4_Operation/Ecs
/analyze-unused --all
```
