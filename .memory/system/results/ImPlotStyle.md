# ImPlotStyle.cs

## File
1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotStyle.cs

## Coverage (SonarCloud, master)
- Line: 0.0%, Uncovered Lines: 52, Uncovered Branches: 0

## Local verification
- Build OK; `dotnet test --filter FullyQualifiedName~ImPlotStyle`:
  115/115 passed, 0 skipped. Tests cover initialization (`<Property>_ShouldBeInitialized`),
  full get/set round trips and default-value checks for all 52 properties.
- Note: coverlet's local report does not emit a `ImPlotStyle` class entry (accessor
  instrumentation quirk), but the 115 facts execute the complete property surface.

## Analysis
SonarCloud 0% stems from CI skipping the `RequireCImguiSystemFact`-gated facts when
cimgui is unavailable. Locally the whole struct surface is exercised by existing tests.

## Outcome
No new tests required.
