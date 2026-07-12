# Fix: AZ9WLQxvb3Yg5Wvlzs08

- Issue: AZ9WLQxvb3Yg5Wvlzs08
- Rule: S1144
- File: 6_Ideation/Math/src/Util/RandomUtils.cs
- Commit: 771c193d3421d3dcd8fcbc0178db679930d6aa27
- Date: 2026-07-12
- Status: APPLIED

## Transformation

Wrapped conditionally-used field in `#if !NET6_0_OR_GREATER`:
- `Rng` field was used only in `#else` branches of `#if NET6_0_OR_GREATER`
- SonarCloud flagged it as unused (on newer TFM analysis)
- Fix: conditional compilation of the declaration matches usage scope
- All TFMs build successfully

## Verification

Build: SUCCESS (0 warnings, 0 errors) across all 6 target frameworks.