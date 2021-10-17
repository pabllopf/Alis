``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1288 (21H1/May2021Update)
Intel Core i5-7200U CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.401
  [Host]     : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT  [AttachedDebugger]
  Job-OPIKZU : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT

Platform=AnyCpu  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                               Method | numOfStrings |            Mean |            Error |        StdDev |             Min |             Max |      Gen 0 |  Gen 1 |    Allocated |
|------------------------------------- |------------- |----------------:|-----------------:|--------------:|----------------:|----------------:|-----------:|-------:|-------------:|
|        Test_String_Concat_2_Elements |         1000 |        18.30 ns |         4.983 ns |      0.273 ns |        18.07 ns |        18.60 ns |     0.0408 |      - |         64 B |
|    Test_String_Concat_Ref_2_Elements |         1000 |        20.95 ns |        10.766 ns |      0.590 ns |        20.37 ns |        21.55 ns |     0.0408 |      - |         64 B |
|        Test_String_Format_2_Elements |         1000 |        88.90 ns |        26.631 ns |      1.460 ns |        87.52 ns |        90.43 ns |     0.0408 |      - |         64 B |
|           Test_String_Add_2_Elements |         1000 |        17.92 ns |         7.995 ns |      0.438 ns |        17.41 ns |        18.18 ns |     0.0408 |      - |         64 B |
|        Test_StringBuilder_2_Elements |         1000 |        82.34 ns |         1.739 ns |      0.095 ns |        82.25 ns |        82.44 ns |     0.1733 |      - |        272 B |
|     Test_String_Concat_1000_Elements |         1000 |        40.15 ns |        12.043 ns |      0.660 ns |        39.42 ns |        40.70 ns |     0.0561 | 0.0002 |         88 B |
| Test_String_Concat_REF_1000_Elements |         1000 |        40.02 ns |         8.194 ns |      0.449 ns |        39.64 ns |        40.51 ns |     0.0561 | 0.0002 |         88 B |
|     Test_String_Format_1000_Elements |         1000 |       126.65 ns |        19.866 ns |      1.089 ns |       125.78 ns |       127.87 ns |     0.0560 |      - |         88 B |
|        Test_String_Add_1000_Elements |         1000 | 4,043,732.29 ns | 1,065,111.161 ns | 58,382.337 ns | 3,992,926.56 ns | 4,107,509.38 ns | 27398.4375 |      - | 43,432,120 B |
|     Test_StringBuilder_1000_Elements |         1000 |       105.67 ns |        18.208 ns |      0.998 ns |       104.58 ns |       106.54 ns |     0.1887 |      - |        296 B |
