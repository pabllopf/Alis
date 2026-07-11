# Issue: AZ7pmgwT8gEfmPgleLrm

## SonarCloud Info
- Rule: csharpsquid:S3928
- Severity: MAJOR
- Component: pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/src/Models/DungeonData.cs
- Line: 145
- Status: OPEN → FIXED

## Description
Parameter name '_board' is not declared in the argument list. Validate() has no parameters, so ArgumentNullException with a field name is invalid.

## Fix
Changed to InvalidOperationException since Validate() checks object state, not method arguments.

## Commit
10506bb37
