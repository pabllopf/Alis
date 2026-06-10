# AZ6mihB5kNcRXyPBxty1

- **Rule**: csharpsquid:S2589
- **Severity**: MAJOR
- **File**: Engine.cs
- **Line**: 572
- **Message**: Change this condition so that it does not always evaluate to 'True'.
- **Fix**: Removed redundant `mouseButtons != null` check (already asserted non-null on line 542)
- **Status**: committed
- **Commit**: 840b533b1
- **Timestamp**: 2026-06-10
