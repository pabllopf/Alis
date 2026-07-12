# Fix: AZ9WLQxvb3Yg5Wvlzs08

## Issue
S1144 — Unused private field `Rng`.

## Fix
Wrapped field declaration with `#if !NET6_0_OR_GREATER` conditional compilation so it only exists on targets where it's actually used.

## Commit
`7f5bf0693`

## Result
Build succeeded. No behavioral changes on any TFM.

