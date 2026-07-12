# GLShaderProgramParam.cs Coverage Result

- **File**: `4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgramParam.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: ~70%
- **Tests Added**: 4

## Tests Added

### `GlShaderProgramParamCoverageTests`
1. `GetLocation_WithUniformParam_SetsProgramIdAndLocation` - Verifies GetLocation sets ProgramId and Location for uniform params
2. `GetLocation_WithAttributeParam_SetsProgramIdAndLocation` - Verifies GetLocation sets ProgramId and Location for attribute params
3. `GetLocation_WhenProgramIdAlreadySet_DoesNotChangeValues` - Verifies guard clause when ProgramId is already set
4. `SetValue_FloatArray_Length9_ThrowsWhenGlNotInitialized` - Covers the Matrix3x3 branch of SetValue(float[])

## Notes
- Uses mock GL function pointers via `Gl.Initialize` for GetLocation tests (same pattern as `GlShaderProgramCoverageTests`)
- SetValue tests use `Assert.ThrowsAny<Exception>` since GL is not initialized in test context
- `EnsureType<T>()` is `[Conditional("DEBUG")]` internal method and cannot be directly tested
