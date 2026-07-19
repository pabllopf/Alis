## COVERAGE TASK

### File
4_Operation/Ecs/src/Collections/ArchetypeNeighborCache.cs

### Coverage
55.5%

### Uncovered Lines
37 lines (82 lines to cover)

### Method
All: Traverse, TraverseArchetype, Lookup, Set (ushort, ushort), Set (ushort, Archetype)

### Existing Tests
ArchetypeNeighborCacheTest.cs — 14 tests, all skipped

### Source Code
```csharp
internal struct ArchetypeNeighborCache
{
    private ushort _k0, _k1, _k2, _k3;
    private ushort _v0, _v1, _v2, _v3;
    private Archetype _arch0, _arch1, _arch2, _arch3;
    internal int _nextIndex;

    public int Traverse(ushort value) { ... }
    public Archetype TraverseArchetype(ushort key) { ... }
    public ushort Lookup(int index) { ... }
    public void Set(ushort key, ushort value) { ... }
    public void Set(ushort key, Archetype archetype) { ... }
}
```

### Generated Tests
ArchetypeNeighborCacheRemainingCoverageTests.cs — 16 tests covering:
- Traverse: empty, slot 0-3, miss, boundary keys
- TraverseArchetype: empty, miss
- Lookup: all 4 slots, out of range (default)
- Set: round-robin, wrap around, eviction, overwrite
- Edge cases: zero key, max key, same key overwrite
