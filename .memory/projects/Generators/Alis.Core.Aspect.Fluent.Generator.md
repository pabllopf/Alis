# Alis.Core.Aspect.Fluent.Generator

## Overview
AOT-safety `DiagnosticAnalyzer` (not a source generator — ships in generator project format). Detects and reports reflection patterns that would break native AOT compilation. All diagnostics emit at `DiagnosticSeverity.Error` to enforce AOT compatibility.

## Details
- **Layer**: 6_Ideation (Fluent aspect)
- **Type**: `DiagnosticAnalyzer` (AOT safety)
- **Files**: 2 (1 `.csproj` + 1 `.cs`)
- **Target**: `netstandard2.0;net8.0;net10.0`

## Source Files

| File | Purpose |
|---|---|
| `AotReflectionAnalyzer.cs` | Diagnostic analyzer — detects 10 AOT-unsafe reflection patterns |

## Diagnostics
| Code | Description |
|---|---|
| ALIS001 | `System.Reflection` API usage |
| ALIS002 | `Reflection.Emit` / dynamic IL generation |
| ALIS003 | `MethodInfo.Invoke` / `PropertyInfo.GetValue` |
| ALIS004 | `Activator.CreateInstance` |
| ALIS005 | `Type.GetType` / `Assembly.Load` |
| ALIS006 | `dynamic` keyword / `IDynamicMetaObjectProvider` |
| ALIS007 | Reflection-based serializers |
| ALIS008 | `Expression.Compile()` |
| ALIS009 | `RuntimeHelpers.PrepareMethod` |
| ALIS010 | Unknown reflection patterns |

## Related
- [[projects/6_Ideation/Fluent]] — Fluent aspect
- [[projects/Generators]] — Generator overview
