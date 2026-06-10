# AZ6sG00gDMjfSxivO2NU

- **Rule**: csharpsquid:S3604
- **Severity**: MINOR
- **File**: ImguiSample.cs
- **Line**: 87
- **Message**: Remove the member initializer, all constructors set an initial value for the member.
- **Fix**: Removed inline initializer `= new List<bool>()` from _mouseClicked (also fixed _mouseDoubleClicked at line 92 in same commit)
- **Status**: committed
- **Commit**: 932f4cfb6
- **Timestamp**: 2026-06-10
