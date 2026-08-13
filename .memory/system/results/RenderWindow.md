# RenderWindow.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/RenderWindow.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 63.35% (102/161 lines)
- **Tests Added**: 21 (RenderWindowExecutionTests.cs + SfmlTestBootstrap.cs + RenderWindowMainThreadWorker.cs — main-thread startup-hook pattern, no-op guarded for CI)
- **Uncovered Lines**: Draw (6, CSFML 3.0 sfRenderStates layout shift → SIGSEGV), SetIcon (ObjC NSException), InternalSetMousePosition (Vector2F vs sfVector2i → SIGBUS), WaitEvent (blocks), VideoMode ctors (2.x ABI vs 3.0 5-arg → broken GL context). Production ABI bugs vs installed CSFML 3.0.
- **Status**: COMPLETED
