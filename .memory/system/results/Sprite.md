# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Render/Sprite.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 0.0% (0/86 lines executable in this environment; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: BLOCKED_BY_NATIVE
Details:
- Sprite.cs wraps sfSprite natives (default/texture/texture+rect/copy ctors, Color, Texture, TextureRect, GetLocalBounds/GetGlobalBounds, ToString, Destroy, and the Draw switch). 26 existing committed tests (SpriteTests.cs) are reflection-only (member existence/type checks) and never construct a Sprite, so local coverage is 0%.
- CSFML 3.0 changed sfSprite_create() to sfSprite_create(const sfTexture* texture). The wrapper's no-arg P/Invoke passes a garbage texture register. Attempted execution suite (built from a live Texture created from tile000.bmp, verifying the Texture path works): the minimal `new Sprite()` probe alone blocked the test host ("Serie de pruebas anulada"), identical to the sfSound_create garbage-buffer crash. Every Sprite ctor routes through sfSprite_create, so no member is reachable. Tests reverted.
- Not coverable without src changes (production fix: pass IntPtr.Zero explicitly to sfSprite_create).