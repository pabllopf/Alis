``` ini

BenchmarkDotNet=v0.13.2, OS=macOS 13.2.1 (22D68) [Darwin 22.3.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=6.0.405
  [Host]     : .NET 6.0.13 (6.0.1322.58009), Arm64 RyuJIT AdvSIMD DEBUG
  Job-JLXWTO : .NET 6.0.13 (6.0.1322.58009), Arm64 RyuJIT AdvSIMD DEBUG

BuildConfiguration=Debug  

```
|                                   Method |    N |        Mean |     Error |    StdDev |
|----------------------------------------- |----- |------------:|----------:|----------:|
|                      **ClearForcesOriginal** |   **10** |    **44.37 ns** |  **0.098 ns** |  **0.077 ns** |
|    Clear_Forces_Optimized_with_copy_temp |   10 |    49.51 ns |  0.110 ns |  0.097 ns |
| Clear_Forces_Optimized_without_copy_temp |   10 |    99.19 ns |  0.505 ns |  0.447 ns |
|                      **ClearForcesOriginal** |  **100** |   **391.71 ns** |  **4.684 ns** |  **4.152 ns** |
|    Clear_Forces_Optimized_with_copy_temp |  100 |   447.40 ns |  1.806 ns |  1.689 ns |
| Clear_Forces_Optimized_without_copy_temp |  100 |   862.05 ns |  4.130 ns |  3.224 ns |
|                      **ClearForcesOriginal** | **1000** | **3,857.99 ns** | **53.701 ns** | **50.232 ns** |
|    Clear_Forces_Optimized_with_copy_temp | 1000 | 4,377.81 ns | 80.317 ns | 75.128 ns |
| Clear_Forces_Optimized_without_copy_temp | 1000 | 8,440.55 ns | 30.237 ns | 23.607 ns |
