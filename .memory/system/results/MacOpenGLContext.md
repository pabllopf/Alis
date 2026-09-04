# Coverage Worker Result
File: 4_Operation/Graphic/src/Platforms/Osx/Native/MacOpenGLContext.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 0.0% (0/33 lines executable in this environment; transitive via MacWindow)
TestsAdded: 0
Commit: (none)
Status: BLOCKED_BY_NATIVE
Details:
- MacOpenGLContext.cs creates an NSOpenGLPixelFormat (with a zero-terminated attribute array, GCHandle-pinned) and an NSOpenGLView for the window's frame, attaches it via setContentView, grabs openGLContext and exposes MakeCurrent/SwapBuffers.
- The single ctor MacOpenGLContext(MacWindow) requires a valid live MacWindow and calls window.GetFrame(); both MacWindow construction (sfSprite-like native garbage arg crash class) and GetFrame (objc_msgSend struct return as IntPtr -> AccessViolation) are confirmed host blockers off the AppKit main thread. The repo's only runnable path is the StartupHook bootstrap (MacWindowExecutionTests/MacOpenGlContextBootstrap), which requires DOTNET_STARTUP_HOOKS in an arch-matching (x64/Rosetta) shell that is unavailable here (see MacWindow.md).
- No probe added: the direct-construction attempts on the sibling MacWindow already crashed the test host; this type is additionally blocked by GetFrame and AppKit view creation on the worker thread. Requires production-side or main-thread-hook fix.