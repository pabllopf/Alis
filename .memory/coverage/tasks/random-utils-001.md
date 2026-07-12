## COVERAGE TASK

### File
6_Ideation/Math/src/Util/RandomUtils.cs

### Previous Coverage
95.7%

### Estimated Coverage After
100.0%

### Uncovered Line
43 (private static field initializer `Rng = RandomNumberGenerator.Create()`)

### Method
.cctor (static constructor)

### Existing Tests
RandomUtilsTest.cs (7 tests before, 8 after)

### Test Added
`StaticConstructor_InitializesRngField` - Uses reflection to access the private `Rng` field, forcing the static constructor to execute and covering the field initializer line.

### Root Cause
The `Rng` field is only referenced in the `#else` preprocessor branch (non-NET6 targets). When tests run on `net8.0`, the `NET6_0_OR_GREATER` branch uses `RandomNumberGenerator.Fill()` directly, so `Rng` is never read in the compiled IL. The JIT can then skip the `.cctor`, leaving line 43 uncovered.

### Commit
pending

### Status
completed
