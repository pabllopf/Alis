# AZ6sG00gDMjfSxivO2NT

- **Rule**: csharpsquid:S3604
- **Severity**: MINOR
- **File**: ImguiSample.cs
- **Line**: 82
- **Message**: Remove the member initializer, all constructors set an initial value for the member.
- **Fix**: Removed inline initializer `= new List<bool>()` since constructors reassign it
- **Status**: committed
- **Commit**: 599b18976
- **Timestamp**: 2026-06-10
