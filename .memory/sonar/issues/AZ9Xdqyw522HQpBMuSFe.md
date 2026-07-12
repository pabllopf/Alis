# Issue: AZ9Xdqyw522HQpBMuSFe

- Rule: csharpsquid:S3776
- Severity: CRITICAL
- File: 1_Presentation/Extension/Math/ProceduralDungeon/src/Models/DungeonData.cs
- Line: 141
- Hash: 3552bb7c5c74233fb56717c4f2341abc
- Status: FIXED
- Commit: 73bcfebbcd23272215808fa86a5f8051140f31dc
- Date: 2026-07-12

## Description

Refactor this method to reduce its Cognitive Complexity from 19 to the 15 allowed.

## Context

The `Validate()` method at line 141 had Cognitive Complexity 19 (threshold 15). The complexity came from:
- Null checks for `_board`, `_rooms`, `_corridors` (3 ifs)
- Dimension check with OR conditions
- Two `for` loops iterating rooms and corridors
- Nested conditionals inside loops checking positions and dimensions with OR conditions

## Fix Applied

Extracted three private methods from `Validate()`:
- `ValidateBoard()` — board null check + dimension check
- `ValidateRooms()` — rooms null check + per-room validation loop
- `ValidateCorridors()` — corridors null check + per-corridor validation loop

`Validate()` now delegates to these three methods, reducing its cognitive complexity to 0.