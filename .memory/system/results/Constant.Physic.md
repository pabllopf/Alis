# Coverage Worker Result
File: 4_Operation/Physic/src/Common/Constant.cs
CoverageBefore: 0.0% (SonarCloud CI, 2 line-hits)
CoverageAfter: N/A — no executable lines exist (by-construction)
TestsAdded: 0
Commit: (none)
Status: BLOCKED_BY_PRODUCTION_CODE (by-construction)
Details:
- Constant.cs declares only `public const float Pi` and `public const float Tau`.
- const literals emit no IL; the 2 SonarCloud line-hits are sequence points with nothing to execute. Not fixable by tests (same conclusion as Math/Util/Constant.cs).