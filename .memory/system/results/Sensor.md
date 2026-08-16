# Result: Sensor.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Sensor.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (5/5, local coverlet)
TestsAdded: 0 (already remediated in commit bced19e1a)
Commit: test: coverage Sensor.cs
Status: ALREADY_REMEDIATED

## Summary

Sensor.cs is the SFML sensor wrapper. Committed `SensorTest.cs` + `SensorTests.cs` +
`SensorEventArgsRemainingCoverageTests.cs` cover 5/5 lines = 100.0%.

## Verification

- `dotnet test Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~Sensor"`: 25 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `Sensor.cs` 5/5 = 100.0%.
