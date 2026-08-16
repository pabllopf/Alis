# Result: GLShaderProgramParam.cs

File: `4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgramParam.cs`
CoverageBefore: 69.2% (SonarCloud; Line: 71.3%, Branch: 60.0%)
CoverageAfter: 100.0% (174/174, local coverlet, full Graphic suite)
TestsAdded: 7 (GlShaderProgramParamExecutionTests.cs: fake-proc-address executions)
Commit: test: coverage GLShaderProgramParam.cs
Status: REMEDIATED

## Summary

GLShaderProgramParam.cs is the OpenGL uniform/attribute parameter wrapper (27 complexity /
113 LOC). Existing tests covered construction, properties and EnsureType; GetLocation and every
SetValue overload completion line were uncovered (the native Gl calls threw because Gl was not
initialized — `Gl.Initialize(null)` + `InvalidOperationException`).

## Tests added (GlShaderProgramParamExecutionTests.cs)

Fake OpenGL function pointers installed via `Gl.Initialize(FakeProcAddress)` (same technique as
FontRenderCoverageTests): no-op delegates for glUseProgram, glGetUniformLocation,
glGetAttribLocation, glUniform1i/1f/2f/3f/4f, glUniformMatrix3fv/4fv. Tests:
- GetLocation: uniform + attribute branches (ProgramId 0 → resolve), already-resolved skip
  (note: production ctor assigns `ProgramId = Program`, so ProgramId is set explicitly).
- SetValue: bool (true+false), int, float, Vector2F/3F/4F, Matrix4X4 — each with a
  correctly-typed param (Debug.Assert-active build).
- SetValue(float[]): lengths 16/9/4/3/2/1 (type-matched EnsureType) and unexpected lengths
  (5/0 → ArgumentException).

## Verification

- Full Graphic suite: 1551 passed / 613 platform skips / 0 failed (net8.0).
- Local coverlet: GLShaderProgramParam.cs 174/174 = 100.0% (before: 71.3% line).
