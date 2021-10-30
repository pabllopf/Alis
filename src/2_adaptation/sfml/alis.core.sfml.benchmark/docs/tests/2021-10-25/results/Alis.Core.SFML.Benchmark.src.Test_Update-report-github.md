``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1288 (21H1/May2021Update)
Intel Core i5-7200U CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.402
  [Host]     : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT  [AttachedDebugger]
  Job-PTTRIO : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT

Platform=AnyCpu  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                     Method | numOfElements |            Mean |         Error |        StdDev |  Gen 0 | Allocated |
|--------------------------- |-------------- |----------------:|--------------:|--------------:|-------:|----------:|
|           **NormalUpdateList** |           **128** |       **158.39 ns** |      **43.00 ns** |      **2.357 ns** |      **-** |         **-** |
|          NormalUpdateArray |           128 |       100.21 ns |      33.80 ns |      1.853 ns |      - |         - |
|              MemmoryUpdate |           128 |        77.52 ns |      25.91 ns |      1.420 ns |      - |         - |
|                 Array_span |           128 |        77.67 ns |      36.65 ns |      2.009 ns |      - |         - |
|          Array_span_base_4 |           128 |       186.97 ns |      50.71 ns |      2.780 ns |      - |         - |
|                 Fast_Array |           128 |        76.84 ns |      14.73 ns |      0.808 ns |      - |         - |
|        Fast_Array_Optimize |           128 |        95.46 ns |      20.99 ns |      1.150 ns |      - |         - |
| Fast_Array_Optimize_Base_4 |           128 |        75.49 ns |      35.23 ns |      1.931 ns |      - |         - |
| Fast_Array_Optimize_Asysnc |           128 |     2,148.35 ns |     139.09 ns |      7.624 ns | 0.5760 |     909 B |
|           **NormalUpdateList** |          **1024** |     **1,688.17 ns** |   **1,919.01 ns** |    **105.187 ns** |      **-** |         **-** |
|          NormalUpdateArray |          1024 |     1,272.41 ns |     379.25 ns |     20.788 ns |      - |         - |
|              MemmoryUpdate |          1024 |       999.06 ns |     332.53 ns |     18.227 ns |      - |         - |
|                 Array_span |          1024 |       972.22 ns |      83.94 ns |      4.601 ns |      - |         - |
|          Array_span_base_4 |          1024 |     1,409.96 ns |     420.26 ns |     23.036 ns |      - |         - |
|                 Fast_Array |          1024 |       997.24 ns |     278.18 ns |     15.248 ns |      - |         - |
|        Fast_Array_Optimize |          1024 |       983.15 ns |     389.84 ns |     21.369 ns |      - |         - |
| Fast_Array_Optimize_Base_4 |          1024 |       984.76 ns |     262.85 ns |     14.408 ns |      - |         - |
| Fast_Array_Optimize_Asysnc |          1024 |     2,935.17 ns |     446.79 ns |     24.490 ns | 0.5798 |     912 B |
|           **NormalUpdateList** |        **102400** |   **969,364.81 ns** | **470,096.79 ns** | **25,767.591 ns** |      **-** |         **-** |
|          NormalUpdateArray |        102400 |   939,980.89 ns |  87,388.27 ns |  4,790.046 ns |      - |         - |
|              MemmoryUpdate |        102400 | 1,043,876.46 ns | 421,391.75 ns | 23,097.904 ns |      - |         - |
|                 Array_span |        102400 | 1,026,390.36 ns | 580,546.06 ns | 31,821.689 ns |      - |         - |
|          Array_span_base_4 |        102400 |   139,078.17 ns |  55,971.36 ns |  3,067.979 ns |      - |         - |
|                 Fast_Array |        102400 | 1,035,902.83 ns | 581,750.63 ns | 31,887.715 ns |      - |         - |
|        Fast_Array_Optimize |        102400 | 1,037,615.69 ns | 544,730.82 ns | 29,858.534 ns |      - |         - |
| Fast_Array_Optimize_Base_4 |        102400 | 1,019,425.13 ns | 294,448.81 ns | 16,139.733 ns |      - |         - |
| Fast_Array_Optimize_Asysnc |        102400 |    69,431.47 ns |  30,537.02 ns |  1,673.837 ns | 0.4883 |     912 B |
