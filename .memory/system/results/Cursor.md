# Cursor.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Cursor.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 38.9% (7/18)
- **Tests Added**: 2 (CursorExecutionTests.cs — CursorType ctors)
- **Uncovered Lines**: 190-202 — Cursor(byte[],Vector2F,Vector2F) body: wrapper passes Vector2F (float HFA regs) vs CSFML 3.0 sfCursor_createFromPixels(sfVector2u,...) (integer regs) → SIGBUS. Production ABI change required.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
