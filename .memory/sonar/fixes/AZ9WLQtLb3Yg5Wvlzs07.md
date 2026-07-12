# Fix: AZ9WLQtLb3Yg5Wvlzs07

- Issue: AZ9WLQtLb3Yg5Wvlzs07
- Rule: S1186
- File: 4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgramParam.cs
- Commit: 31988c64f2dcaf41ffe5af68853d738c1eb96d61
- Date: 2026-07-12
- Status: APPLIED

## Transformation

Completed empty `[Conditional("DEBUG")]` method with `Debug.Assert` type validation:
- Added `Debug.Assert(Type == typeof(T), ...)` inside `EnsureType<T>()`
- Both the method and `Debug.Assert` are DEBUG-only (Conditional attribute)
- No behavior change in Release builds
- DEBUG builds gain actual type-mismatch detection

## Verification

Build: SUCCESS (0 warnings, 0 errors) across all target frameworks.