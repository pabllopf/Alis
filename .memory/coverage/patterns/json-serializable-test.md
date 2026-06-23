# Pattern: Testing IJsonSerializable / IJsonDesSerializable

## When to Use
When a type implements `IJsonSerializable` and/or `IJsonDesSerializable<T>` via explicit interface implementation.

## Test Approach
1. Cast to the interface: `IJsonSerializable serializable = instance;`
2. For `GetSerializableProperties()`: call, materialize via `.ToList()`, assert with `Assert.Contains`
3. For `CreateFromProperties(Dictionary)`: cast to `IJsonDesSerializable<T>`, call with various dict contents
4. Test branches: all values present, missing values (fallbacks), invalid parse values, empty dict

## Example
```csharp
IJsonSerializable serializable = new MyStruct();
List<(string Name, string Value)> props = serializable.GetSerializableProperties().ToList();
Assert.Contains(props, p => p.PropertyName == "Field" && p.Value == "expected");
```
