# Issue: S1192 - Define a constant

## Issue ID
AZ64sUr6LnQ0n5Zded5E

## Rule
csharpsquid:S1192

## File
1_Presentation/Engine/src/Engine.cs

## Line
184

## Severity
MINOR

## Description
Define a constant instead of using this literal 'JetBrainsMonoFontName' 6 times.

## Fix
Added `private const string JetBrainsMonoFontName = "JetBrainsMonoFontName";` and replaced all 6 raw literals with the constant reference.

## Commit
b38b3cebf

## Timestamp
2026-06-12T17:44:30+01:00

## Status
FIXED
