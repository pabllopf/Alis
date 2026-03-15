# Design Constraints and Tradeoffs

## Constraints from current implementation

- Time source is fixed to `DateTime.UtcNow`.
- No dependency injection point is available for time.
- Class state is mutable and not explicitly synchronized.
- Precision is constrained by OS/runtime clock granularity.

## Why these constraints are acceptable here

- The module goal is a tiny elapsed-time helper, not a full timing framework.
- Keeping only one public type reduces API and maintenance overhead.
- `DateTime.UtcNow` is universally available across target frameworks.

## Tradeoffs

### Simplicity vs precision

- Simplicity is high because implementation is minimal.
- Precision is lower than high-resolution timing APIs in benchmark tools.

### Minimal API vs extensibility

- Public surface is easy to learn.
- Advanced scenarios (mockable clocks, deterministic replay) require extra layers outside this module.

### Portability vs specialized optimization

- Broad framework compatibility is supported by shared project configuration.
- No platform-specific optimization is attempted in this core class.

## Operational guidance

- Use this module for elapsed duration tracking in application logic.
- Use specialized benchmarking libraries for micro-performance analysis.
- Avoid assuming thread-safe behavior unless synchronization is added at call sites.

