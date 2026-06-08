# Alis.Core.Aspect.Logging

## Overview

The **Alis.Core.Aspect.Logging** project provides a structured logging framework with filters, formatters, and pluggable outputs. It's designed for AOT compatibility with no reflection or singleton patterns in the core API.

## Purpose

- Provide structured logging with log levels (Trace, Debug, Info, Warning, Error, Critical)
- Support pluggable filters, formatters, and outputs
- Enable logging scopes and correlation IDs for request tracing
- Maintain AOT compatibility without reflection

## Architecture

### Core Interfaces

| Interface | Description |
|-----------|-------------|
| `ILogger` | Core logging interface with LogTrace/Debug/Info/Warning/Error/Critical |
| `ILogFilter` | Filters log entries (ShouldLog method) |
| `ILogFormatter` | Formats log entries to strings |
| `ILogOutput` | Output destinations (Write, Flush, Dispose) |
| `ILogEntry` | Log entry record with Level, Message, Properties, CorrelationId, Scope |

### Components

| Component | Description |
|-----------|-------------|
| **Filters** | LogLevelFilter, LoggerNameFilter, ConditionalLogFilter, CompositeLogFilter, SamplingLogFilter |
| **Formatters** | SimpleLogFormatter, CompactLogFormatter, JsonLogFormatter |
| **Outputs** | ConsoleLogOutput, FileLogOutput, MemoryLogOutput, DebugLogOutput, AsyncLogOutput |
| **Factory** | LoggerFactory - Builder-pattern factory for ILogger instances |

### Usage Pattern

```csharp
using Alis.Core.Aspect.Logging;

var loggerFactory = new LoggerFactory()
    .AddOutput(new ConsoleLogOutput())
    .AddFilter(new LogLevelFilter(LogLevel.Warning))
    .SetFormatter(new JsonLogFormatter());

var logger = loggerFactory.CreateLogger("MyApp");

logger.LogInformation("User {UserId} logged in", userId);
```

## Files

| File | Count | Description |
|------|-------|-------------|
| ILogger.cs | 1 | Core interface |
| CoreLogger.cs | 1 | ILogger implementation |
| LogEntry.cs | 1 | ILogEntry implementation |
| Filters/*.cs | 5 | Log filters |
| Formatters/*.cs | 3 | Log formatters |
| Outputs/*.cs | 5 | Output destinations |

## Dependencies

- **None** - Pure C# implementation, no external dependencies

## Quality Plan

See [QualityPlan.md](QualityPlan.md) for performance goals.

## Known Issues

1. **Static Logger anti-pattern** - `Logger.cs` uses lazy-initialized static singleton
2. **Mixed language in docs** - Some XML docs in Spanish, some in English
3. **No log level filtering at factory** - Redundant between SetMinimumLevel() and LogLevelFilter
4. **AsyncLogOutput complexity** - Queue-based wrapper with no backpressure strategy
5. **FileLogOutput rotation** - No configurable rotation policy

## TODOs

- [ ] Deprecate static Logger class
- [ ] Unify log level filtering
- [ ] Add backpressure to AsyncLogOutput
- [ ] FileLogOutput improvements (size-based rotation, compression)
- [ ] Performance optimization (object pooling, lock-free queue)
- [ ] Add Activity ID support for OpenTelemetry

## Related Projects

- [[Alis.Core.Ecs]] - Uses logging for debugging
- [[Alis.Core.Graphic]] - Rendering errors logged
