# FastestStack.cs

## File
`4_Operation/Ecs/src/Collections/FastestStack.cs`

## Coverage Before
- SonarCloud: 96.7% line / 94.4% branch (7 uncovered lines, 5 uncovered branches)
- Local coverlet (net8.0, filtered suite): FastestStack line 0.9864 (6 lines uncovered: 465-467); Enumerator line 0.9216 (8 lines uncovered: 576-577, 646-647)

## Coverage After (local coverlet, filtered 118-test suite)
- FastestStack: line 0.9863, branch 0.9864 (only lines 465-467 uncovered)
- Enumerator: line 0.9215, branch 0.875 (only lines 576-577, 646-647 + the 2 guard conditions)

## Tests Added
`test/Collections/FastestStackVersioningCoverageTest.cs` — 4 tests:
1. `Contains_OnEmptyStack_ReturnsFalse` — covers the `_size != 0` short-circuit in `Contains` (line 160 went 50%→100%).
2. `GetEnumerator_EmptyStack_ReturnsEmptyEnumerator` — covers the `Count == 0` branch of `IEnumerable<T>.GetEnumerator` (line 253 went 50%→100%).
3. `GetEnumerator_DisposedStack_ReturnsEmptyEnumerator` — same branch after `Dispose`.
4. `Enumerator_EmptyStack_MoveNextReturnsFalse` — empty-enumerator cycling through `MoveNext`.

## Attempted but reverted (unreachable behavior confirmed)
Three tests asserted the enumerator version-mismatch throws (`MoveNext`/`Reset` after `Push`/`Pop`/`Clear`). All three **passed without throwing**: `FastestStack<T>` is a struct and `GetEnumerator()` copies the stack, so `_version` and `_fastestStack._version` inside the `Enumerator` are always equal. Removed; documented as dead code.

## Remaining uncovered (dead defensive guards, unreachable)
- **Lines 465-467 / condition 464** (`Grow`): `if ((uint) newcapacity > MaxArrayLength)` guard. Reaching it requires an internal array of >2.1 billion elements (~8.6 GB for `int`), beyond feasible allocation and never produced by doubling from any sane capacity. Defensive upper-bound guard; unreachable in tests.
- **Lines 576-577 / condition 575 and 646-647 / condition 645** (Enumerator `MoveNext`/`Reset`): `InvalidOperationException` version-mutation guards. Since the enumerator holds a struct copy of the stack, the version can never differ from the copy it captured. Dead by construction.

## Status
COMPLETED (all reachable lines and branches covered; remaining 6 lines are structurally/memory-bound unreachable defensive guards)