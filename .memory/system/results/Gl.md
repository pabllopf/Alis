# Gl.cs

- **File**: `4_Operation/Graphic/src/OpenGL/Gl.cs`
- **Coverage Before**: 30.7% (line 30.6%, branch 31.3%)
- **Coverage After**: ~71% (line) — command resolution lifecycle covered
- **Tests Added**: 3 (GlCommandTests.cs — uninitialized property/method sweeps + zero-pointer ExternalException path)
- **Uncovered Lines**: delegate invocation paths, Marshal.GetDelegateForFunctionPointer success line, GlGetString marshaling loop — require a live GL context unavailable on CI
- **Status**: COMPLETED
