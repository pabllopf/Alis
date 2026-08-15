# MacNativePlatform.cs

- **File**: `4_Operation/Graphic/src/Platforms/Osx/MacNativePlatform.cs`
- **Coverage Before**: 14.2% (SonarCloud); 43.7% local baseline (153/350)
- **Coverage After**: 51.7% (181/350 lines, 58.5% branches, local coverlet)
- **Tests Added**: 11 (MacNativePlatformFinalCoverageTests.cs — mouse state clone semantics, multi-key pressed state, synthesized NSEvent keyDown/keyUp handling via CGEvent keyboard events)
- **Skipped**: Initialize (both overloads), SetWindowIcon, Cleanup-with-pool, PollEvents event dispatch, mouse event handlers and UpdateMousePosition, GetWindowPositionX/Y and GetWindowMetrics non-null paths, GetMousePositionInView view paths, GetProcAddress dlopen-failure branch — all require a live AppKit window session/real NSEvents/GUI interaction (UpdateMousePosition reads the NSPoint return as a pointer and would fault), or an unfalsifiable native failure. Key event handlers were covered without NSApplication by dlopen-ing AppKit and synthesizing keyboard CGEvents (no windows, non-blocking, deterministic).
- **Status**: COMPLETED
