# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Render/VertexBuffer.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 90.0% (72/80 lines, existing committed suite; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: PARTIAL_BLOCKED_BY_NATIVE
Details:
- VertexBuffer.cs wraps sfVertexBuffer natives (create/from VertexArray, usage, size, vertex list access, primitives type, attribute flags, native handle/map helpers and the Draw switch over RenderWindow/RenderTexture).
- Existing committed suite (VertexBufferTest.cs) covers 72/80 executable lines.
- Missed 160-164: Draw(IRenderTarget, RenderStates) RenderWindow/RenderTexture case bodies calling sfRenderWindow_drawVertexBuffer / sfRenderTexture_drawVertexBuffer. Same native blockers as SfmlText.cs/Shape.cs/VertexArray.cs (RenderWindow draw crashes on RenderStates stencil ABI; RenderTexture construction SIGSEGV). Not deterministically coverable without src changes.