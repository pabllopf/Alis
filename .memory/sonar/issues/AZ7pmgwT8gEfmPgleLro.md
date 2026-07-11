# Issue: AZ7pmgwT8gEfmPgleLro

## SonarCloud Info
- Rule: csharpsquid:S3928
- Severity: MAJOR
- Component: pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/src/Models/DungeonData.cs
- Line: 155
- Status: OPEN → FIXED

## Description
Parameter name '_rooms' is not declared in the argument list.

## Fix
Changed to InvalidOperationException since Validate() checks object state, not method arguments.

## Commit
df174c9e6
