# Quality Improvement Plan for Alis.Core.Aspect.Time.csproj

## Current Situation Analysis
The Time module is a simple stopwatch-like utility providing basic elapsed time tracking with start/stop/reset/restart semantics. It currently uses `DateTime.UtcNow` for timing which has limited precision (~1-15ms depending on OS) and lacks several features essential for game engine timing. The project is a leaf module (no internal dependencies) in Layer 6: Ideation, following the src/test/sample pattern.

### Current Stats
| Metric | Value |
|--------|-------|
| Source files | 1 (`Clock.cs`, 153 lines) |
| Test files | 3 (`ClockTest.cs`, `ClockExtensiveTest.cs`, `DefaultTest.cs`) |
| Test cases | 19 test methods |
| Sample files | 2 (`Program.cs`, `QuickStartScenario.cs`) |
| Coverage gaps | No TimeScale, DeltaTime, FixedTimestep, or event support |

## Goals
- Improve code quality and precision of timing
- Add essential game engine timing features (TimeScale, DeltaTime, FixedTimestep)
- Add comprehensive unit tests for all public APIs
- Create sample programs demonstrating advanced usage patterns
- Strictly follow Alis architecture, style, and documentation rules
- Do not change the solution/project structure

## Updated Requirements (Priority Ordered)

### P1 - Critical (Must Have)
| # | Requirement | Rationale |
|---|------------|-----------|
| 1 | Replace `DateTime.UtcNow` with `Stopwatch` high-precision timing | Sub-millisecond precision required for game engines |
| 2 | Add `TimeScale` property (default 1.0) | Essential for slow-motion, pause, speed-up gameplay features |
| 3 | Convert `Clock` from `class` to `readonly struct` | Zero-allocation usage in hot paths; value semantics are correct for a time utility |

### P2 - Important (Should Have)
| # | Requirement | Rationale |
|---|------------|-----------|
| 4 | Add `DeltaTime` property | Frame-rate independent physics and game logic |
| 5 | Add `FixedTimestep` support | Physics simulation requires fixed intervals (60fps = 16.67ms) |
| 6 | Fix `ElapsedSeconds` truncation | Use fractional seconds via `TotalSeconds` instead of integer division |

### P3 - Nice to Have (Could Have)
| # | Requirement | Rationale |
|---|------------|-----------|
| 7 | Add `OnTick` / `OnElapsed` events | Callback-based timing for game systems |
| 8 | Expose internal `Stopwatch` | Advanced timing scenarios |
| 9 | Platform-specific performance counter | Benchmarking support |

## Implementation Steps
1. Design Clock v2 API maintaining backward compatibility
2. Implement high-precision timing with `Stopwatch`
3. Implement `TimeScale` multiplier on all elapsed calculations
4. Implement `DeltaTime` tracking (last frame elapsed)
5. Implement `FixedTimestep` accumulator pattern
6. Convert to `readonly struct`
7. Fix `ElapsedSeconds` to return fractional seconds
8. Add comprehensive unit tests (target: 100% branch coverage)
9. Create advanced sample scenarios (fixed timestep loop, time scale demo)
10. Update all documentation (plan.md, QualityPlan.md, cache files)
11. Validate with build and test runs

## Tracking
- Progress tracked in this plan file and `.info/cache-module-status.md`
- All tasks follow commit format: `fix: xxx` / `feat: xxx` / `docs: xxx`