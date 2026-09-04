# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Render/Image.cs
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 95.6% (87/91 lines, existing committed suite; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: PARTIAL_BLOCKED_BY_NATIVE
Details:
- CSFML 3.0 (brew) present. Existing committed suite (ImageRemainingCoverageTests/ImageExecutionTests, 62 tests) covers 87/91 executable lines (constructors, Pixels, Size, SaveToFile, CreateMaskFromColor, Copy, GetPixel, SetPixel, Flip*, ToString, Destroy).
- Remaining 4 uncovered lines are defensive LoadingFailedException throw guards in Image(uint,uint,Color) (lines 73-74) and Image(uint,uint,byte[]) (lines 153-154) when native create returns IntPtr.Zero.
- Attempted to trigger via zero-size constructor args (new Image(0,0,Color.Black) / new Image(0,0,byte[4])): CSFML 3.0 sfImage_createFromColor/sfImage_createFromPixels always return a non-null wrapper even for empty images; guard branches require native allocation failure, not deterministically producible. Tests reverted.
- Production wrapper uses CSFML 2.x 3-arg signatures while installed CSFML 3.0 uses 2-arg (sfVector2u, ...), but tolerated by native.