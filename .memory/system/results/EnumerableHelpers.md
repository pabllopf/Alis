File:
pabllopf-official_alis:4_Operation/Ecs/src/Collections/EnumerableHelpers.cs

CoverageBefore:
92.2% (SonarCloud)

CoverageAfter:
94.9% line (112/118, local coverlet net8.0 — matches SonarCloud Line 94.9%); Branch 83.3% (5/6)

TestsAdded:
0

Commit:
test: coverage EnumerableHelpers.cs

Status:
BLOCKED_BY_PRODUCTION_CODE

## Summary

EnumerableHelpers.cs (118 executable LOC). The committed suite (9 files, 68 tests in
4_Operation/Ecs/test/Collections/) passes on net8.0 and locally covers every reachable
path. The only 3 uncovered lines are 142-144 inside `ToArrayFromEnumerator<T>`:

```csharp
if ((uint) newLength > arrayMaxLength)              // line 142
{
    newLength = arrayMaxLength <= count ? count + 1 : arrayMaxLength;   // line 143
}                                                   // line 144
```

## Analysis

`arrayMaxLength` is `0X7FFFFFC7` (2,147,483,591). The guard fires only when
`count << 1 > 2,147,483,591`, i.e. once the enumerator path has already buffered
`count = 2^30 = 1,073,741,824` elements. Reaching it requires a non-`ICollection`
source yielding over one billion items while `Array.Resize` grows the buffer up to
~2 GB (byte) / ~8.6 GB (int). Infeasible in CI; no public-API test can reach it.

## Verification

- Build: dotnet build 4_Operation/Ecs/test/Alis.Core.Ecs.Test.csproj -f net8.0 (0 warnings/errors).
- Test: dotnet test -f net8.0 --filter "FullyQualifiedName~EnumerableHelpers" → 68/68 pass.
- Local coverlet: 112/118 line (94.9%), 3 uncovered lines = 142, 143, 144.
