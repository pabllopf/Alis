# Issue: AZ9WLQtLb3Yg5Wvlzs07

- Rule: csharpsquid:S1186
- Severity: CRITICAL
- File: 4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgramParam.cs
- Line: 231
- Hash: 1ba82f9d0d5b3ad6df0c432252461e29
- Status: FIXED
- Commit: 31988c64f2dcaf41ffe5af68853d738c1eb96d61
- Date: 2026-07-12

## Description

Add a nested comment explaining why this method is empty, throw a 'NotSupportedException' or complete the implementation.

## Context

The `EnsureType<T>()` method was empty with `[Conditional("DEBUG")]` attribute. It's called by all `SetValue` overloads as a type-checking guard. In Release builds, all calls are compiled out by the Conditional attribute, so no behavior change occurs.

## Fix Applied

Completed the implementation with `Debug.Assert(Type == typeof(T), ...)` since:
- `System.Diagnostics` was already imported
- `Debug.Assert` is also `[Conditional("DEBUG")]` — only fires in debug
- In Release builds, both the method calls and the assert are compiled out
- No behavior change in Release; DEBUG builds now get actual type validation