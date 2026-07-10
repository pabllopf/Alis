## COVERAGE TASK

### File
`4_Operation/Ecs/src/Kernel/ComponentRegistry.cs`

### Coverage
81.0%

### Uncovered Lines
19

### Existing Tests
- ComponentRegistryTest.cs
- ComponentRegistryCoverageTest.cs
- ComponentRegistryExtendedTest.cs

### New Tests
- ComponentRegistryRemainingTest.cs (6 tests)

### Key Paths Covered
- GetComponentFactoryFromType with non-IComponentBase type (RegisterComponent error message)
- GetComponentFactoryFromType with IComponentBase type (source generator error message)
- GetComponentId for already existing type (stable ID)
- GetExistingOrSetupNewComponent for new type
- RegisterComponent idempotency
