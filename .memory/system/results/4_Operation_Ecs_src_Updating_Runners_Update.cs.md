# Update.cs Coverage Remediation Result

## File
4_Operation/Ecs/src/Updating/Runners/Update.cs

## Work
- Added Update_Arity8_Run_MutatesAllExpectedComponents to UpdateAllClassesTest.cs (completes the
  arity matrix; the arity-8 full Run(Scene, Archetype) was already exercised by another test, so
  this is behavioral completeness rather than new line coverage).
- Investigated the arity-8 range Run(Scene, Archetype, start, length) (lines 707-723, the only
  remaining uncovered lines): it is invoked only for deferred entities in an 8-argument archetype.
  A 9-component entity (Update8Component + 8 args) cannot be created as a single deferred creation
  because Scene.Create maxes at 8 components and buffered Add operations are played back AFTER the
  deferred update subset runs (Scene.ExitDisallowState -> ResolveUpdateDeferredCreationEntities
  before WorldUpdateCommandBuffer.Playback). A Create+Add deferred entity lands in an intermediate
  archetype missing an argument and the runner throws ComponentNotFoundException. Therefore the
  arity-8 range Run is not reachable with the current public API.
  Status: BLOCKED_BY_PRODUCTION_API.

## Status
COMPLETED (behavioral) / BLOCKED (arity-8 range Run)
