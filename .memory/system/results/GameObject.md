# GameObject.cs — Coverage Remediation Result (FLAGGED)

Target: `4_Operation/Ecs/src/GameObject.cs` (SonarCloud key `pabllopf-official_alis:4_Operation/Ecs/src/GameObject.cs`)
Baseline: 37.4% (973 lines; 609 uncovered) → SonarCloud card reported 42.0% line / 35.1% branch (548 uncovered).
Status: **REMEDIATED-CONTINGENT on engine fix** — coverage achieved 99.9% (972/973; only genuinely-dead guard at line 188) in the canonical filtered/per-project run; full-suite runs flake nondeterministically due to a PRE-EXISTING ENGINE defect below. DO NOT re-touch via coverage tests until the engine issue is fixed.

## Deliverable
- `4_Operation/Ecs/test/GameObjectMultiArityCoverageTests.cs` (committed `0c0f2cf86`): 5 tests — boxed/by-id AddAs, count deferred structural changes on disallow-exit, dead-entity access, per-entity events+unsubscribe+generic InitalizeEventRecord, and direct calls of the public `GameObject.InvokePerEntityEvents<T1..Tn>(..., hasGenericEvent:false)` for arities 2..8 (covers the `if (!hasGenericEvent) return;` paths at lines 572-573, 706-707, 852-853, 1011-1012, 1182-1183, 1365-1366, 1562-1563).
- Multi-arity `Add<T1..Tn>`/`Remove<T1..Tn>` union tests (arities 1-8) were BUILT, VALIDATED (world events fire once per component → 36, per-entity events once per `Add` call due to arity-1 helper delegation → 8), and REMOVED in commit `0c0f2cf86` because they maximally perturb the engine's first-touch order (see blocker).

## ECS semantics discovered (documented for engine owner and future workers)
- World `ComponentAddedEvent` fires once PER COMPONENT; per-entity `OnComponentAdded` fires once PER `Add(...)` call (multi-arity Add blocks delegate to the arity-1 `InvokePerEntityEvents` with only `ref c1Ref`).
- `EventRecord` is a class; `GameObject.InitalizeEventRecord` calls `EventRecord.Initalize(exists, ...)` which REPLACES the stored record whenever the flag for that event type is unset — subscribing a second per-entity event type on the same entity silently drops earlier handlers.

## BLOCKER — Engine defect: order-sensitive global component/archetype registration
Symptom: full Ecs-suite runs (net8.0, any config) fail nondeterministically (~30-70% of runs) with
`System.InvalidOperationException : System.Void is not initalized. (Did you initalize T with Component.RegisterComponent<T>()?)`
thrown from `Archetype.CreateOrGetExistingArchetype` (Archetype.cs:562, `GetComponentFactoryFromType(types[i-1].Type)` with a `default(ComponentId)`) via `TraverseThroughCacheOrCreate` (GameObject.cs) and via `CommandBuffer.PlaybackInternal → Scene.ExitDisallowState`.
Failing tests observed: `Add/Remove_Arities*`, `Add/Remove_WhileDisallowed*`, `AddBoxed_And_AddAs*` (all GameObject.archetype-union paths).

Root-cause assessment (high confidence, from control experiments):
- `Component<T>.Id` is lazily assigned per-process in global first-touch order (`Component.GetExistingOrSetupNewComponent<T>()`); unions are registered once globally into `ExistingArchetypes`/`ArchetypeTable` (RawIndex-based `GameObjectType`).
- ANY new test file that adds first-touch registrations perturbs the per-run execution/discovery ORDER (xUnit randomizes collection order across runs; `parallelizeTestCollections:false` is honored) and flips the suite between healthy and poisoned regimes. The suite was riding on a knife's edge.

Control measurements (Ecs test assembly, net8.0):
| Config | Flake rate |
|---|---|
| Full suite, no `GameObjectMultiArityCoverageTests.cs` | 0/10 |
| Full suite + committed safe version (5 tests, HEAD) | 7/10 (Debug), 3/10 (Release) |
| Full suite + union-heavy version (9 tests) | 6/10 |
| Full suite + prewarm static ctor (union-heavy) | 6/10 |
| Full suite + shared long-lived static Scene | 6/10 |
| Full suite + minimal 1-test file (Position/Delete only) | 1/10 |
| Filter pair `ComponentRegistryFinalCoverageTest|GameObjectMultiArity` | 0/8 |
| CI-gate `alis_design.slnx -c Release -f net8.0` with committed safe version | 2/4 |

## Recommended engine fix (src-owned, OUT of coverage-worker scope)
- `GlobalWorldTables`/`Component.ResetForTests`/`NextArchetypeId`+`NextComponentId` global tables are ISE order-sensitive rebuilds: `Component.ResetForTests` (ComponentRegistryFinalCoverageTest) rebuilds the component table; combined with later first-touch unions, previously issued raw indexes can alias `default(ComponentId)` (RawIndex 0 = System.Void). Root candidate paths already inspected and individually sound: FastestStack.Push/Grow, ArchetypeNeighborCache (exact 4-way keyed), EventRecord, MemoryHelpers.Remove/Concat.
- Suggested directions: make `ComponentId`/`GameObjectType` resolution resilient to table rebuilds (versioned/sturdy handles), OR make registration order-independent, OR make `ResetForTests` fully re-establish prior raw-index bindings.
- Repro for the engine owner: add the union/while-disallowed test class above to the Ecs test project and run `dotnet test 4_Operation/Ecs/test/Alis.Core.Ecs.Test.csproj -c Debug -f net8.0` repeatedly (~10×) — expect 30-70% failure; delete the class → 0/10 in the same 10 runs.

## Verification notes
- Correct coverlet invocation for this project: `dotnet test ... --results-directory <dir> --collect:"XPlat Code Coverage"` (the project uses `coverlet.collector`; `-p:CollectCoverage=` is ignored). Output: `<dir>/<guid>/coverage.cobertura.xml`.
- Latest measured: 972/973 (99.9%) for GameObject.cs; only line 188 (dead `gameObject is null` throw in `AssertIsAlive`) uncovered — genuinely unreachable.
- `alis_design.sln` (xml content, non-standard) is NOT a valid solution header; the real CI file is `alis_design.slnx`.
