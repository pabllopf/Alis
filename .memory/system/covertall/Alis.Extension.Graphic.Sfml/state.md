# Project Coverage State

Project:
1_Presentation/Extension/Graphic/Sfml/src/Alis.Extension.Graphic.Sfml.csproj

Test project:
1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj


Status:
COMPLETED

Agent:
sfml-agent

Started:
2026-08-24T20:09:06Z

Last update:
2026-08-24T22:05:00Z

Baseline commit:
2734a0dfa7afe77a9827bef131b66a5c5ab2784e

Initial coverage:
75.97% (1938/2551 sequence points)

Current coverage:
76.44% (1950/2551 sequence points)

Tests before:
1626

Tests after:
1630

Tests added:
4

Files modified (test only):
- test/Windows/ContextRemainingCoverageTests.cs (new, 3 tests)
- test/Render/DrawableDrawCoverageTests.cs (new, 1 test)

Coverage work:
- Context.cs: Settings getter, ToString, and finalizer path (17/20 now)
- Shape.cs: Draw state marshaling on a non-window/target stub (56/60 now)

Remaining opportunities (BLOCKED - documented in attempts):
- RenderWindow.cs (0/161): requires live native window on the macOS main thread.
  The startup-hook infra exists but coverlet + CSFML 3.0 ABI corruption crashes
  the test host ("BadImageFormatException: Bad IL range") during coverage runs.
- Window.cs (54/169): same main-thread window requirement; CallEventHandler
  (49/49) already covered. All remaining members call native window APIs that
  hang/crash off-main-thread.
- RenderTexture.cs (2/93): sfRenderTexture_create hangs (offscreen GL FBO).
- Sprite.cs (0/43): sfSprite_create hangs on this machine.
- Sound.cs (0/53): sfSound_create hangs on this machine.
- SoundStream.cs (3/69): needs audio device + callbacks; zero CPointer.
- Image.cs (73-74, 153-154): LoadingFailedException branches not triggerable.
- Mouse.cs (125-127,145-147): sfMouse_setPosition hangs.
- Touch.cs (72-73): needs a live window.
- Texture.cs (364-400): Update(Window/RenderWindow) needs a live window.
- Draw case bodies (Shape 166-170, SfmlText 263-267, VertexArray 147-151,
  VertexBuffer 160-164): need real RenderWindow/RenderTexture instances.
- Shader.cs SetParameter (9 lines), View.cs Reset (1), SoundRecorder.cs
  SetProcessingInterval (1): CSFML 3.0 renamed the entry points; the call
  throws EntryPointNotFoundException BEFORE coverlet's visit marker, so the
  lines are not countable even though tests exercise them.

Last commit:
4dae2ec3e (test: cover draw state marshaling of Shape.cs)

Attempts:
4