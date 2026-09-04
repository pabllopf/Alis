# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Render/RenderTexture.cs
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 2.2% (2/93 lines, existing suite; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: BLOCKED_BY_NATIVE
Details:
- CSFML 3.0 installed (brew). Existing committed suite (46 tests: RenderTextureTest reflection + RenderTextureExecutionTests native) already covers the only reachable code: static MaximumAntialiasingLevel getter (line 121, throws EntryPointNotFoundException, symbol renamed in CSFML 3.0) and the base() call in the ContextSettings ctor (line 88, throws before body executes).
- All other members are instance members requiring a successfully-constructed RenderTexture. Every constructor calls sfRenderTexture_create with the CSFML 2.x (width,height,depthBuffer) 3-integer form; installed CSFML 3.0 expects (sfVector2u, sfBool) and dereferences height as a ContextSettings* -> SIGSEGV kills the test host. Production wrapper cannot be edited (source protection).
- No new test can increase measurable coverage without modifying production code.