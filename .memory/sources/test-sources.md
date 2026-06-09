# Test Sources

Unit and integration tests across all layers.

## Test Organization

| Layer | Test Location | Files |
|-------|---------------|-------|
| **1_Presentation** | `1_Presentation/*/test/` | 50+ |
| **4_Operation** | `4_Operation/*/test/` | 100+ |
| **6_Ideation** | `6_Ideation/*/test/` | 50+ |

## ECS Test Files

| Test File | Purpose |
|-----------|---------|
| `GameObjectRefTupleTest.cs` | Entity reference tuple tests |
| `GameObjectLocationParametrizedTest.cs` | Location-based entity tests with parameters |
| `QueryEnumerableTest.2.cs` | Query enumeration variant 2 |
| `QueryEnumerableTest.6.cs` | Query enumeration variant 6 |
| `GameObjectRemoveTest.cs` | Entity removal and cleanup tests |
| `GameObjectPerEntityEventsTest.cs` | Per-entity event handling tests |

## Memory Test Files

| Test File | Purpose |
|-----------|---------|
| `AssetRegistryTest.cs` | Asset registry functionality |
| `ZipCacheEntryTest.cs` | Compressed cache entry tests |
| `ZipEntryInfoTest.cs` | Zip entry metadata tests |
| `DefaultTest.cs` | Default resource handling tests |

## Test Framework

- **xUnit** - Primary testing framework
- **Xunit.StaFact** - Single-threaded UI tests
- **Moq** - Mocking for dependency injection

## Generated Test Files

| Generated File | Source Generator |
|----------------|------------------|
| `AlisComponentRegistry.g.cs` | ComponentUpdateTypeRegistryGenerator |
| `GenerationServicesInitDestroyProbe.g.cs` | ECS Generator |
| `AssemblyLoader.g.cs` | ResourceAccessorGenerator |

## Test Output Structure

```
.test/<TargetFramework>/
  - Test assemblies
  - Test reports (cobertura, lcov, json)
  - Coverage data
```

## See Also
- [[Testing Strategy]]
- [[Build System Configuration]]
