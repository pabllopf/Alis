# Serializable Interfaces

## IJsonSerializable

**Location**: `src/Json/IJsonSerializable.cs`

Defines a contract for objects that can be serialized to JSON format.

### Method: GetSerializableProperties

Returns an enumerable of property name-value tuples for JSON serialization.

**Signature**:
```csharp
IEnumerable<(string PropertyName, string Value)> GetSerializableProperties();
```

**Returns**:
- `IEnumerable<(string, string)>` - Property names and string values

### Implementation Guidelines

1. **Use yield return** for each property:
```csharp
yield return ("PropertyName", value.ToString());
```

2. **Primitive types** should be converted to strings:
```csharp
yield return ("Age", Age.ToString());
yield return ("IsActive", IsActive.ToString());
yield return ("Price", Price.ToString("F2"));
```

3. **Complex types** should return raw JSON:
```csharp
yield return ("Address", JsonNativeAot.Serialize(address));
yield return ("Tags", "[\"tag1\",\"tag2\"]");
```

4. **Null or empty values** are allowed:
```csharp
yield return ("Optional", OptionalValue ?? "");
```

### Example Implementation

```csharp
public class Person : IJsonSerializable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public List<string> Hobbies { get; set; }

    public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
    {
        yield return ("Name", Name);
        yield return ("Age", Age.ToString());
        yield return ("Email", Email ?? "");
        yield return ("Hobbies", "[" + string.Join(",", 
            Hobbies.Select(h => $"\"{h}\"")) + "]");
    }
}
```

## IJsonDesSerializable<T>

**Location**: `src/Json/IJsonDesSerializable.cs`

Defines a contract for objects that can be deserialized from JSON format.

### Method: CreateFromProperties

Creates an instance populated with data from a property dictionary.

**Signature**:
```csharp
T CreateFromProperties(Dictionary<string, string> properties);
```

**Parameters**:
- `properties` (Dictionary<string, string>) - Property names and values from JSON

**Returns**:
- `T` - Fully initialized instance

### Implementation Guidelines

1. **Always use TryGetValue** to safely access properties:
```csharp
if (properties.TryGetValue("PropertyName", out var value))
{
    // Use value
}
```

2. **Provide defaults** for missing properties:
```csharp
var age = 0;
if (properties.TryGetValue("Age", out var ageStr) && 
    int.TryParse(ageStr, out var ageValue))
{
    age = ageValue;
}
```

3. **Handle type conversions**:
```csharp
// String
var name = properties.TryGetValue("Name", out var n) ? n : null;

// Integer
int age = 0;
if (properties.TryGetValue("Age", out var ageStr) && 
    int.TryParse(ageStr, out var ageValue))
    age = ageValue;

// Boolean
bool active = false;
if (properties.TryGetValue("Active", out var activeStr) && 
    bool.TryParse(activeStr, out var activeValue))
    active = activeValue;

// DateTime
DateTime date = DateTime.MinValue;
if (properties.TryGetValue("Date", out var dateStr) && 
    DateTime.TryParse(dateStr, out var dateValue))
    date = dateValue;

// Guid
Guid id = Guid.Empty;
if (properties.TryGetValue("Id", out var idStr) && 
    Guid.TryParse(idStr, out var idValue))
    id = idValue;
```

4. **Complex types** are returned as raw JSON:
```csharp
var tags = new List<string>();
if (properties.TryGetValue("Tags", out var tagsJson))
{
    // Parse the raw JSON array
    // Implementation depends on format
}
```

### Example Implementation

```csharp
public class Person : IJsonSerializable, IJsonDesSerializable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
    {
        yield return ("Name", Name);
        yield return ("Age", Age.ToString());
        yield return ("Email", Email ?? "");
    }

    public Person CreateFromProperties(Dictionary<string, string> properties)
    {
        var person = new Person();

        if (properties.TryGetValue("Name", out var name))
            person.Name = name;

        if (properties.TryGetValue("Age", out var ageStr) && 
            int.TryParse(ageStr, out var age))
            person.Age = age;

        if (properties.TryGetValue("Email", out var email))
            person.Email = email;

        return person;
    }
}
```

## Combined Example

Here's a complete class implementing both interfaces:

```csharp
public class User : IJsonSerializable, IJsonDesSerializable<User>
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<string> Roles { get; set; }

    public User()
    {
        UserId = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        Roles = new List<string>();
    }

    public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
    {
        yield return ("UserId", UserId.ToString());
        yield return ("Username", Username);
        yield return ("Email", Email);
        yield return ("Age", Age.ToString());
        yield return ("IsActive", IsActive.ToString());
        yield return ("CreatedAt", CreatedAt.ToString("O")); // ISO 8601
        yield return ("Roles", "[" + string.Join(",", 
            Roles.Select(r => $"\"{r}\"")) + "]");
    }

    public User CreateFromProperties(Dictionary<string, string> properties)
    {
        var user = new User();

        if (properties.TryGetValue("UserId", out var userId) && 
            Guid.TryParse(userId, out var userIdValue))
            user.UserId = userIdValue;

        if (properties.TryGetValue("Username", out var username))
            user.Username = username;

        if (properties.TryGetValue("Email", out var email))
            user.Email = email;

        if (properties.TryGetValue("Age", out var age) && 
            int.TryParse(age, out var ageValue))
            user.Age = ageValue;

        if (properties.TryGetValue("IsActive", out var active) && 
            bool.TryParse(active, out var activeValue))
            user.IsActive = activeValue;

        if (properties.TryGetValue("CreatedAt", out var created) && 
            DateTime.TryParse(created, out var createdValue))
            user.CreatedAt = createdValue;

        if (properties.TryGetValue("Roles", out var rolesJson))
        {
            // Parse JSON array
            // Implementation: extract role names from rolesJson
            user.Roles = ParseRolesFromJson(rolesJson);
        }

        return user;
    }

    private static List<string> ParseRolesFromJson(string json)
    {
        var roles = new List<string>();
        // Simple extraction - in production use proper JSON parsing
        var items = json.Trim('[', ']').Split(',');
        foreach (var item in items)
        {
            var role = item.Trim().Trim('"');
            if (!string.IsNullOrEmpty(role))
                roles.Add(role);
        }
        return roles;
    }
}
```

## Usage

### Serialization
```csharp
var user = new User 
{ 
    Username = "john_doe",
    Email = "john@example.com",
    Age = 30,
    IsActive = true,
    Roles = new List<string> { "Admin", "User" }
};

string json = JsonNativeAot.Serialize(user);
```

### Deserialization
```csharp
string json = "{\"UserId\":\"...\",\"Username\":\"john_doe\",...}";
var user = JsonNativeAot.Deserialize<User>(json);
```

## Best Practices

1. **Always implement both interfaces** for complete support
2. **Use TryGetValue** to safely access properties
3. **Provide defaults** for missing or invalid data
4. **Document custom conversions** in implementation
5. **Test both serialization and deserialization** for round-trip integrity
6. **Handle null values** gracefully
7. **Use consistent property naming** between serialization and deserialization

## Related

- [JsonNativeAot](jsonNativeAot.md) - Main API
- [Usage Examples](samples/usageExamples.md) - Complete examples

