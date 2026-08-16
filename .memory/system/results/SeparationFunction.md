# Result: SeparationFunction.cs

File: `4_Operation/Physic/src/Collisions/SeparationFunction.cs`
CoverageBefore: 95.7% (SonarCloud; Line: 96.7%, Branch: 87.5%, 4 uncovered lines)
CoverageAfter: 96.7% (238/246, local coverlet, SeparationFunction-filtered run; unchanged)
TestsAdded: 0 (existing suite covers every reachable line)
Commit: test: coverage SeparationFunction.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

SeparationFunction.cs is the TOI separation function evaluator (13 complexity / 161 LOC). The
committed suite covers Set/FindMinSeparation/Evaluate for all three SeparationFunctionType
variants (Points, FaceA, FaceB).

## Remaining uncovered lines (4) — BLOCKED_BY_PRODUCTION_CODE

- 272-274, 328 — the `default:` cases of the `_type` switches in FindMinSeparation and
  Evaluate. `_type` is a private `[ThreadStatic]` field assigned only the three enum values
  (Points/FaceA/FaceB); the default cases are defensive and unreachable without an invalid
  enum value, which cannot be injected without reflection (forbidden by AOT rules).

## Verification

- SeparationFunction-filtered run: 20 passed / 0 failed (net8.0).
- Local coverlet: SeparationFunction.cs 238/246 = 96.7% (matches SonarCloud line metric).
