# Test Record #1 — BottomMenu.cs

## Source File

- **Path**: `1_Presentation/Engine/src/Menus/BottomMenu.cs`
- **Class**: `BottomMenu`
- **Namespace**: `Alis.App.Engine.Menus`

## Test File

- **Path**: `1_Presentation/Engine/test/BottonMenuTest.cs`
- **Class**: `BottomMenuTest`

## Test Cases

### 1. Constructor_ShouldSetSpaceWork

**Purpose**: Validate constructor injection works correctly.

**Arrange**:
- Create uninitialized `SpaceWork` instance using `RuntimeHelpers.GetUninitializedObject`
- Instantiate `BottomMenu` with `SpaceWork`

**Act**:
- Create `BottomMenu menu = new BottomMenu(spaceWork)`

**Assert**:
- `menu` is not null
- `menu.SpaceWork` references the same instance as constructor parameter

---

### 2. SpaceWork_Property_ShouldReturnSetValue

**Purpose**: Validate property getter returns the set value.

**Arrange**:
- Create uninitialized `SpaceWork` instance
- Instantiate `BottomMenu` with `SpaceWork`

**Act**:
- Access `menu.SpaceWork` property

**Assert**:
- Property is not null
- Property returns the same instance as constructor parameter

---

### 3. Initialize_ShouldNotThrow

**Purpose**: Validate `Initialize()` method does not throw exceptions.

**Arrange**:
- Create uninitialized `SpaceWork` instance
- Instantiate `BottomMenu` with `SpaceWork`

**Act**:
- Call `menu.Initialize()`

**Assert**:
- No exception thrown
- `menu` instance remains valid

---

### 4. Start_ShouldNotThrow

**Purpose**: Validate `Start()` method does not throw exceptions.

**Arrange**:
- Create uninitialized `SpaceWork` instance
- Instantiate `BottomMenu` with `SpaceWork`

**Act**:
- Call `menu.Start()`

**Assert**:
- No exception thrown
- `menu` instance remains valid

---

### 5. Update_ShouldNotThrow

**Purpose**: Validate `Update()` method does not throw exceptions.

**Arrange**:
- Create uninitialized `SpaceWork` instance
- Instantiate `BottomMenu` with `SpaceWork`

**Act**:
- Call `menu.Update()`

**Assert**:
- No exception thrown
- `menu` instance remains valid

---

### 6. Render_ShouldNotThrow

**Purpose**: Validate `Render()` method does not throw exceptions.

**Arrange**:
- Create uninitialized `SpaceWork` instance
- Instantiate `BottomMenu` with `SpaceWork`

**Act**:
- Call `menu.Render()`

**Assert**:
- No exception thrown
- `menu` instance remains valid

---

## Notes

- All tests use `RuntimeHelpers.GetUninitializedObject` to avoid complex `SpaceWork` initialization
- Tests follow the same pattern as existing `TopMenuMacTest.cs`
- Private methods (`ApplyBottomMenuStyling`, `RenderMenuContent`, `RenderBranchSelector`, `SetupNextWindowProperties`) are not tested as they are implementation details
- Tests are designed to avoid flakiness and external dependencies

## Commit Information

- **Commit Hash**: 7a6febaad
- **Commit Message**: `test: coverage BottomMenu.cs`
- **Date**: 2026-06-22
