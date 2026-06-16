# Issue: AZ7KU74wgfB4D_M8MD1E (S4136 - CopyTo)

- **Rule**: csharpsquid:S4136
- **File**: 4_Operation/Ecs/generator/Collections/FastImmutableArray.cs
- **Line**: 313
- **Severity**: MINOR
- **Status**: DEFERRED

## Description

All 'CopyTo' method overloads should be adjacent.

## Reason for Deferral

This requires restructuring the Builder class and related types to group all CopyTo overloads together. The file has CopyTo methods scattered across:
- Line 313 (Builder.CopyTo)
- Line 661, 673 (ICollection.CopyTo overloads)
- Line 916 (Span<T> CopyTo)
- Lines 1141-1153 (FastImmutableArray.CopyTo)
- Line 1167 (FastImmutableArray.CopyTo with source index)

Moving these would require significant refactoring and risk breaking behavior. This is a structural issue that should be addressed in a dedicated refactoring effort, not incrementally.

## Issue: AZ7KU74wgfB4D_M8MD1F (S4136 - IndexOf)

- **Rule**: csharpsquid:S4136
- **File**: 4_Operation/Ecs/generator/Collections/FastImmutableArray.cs
- **Line**: 325
- **Severity**: MINOR
- **Status**: DEFERRED

## Description

All 'IndexOf' method overloads should be adjacent.

## Reason for Deferral

Similar to CopyTo — IndexOf overloads are scattered across lines 325, 697, 706, 719, 754, 1007. Requires structural refactoring.
