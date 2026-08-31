# Result: BitOperations.cs

File: `4_Operation/Ecs/src/Redifinition/BitOperations.cs`
CoverageBefore: 31.0% (SonarCloud)
CoverageAfter: UNCHANGED
TestsAdded: 0
Commit: none (no remediable test)
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

This file declares a custom `public static class BitOperations` in `namespace System.Numerics`
(alongside the other `Redifinition/` redefinitions of BCL APIs for legacy TFMs) with three methods:
`Log2(uint)`, `RoundUpToPowerOf2(uint)`, and `RotateLeft(uint, int)`.

SonarCloud reports 31% because `Log2` (which uses `Unsafe.AddByteOffset` over a De Bruijn table)
and `RoundUpToPowerOf2` are uncovered.

This task is NOT remediable under the working constraints:

- The type's full name `System.Numerics.BitOperations` collides with the BCL type of the same name
  in `System.Runtime` on net8.0. Any reference to `BitOperations` (unqualified or fully qualified)
  from the test assembly produces **CS0433** (type exists in both `Alis.Core.Ecs` and
  `System.Runtime`).
- The only language-level way to disambiguate two same-full-name types from different assemblies is
  an `extern alias` on the project reference, which requires adding `<Aliases>` to the
  `Alis.Core.Ecs.Test.csproj`. Editing `.csproj`/`.props` files is forbidden (only `.cs` files may
  be created or edited).
- Using reflection to invoke the type/methods is forbidden (no reflection in tests).

A coverage test file (`BitOperationsCoverageTests.cs`) was written but failed to build with
CS0433 and was removed. The production file is included for all TFMs by default glob, so the
collision is inherent to net8.0 (the TFM CI runs).
