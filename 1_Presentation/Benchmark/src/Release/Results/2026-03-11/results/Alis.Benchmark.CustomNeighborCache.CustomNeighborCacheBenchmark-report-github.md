```

BenchmarkDotNet v0.14.0, macOS 26.3.1 (25D2128) [Darwin 25.3.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 10.0.103
  [Host] : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=Release  Runtime=.NET 8.0  Force=True  
Server=True  BuildConfiguration=Release  Toolchain=InProcessEmitToolchain  
InvocationCount=1  UnrollFactor=1  

```
| Method                   | EntityCount | Arity | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------- |------------ |------ |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| **Alis_Neighbor_AddRemove**  | **1000**        | **1**     | **249.3 μs** |  **4.94 μs** | **10.19 μs** |  **0.88** |    **0.05** |   **1.38 KB** |        **1.02** |
| Frent_Neighbor_AddRemove | 1000        | 1     | 285.3 μs |  5.63 μs | 13.28 μs |  1.00 |    0.06 |   1.35 KB |        1.00 |
|                          |             |       |          |          |          |       |         |           |             |
| **Alis_Neighbor_AddRemove**  | **1000**        | **2**     | **296.9 μs** |  **7.07 μs** | **20.52 μs** |  **0.92** |    **0.08** |   **1.47 KB** |        **1.02** |
| Frent_Neighbor_AddRemove | 1000        | 2     | 323.4 μs |  6.43 μs | 17.16 μs |  1.00 |    0.07 |   1.45 KB |        1.00 |
|                          |             |       |          |          |          |       |         |           |             |
| **Alis_Neighbor_AddRemove**  | **1000**        | **3**     | **321.6 μs** |  **6.41 μs** |  **8.56 μs** |  **0.85** |    **0.04** |   **1.56 KB** |        **1.02** |
| Frent_Neighbor_AddRemove | 1000        | 3     | 377.0 μs |  7.45 μs | 15.71 μs |  1.00 |    0.06 |   1.54 KB |        1.00 |
|                          |             |       |          |          |          |       |         |           |             |
| **Alis_Neighbor_AddRemove**  | **1000**        | **4**     | **357.8 μs** |  **7.14 μs** | **11.73 μs** |  **0.85** |    **0.04** |   **1.66 KB** |        **1.01** |
| Frent_Neighbor_AddRemove | 1000        | 4     | 421.8 μs |  8.24 μs | 15.28 μs |  1.00 |    0.05 |   1.63 KB |        1.00 |
|                          |             |       |          |          |          |       |         |           |             |
| **Alis_Neighbor_AddRemove**  | **1000**        | **5**     | **403.9 μs** |  **8.00 μs** | **15.61 μs** |  **0.86** |    **0.05** |   **1.75 KB** |        **1.01** |
| Frent_Neighbor_AddRemove | 1000        | 5     | 472.0 μs |  8.99 μs | 18.97 μs |  1.00 |    0.06 |   1.73 KB |        1.00 |
|                          |             |       |          |          |          |       |         |           |             |
| **Alis_Neighbor_AddRemove**  | **1000**        | **6**     | **436.7 μs** |  **8.54 μs** | **17.63 μs** |  **0.82** |    **0.05** |   **1.84 KB** |        **1.01** |
| Frent_Neighbor_AddRemove | 1000        | 6     | 533.0 μs | 10.33 μs | 21.11 μs |  1.00 |    0.05 |   1.82 KB |        1.00 |
|                          |             |       |          |          |          |       |         |           |             |
| **Alis_Neighbor_AddRemove**  | **1000**        | **7**     | **511.6 μs** |  **9.94 μs** | **17.15 μs** |  **0.89** |    **0.03** |   **1.94 KB** |        **1.01** |
| Frent_Neighbor_AddRemove | 1000        | 7     | 577.0 μs | 11.24 μs | 12.03 μs |  1.00 |    0.03 |   1.91 KB |        1.00 |
|                          |             |       |          |          |          |       |         |           |             |
| **Alis_Neighbor_AddRemove**  | **1000**        | **8**     | **534.5 μs** | **10.50 μs** | **21.21 μs** |  **0.83** |    **0.04** |   **2.03 KB** |        **1.01** |
| Frent_Neighbor_AddRemove | 1000        | 8     | 642.1 μs | 12.49 μs | 21.20 μs |  1.00 |    0.05 |   2.01 KB |        1.00 |
