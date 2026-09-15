# Directory Coverage Verification — 1_Presentation/Extension/Graphic/Sdl2/src

Date: 2026-09-14
Verified by: fix-coverage-orchestrator (interactive session)

## Command executed

```bash
dotnet test 1_Presentation/Extension/Graphic/Sdl2/test/Alis.Extension.Graphic.Sdl2.Test.csproj \
  -c Debug -f net8.0 --collect:"XPlat Code Coverage" --results-directory .test/net8.0
```

Result: 735 passed, 0 failed, 0 skipped.

## Measured coverage (coverlet, local, SDL2 present)

- Instrumented src lines: **1137 / 1137 hit (100.0% line)**
- All 30 instrumented src classes at line-rate 1.0.
- Branch coverage 100% everywhere EXCEPT Sdl.cs static ctor:
  - 4 conditions at 50% (lines 444, 449, 454, 459): `GlAudioU16Sys/S16/S32/F32Sys = BitConverter.IsLittleEndian ? Lsb : Msb`.
  - Big-endian path unreachable on little-endian hardware (macOS x86_64/arm64). Existing test
    `SdlManagedCoverageTests.GlAudioSysFormats_MatchPlatform` exercises the little-endian side.

## Files without coverlet lines (no executable code)

- Delegates/ (13): pure `[UnmanagedFunctionPointer]` delegate declarations. Covered by DelegatesTest.
- Enums/ (55): pure enum declarations. Covered by EnumsTest.
- Mapping/KeyCodes.cs, Mapping/SdlScancode.cs: enums. KeyCodesTest asserts all 228 members.
- Mapping/SdlInputConst.cs: `const`-only static class (no cctor). SdlInputConstTest references all values.
- IWindow.cs: interface.
- Structs field-only types (AudioDeviceEvent, Controller*, DisplayEvent, Event, GenericEvent,
  GameControllerButtonBind, GameControllerType, HapticDirection, Hint, Internal*Kms*,
  Internal*GameControllerButtonBind*, Internal*SysWmDriver*, Joy*, KeySym, Mouse*, MultiGestureEvent,
  QuitEvent, SensorEvent, TouchFingerEvent): struct declarations without methods. Covered by event tests.
- NativeSdl.cs, Sdl2Image/NativeSdlImage.cs: `[ExcludeFromCodeCoverage]`.
- Sdl2Image/ImgInitFlags.cs: enum, covered by ImgInitFlagsTest.

## SonarCloud reconciliation

SonarCloud SDL2 project last analysis: 2026-09-12T18:40:43Z at revision 9ce484709
(main project 2026-09-14 at a421cb631). Both PREDATE the pushed coverage commits
(test: Sdl.cs = d9d7f98f0 and earlier), so SonarCloud numbers are STALE.

CI workflow `[ALIS][EXTENSION][GRAPHIC][SDL2][SONARCLOUD].yml` runs on macos-15-intel
and does NOT install SDL2. GitHub runner images do not ship sdl2/sdl2_image/sdl2_ttf
(actions/runner-images issue #192; no sdl* formula in macos-15 Readme). Therefore
`RequireSdl2*Fact` tests SKIP in the SonarCloud CI run, capping reported coverage for
Sdl.cs (native), Sdl2Image/SdlImage.cs, and Sdl2Ttf/SdlTtf.cs regardless of tests.

## Status

Local coverage of coverable code: **100% line, 100% branch except 4 unreachable big-endian conditions.**
SonarCloud reflection of 100% is blocked by:
1. Stale analysis (needs a `scan:`-triggered CI run).
2. CI runner lacks SDL2 native libs (`.github/workflows` shared resource — would need
   `brew install sdl2 sdl2_image sdl2_ttf`, not performed per shared-file protection).
3. 4 hardware-bound big-endian branches in Sdl.cs .cctor.
4. Enum/const declaration lines (Mapping) that coverlet cannot emit hits for.