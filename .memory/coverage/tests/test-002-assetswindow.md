# Test Record #2 — AssetsWindow.cs

## Source File

- **Path**: `1_Presentation/Engine/src/Windows/AssetsWindow.cs`
- **Class**: `AssetsWindow`
- **Namespace**: `Alis.App.Engine.Windows`

## Test File

- **Path**: `1_Presentation/Engine/test/AssetsWindowTest.cs`
- **Class**: `AssetsWindowTest`

## Test Cases

### 1. WindowName_Field_ShouldNotBeNull

**Purpose**: Validate public static `WindowName` field exists and is not empty.

**Arrange**: None (static field)

**Act**: Access `AssetsWindow.WindowName`

**Assert**:
- Field is not null
- Field is not empty

---

### 2. Constructor_ShouldSetSpaceWork

**Purpose**: Validate constructor injection works correctly.

**Arrange**:
- Create uninitialized `SpaceWork` instance using `RuntimeHelpers.GetUninitializedObject`

**Act**:
- Create `AssetsWindow window = new AssetsWindow(spaceWork)`

**Assert**:
- `window` is not null
- `window.SpaceWork` references the same instance as constructor parameter

---

### 3. Constructor_ShouldAllocateCommandPtr

**Purpose**: Validate constructor allocates native memory successfully.

**Arrange**:
- Create uninitialized `SpaceWork` instance

**Act**:
- Create `AssetsWindow window = new AssetsWindow(spaceWork)`

**Assert**:
- `window` is not null (successful instantiation implies successful allocation)

---

### 4. SpaceWork_Property_ShouldReturnSetValue

**Purpose**: Validate property getter returns the set value.

**Arrange**:
- Create uninitialized `SpaceWork` instance
- Instantiate `AssetsWindow` with `SpaceWork`

**Act**:
- Access `window.SpaceWork` property

**Assert**:
- Property is not null
- Property returns the same instance as constructor parameter

---

### 5. IsDefaultSize_Property_ShouldDefaultToTrue

**Purpose**: Validate `IsDefaultSize` property defaults to true.

**Arrange**:
- Create uninitialized `SpaceWork` instance
- Instantiate `AssetsWindow` with `SpaceWork`

**Act**:
- Access `window.IsDefaultSize` property

**Assert**:
- Property value is true (default)

---

### 6. IsDefaultSize_Property_ShouldAllowSetValueToFalse

**Purpose**: Validate `IsDefaultSize` property can be set to false.

**Arrange**:
- Create uninitialized `SpaceWork` instance
- Instantiate `AssetsWindow` with `SpaceWork`

**Act**:
- Set `window.IsDefaultSize = false`

**Assert**:
- Property value is false after assignment

---

### 7. IsDefaultSize_Property_ShouldAllowSetValueToTrue

**Purpose**: Validate `IsDefaultSize` property can be set to true.

**Arrange**:
- Create uninitialized `SpaceWork` instance
- Instantiate `AssetsWindow` with `SpaceWork`

**Act**:
- Set `window.IsDefaultSize = true`

**Assert**:
- Property value is true after assignment

---

### 8. Initialize_ShouldNotThrow

**Purpose**: Validate `Initialize()` method does not throw exceptions.

**Arrange**:
- Create uninitialized `SpaceWork` instance
- Instantiate `AssetsWindow` with `SpaceWork`

**Act**:
- Call `window.Initialize()`

**Assert**:
- No exception thrown
- `window` instance remains valid

---

### 9. Start_ShouldNotThrow

**Purpose**: Validate `Start()` method does not throw exceptions.

**Arrange**:
- Create uninitialized `SpaceWork` instance
- Instantiate `AssetsWindow` with `SpaceWork`

**Act**:
- Call `window.Start()`

**Assert**:
- No exception thrown
- `window` instance remains valid

---

### 10. Render_ShouldNotThrow

**Purpose**: Validate `Render()` method does not throw exceptions.

**Arrange**:
- Create uninitialized `SpaceWork` instance
- Instantiate `AssetsWindow` with `SpaceWork`

**Act**:
- Call `window.Render()`

**Assert**:
- No exception thrown
- `window` instance remains valid

---

## Notes

- All tests use `RuntimeHelpers.GetUninitializedObject` to avoid complex `SpaceWork` initialization
- Tests follow the same pattern as existing `TopMenuMacTest.cs` and `BottomMenuTest.cs`
- Private methods (`RenderXXX` methods) are not tested as they are implementation details
- Tests are designed to avoid flakiness and external dependencies
- `WindowName` is a public static readonly field containing UI display text

## Commit Information

- **Commit Hash**: 49be1b849
- **Commit Message**: `test: coverage AssetsWindow.cs`
- **Date**: 2026-06-22
