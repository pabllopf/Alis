# Test: GeneralSetting Struct Coverage

## File
2_Application/Alis/test/GeneralSettingStructTest.cs

## Methods Tested
- `IJsonSerializable.GetSerializableProperties()` — 2 tests (custom values + defaults)
- `IJsonDesSerializable<GeneralSetting>.CreateFromProperties(Dictionary)` — 4 tests (all values, missing, invalid bool, partial)

## Test Details
1. `GetSerializableProperties_ShouldReturnAllProperties` — verifies all 7 properties with custom values
2. `GetSerializableProperties_WithDefaults_ShouldReturnDefaultValues` — verifies defaults match constructor defaults
3. `CreateFromProperties_WithAllValues_ShouldCreatePopulatedInstance` — full dict roundtrip
4. `CreateFromProperties_WithMissingValues_ShouldUseDefaults` — empty dict, all fallbacks
5. `CreateFromProperties_WithInvalidDebug_ShouldTreatAsFalse` — non-parsable bool -> false
6. `CreateFromProperties_WithPartialValues_ShouldUseFallbacks` — only Name+Version set, rest defaulted

## Result
All 9 tests pass (3 existing + 6 new)
