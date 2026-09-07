# AssetRegistry.cs

## File
`6_Ideation/Memory/src/AssetRegistry.cs` (6_Ideation/Memory)

## Coverage Before
- SonarCloud: 96.5% line / 94.1% branch (7 lines uncovered, 6 branches uncovered)
- Local coverlet (net8.0): line 0.985 / branch 0.9411

## Coverage After (local coverlet, filtered AssetRegistry suite)
- line 0.9850 (526/534)
- branch 0.9608 (196/204)
- 60 tests run, all passed, filtered `FullyQualifiedName~AssetRegistry`

## Tests Added
`test/AssetRegistryFallbackCoverageTest.cs` — 3 tests (collection-scoped, state-save/restore via reflection like existing tests):
1. `GetResourceMemoryStreamByName_BareFileNameUnique_ResolvesThroughFileNameIndex` — single-entry file-name index match.
2. `GetResourceMemoryStreamByName_BareFileNameAmbiguous_ResolvesViaEndsWithFallback` — duplicate file names (`dir1/data.xml`, `dir2/data.xml`) looked up by bare `data.xml` forces the full-path `EndsWith` fallback branch in `FindZipEntryInfo`.
3. `GetResourcePathByName_BareFileNameMixedDirs_ExtractsContent` — bare-name extraction across mixed directories.

Impact: branch coverage 94.11% → 96.08%; the `FindZipEntryInfo` fallback condition line (624) went from 4/6 → 6/6.

## Remaining uncovered (4 lines, all unreachable defensive code)
- **Lines 500-501** (`ToLowerHex`: `if (bytes.Length == 0) return string.Empty;`): SHA-256 over the normalized resource key always produces 32 bytes; empty-span return is dead defensive code. Line 499 condition stays at 50% (null/empty path never taken).
- **Lines 541-542** (`EnsureZipCachedForActiveAssembly`: `throw new InvalidOperationException(...)` when loader missing): all public entry points (`GetResourceMemoryStreamByName` line 184, `GetResourcePathByName` via `ValidateActiveAssembly` line 654) pre-check `RegisteredAssetLoaders.ContainsKey` and throw the identical message before the cache ensures; the throw is reachable only through an artificial race (loader removed between the pre-check and the cache ensure). Defensive double-guard.

## Dead/partial conditions (documented, not forced)
- Line 377 50%: `Path.GetDirectoryName(tempFilePath) ?? Path.GetTempPath()` — `tempFilePath` always has a parent dir; `?? ` fallback unreachable.
- Line 434 50%: `Path.GetExtension(normalizedResourceKey) ?? string.Empty` — `Path.GetExtension` returns `""` (never null) for non-null input.
- Line 540 50%: loader-missing guard (see lines 541-542).

## Status
COMPLETED (reachable code fully covered; remaining lines are defensively dead / not reachable via public API without artificial races)