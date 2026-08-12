# Transform.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Transform.cs`
- **Coverage Before**: 0.0% (SonarCloud — all tests native-gated)
- **Coverage After**: Pure-managed surface covered by plain `[Fact]` (constructor 9-element assignment, Identity, GetHashCode, ToString); native sf* wrapper lines (GetInverse/TransformPoint/TransformRect/Combine/Translate/Rotate/Scale/Equals) still require csfml runtime on CI
- **Tests Added**: 6 (TransformRemainingCoverageTests.cs)
- **Uncovered Lines**: Native P/Invoke wrappers requiring csfml-window runtime
- **Status**: COMPLETED
