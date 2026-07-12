---
title: Alis.Core.Aspect.Logging
tags:
  - ideation
  - logging
  - diagnostics
status: Draft
license: GPLv3
---

# Alis.Core.Aspect.Logging

**Layer:** 6_Ideation
**Path:** `6_Ideation/Logging/src/Alis.Core.Aspect.Logging.csproj`

## Purpose

Comprehensive logging framework with multiple output targets, formatters, and filtering capabilities.

## Architecture

### Core
- `ILogger` — Main logging interface
- `Logger` / `CoreLogger` — Logger implementations
- `LoggerFactory` — Logger creation and configuration
- `ILogEntry` / `LogEntry` — Log entry data model
- `LogLevel` — Severity enumeration
- `LoggerScope` — Scoped logging context

### Outputs
- `ConsoleLogOutput` — Console output
- `FileLogOutput` — File output
- `MemoryLogOutput` — In-memory buffer
- `AsyncLogOutput` — Async-wrapped output
- `DebugLogOutput` — Debug output

### Formatters
- `SimpleLogFormatter` — Plain text
- `JsonLogFormatter` — Structured JSON
- `CompactLogFormatter` — Minimal format

### Filters
- `LogLevelFilter` — Level-based filtering
- `LoggerNameFilter` — Name-based filtering
- `CompositeLogFilter` — Combined filters
- `ConditionalLogFilter` — Predicate-based
- `SamplingLogFilter` — Sampling/rate limiting

## Dependencies

None (leaf layer)

## Testing

**Path:** `6_Ideation/Logging/test/`

78 test files — very extensive test suite covering:
- Unit tests for all outputs, formatters, filters, core
- Integration tests
- Stress tests (thread safety, performance)
- Platform-specific tests (Windows, macOS, Linux)
- Edge case and branch coverage tests
- Contract tests for all abstractions

## Observations

- Most thoroughly tested module in the repository
- Pattern: ILogXxx abstraction → XxxLog concrete implementation
- All outputs follow open/closed principle via ILogOutput
- Platform-specific file output tests for macOS, Windows, Linux

## Related Documents

- [[Alis.Core.Aspect]]
- [[testing-overview]]
- [[Alis.Core.Aspect.Math]]
