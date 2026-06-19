# ImGui Window Testing Pattern

## Problem
Windows that directly call ImGui static methods cannot be unit-tested 
without an ImGui runtime context.

## Strategy
Test what IS testable, accept what is not:

### Testable:
- Constructor (assigns dependencies)
- Initialize() / Start() (often no-ops)
- Public properties (via reflection)
- Static members (WindowName, constants)
- Interface implementation (via reflection)
- Private field existence and types (via reflection)

### NOT Testable (without ImGui runtime):
- Render() method (calls ImGui.Begin, ImGui.Button, etc.)
- Any method that calls ImGui rendering functions

## When to Use Moq
Only when testing a method that:
- Calls an interface-based abstraction
- Has a mockable dependency
- Cannot be tested with real objects

For ImGui windows: DO NOT use Moq for ImGui (it's a static class).
Instead, use reflection-based tests.

## Applicable Files
- AssetsWindow.cs (382 lines, 0% coverage)
- AudioPlayerWindow.cs (35 lines, 0% coverage)
- Other ImGui-dependent windows in 1_Presentation/Engine/src/Windows/
