``` ini

BenchmarkDotNet=v0.13.2, OS=macOS 13.2.1 (22D68) [Darwin 22.3.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=6.0.405
  [Host]     : .NET 6.0.13 (6.0.1322.58009), Arm64 RyuJIT AdvSIMD DEBUG
  Job-OFZKDV : .NET 6.0.13 (6.0.1322.58009), Arm64 RyuJIT AdvSIMD DEBUG

BuildConfiguration=Debug  

```
|    Method |    N |        Mean |     Error |   StdDev |
|---------- |----- |------------:|----------:|---------:|
|  **Original** |   **10** |    **45.78 ns** |  **0.114 ns** | **0.089 ns** |
| Optimized |   10 |    50.80 ns |  0.457 ns | 0.427 ns |
|  **Original** |  **100** |   **385.65 ns** |  **1.956 ns** | **1.734 ns** |
| Optimized |  100 |   439.43 ns |  2.287 ns | 2.027 ns |
|  **Original** | **1000** | **3,721.14 ns** | **10.039 ns** | **9.391 ns** |
| Optimized | 1000 | 4,217.72 ns | 10.498 ns | 9.307 ns |
