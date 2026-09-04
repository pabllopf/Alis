# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sdl2/src/Mapping/SdlInputConst.cs
CoverageBefore: 0.0% (SonarCloud CI, 1 line-hit)
CoverageAfter: N/A — no executable lines exist (by-construction)
TestsAdded: 0
Commit: (none)
Status: BLOCKED_BY_PRODUCTION_CODE (by-construction)
Details:
- SdlInputConst.cs is a `public static class` of `public const` int/uint/byte key/button/hat/touch constants (KScancodeMask, ButtonLeft/Middle/Right, TouchMouseId, HatCentered, ...).
- const literals emit no IL; the single SonarCloud line-hit is a sequence point with nothing to execute. Not coverable by tests.