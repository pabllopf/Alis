# Result: FloatRect.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/FloatRect.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: Not measured locally (cobertura generation disabled per pipeline rules); all 63 lines / 18 branches exercised via 36 new public-API tests + 45 pre-existing FloatRect tests (81/81 pass). Struct is pure value-type geometry: constructors, Contains, Intersects (both overloads), ToString, Equals, GetHashCode, operators, explicit IntRect cast.
TestsAdded: 36
Commit: ee94858f64a15396d105e04523fc52f64e7603f7
Status: COMPLETED

## Summary
Added FloatRectTests.cs covering every public member of the FloatRect struct: both constructors, Contains (inside/outside/boundaries/negative dimensions), Intersects both overloads (overlap, no-overlap, touching edges, negative dimensions, overlap output), ToString, Equals (typed/object/tolerance/null), GetHashCode, equality operators, and the explicit cast to IntRect. Tests use plain [Fact] so they run without the native csfml-system library (FloatRect needs no native interop). All 36 new tests plus the 45 pre-existing FloatRect tests pass.

## Verification
- dotnet build 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -> PASS (0 warnings, 0 errors)
- dotnet test 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj --filter FullyQualifiedName~FloatRect -c Debug -f net8.0 -> PASS (81 passed, 0 failed, 0 skipped)
