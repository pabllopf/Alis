# Result: SdlTtf.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Sdl2Ttf/SdlTtf.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 0.0% (unchanged)
TestsAdded: 0
Commit: (none)
Status: BLOCKED_BY_NATIVE

## Summary

SdlTtf.cs is a `public static class SdlTtf` that is a thin static wrapper over SDL_ttf P/Invokes
(`NativeSdlTtf.Internal*`) and SDL-core (`Sdl.GetError`/`Sdl.SetError`). Every method body is exactly
one of:
- A direct delegation to a native P/Invoke (`NativeSdlTtf.Internal*`), with no managed prelude.
- A straight `return result;` from such a delegation.
- `Marshal.PtrToStringAnsi(...)` on the result of a native call (Sdl.GetError).

A source scan confirms **zero managed control flow** (no if/for/foreach/while/switch, no `GetBytes`,
no `Encoding`, no array construction, no `Marshal` logic) in the entire file.

## Why it cannot be deterministically covered (per the engine's deterministic constraints)

- The string-marshaling path is `[MarshalAs(UnmanagedType.LPStr)]`/default string params passed
  directly to native. Empirically verified (libc strlen probe in this session): a null C# string is
  marshaled straight through without a managed `ArgumentNullException` at the call site and segfaults
  the test host. So the null-probe pattern used for the ImGui/ImPlot partials is invalid here.
- Non-string methods require the native SDL_ttf library at runtime AND valid font/render — on a CI
  image without the native lib they throw `DllNotFoundException` (non-deterministic), and with a null
  `IntPtr` font they would crash. No plain `[Fact]` can cover them deterministically without native
  dependencies.

Fabricating tests that "pass" by expecting a native-presence exception would be non-deterministic
across environments and would not represent real coverage. Per the engine rules, this file is recorded
as BLOCKED_BY_NATIVE with no test added.

## Verification

- Static analysis only (whole-file scan for managed control flow): none present.
- No build/test run needed — no tests were generated.