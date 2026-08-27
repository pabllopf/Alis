# Result: Color.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Color.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: Not measured locally (cobertura generation disabled per pipeline rules); all 48 lines / 8 branches exercised via 31 new public-API tests + 18 pre-existing ColorTest tests (102/102 pass with Color filter). Struct is a pure value type: constructors, ToInteger, ToString, Equals, GetHashCode, operators, static colors.
TestsAdded: 31
Commit: d72fcc99f06f6379fd04c50030335cee71f2255f
Status: COMPLETED

## Summary
Added ColorTests.cs covering every public member of the Color struct: all four constructors (4-component, 3-component with alpha 255, uint RGBA decode, copy), default value, ToInteger packing and round-trip, ToString format, Equals (typed/object/non-color/null), GetHashCode stability, equality/inequality operators, addition/subtraction clamp and non-clamp branches, multiplication scaling/zero/rounding branches, and all nine static colors. Tests use plain [Fact] so they run without the native csfml-system library (Color needs no native interop). All 31 new tests plus the 18 pre-existing ColorTest tests pass.

## Verification
- dotnet build 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -> PASS (0 warnings, 0 errors)
- dotnet test 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj --filter FullyQualifiedName~Color -c Debug -f net8.0 -> PASS (102 passed, 0 failed, 0 skipped)
