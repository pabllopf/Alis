# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Render/SfmlText.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 95.2% (160/168 lines, existing committed suite; verified via XPlat Code Coverage, 38 tests pass)
TestsAdded: 0
Commit: (none)
Status: PARTIAL_BLOCKED_BY_NATIVE
Details:
- SfmlText.cs wraps the SFML text object over CSFML 3.0 natives: arg-less sfText_create() still binds (3.0 takes const sfFont* — extra register ignored), sfText_set/getUnicodeString, colors, thickness, font, char/letter/line spacing, style, copy ctor, FindCharacterPos, local/global bounds, ToString, Destroy. Existing committed suite (SfmlTextTests.cs + SfmlTextTest.cs, 38 tests) covers 160/168 executable lines.
- Only 4 uncovered lines: Draw(IRenderTarget) switch bodies 263-264 (sfRenderWindow_drawText) and 266-267 (sfRenderTexture_drawText).
- RenderWindow real-draw path: RenderWindowMainThreadWorker documents that "[s]fRenderStates gained stencil fields... the draw calls ... are skipped because they crash the test host." sfRenderWindow_drawText continues to crash the host, so the case body cannot be executed locally.
- RenderTexture real-draw path: RenderTexture construction SIGSEGVs (CSFML 3.0 sfRenderTexture_create(sfVector2u,sfBool) vs 2.x 3-arg), so the case is unreachable (see RenderTexture.md).
- Mock<IRenderTarget> Draw tests (existing) only exercise the switch default path. Not deterministically extendable without crashing the host.