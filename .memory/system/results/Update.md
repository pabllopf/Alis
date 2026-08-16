# Result: Update.cs

File: `4_Operation/Ecs/src/Updating/Runners/Update.cs`
CoverageBefore: 93.6% (SonarCloud; Line: 95.3%, Branch: 78.6%, 12 uncovered lines)
CoverageAfter: 100.0% (668/668, local coverlet, Update-filtered Ecs run)
TestsAdded: 1 (UpdateArity9CoverageTests.cs: arity-9 non-range Run)
Commit: test: coverage Update.cs
Status: REMEDIATED

## Summary

Update.cs contains the UpdateLoop runner and the generic Update<TComp, ...> runner classes
(35 complexity / 394 LOC). The committed suite covered every runner except the 9-arity
non-range `Run(Scene, Archetype)` (Update<TComp, TArg1..TArg8>), which fetches eight component
references and dispatches the update loop.

## Tests added (UpdateArity9CoverageTests.cs)

`Update_Arity9_NonRangeRun_ProcessesEntities`: creates an entity with `Update9Comp`
(`IOnUpdate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>`)
plus the eight argument components (`Create<T1..T8>` caps at eight components, so the eighth
argument is added via `entity.Add`), then invokes the storage's non-range internal
`Run(scene, archetype)` and asserts the component update ran.

## Verification

- Update-filtered run: 265 passed / 0 failed (net8.0).
- Local coverlet: Update.cs 668/668 = 100.0% (before: 95.3% line; Update`9 was 30/58).
