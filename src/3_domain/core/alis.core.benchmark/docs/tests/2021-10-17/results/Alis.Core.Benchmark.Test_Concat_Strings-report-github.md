``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1288 (21H1/May2021Update)
Intel Core i5-7200U CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.401
  [Host]     : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT  [AttachedDebugger]
  Job-GGJSEI : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT

Platform=AnyCpu  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                            Method | numOfStrings |      Mean |      Error |    StdDev |  Gen 0 |  Gen 1 | Allocated |
|---------------------------------- |------------- |----------:|-----------:|----------:|-------:|-------:|----------:|
|     **Test_String_Concat_2_Elements** |           **10** |  **17.81 ns** |   **9.027 ns** |  **0.495 ns** | **0.0408** |      **-** |      **64 B** |
| Test_String_Concat_Ref_2_Elements |           10 |  20.03 ns |   5.682 ns |  0.311 ns | 0.0408 |      - |      64 B |
|     Test_String_Format_2_Elements |           10 |  91.77 ns |  15.007 ns |  0.823 ns | 0.0408 |      - |      64 B |
|     Test_StringBuilder_2_Elements |           10 |  83.78 ns |   1.895 ns |  0.104 ns | 0.1733 |      - |     272 B |
|                Test_String_Concat |           10 |  39.64 ns |   4.563 ns |  0.250 ns | 0.0561 | 0.0002 |      88 B |
|            Test_String_Concat_REF |           10 |  39.71 ns |   2.410 ns |  0.132 ns | 0.0561 | 0.0001 |      88 B |
|                Test_String_Format |           10 | 153.26 ns | 252.174 ns | 13.823 ns | 0.0560 |      - |      88 B |
|                Test_StringBuilder |           10 | 110.32 ns | 149.458 ns |  8.192 ns | 0.1887 |      - |     296 B |
|     **Test_String_Concat_2_Elements** |         **1000** |  **17.01 ns** |   **4.496 ns** |  **0.246 ns** | **0.0408** |      **-** |      **64 B** |
| Test_String_Concat_Ref_2_Elements |         1000 |  20.41 ns |   2.247 ns |  0.123 ns | 0.0408 |      - |      64 B |
|     Test_String_Format_2_Elements |         1000 |  93.76 ns |  18.313 ns |  1.004 ns | 0.0408 |      - |      64 B |
|     Test_StringBuilder_2_Elements |         1000 |  84.32 ns |   7.467 ns |  0.409 ns | 0.1733 |      - |     272 B |
|                Test_String_Concat |         1000 |  40.34 ns |  19.595 ns |  1.074 ns | 0.0561 | 0.0002 |      88 B |
|            Test_String_Concat_REF |         1000 |  41.38 ns |  11.536 ns |  0.632 ns | 0.0561 | 0.0002 |      88 B |
|                Test_String_Format |         1000 | 127.07 ns |  42.680 ns |  2.339 ns | 0.0560 |      - |      88 B |
|                Test_StringBuilder |         1000 | 109.72 ns |  58.832 ns |  3.225 ns | 0.1887 |      - |     296 B |
|     **Test_String_Concat_2_Elements** |       **100000** |  **17.16 ns** |   **3.882 ns** |  **0.213 ns** | **0.0408** |      **-** |      **64 B** |
| Test_String_Concat_Ref_2_Elements |       100000 |  19.67 ns |   2.685 ns |  0.147 ns | 0.0408 |      - |      64 B |
|     Test_String_Format_2_Elements |       100000 |  92.08 ns |  21.477 ns |  1.177 ns | 0.0408 |      - |      64 B |
|     Test_StringBuilder_2_Elements |       100000 |  86.97 ns |  16.809 ns |  0.921 ns | 0.1733 |      - |     272 B |
|                Test_String_Concat |       100000 |  39.61 ns |   5.029 ns |  0.276 ns | 0.0561 | 0.0002 |      88 B |
|            Test_String_Concat_REF |       100000 |  41.81 ns |  17.942 ns |  0.983 ns | 0.0561 | 0.0002 |      88 B |
|                Test_String_Format |       100000 | 127.44 ns |  50.893 ns |  2.790 ns | 0.0560 |      - |      88 B |
|                Test_StringBuilder |       100000 | 106.44 ns |  31.514 ns |  1.727 ns | 0.1887 |      - |     296 B |
