# Issue: AZ7ud83Q7oTRF9lfUdEv

## SonarCloud Info
- Rule: csharpsquid:S2376
- Severity: MAJOR
- Component: pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Audio/AudioSource.cs
- Line: 59
- Status: OPEN → FIXED

## Description
Write-only property 'PlayerForTest' should provide a getter or be replaced with a method.

## Fix
Added getter to the write-only property that returns the underlying `player` field.

## Commit
b94470b5f
