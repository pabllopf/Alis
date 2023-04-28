``` ini

BenchmarkDotNet=v0.13.2, OS=macOS 13.2.1 (22D68) [Darwin 22.3.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=6.0.405
  [Host]     : .NET 6.0.13 (6.0.1322.58009), Arm64 RyuJIT AdvSIMD DEBUG
  Job-OONPGH : .NET 6.0.13 (6.0.1322.58009), Arm64 RyuJIT AdvSIMD DEBUG

BuildConfiguration=Debug  

```
|                              Method |    N |         Mean |      Error |     StdDev |       Median |
|------------------------------------ |----- |-------------:|-----------:|-----------:|-------------:|
|                 **ClearForcesOriginal** |   **10** |     **44.26 ns** |   **0.089 ns** |   **0.079 ns** |     **44.23 ns** |
|                      FastClearForce |   10 |     58.56 ns |   0.492 ns |   0.460 ns |     58.49 ns |
|    ClearForcesOptimizedWithCopyTemp |   10 |     49.65 ns |   0.216 ns |   0.202 ns |     49.53 ns |
| ClearForcesOptimizedWithoutCopyTemp |   10 |    100.51 ns |   0.055 ns |   0.049 ns |    100.50 ns |
|    ClearForcesOptimizedWithParallel |   10 |  4,399.39 ns |  86.572 ns | 164.713 ns |  4,394.63 ns |
|                 **ClearForcesOriginal** |  **100** |    **378.45 ns** |   **1.237 ns** |   **1.033 ns** |    **378.35 ns** |
|                      FastClearForce |  100 |    404.42 ns |   0.396 ns |   0.351 ns |    404.46 ns |
|    ClearForcesOptimizedWithCopyTemp |  100 |    432.95 ns |   2.329 ns |   2.178 ns |    431.63 ns |
| ClearForcesOptimizedWithoutCopyTemp |  100 |    854.66 ns |   8.756 ns |   8.191 ns |    861.25 ns |
|    ClearForcesOptimizedWithParallel |  100 |  6,305.87 ns | 118.583 ns | 105.121 ns |  6,297.16 ns |
|                 **ClearForcesOriginal** | **1000** |  **3,666.26 ns** |   **6.429 ns** |   **5.368 ns** |  **3,666.52 ns** |
|                      FastClearForce | 1000 |  3,871.98 ns |   5.748 ns |   4.800 ns |  3,871.97 ns |
|    ClearForcesOptimizedWithCopyTemp | 1000 |  4,228.15 ns |  34.695 ns |  32.454 ns |  4,243.83 ns |
| ClearForcesOptimizedWithoutCopyTemp | 1000 |  7,373.84 ns |   7.795 ns |   6.910 ns |  7,374.15 ns |
|    ClearForcesOptimizedWithParallel | 1000 | 15,967.48 ns | 312.979 ns | 448.865 ns | 16,027.29 ns |
