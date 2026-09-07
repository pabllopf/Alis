# Result: Update.cs

File: `4_Operation/Ecs/src/Updating/Runners/Update.cs`
CoverageBefore: 83.1% (424/510, local coverlet, Runners-filtered Ecs run)
CoverageAfter: 94.5% (482/510, local coverlet, Runners-filtered Ecs run)
TestsAdded: 3 (UpdateArity9CoverageTests.cs: arity-9 non-range Run via scene.Update)
Commit: test: Update.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

Update.cs defines `UpdateLoop.Run<...>` overloads (arities 0..8) and the generic
`Update<TComp, TArg1..TArg8>` runner classes. Prior to this pass the arity-8
`UpdateLoop.Run` loop body (lines 360-376) and the whole `Update<...9 generics>`
runner (lines 680-723, 3.4% covered) were uncovered.

## Tests added (UpdateArity9CoverageTests.cs)

Three tests build a 9-component entity (`Update8Component` + Position, Velocity,
Health, Armor, Damage, Transform, TestComponent, AnotherComponent). The main
component plus seven args are created via `Scene.Create<T1..T8>`; the eighth
argument (`AnotherComponent`) is attached via `GameObject.Add`, which moves the
entity into the 9-component archetype. Then `scene.Update()` drives the
non-range `Update<TComp, TArg1..TArg8>.Run(Scene, Archetype)` which delegates to
`UpdateLoop.Run<TComp, TArg1..TArg8>`, covering the previously-uncovered
do-while loop body.

- `Update_Arity9_SceneUpdate_ProcessesAllEntities`: two 9-component entities, asserts per-entity counts and mutations.
- `Update_Arity9_SceneUpdate_MutatesAllArgs`: verifies all eight argument components mutate by reference.
- `Update_Arity9_TwoFrames_AccumulatesChanges`: two update frames confirm loop iteration is correct.

## Blocked lines (707-723)

The range-based `Update<TComp, TArg1..TArg8>.Run(Scene, Archetype, int, int)`
(lines 707-723) is unreachable from the public API:

- `Archetype.Update(scene, start, length)` is only invoked from
  `Scene.ResolveUpdateDeferredCreationEntities` (Scene.cs:673), processing
  `DeferredCreationArchetypes`.
- `Scene.Create<T1..T8>` (Scene.cs:1477) is the highest-arity generic creation
  API (8 component types). The only way to reach 9 component types is a
  `GameObject.Add<T>` call, which during disallow state is buffered into
  `WorldUpdateCommandBuffer` (GameObject.cs:315-319) and replayed only after
  `UpdateSubset`/deferred resolution (Scene.cs:632).
- Therefore no 9-component archetype can ever appear in
  `DeferredCreationArchetypes`, so the arity-9 range-based Run can never be
  dispatched. `CreateFromObjects` (Scene.cs:695) creates entities immediately
  via `CreateEntityLocation` (it does not defer), so it cannot seed the
  deferred-creation path either.

## Verification

- Runners-filtered run: 112 passed / 0 failed (net8.0).
- Local coverlet: `UpdateLoop` 100.0% (216/216); `Update`9 51.7% (30/58);
  all other Update.cs classes already 100%. Whole file 94.5% (was 83.1%).