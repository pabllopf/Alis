```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4890/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-13800H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.202
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2
  Job-XLTWLZ : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method           | EntityCount | Mean      | Error     | StdDev     | Median    | Gen0      | Gen1      | Gen2      | Allocated   |
|----------------- |------------ |----------:|----------:|-----------:|----------:|----------:|----------:|----------:|------------:|
| Alis_Bulk        | 100000      |  1.202 ms | 0.0506 ms |  0.1444 ms |  1.176 ms |         - |         - |         - |  2541.75 KB |
| Frent_Bulk       | 100000      |  1.581 ms | 0.1451 ms |  0.4232 ms |  1.374 ms |         - |         - |         - |  2541.47 KB |
| Alis             | 100000      |  2.036 ms | 0.1422 ms |  0.4012 ms |  1.966 ms |         - |         - |         - |  2541.75 KB |
| Frent            | 100000      |  2.761 ms | 0.1779 ms |  0.5217 ms |  2.494 ms |         - |         - |         - |  2541.75 KB |
| FrifloEngineEcs  | 100000      |  4.282 ms | 0.3156 ms |  0.9306 ms |  4.256 ms |         - |         - |         - |  3381.74 KB |
| Arch             | 100000      |  5.880 ms | 0.6240 ms |  1.8005 ms |  5.453 ms |         - |         - |         - |  3178.44 KB |
| LeopotamEcsLite  | 100000      |  6.648 ms | 0.5736 ms |  1.6913 ms |  6.244 ms |         - |         - |         - |  7151.08 KB |
| FlecsNet         | 100000      |  9.805 ms | 0.2443 ms |  0.6520 ms |  9.543 ms |         - |         - |         - |     2.73 KB |
| TinyEcs          | 100000      | 11.330 ms | 1.0724 ms |  3.1620 ms | 12.310 ms |         - |         - |         - |  5977.53 KB |
| LeopotamEcs      | 100000      | 11.743 ms | 0.8238 ms |  2.4289 ms | 12.004 ms |         - |         - |         - | 13685.65 KB |
| DefaultEcs       | 100000      | 12.712 ms | 0.7123 ms |  2.0666 ms | 13.361 ms |         - |         - |         - | 11321.11 KB |
| Fennecs          | 100000      | 20.010 ms | 0.9793 ms |  2.8567 ms | 19.695 ms |         - |         - |         - | 13636.45 KB |
| Myriad           | 100000      | 20.056 ms | 1.3287 ms |  3.6148 ms | 18.762 ms |         - |         - |         - |  7633.16 KB |
| MonoGameExtended | 100000      | 22.945 ms | 1.8484 ms |  5.4500 ms | 22.507 ms |         - |         - |         - | 16408.61 KB |
| HypEcs           | 100000      | 25.130 ms | 2.4060 ms |  7.0564 ms | 23.905 ms | 1000.0000 | 1000.0000 |         - | 25826.77 KB |
| Morpeh_Direct    | 100000      | 28.889 ms | 2.1289 ms |  6.1762 ms | 28.019 ms | 1000.0000 | 1000.0000 | 1000.0000 |  33833.4 KB |
| Morpeh_Stash     | 100000      | 36.508 ms | 3.3803 ms |  9.8604 ms | 34.970 ms | 1000.0000 | 1000.0000 | 1000.0000 |  33833.4 KB |
| RelEcs           | 100000      | 44.522 ms | 3.9520 ms | 11.5905 ms | 38.970 ms | 1000.0000 | 1000.0000 |         - | 29706.66 KB |
| SveltoECS        | 100000      | 54.014 ms | 3.4211 ms | 10.0873 ms | 56.535 ms |         - |         - |         - |      3.2 KB |
