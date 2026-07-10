## COVERAGE TASK

### File
4_Operation/Ecs/src/Kernel/ComponentRegistry.cs

### Coverage
81.0%

### Uncovered Lines
19

### Methods Targeted
- GetExistingOrSetupNewComponent<T> for types without lifecycle (Armor)
- GetComponentId after RegisterComponent<T> (NoneComponentRunnerTable path)
- GetExistingOrSetupNewComponent<T> cached delegates for existing types
- GetComponentFactoryFromType for non-existent plain type (Throw path)

### Existing Tests
- ComponentRegistryTest.cs
- ComponentRegistryExtendedTest.cs
- ComponentRegistryCoverageTest.cs
- ComponentRegistryResetTest.cs
- ComponentRegistryRemainingTest.cs

### Changes
1. Fixed GetComponentFactoryFromType_IComponentBaseType_ThrowsWithGeneratorMessage to use typeof(IOnInit) instead of typeof(Position)
2. Added GetExistingOrSetupNewComponent_PlainStructWithoutLifecycle_ReturnsNullDelegates
3. Added GetComponentId_AfterRegisterComponent_ReturnsValidId
4. Added GetExistingOrSetupNewComponent_ExistingType_ReturnsCachedDelegates
5. Added GetComponentId_NonExistentPlainType_ThrowsWithRegisterMessage

### Status
COMPLETED
