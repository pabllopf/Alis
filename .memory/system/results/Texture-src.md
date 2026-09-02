# Result: Texture.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Texture.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 0.0% (unchanged)
TestsAdded: 0 (none — no deterministic managed logic)
Commit: test: coverage Texture.cs
Status: BLOCKED_BY_NATIVE

## Summary

Texture.cs is a pure native-boundary SFML wrapper. Every ctor chains to a `base(sfTexture_create*)` /
`sfTexture_createFromStream` native creation call, and every public method (Size, NativeHandle,
CopyToImage, Update*, GenerateMipmap, Swap, Bind, ToString) is a direct `sfTexture_*` P/Invoke.

The only "managed" lines are ctor `if (CPointer == IntPtr.Zero) throw new LoadingFailedException(...)`
guards. These depend on the native `sfTexture_create*` return value (whether a real texture can be
allocated), which is non-deterministic across hosts/GPUs/contexts and requires a live CSfml native
context. Unlike the ImGui null-probe pattern (where a null label throws managed-side via
Encoding.UTF8.GetBytes before any native call), there is no string arg marshaled at the call site. Calling
native creation paths risks crashes (verified: ImGuizMo null probes segfaulted the test host) and is not
deterministically coverable in CI.

## Remaining uncovered (BLOCKED_BY_NATIVE)

All method bodies and ctor branches in the file (native-return-dependent).

## Verification

- No test file generated (record-only task).
- Full project build: unaffected.
- Local coverlet: no new coverage (0.0%).