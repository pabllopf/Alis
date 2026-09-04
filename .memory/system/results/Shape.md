# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Render/Shape.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 93.3% (112/120 lines, existing committed suite; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: PARTIAL_BLOCKED_BY_NATIVE
Details:
- Shape.cs is the abstract SFML shape base (PointCount, Point, Texture, TextureRect, FillColor, OutlineColor, OutlineThickness, Radius delegates etc.) wrapping sfShape natives.
- Existing committed suite (ShapeTests.cs etc., incl. subclass accessors) covers 112/120 executable lines.
- Only 4 uncovered lines: Draw(IRenderTarget) switch bodies 166-167 (sfRenderWindow_drawShape) and 169-170 (sfRenderTexture_drawShape). Same blockers as SfmlText.cs: RenderWindow draw calls crash the test host (sfRenderStates stencil ABI, per RenderWindowMainThreadWorker doc) and RenderTexture construction SIGSEGVs (CSFML 3.0 sfRenderTexture_create(sfVector2u,sfBool) vs 2.x 3-arg). Not deterministically coverable.