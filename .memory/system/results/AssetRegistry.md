# Result: AssetRegistry.cs

File: `6_Ideation/Memory/src/AssetRegistry.cs`
CoverageBefore: 90.2% (SonarCloud; Line: 92.1%, Branch: 85.3%, 21 uncovered lines)
CoverageAfter: 98.5% (526/534, local coverlet, full Memory suite)
TestsAdded: 0 (existing suite covers every reachable line; the 4 remaining lines are dead guards)
Commit: test: coverage AssetRegistry.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

AssetRegistry.cs is the embedded-assets pack registry (66 complexity / 334 LOC). The committed
suite (AssetRegistryTest/AssetRegistryCoverageTest/AssetRegistryExtendedCoverageTest/
AssetRegistryFinalCoverageTests/AssetRegistryMissingCoverageTest/AssetRegistryPureLogicTest/
AssetRegistryRemainingCoverageTests, 94 tests) covers registration, resource lookup by name and
by path, zip extraction, temp-path validation and every exception path.

## Remaining uncovered lines (4) — BLOCKED_BY_PRODUCTION_CODE

- 500-501 — `ToLowerHex` empty-bytes branch: only reachable with a zero-length hash input;
  both callers pass SHA256 outputs (always 32 bytes) or the UTF8 bytes of a non-empty resource
  key. Defensive branch.
- 541-542 — `EnsureZipCachedForActiveAssembly`'s "no assets.pack loader" throw: `GetResource
  MemoryStreamByName`/`GetResourcePathByName` already validate `RegisteredAssetLoaders.
  ContainsKey(ActiveAssemblyName)` immediately before calling it, so the second guard can never
  fire (duplicate guard). A test targeting it (setting an unregistered ActiveAssemblyName via
  the backing-field helper) was written, verified to only hit the pre-check, and reverted.

## Verification

- Full Memory suite: passes with the same pre-existing order-dependent failure set as without
  any new test (AssetRegistryTest.GetResourcePathByName_ExistingResource_ReturnsValidFilePath).
- Local coverlet: AssetRegistry.cs 526/534 = 98.5% (before: 92.1% line).
