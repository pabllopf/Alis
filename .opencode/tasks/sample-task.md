# Sample Task: Multi-Agent Analysis of Alis Project

## Task Description
Analyze the Alis codebase to:
1. Map project structure and dependencies
2. Identify architectural patterns and issues
3. Detect performance bottlenecks
4. Generate test coverage for key modules
5. Review recent code changes
6. Optimize rendering pipelines (if applicable)
7. Coordinate build system for large monorepo

## Sample Scenario
**Context**: The Alis project is a .NET multi-csproj library with 6+ Ideation modules (Memory, Fluent, Math, etc.). We need to analyze the current state and identify improvements.

## Subtasks (Parallel Execution)

### 1. @explorer - Codebase Mapping
**Goal**: Extract project structure, dependencies, and entry points.
**Output**: PROJECTS, DEPENDENCIES, LAYERS, ENTRY POINTS

### 2. @dotnet-architect - Architecture Analysis
**Goal**: Identify architectural patterns, circular dependencies, and improvements.
**Output**: ARCHITECTURE OVERVIEW, DEPENDENCY GRAPH, PROBLEMS, MINIMAL IMPROVEMENTS

### 3. @performance-engineer - Bottleneck Detection
**Goal**: Find performance issues in hot paths, loops, and async operations.
**Output**: BOTTLENECKS, CAUSES, OPTIMIZATIONS, IMPACT

### 4. @test-engineer - Test Generation
**Goal**: Generate minimum tests for behavioral coverage of key modules.
**Output**: UNIT TESTS, EDGE CASES, FAILURE CASES

### 5. @reviewer - Code Review
**Goal**: Analyze code diffs and detect issues.
**Output**: MUST-FIX, SHOULD-FIX, NICE-TO-HAVE

### 6. @rendering-specialist - Pipeline Optimization
**Goal**: Optimize rendering loops and GPU pipelines (if 2D rendering exists).
**Output**: RENDER LOOP, BATCHING STRATEGY, GPU PIPELINE

### 7. @build-coordinator - Build System Analysis
**Goal**: Map csproj dependencies and detect circular references.
**Output**: DEPENDENCY GRAPH, ISSUES, OPTIMIZATIONS, ORDERING

---

## Execution Plan

**Phase 1**: Parallel execution of all independent subagents
**Phase 2**: Aggregate results and identify cross-cutting issues
**Phase 3**: Generate consolidated report with actionable recommendations

## Expected Output Format

```
## ANALYSIS RESULTS

### 1. Project Structure (explorer)
- X projects found
- Y layers identified
- Z entry points detected

### 2. Architecture (dotnet-architect)
- A architectural issues found
- B minimal improvements proposed

### 3. Performance (performance-engineer)
- C bottlenecks detected
- D optimizations suggested

### 4. Tests (test-engineer)
- E unit tests generated
- F edge cases covered

### 5. Review (reviewer)
- G issues classified (MUST-FIX, SHOULD-FIX, NICE-TO-HAVE)

### 6. Rendering (rendering-specialist)
- H rendering optimizations proposed

### 7. Build System (build-coordinator)
- I dependency issues found
- J build order corrections suggested

## CONSOLIDATED RECOMMENDATIONS
[Actionable items prioritized by impact]
```

---

## Sample Data for Testing

**Project**: Alis.Core.Aspect.Memory
- Type: Library (class library)
- Dependencies: Alis.Core.Framework, Alis.Core.Aspect.Generator
- Entry Point: Program.cs (generator), Main.cs (sample)

**Architecture Pattern**: Aspect-Oriented Programming (AOP)
- Generator: Code generation for aspects
- Core: Runtime aspect injection
- Sample: Usage examples

**Performance Concerns**:
- Reflection overhead in aspect injection
- Memory allocations in hot paths
- Async/await patterns in generator

**Test Coverage**:
- Unit tests for aspect injection logic
- Integration tests for generator output
- Edge cases for null/empty inputs

---

## Ready to Execute

All subagents are configured and ready. Execute in parallel for maximum throughput.
