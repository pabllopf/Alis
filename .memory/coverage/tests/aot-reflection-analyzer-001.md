# Test File: AotReflectionAnalyzerTest

## Location
6_Ideation/Fluent/test/AotReflectionAnalyzerTest.cs

## Framework
xUnit + Moq

## Test Count
54 tests

## Test Categories
- IsReflectionType: 9 tests (null, reflection types, non-reflection types)
- IsEmitApi: 9 tests (emit APIs, non-emit APIs, null containing type)
- IsInvokeApi: 12 tests (invoke APIs, non-invoke APIs, null containing type)
- IsActivatorApi: 7 tests (activator APIs, non-activator APIs, null containing type)
- IsTypeGetTypeApi: 7 tests (type-get-type APIs, non-type-get-type APIs, null containing type)
- IsKnownSerializer: 7 tests (serializer types, non-serializer types, null containing type)
- SupportedDiagnostics: 2 tests (length, not empty)
- DiagnosticId Constants: 2 tests (values, uniqueness)

## Helper Classes
- MockTypeSymbolFactory: Creates mock ITypeSymbol with display string
- MockMethodSymbolFactory: Creates mock IMethodSymbol with containing type and name

## Pattern Notes
- Uses Moq for Roslyn interface mocking
- Factory pattern for mock creation to reduce boilerplate
- Tests cover both positive and negative cases for each method
- Null-containing-type tests verify defensive behavior
