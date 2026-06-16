# Issues Index

<!-- Last Sync: 2026-06-16T09:01:00-03:00 -->
<!-- Total Issues: 36 -->
<!-- Fixed in Code: 30 -->
<!-- Awaiting Rescan: 29 -->
<!-- Needs Code Change: 0 -->
<!-- Needs Config Change: 7 -->

## Verified Already Fixed in Code (awaiting SonarCloud rescan)

| # | Key | Rule | File | Fix Applied |
|---|-----|------|------|-------------|
| 1 | AZ7PZo8YIRleBA2bjxWx | S3776 | ComponentUpdateTypeRegistryGenerator.cs | Extract Method (committed a8123d754) |
| 2-8 | AZ7PZpH4IRleBA2bjxW0-W5, AZ7KU8HPgfB4D_M8MD1t | S1192 | HelperMethodsGenerator.cs | Constants defined |
| 8 | AZ7PZo8ZIRleBA2bjxWy | CA1068 | ComponentUpdateTypeRegistryGenerator.cs | CancellationToken last param |
| 24 | AZ7KU8JEgfB4D_M8MD10 | CA1850 | ResourceAccessorGenerator.cs | SHA256.HashData |
| 25 | AZ7KU7-PgfB4D_M8MD1T | S3776 | ComponentUpdateTypeRegistryGenerator.cs | Extract Method |
| 26 | AZ7KU79QgfB4D_M8MD1N | CA1510 | EquatableArray.cs | ThrowIfNull |
| 27 | AZ7PZo8ZIRleBA2bjxWz | CA1825 | ComponentUpdateTypeRegistryGenerator.cs | Array.Empty |
| 28 | AZ7KU7-PgfB4D_M8MD1Y | CA1825 | ComponentUpdateTypeRegistryGenerator.cs | Array.Empty |
| 29 | AZ7KU78RgfB4D_M8MD1K | CA1825 | Stack.cs | Array.Empty |
| 30-32 | AZ7KU74wgfB4D_M8MD1D-1F | S4136 | FastImmutableArray.cs | Overloaded methods scattered in Builder |
| 33 | AZ7KU74wgfB4D_M8MD1I | S112 | FastImmutableArray.cs | Throws ArgumentOutOfRangeException |
| 34 | AZ7KU74wgfB4D_M8MD1J | CA1825 | FastImmutableArray.cs | Array.Empty |
| 35-36 | AZ7KU8AVgfB4D_M8MD1a-1b | CA1068 | CodeBuilder.cs | CancellationToken last param |

## Needs Config Change (AnalyzerReleases files exist, may need shipped release)

| # | Key | Rule | File | Notes |
|---|-----|------|------|-------|
| 9-12 | AZ7PZo6MIRleBA2bjxWt-Ww | RS2008 | GeneratorAnalyzer.cs | Unshipped rules exist, shipped is empty |
| 14-23 | AZ7KU8FagfB4D_M8MD1d-1m | RS2000 | AotReflectionAnalyzer.cs | Unshipped rules exist, shipped is empty |
