# Issue: AZ9WLQxvb3Yg5Wvlzs08

- Rule: csharpsquid:S1144
- Severity: MAJOR
- File: 6_Ideation/Math/src/Util/RandomUtils.cs
- Line: 43
- Hash: 86924d67a3a53520f75bf98bcb860529
- Status: FIXED
- Commit: 771c193d3421d3dcd8fcbc0178db679930d6aa27
- Date: 2026-07-12

## Description

Remove the unused private field 'Rng'.

## Context

The `Rng` field (`private static readonly RandomNumberGenerator`) was only used in `#else` branches of `#if NET6_0_OR_GREATER` conditionals. On newer TFMs (net6.0+), the `#else` branch is compiled out, making the field appear unused to SonarCloud. However, removing it outright would break older TFMs (net5.0, net461, netcoreapp2.0, netstandard2.0) where the `#else` branch is active.

## Fix Applied

Wrapped the field declaration (and its XML doc comment) in `#if !NET6_0_OR_GREATER`:
- On NET6_0+ TFMs: field is not compiled, no unused warning
- On older TFMs: field is compiled and used as before
- Behavior preserved across all target frameworks