# Tests for ComponentID.cs

## File
`4_Operation/Ecs/test/Kernel/ComponentIdExtendedTest.cs`

## Tests (unskipped + new)
| Test | Description | Status |
|------|-------------|--------|
| `ComponentId_CanBeCreated` | Constructor with index 0 | Passing |
| `ComponentId_RawIndexIsPreserved` | RawIndex stored correctly | Passing |
| `ComponentId_WithZeroIndex` | Zero index preserved | Passing |
| `ComponentId_WithMaxIndex` | Max ushort index | Passing |
| `ComponentId_EqualsWithSameIndex` | Equality for same index | Passing |
| `ComponentId_NotEqualsWithDifferentIndex` | Inequality for different indices | Passing |
| `ComponentId_HashCodeEqualsWithSameIndex` | Hash code consistency | Passing |
| `ComponentId_EqualityOperator` | `==` operator | Passing |
| `ComponentId_InequalityOperator` | `!=` operator | Passing |
| `ComponentId_EqualsObjectMethod` | `Equals(object)` including null/string | Passing |
| `ComponentId_ExplicitITypeId_ReturnsRawIndex` | Explicit interface `ITypeId.Value` | Passing |

## Pattern
Direct struct construction via internal constructor + InternalsVisibleTo.
