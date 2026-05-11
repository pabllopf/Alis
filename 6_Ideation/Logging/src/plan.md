# Logging Module Plan

## Overview

Structured logging framework with filters, formatters, and pluggable outputs. Designed for AOT compatibility with no reflection or singleton patterns in the core API.

## Project Structure

| Project | Path | Type | Files |
|---------|------|------|-------|
| Alis.Core.Aspect.Logging | `src/` | Library (net461-net9.0) | 24 source files |
| Alis.Core.Aspect.Logging.Sample | `sample/` | Console App | 1 file |
| Alis.Core.Aspect.Logging.Test | `test/` | xUnit Tests | 40+ files |

## Source Files (src/)

### Abstractions (6 files)
- `ILogger.cs` - Core interface with LogTrace/Debug/Info/Warning/Error/Critical, structured logging, scopes, correlation IDs
- `ILogFilter.cs` - Interface for filtering log entries (ShouldLog method)
- `ILogFormatter.cs` - Interface for formatting log entries to strings
- `ILogOutput.cs` - Interface for output destinations (Write, Flush, Dispose)
- `ILogEntry.cs` - Log entry record with Level, Message, Name, Timestamp, Exception, Properties, CorrelationId, Scope
- `LogLevel.cs` - Enum: Trace, Debug, Info, Warning, Error, Critical

### Core (4 files)
- `CoreLogger.cs` - ILogger implementation with filter chain, output dispatch, thread safety via lock
- `LogEntry.cs` - ILogEntry implementation with structured properties dictionary
- `LoggerScope.cs` - Scope implementation for BeginScope()
- `Logger.cs` - Static backward-compatibility wrapper (lazy-initialized default logger)

### Filters (5 files)
- `LogLevelFilter.cs` - Filters by minimum LogLevel
- `LoggerNameFilter.cs` - Filters by logger name (wildcard support)
- `ConditionalLogFilter.cs` - Filters by predicate on LogEntry
- `CompositeLogFilter.cs` - Chains multiple filters (AND/OR composition)
- `SamplingLogFilter.cs` - Samples N out of M log entries (rate limiting)

### Formatters (3 files)
- `SimpleLogFormatter.cs` - `[Level] Name: Message` format
- `CompactLogFormatter.cs` - Minimal `[L] Message` format
- `JsonLogFormatter.cs` - JSON-formatted log entries

### Outputs (5 files)
- `ConsoleLogOutput.cs` - Writes to Console.Out/Console.Error
- `FileLogOutput.cs` - Writes to file with rotation support
- `MemoryLogOutput.cs` - In-memory buffer (IList<ILogEntry>)
- `DebugLogOutput.cs` - Writes to Debug.WriteLine
- `AsyncLogOutput.cs` - Wraps another output with async queue

### Factory
- `LoggerFactory.cs` - Builder-pattern factory for ILogger instances
  - Configurable outputs (multiple), filters, formatter, minimum level
  - IDisposable for cleanup
  - AOT-compatible: no reflection, no singleton

## Dependencies

- **Internal**: None (leaf module)
- **External**: None

## Architecture Notes

- **AOT-compatible**: No reflection, no dynamic method generation, no singleton pattern
- **Thread-safe**: CoreLogger uses lock for filter chain and output dispatch
- **Pluggable**: Any ILogger/ILogFilter/ILogFormatter/ILogOutput implementation can be swapped
- **Structured logging**: Properties dictionary supports key-value contextual data
- **Scopes**: BeginScope() returns IDisposable for grouped logging
- **Correlation IDs**: Per-logger correlation tracking for request tracing
- **Static Logger class**: Legacy backward-compat wrapper with lazy initialization

## Code Quality Issues

1. **Static Logger anti-pattern**: `Logger.cs` uses lazy-initialized static singleton, contradicts AOT/design goals. Marked as "backward compatibility only" but still actively used.
2. **Mixed language in docs**: Some XML docs in Spanish ("La asamblea activa"), some in English.
3. **No log level filtering at factory level**: LogLevelFilter exists but LoggerFactory.SetMinimumLevel() creates a redundant filter. Should be unified.
4. **AsyncLogOutput implementation**: Queue-based async wrapper adds complexity; no backpressure strategy when queue is full.
5. **FileLogOutput rotation**: No configurable rotation policy (size-based, time-based, or count-based).
6. **Thread safety granularity**: Single lock in CoreLogger protects everything - could use ReaderWriterLockSlim for read-heavy workloads.

## Next Refactoring Tasks

### Priority 1 - Critical
1. **Deprecate static Logger class**: Add Obsolete attribute with migration guide pointing to LoggerFactory pattern.
2. **Unify log level filtering**: Remove redundancy between SetMinimumLevel() and LogLevelFilter.

### Priority 2 - Important
3. **Add backpressure to AsyncLogOutput**: Drop strategy or blocking queue when buffer is full.
4. **FileLogOutput improvements**: Add size-based rotation, compression of old files.
5. **Add log level to ILogger.Log()**: Consolidate LogTrace/Debug/Info/etc into single Log(LogLevel, string) with extension methods.

### Priority 3 - Nice to have
6. **Performance**: Object pooling for LogEntry, lock-free queue for AsyncLogOutput.
7. **Add activity ID support**: System.Diagnostics.Activity for OpenTelemetry integration.
8. **Add log aggregation**: Batch output for remote logging (HTTP, message queue).

## Test Coverage

- Extensive test suite (40+ tests)
- Tests for all filters, formatters, outputs
- Thread safety tests and stress tests
- Integration tests for full logging pipeline
- Platform-specific tests (console, file, memory)
