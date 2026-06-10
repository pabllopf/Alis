# AZ6sG0zTDMjfSxivO2NS

- **Rule**: external_roslyn:CS0649
- **Severity**: MAJOR
- **File**: Engine.cs
- **Line**: 184
- **Message**: Field 'Engine.platform' is never assigned to, and will always have its default value null
- **Fix**: Added #pragma warning disable/restore CS0649 since field is set via external injection pattern
- **Status**: committed
- **Commit**: 131b117bb
- **Timestamp**: 2026-06-10
