# Pattern: S3928 ArgumentException Parameter Name

## Description
When using ArgumentException/ArgumentNullException in methods without parameters (like Validate()), the parameter name must match an actual method parameter.

## Fix
Replace with InvalidOperationException since the method validates object state, not method arguments:
```csharp
// Before
throw new ArgumentNullException(nameof(fieldName));

// After  
throw new InvalidOperationException("fieldName cannot be null.");
```

## Used In
- AZ7pmgwT8gEfmPgleLrm (DungeonData.cs:145)
- AZ7pmgwT8gEfmPgleLrn (DungeonData.cs:150)
- AZ7pmgwT8gEfmPgleLro (DungeonData.cs:155)
- AZ7pmgwT8gEfmPgleLrp (DungeonData.cs:160)
