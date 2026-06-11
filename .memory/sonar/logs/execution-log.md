# Execution Log

## Session Start

- **Timestamp**: 2026-06-11

### AZ6zQlWZ6-8DAyAuaboj — csharpsquid:S3776 (CRITICAL)
- **File**: Engine.cs:242
- **Issue**: Cognitive Complexity 18 → 15 allowed
- **Fix**: Extracted `CalculateDeltaTime`, `ProcessPendingInput`, `CheckGlError` helper methods
- **Commit**: bcec4dcba

### AZ6zQlUF6-8DAyAuabof — csharpsquid:S1186 (CRITICAL)
- **File**: TopMenuAction.cs:226
- **Issue**: Empty method — must throw `NotSupportedException` or have explanatory comment
- **Fix**: Changed `NotImplementedException` → `NotSupportedException`, fixed indentation
- **Commit**: 907e5aae2

### AZ6zQlOe6-8DAyAuabod — csharpsquid:S3776 (CRITICAL)
- **File**: HubEngine.cs:364
- **Issue**: Cognitive Complexity 18 → 15 allowed
- **Fix**: Extracted `CalculateDeltaTime`, `ProcessPendingInput`, `CheckGlError` helper methods
- **Commit**: 7c8d6c7aa

### AZ6zQlXO6-8DAyAuabok — csharpsquid:S3776 (CRITICAL)
- **File**: Installer.cs:361
- **Issue**: Cognitive Complexity 18 → 15 allowed
- **Fix**: Extracted `CalculateDeltaTime`, `ProcessPendingInput`, `CheckGlError` helper methods
- **Commit**: e2114293b
- **Timestamp**: 2026-06-11

### AZ6zQlWZ6-8DAyAuaboi — csharpsquid:S2933 (MAJOR)
- **File**: Engine.cs:185
- **Issue**: Field 'platform' is never assigned and always has default value null
- **Fix**: Removed readonly modifier, added GetPlatform() method, assigned platform in Run()
- **Commit**: 571f17590
- **Timestamp**: 2026-06-11

### AZ6zQlV-6-8DAyAuabog — csharpsquid:S2325 (MINOR)
- **File**: DockSpaceMenu.cs:134
- **Issue**: Method should not be static when it only accesses instance members
- **Fix**: Removed static modifier from RenderSolutionCombo() and RenderControlButtons()
- **Commit**: 6198973a1
- **Timestamp**: 2026-06-11

### AZ6OPa6Rsynw1OJ1vi46 — csharpsquid:S3776 (CRITICAL)
- **File**: AssetsWindow.cs:196
- **Issue**: Cognitive Complexity 70 → 15
- **Fix**: Extracted `RenderPlusMenu()` helper
- **Commit**: 5f1b41c2c

### AZ6OPa6Rsynw1OJ1vi5B — csharpsquid:S3776 (CRITICAL)
- **File**: AssetsWindow.cs:368
- **Issue**: Cognitive Complexity 29 → 15
- **Fix**: Extracted `RenderDirectoryItem`, `RenderFileItem`, `RenderTableFillItems` helpers
- **Commit**: 9b75abf72

### AZ6OPa6Rsynw1OJ1vi5F — csharpsquid:S3776 (CRITICAL)
- **File**: AssetsWindow.cs:553
- **Issue**: Cognitive Complexity 29 → 15
- **Fix**: Extracted `RenderNonRootDirectory`, `RenderLeafDirectory` from `RenderDirectory`
- **Commit**: 49ef6f542

### AZ6OPa6Rsynw1OJ1vi5G — csharpsquid:S3776 (CRITICAL)
- **File**: AssetsWindow.cs:653
- **Issue**: Cognitive Complexity 40 → 15
- **Fix**: Refactored `RenderFilesOnFolder()` to use shared helpers
- **Commit**: 81bf81a18

### AZ6OPa7Wsynw1OJ1vi5p — csharpsquid:S3776 (CRITICAL)
- **File**: ConsoleWindow.cs:191
- **Issue**: Cognitive Complexity 21 → 15
- **Fix**: Extracted `RenderConsoleLine`, `PushLineColor` helpers
- **Commit**: 56af5b8f0

### AZ6OPa6zsynw1OJ1vi5O — csharpsquid:S125 (MAJOR)
- **File**: InspectorWindow.cs:55
- **Issue**: Commented-out _componentIcons block
- **Fix**: Removed commented code
- **Commit**: 3740885ef

### AZ6OPa6zsynw1OJ1vi5Q — csharpsquid:S125 (MAJOR)
- **File**: InspectorWindow.cs:152
- **Issue**: Commented-out AddComponentPopup block
- **Fix**: Removed commented code
- **Commit**: 7cb32f3cc

### AZ6OPa7rsynw1OJ1vi5t — csharpsquid:S1144 (MAJOR)
- **File**: TopMenuAction.cs:233
- **Issue**: Unused private method 'SaveAsSceneTemplate'
- **Fix**: Removed method
- **Commit**: dfda84a02

### AZ6OPa7rsynw1OJ1vi5u — csharpsquid:S1144 (MAJOR)
- **File**: TopMenuAction.cs:257
- **Issue**: Unused private method 'SaveProject'
- **Fix**: Removed method
- **Commit**: 830501534

### AZ6OPa7rsynw1OJ1vi5v — csharpsquid:S1144 (MAJOR)
- **File**: TopMenuAction.cs:393
- **Issue**: Unused private method 'Duplicate'
- **Fix**: Removed method (and Delete, CreateUi, CreateAudio, RenameGameObject)
- **Commit**: ebc28db20

### AZ6zQlSD6-8DAyAuaboe — csharpsquid:S108 (MAJOR)
- **File**: SettingsWindow.cs:92
- **Issue**: Empty block in ImGui.Begin
- **Fix**: Changed to early-return pattern (`if (!ImGui.Begin(...)) return;`)
- **Commit**: 7c85d08ab

### AZ6OPa5osynw1OJ1vi44 — csharpsquid:S108 (MAJOR)
- **File**: GameWindow.cs:72
- **Issue**: Empty block in ImGui.Begin
- **Fix**: Changed to early-return pattern (`if (!ImGui.Begin(...)) return;`)
- **Commit**: ee0ac445b

### AZ6OPa5Tsynw1OJ1vi4y — csharpsquid:S108 (MAJOR)
- **File**: SceneWindow.cs:118
- **Issue**: Empty block in ImGui.Begin
- **Fix**: Changed to early-return pattern (`if (!ImGui.Begin(...)) return;`)
- **Commit**: a8f6dcd24
