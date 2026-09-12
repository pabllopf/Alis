# Transform.cs

## File
1_Presentation/Extension/Graphic/Sfml/src/Render/Transform.cs

## Coverage (SonarCloud, master)
- Line: 0.0%, Branch: 0.0%, Uncovered Lines: 76, Uncovered Branches: 2

## Local verification
- Build: `dotnet build Alis.Extension.Graphic.Sfml.Test.csproj -c Debug` → OK
- Coverlet (XPlat, .config/coverlet.runsettings): Transform class
  `line-rate = 1.0`, `branch-rate = 1.0` (100% / 100%)
- Existing tests: `TransformTest.cs` + `TransformRemainingCoverageTests.cs`
  (40 facts) cover ctors, Identity, Combine, Translate/Rotate/Scale (all
  overloads), TransformPoint/Rect, GetInverse, Equals/GetHashCode/ToString and
  the multiply operators.

## Analysis
Existing tests already exercise 100% of lines and branches locally. SonarCloud
reports 0% on master because the CI environment cannot exercise this surface.
No untested managed behavior remains.

## Outcome
No new tests required. State + summary updated.
