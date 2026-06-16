## FIX: AZ7QY7FeQ4rNF2j6P6Nz

- File: FastImmutableArray.cs
- Change: Parameterized ThrowArgumentOutOfRangeException to accept paramName, passed nameof(index) at all 3 call sites.
- Commit: $(git rev-parse HEAD 2>/dev/null || echo "pending")
