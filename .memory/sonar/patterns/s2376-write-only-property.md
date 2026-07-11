# Pattern: S2376 Write-Only Property

## Description
Properties with only a setter (write-only) violate S2376. Provide a getter or replace with a method.

## Fix
Add a getter that returns the underlying field:
```csharp
internal IType Property { get => field; set => field = value; }
```

## Used In
- AZ7ud83Q7oTRF9lfUdEv (AudioSource.cs)
