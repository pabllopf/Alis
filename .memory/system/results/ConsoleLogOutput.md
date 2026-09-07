# ConsoleLogOutput.cs — Coverage Remediation Results

## File
6_Ideation/Logging/src/Outputs/ConsoleLogOutput.cs

## Coverage
- SonarCloud: 92.9% line, 100.0% branch
- Local (coverlet): 92.9% (3 unreachable lines)

## Uncovered Lines
Lines 119, 121, 125 — inner catch block in finally:
```csharp
finally
{
    try
    {
        Console.ForegroundColor = originalColor;  // line 117
    }
    catch       // line 119 — UNREACHABLE
    {           // line 121 — UNREACHABLE
        // Swallow exception
    }           // line 125 — UNREACHABLE
}
```

## Why Unreachable
.NET's `ConsolePal.Unix.cs` caches `s_out` at first access via `s_out ??= Console.Out`. Once cached:
- `Console.SetOut(new ThrowingTextWriter())` changes `Console.Out` but `ConsolePal.s_out` still references the old writer
- Closing stdout fd via `close(1)` (P/Invoke) does not cause `Console.ForegroundColor` setter to throw — the setter writes ANSI sequences through the cached `s_out` which may buffer or handle errors internally
- No test harness can force the ForegroundColor setter to throw on macOS

## Existing Test Coverage
6 test files with 73+ tests covering:
- Constructor (default, null, custom formatter)
- Name/IsEnabled properties
- Write (all log levels, null entry, disposed state, all edge cases)
- Flush, Dispose (idempotent)
- Exception swallowing (ThrowingTextWriter, closed stdout)
- Color switch (all LogLevel values + unknown default)

## Status
PARTIAL_BLOCKED_BY_PRODUCTION_CODE — 3 lines unreachable defensive code
