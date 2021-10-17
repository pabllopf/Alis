``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1288 (21H1/May2021Update)
Intel Core i5-7200U CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.401
  [Host]     : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT  [AttachedDebugger]
  Job-TDJCIA : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT

Platform=AnyCpu  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|             Method | size_of_list |       Mean |      Error |    StdDev |        Min |        Max |  Gen 0 | Allocated |
|------------------- |------------- |-----------:|-----------:|----------:|-----------:|-----------:|-------:|----------:|
|      **Test_With_For** |           **10** |  **0.6380 ns** |  **0.2126 ns** | **0.0117 ns** |  **0.6301 ns** |  **0.6514 ns** |      **-** |         **-** |
|  Test_With_Foreach |           10 |  4.0802 ns |  3.8326 ns | 0.2101 ns |  3.9318 ns |  4.3206 ns |      - |         - |
|  Test_With_ForEach |           10 |  2.1568 ns |  2.6622 ns | 0.1459 ns |  2.0647 ns |  2.3251 ns |      - |         - |
| Test_With_Parallel |           10 | 75.3483 ns | 25.4661 ns | 1.3959 ns | 73.7386 ns | 76.2249 ns | 0.1428 |     224 B |
|      **Test_With_For** |         **1000** |  **0.6940 ns** |  **1.2044 ns** | **0.0660 ns** |  **0.6258 ns** |  **0.7576 ns** |      **-** |         **-** |
|  Test_With_Foreach |         1000 |  4.1868 ns |  6.7584 ns | 0.3704 ns |  3.9350 ns |  4.6122 ns |      - |         - |
|  Test_With_ForEach |         1000 |  2.0034 ns |  2.6019 ns | 0.1426 ns |  1.8583 ns |  2.1434 ns |      - |         - |
| Test_With_Parallel |         1000 | 74.2064 ns | 25.3977 ns | 1.3921 ns | 72.7661 ns | 75.5447 ns | 0.1428 |     224 B |
|      **Test_With_For** |       **100000** |  **0.6768 ns** |  **0.9387 ns** | **0.0515 ns** |  **0.6431 ns** |  **0.7361 ns** |      **-** |         **-** |
|  Test_With_Foreach |       100000 |  3.9571 ns |  0.9127 ns | 0.0500 ns |  3.9016 ns |  3.9988 ns |      - |         - |
|  Test_With_ForEach |       100000 |  2.0752 ns |  0.9995 ns | 0.0548 ns |  2.0344 ns |  2.1375 ns |      - |         - |
| Test_With_Parallel |       100000 | 77.8559 ns | 67.9943 ns | 3.7270 ns | 75.4496 ns | 82.1490 ns | 0.1428 |     224 B |
