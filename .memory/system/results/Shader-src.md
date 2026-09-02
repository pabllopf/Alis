# Result: Shader.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Shader.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 14.1% (53/376 instrumented lines, local coverlet, ShaderDeterministicCoverageTests run)
TestsAdded: 9 (ShaderDeterministicCoverageTests.cs, plain [Fact])
Commit: test: coverage Shader.cs
Status: PARTIAL_BLOCKED_BY_NATIVE

## Summary

Shader.cs is an SFML/CSFML native wrapper (`Alis.Extension.Graphic.Sfml.Render.Shader`). Unlike the
ImGui/ImPlot partials, its methods pass C# `string` arguments DIRECTLY through `[DllImport]` P/Invokes
with no managed `GetBytes` interop layer. Empirically verified (libc strlen probe): a null C# string
does NOT raise a managed `ArgumentNullException` at the call site — the marshaller passes it straight
through and native code segfaults. So the null-string probe pattern is invalid here.

The only deterministically-coverable managed paths (no native-library dependency) are:
- `SetUniformArray(string, T[])` (6 overloads): the first statement is `GCHandle.Alloc(array, ...)`.
  `GCHandle.Alloc(null, Pinned)` returns a valid handle (no throw), but then `array.Length` is
  evaluated as the final argument to the P/Invoke → `NullReferenceException` BEFORE any native call.
  Deterministic on every platform, no native lib required.
- `Shader(IntPtr)` ctor (stores pointer only, `ObjectBase` does no native work).
- `ToString()` → "[Shader]" (pure managed).
- `Shader.CurrentTextureType()` ctor (pure managed).

Added `ShaderDeterministicCoverageTests.cs` (9 plain `[Fact]`): the 6 SetUniformArray null-array
overloads (expecting NullReferenceException) + Shader(IntPtr) ctor + ToString + CurrentTextureType ctor.

## Remaining uncovered (BLOCKED_BY_NATIVE)

- All `SetUniform(string name, T)` scalar/uniform setters (float, Vec2/3/4, int, Ivec, Bvec, Matrix,
  Texture, CurrentTextureType): bodies are single `sfShader_*Uniform(CPointer, name, value)` calls with
  no managed work and direct string→native marshaling. Covering them requires native `csfml-graphics`
  at runtime AND a valid CPointer; null name segfaults. Not deterministically coverable under plain
  `[Fact]` without native deps.
- `FromString`/`FromFile`/`FromStream`, `Bind`, `NativeHandle`, `IsAvailable`, `IsGeometryAvailable`,
  `Destroy(bool)`: native-boundary (would throw DllNotFoundException without native lib or need true
  GLSL content).

## Verification

- ShaderDeterministicCoverageTests-filtered run: 9 passed / 0 failed (net8.0). (Initial attempt
  expected ArgumentNullException; empirically GCHandle.Alloc(null,Pinned) does NOT throw, NRE thrown
  by array.Length — corrected assertion.)
- Local coverlet: Shader.cs 14.1% (53/376 instrumented lines).