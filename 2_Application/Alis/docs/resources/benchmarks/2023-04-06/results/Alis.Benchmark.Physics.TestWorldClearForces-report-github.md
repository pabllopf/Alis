``` ini

BenchmarkDotNet=v0.13.2, OS=macOS 13.2.1 (22D68) [Darwin 22.3.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=6.0.405
  [Host]     : .NET 6.0.13 (6.0.1322.58009), Arm64 RyuJIT AdvSIMD DEBUG
  Job-TXELPQ : .NET 6.0.13 (6.0.1322.58009), Arm64 RyuJIT AdvSIMD DEBUG

BuildConfiguration=Debug  

```
|                              Method |       N |            Mean |         Error |        StdDev |
|------------------------------------ |-------- |----------------:|--------------:|--------------:|
|                 **ClearForcesOriginal** |      **10** |        **44.84 ns** |      **0.342 ns** |      **0.320 ns** |
|    ClearForcesOptimizedWithCopyTemp |      10 |        50.23 ns |      0.380 ns |      0.317 ns |
| ClearForcesOptimizedWithoutCopyTemp |      10 |       100.63 ns |      0.723 ns |      0.641 ns |
|    ClearForcesOptimizedWithParallel |      10 |     5,560.00 ns |    110.508 ns |    308.051 ns |
|                 **ClearForcesOriginal** |     **100** |       **380.06 ns** |      **1.070 ns** |      **1.001 ns** |
|    ClearForcesOptimizedWithCopyTemp |     100 |       444.71 ns |      8.351 ns |      7.811 ns |
| ClearForcesOptimizedWithoutCopyTemp |     100 |       862.89 ns |     10.933 ns |      9.691 ns |
|    ClearForcesOptimizedWithParallel |     100 |     7,972.56 ns |    169.167 ns |    479.900 ns |
|                 **ClearForcesOriginal** |    **1000** |     **3,694.43 ns** |      **7.894 ns** |      **7.384 ns** |
|    ClearForcesOptimizedWithCopyTemp |    1000 |     4,214.51 ns |     14.186 ns |     12.576 ns |
| ClearForcesOptimizedWithoutCopyTemp |    1000 |     7,455.77 ns |     19.299 ns |     18.053 ns |
|    ClearForcesOptimizedWithParallel |    1000 |    20,546.34 ns |    409.685 ns |  1,148.801 ns |
|                 **ClearForcesOriginal** | **1000000** | **3,733,851.44 ns** |  **9,223.872 ns** |  **8,176.723 ns** |
|    ClearForcesOptimizedWithCopyTemp | 1000000 | 4,492,155.66 ns | 52,450.744 ns | 49,062.458 ns |
| ClearForcesOptimizedWithoutCopyTemp | 1000000 | 8,045,863.68 ns | 40,997.988 ns | 38,349.544 ns |
|    ClearForcesOptimizedWithParallel | 1000000 | 1,641,198.02 ns | 11,241.709 ns |  8,776.787 ns |
