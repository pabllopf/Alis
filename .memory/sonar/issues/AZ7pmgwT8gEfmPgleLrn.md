# Issue: AZ7pmgwT8gEfmPgleLrn

## SonarCloud Info
- Rule: csharpsquid:S3928
- Severity: MAJOR
- Component: pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/src/Models/DungeonData.cs
- Line: 150
- Status: OPEN → FIXED

## Description
Parameter name '_board' is not declared in the argument list.

## Fix
Changed to InvalidOperationException since Validate() checks object state, not method arguments.

## Commit
cb08bb3ae
