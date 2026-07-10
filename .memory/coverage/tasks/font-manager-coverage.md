## COVERAGE TASK

### File
`4_Operation/Graphic/src/Ui/FontManager.cs`

### Coverage
0.0%

### Uncovered Lines
7

### Method
Various (static class)

### Existing Tests
- `FontManagerTest.cs` (10 reflection-based tests)
- `FontTest.cs` (11 reflection-based tests)
- `FontRemainingCoverageTests.cs` (6 functional tests)

### Source Code
```csharp
public static class FontManager
{
    public static Font DefaultFont { get; } = new Font("mono.bmp", 1, 1);

    public static void RenderText(string text, int x, int y, Color foreColor, Color backColor)
    {
        DefaultFont.RenderText(text, x, y, foreColor, backColor);
    }

    public static void RenderText(string text, int x, int y)
    {
        DefaultFont.RenderText(text, x, y, Color.White, Color.Transparent);
    }
}
```

### Task
- Add functional tests that execute FontManager.DefaultFont getter (currently only tested via reflection)
- Verify RenderText methods throw expected native exceptions when OpenGL is unavailable
- Maximize coverage on 7 uncovered lines

### Status
Completed - 6 NEW TESTS ADDED (all passing)

### Tests Added
- `DefaultFont_IsNotNull` — verifies DefaultFont returns non-null Font instance
- `DefaultFont_HasExpectedNameFile` — verifies NameFile is "mono.bmp"
- `DefaultFont_HasDepthOne` — verifies Depth is 1
- `RenderText_WithColors_ThrowsWhenOpenGLNotInitialized` — verifies InvalidOperationException
- `RenderText_WithCoordinates_ThrowsWhenOpenGLNotInitialized` — verifies InvalidOperationException  
- `DefaultFont_PropertyExists_AndIsReadOnly` — verifies property metadata

### File
`FontManagerCoverageTest.cs`
