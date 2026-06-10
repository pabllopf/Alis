# AZ6OPa1Dsynw1OJ1vi4Q

- **Rule**: csharpsquid:S2589
- **Severity**: MAJOR
- **File**: HubEngine.cs
- **Line**: 450 (originally 458)
- **Message**: Change this condition so that it does not always evaluate to 'True'.
- **Fix**: Removed redundant `mouseButtons != null` check (already asserted non-null on line 424)
- **Status**: committed
- **Commit**: 24d60a422
- **Timestamp**: 2026-06-10
