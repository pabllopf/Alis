``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1288 (21H1/May2021Update)
Intel Core i5-7200U CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.402
  [Host]     : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT  [AttachedDebugger]
  Job-PZZBOL : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT

Platform=AnyCpu  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```

|               Method | arraySize |            Mean |            Error |        StdDev | Allocated |
|--------------------- |---------- |----------------:|-----------------:|--------------:|----------:|
| **Update_With_For_Span** |        **10** |        **19.05 ns** |         **7.439 ns** |      **0.408 ns** |         **
-** |
| Update_Array_Foreach |        10 |        31.67 ns |         8.089 ns |      0.443 ns |         - |
| **Update_With_For_Span** |      **1000** |     **2,025.40 ns** |       **308.733 ns** |     **16.923 ns** |         **
-** |
| Update_Array_Foreach |      1000 |     2,908.62 ns |       457.564 ns |     25.081 ns |         - |
| **Update_With_For_Span** |    **100000** | **1,123,760.74 ns** | **1,592,009.803 ns** | **87,263.429 ns** |         **
-** |
| Update_Array_Foreach |    100000 | 1,024,450.85 ns |   504,722.791 ns | 27,665.559 ns |         - |
