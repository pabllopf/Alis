## COVERAGE TASK

### File

4_Operation/Physic/src/Dynamics/Contacts/ContactListHead.cs

### Coverage

79.2% (5 uncovered lines, 0 uncovered conditions)

### Uncovered Lines

59, 80, 97-99

### Method

- `IEnumerable.GetEnumerator()` (explicit interface implementation)
- `IEnumerator.Current` (explicit interface implementation)
- `ContactEnumerator.Reset()`

### Existing Tests

ContactListHeadTest.cs — 14 tests covering constructor, IsAssignableFrom, foreach iteration, circular linked list, LINQ support, multiple instances, null fixtures, multiple enumeration.

### Gap

No test calls the non-generic `IEnumerable.GetEnumerator()` or non-generic `IEnumerator.Current` or `Reset()`.

### Approach

Add 3 tests:
1. Cast to `System.Collections.IEnumerable`, call `GetEnumerator()`, assert non-null
2. Access non-generic `IEnumerator.Current`, assert non-null and assignable to Contact
3. Call `Reset()`, assert Current equals head

### Commit

`4174a971d` test: coverage ContactListHead.cs
