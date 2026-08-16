# Result: FontManager.cs

File: `4_Operation/Graphic/src/Ui/FontManager.cs`
CoverageBefore: 71.4% (SonarCloud; Line: 71.4%)
CoverageAfter: 100.0% (14/14, local coverlet, full Graphic suite)
TestsAdded: 2 (FontManagerExecutionTests.cs: full DefaultFont pipeline executions)
Commit: test: coverage FontManager.cs
Status: REMEDIATED

## Summary

FontManager.cs is the static font facade (3 complexity / 16 LOC): DefaultFont +
two RenderText overloads delegating to `DefaultFont.RenderText`. The two completion lines were
uncovered because DefaultFont.RenderText always threw: with NameFile="mono.bmp" and an empty
Path it enters the texture-loading branch, and `AssetRegistry.GetResourceMemoryStreamByName`
throws when no assets pack is registered (plus the GL layer was uninitialized).

## Tests added (FontManagerExecutionTests.cs)

- Registers an in-memory assets pack zip containing "mono.bmp" (minimal valid 24-bit BMP) via
  `AssetRegistry.RegisterAssembly`, switches `ActiveAssemblyName` (save/restore via the
  backing-field helper pattern established in ImageAdditionalCoverageTests).
- Installs the full fake OpenGL function-pointer set for the font pipeline (glCreateShader,
  glCompileShader, glCreateProgram, glAttachShader, glLinkProgram, glDeleteShader,
  glGenVertexArrays/glGenBuffers/glGenTextures, glBind*, glBufferData, glTexImage2D,
  glTexParameteri, glGenerateMipmap, glUseProgram, glGetUniformLocation, glEnable/glDisable,
  glBlendFunc, glUniform4f/2f/1f/1i, glDrawElements — copied verbatim from
  FontRenderCoverageTests).
- `RenderText_WithColors_Completes` / `RenderText_WithDefaultColors_Completes` exercise both
  FontManager overloads end to end; class Dispose restores the previous active assembly and
  resets `Gl.Initialize(null)`.

## Verification

- Full Graphic suite: 1553 passed / 613 platform skips / 0 failed (net8.0).
- Local coverlet: FontManager.cs 14/14 = 100.0% (before: 71.4% line).
