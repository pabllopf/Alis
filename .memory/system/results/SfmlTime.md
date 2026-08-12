# SfmlTime.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Systems/SfmlTime.cs`
- **Coverage Before**: 0.0% (SonarCloud — all tests native-gated)
- **Coverage After**: Managed-only members covered by plain `[Fact]` (Equals(object), Equals(SfmlTime), GetHashCode, ==, !=); native sf* wrappers still require csfml runtime (unavailable on SonarCloud CI)
- **Tests Added**: 6 (SfmlTimeRemainingCoverageTests.cs)
- **Uncovered Lines**: Native P/Invoke wrappers (`sfSeconds`/`sfMilliseconds`/`sfTime_*` calls, comparison and arithmetic operators routed through them)
- **Status**: COMPLETED
