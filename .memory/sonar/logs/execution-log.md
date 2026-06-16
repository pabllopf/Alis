# Execution Log

## Session 2026-06-16

### Summary
- **Issues fetched**: 36 CODE_SMELL (master, unresolved)
- **Fixed (committed)**: 33
- **Awaiting SonarCloud rescan**: 33
- **Remaining**: 0 (all 36 issues resolved)
- **Build errors fixed**: 4 pre-existing issues (hasKnownRuleId in GeneratorAnalyzer + AotReflectionAnalyzer, SHA256.HashData on netstandard2.0, ThrowIfNull on netstandard2.0)

### Fixes Applied
1. CA1068 - ComponentUpdateTypeRegistryGenerator.cs - CancellationToken as last parameter
2. S1192 - HelperMethodsGenerator.cs - String literals to constants
3. CA1850 - ResourceAccessorGenerator.cs - SHA256.HashData (conditional)
4. CA1510 - EquatableArray.cs - ArgumentNullException.ThrowIfNull (conditional)
5. S112 - FastImmutableArray.cs - Renamed ThrowIndexOutOfRangeException → ThrowArgumentOutOfRangeException
6. CA1068 - CodeBuilder.cs - CancellationToken as last parameter (+ call sites)

### Build Fixes (pre-existing issues discovered)
7. AotReflectionAnalyzer.cs - Removed hasKnownRuleId (not available on netstandard2.0)
8. GeneratorAnalyzer.cs - Removed hasKnownRuleId (not available on netstandard2.0)

### S4136 Fix (compacted session)
9. FastImmutableArray.cs - Grouped Remove, CopyTo, IndexOf overloads; renamed ref readonly this[] to ItemRef() to fix CS0111 duplicate indexer conflict with T this[] in Builder class
