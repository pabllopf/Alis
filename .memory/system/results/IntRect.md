# Result: IntRect.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/IntRect.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: Not measured locally (cobertura generation disabled per pipeline rules); all 59 lines / 18 branches exercised via 27 new public-API tests + 51 pre-existing IntRect tests (78/78 pass). Struct is pure value-type geometry: constructors, Contains, Intersects (both overloads), ToString, Equals, GetHashCode, operators, explicit FloatRect cast.
TestsAdded: 27
Commit: a9201b384bd4884ec1728bd3334794b234510453
Status: COMPLETED

## Summary
Added IntRectTests.cs covering every public member of the IntRect struct: both constructors, Contains (inside/outside/boundaries/negative dimensions), Intersects both overloads (overlap, no-overlap, touching edges, negative dimensions, overlap output), ToString, Equals (typed/object/tolerance/null), GetHashCode, equality operators, and the explicit cast to FloatRect. Tests use plain [Fact] so they run without the native csfml-system library (IntRect needs no native interop). All 27 new tests plus the 51 pre-existing IntRect tests pass.

## Verification
- dotnet build 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -> PASS (0 warnings, 0 errors)
- dotnet test 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj --filter FullyQualifiedName~IntRect -c Debug -f net8.0 -> PASS (78 passed, 0 failed, 0 skipped)