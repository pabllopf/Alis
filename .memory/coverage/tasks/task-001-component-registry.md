## COVERAGE TASK

### File
4_Operation/Ecs/src/Kernel/ComponentRegistry.cs

### Coverage
75.2%

### Uncovered Lines
25 (estimated)

### Uncovered Conditions
9

### Method
Multiple: GetComponentFactoryFromType, Throw_ComponentTypeNotInit, ResetForTests, RegisterComponent, GetExistingOrSetupNewComponent

### Existing Tests
- Kernel/ComponentRegistryTest.cs (10 tests)
- Kernel/ComponentRegistryExtendedTest.cs (6 tests)
- ComponentRegistrationTest.cs (6 tests)

### Target Coverage Paths
1. Throw_ComponentTypeNotInit with IComponentBase type (IOnInit interface)
2. ResetForTests internal method
3. GetComponentFactoryFromType with source-generated type
4. GetComponentFactoryFromType with type in UserGeneratedTypeMap
5. TypeIniters/TypeDestroyers delegate paths in GetExistingOrSetupNewComponent

### Status
completed

### Commit
7fc90e128

### Estimated Coverage Improvement
~5 uncovered lines covered, ~3 uncovered conditions covered

### Tests Added
- GetComponentFactoryFromType_SourceGeneratedType_ReturnsFactory
- GetComponentFactoryFromType_IComponentBaseInterface_ThrowsWithSourceGenMessage
- RegisterComponent_SourceGeneratedType_SkipsRegistration
- GetExistingOrSetupNewComponent_SourceGeneratedType_HasInitDelegate
- GetComponentId_WithInitAndDestroyDelegates_PopulatesTable
