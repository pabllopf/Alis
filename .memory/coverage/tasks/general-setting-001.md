## COVERAGE TASK

### File
2_Application/Alis/src/Core/Ecs/Systems/Configuration/General/GeneralSetting.cs

### Coverage
Current: ~51.8% (overall project)

### Method(s)
- `IJsonSerializable.GetSerializableProperties()` (implicit, 7 yield returns)
- `IJsonDesSerializable<GeneralSetting>.CreateFromProperties(Dictionary)` (7 TryGetValue branches with fallbacks)
- `OnSave()` (internal)
- `OnLoad()` (internal static)

### Existing Tests
- `GeneralSettingStructTest.cs` (82 lines, 3 tests: default constructor, custom constructor, interface check)

### Source Code
[See GeneralSetting.cs]

### Approach
Test explicit interface implementations through interface casts. Test:
1. GetSerializableProperties returns all 7 properties with correct values
2. CreateFromProperties with all values present
3. CreateFromProperties with missing values (fallback defaults)
4. CreateFromProperties with invalid bool for Debug field
5. CreateFromProperties with empty dictionary
