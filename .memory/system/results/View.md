# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Render/View.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 97.9% (94/96 lines, existing committed suite; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: PARTIAL_BLOCKED_BY_NATIVE
Details:
- View.cs wraps sfView natives (ctors from rect/size, Center/Size/Viewport/Rotation read-write, Move/Zoom/Rotate/Reset, GetTransform, ToString, Destroy). CSFML 3.0 View ABI is otherwise stable; existing committed suite (ViewExecutionTests.cs + ViewTest.cs, + SfmlSmallRemainingCoverageTests) covers 94/96 executable lines.
- Sole missed line 156: Reset(FloatRect) body. sfView_reset does not exist in CSFML 3.0 (absent from View.h and the dylib); existing tests already assert EntryPointNotFoundException from view.Reset(...). Line unreachable. Not deterministically coverable.