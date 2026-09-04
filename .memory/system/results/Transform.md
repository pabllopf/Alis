# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Render/Transform.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 100.0% (152/152 lines, existing committed suite; verified via XPlat Code Coverage, 105 tests pass)
TestsAdded: 0
Commit: (none)
Status: ALREADY_COVERED_LOCALLY
Details:
- Transform.cs is the SFML 3x3 matrix struct (9 float elements, LayoutKind.Sequential): 9-arg ctor, GetInverse, TransformPoint (xy + Vector2F), TransformRect, Combine, Translate (xy + Vector2F), Rotate (angle; angle+center), Scale (factors; factors+center; factor pairs), Equals(object/Transform via sfTransform_equal), GetHashCode, operator*, operator* (point), Identity, ToString, internal m00..m22 fields.
- Existing committed suite (TransformTest.cs + TransformRemainingCoverageTests.cs, 105 tests) covers 152/152 executable lines locally against libcsfml-graphics.dylib (native matrix ops are exact-C-ABI here: sfTransform struct is 9 floats, signatures unchanged in CSFML 3.0, so everything executes).
- Note: naive cobertura parse also finds 2_Application/Alis/src/Core/Ecs/Components/Transform.cs (0%) and Physics ControllerTransform.cs (0%) — different files; only the Sfml Render Transform.cs is this task and it is fully covered. SonarCloud 0% is the CI no-native-lib artifact.