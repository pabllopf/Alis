# GLShader.cs

- **File**: `4_Operation/Graphic/src/OpenGL/Constructs/GLShader.cs`
- **Coverage Before**: 55.6%
- **Coverage After**: ~56.0% (ceiling)
- **Tests Added**: 0 (existing tests cover uninitialized-instance, Dispose, and finalizer paths)
- **Uncovered Lines**: Constructor GL calls (`GlCreateShader`, compile) and `ReleaseUnmanagedResources` with nonzero ID — require GL context unavailable on CI
- **Status**: COMPLETED
