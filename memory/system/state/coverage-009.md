# coverage-009 — AssetRegistry.cs (Complete)

## Summary
Added 12 tests covering uncovered branches in `AssetRegistry.cs`, targeting:
- **MakeSafeTempName**: no-extension key, border-case extension length (16 chars including dot)
- **FindZipEntryInfo**: duplicate filenames (full path, partial path, triple duplicate)
- **Partial match via IndexOf**: substring fallback when full-path and file-name lookups fail
- **Resource without extension**: round-trip via GetResourceMemoryStreamByName and GetResourcePathByName
- **Duplicate filename in EntriesByFileNameLower**: EnsureZipCached builds list correctly
- **Backslash normalization**: resource name with backslashes resolves via forward-slash normalized lookup
- **ExtractedPathCache invalidation**: RegisterAssembly clears stale cache for same assembly

## Files Changed
- `6_Ideation/Memory/test/AssetRegistryCoverageTest.cs` (new, 349 lines) — 12 new xUnit tests
- `6_Ideation/Memory/test/CollectionDefinitions.cs` (new) — collection definition for sequential execution

## Commit
- `c9ba41391` — test: coverage AssetRegistry.cs

## Coverage Delta
- File: `AssetRegistry.cs` — was 90.3% (Line: 91.2%, Branch: 87.8%) with 22 ul / 11 branches
- Note: Some branches (zipEntry null race, cache-miss-after-ensure) are practically unreachable; the 12 new tests cover the testable gaps.

## Next
- Increment skip to 9 for next loop iteration
