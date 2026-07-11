# Issue: AZ7pmgwT8gEfmPgleLrp

## SonarCloud Info
- Rule: csharpsquid:S3928
- Severity: MAJOR
- Component: pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/src/Models/DungeonData.cs
- Line: 160
- Status: OPEN → FIXED

## Description
Parameter name '_corridors' is not declared in the argument list.

## Fix
Changed to InvalidOperationException since Validate() checks object state, not method arguments.

## Commit
d82ae2ea9
