## COVERAGE TEST

### Files Under Test
GLShader.cs, GLShaderProgram.cs, GLShaderProgramParam.cs

### Test Files
- GLShaderCoverageTest.cs (7 tests)
- GLShaderProgramCoverageTest.cs (10 tests)
- GLShaderProgramParamCoverageTest.cs (2 tests)

### Pattern
Delegate-based mocking of OpenGL functions via `Marshal.GetFunctionPointerForDelegate`

### Technique
Created `GlMock.cs` which registers managed delegates for 25+ OpenGL functions (glCreateShader, glCompileShader, glLinkProgram, glUniform*, etc.) and converts them to native function pointers. These are passed to `Gl.Initialize()` to simulate a real OpenGL context without requiring a GPU or native library.

The mock maintains internal state (shader IDs, compile status, program links) to simulate realistic OpenGL behavior including error paths.

### Tests (19 total)
- CreateVertexShader_WithValidSource_Succeeds
- CreateFragmentShader_WithValidSource_Succeeds
- CreateShader_WithInvalidSource_ThrowsInvalidOperationException
- ShaderLog_ReturnsNonEmpty_AfterFailedCompilation
- Dispose_ReleasesUnmanagedResources
- MultipleDispose_DoesNotThrow
- CreateProgram_WithValidShaders_Succeeds
- CreateProgram_WithFailedLink_ThrowsInvalidOperationException
- UseProgram_SetsCurrentProgram
- GetUniformLocation_ReturnsLocation
- GetAttribLocation_ReturnsLocation
- Dispose_ReleasesProgramResources
- MultipleDispose_DoesNotThrow
- UseProgram_AfterDispose_DoesNotThrow
- CreateProgram_FromStringSource_Succeeds
- CreateProgram_FromStringSource_WithFailedShader_Throws
- ProgramLog_ReturnsString
- Indexer_ReturnsNull_ForUnknownParam
- CreateParam_WithTypeAndName_Succeeds
- GetLocation_WithProgram_SetsLocation
