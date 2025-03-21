```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.3.2 (24D81) [Darwin 24.3.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD


```
| Method                                           | ArraySize | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------- |---------- |------------:|----------:|----------:|-------:|----------:|
| &#39;[UNSAFE] Iteration over NativeArrayUnsafe&#39;      | 2         |   0.0193 ns | 0.0106 ns | 0.0099 ns |      - |         - |
| &#39;[SAFE] Iteration over NativeArray&#39;              | 2         |   7.7986 ns | 0.1039 ns | 0.0972 ns | 0.0076 |      64 B |
| &#39;[FASTEST] Iteration over FastestArray&#39;          | 2         |   1.4854 ns | 0.0145 ns | 0.0129 ns |      - |         - |
| &#39;[FASTEST SAFE] Iteration over FastArraySafe&#39;    | 2         |   0.2719 ns | 0.0050 ns | 0.0042 ns |      - |         - |
| &#39;[UNSAFE] Resize NativeArrayUnsafe&#39;              | 2         |  12.9504 ns | 0.0551 ns | 0.0516 ns |      - |         - |
| &#39;[SAFE] Resize NativeArray&#39;                      | 2         |  13.6000 ns | 0.0986 ns | 0.0923 ns |      - |         - |
| &#39;[FASTEST] Resize FastestArray&#39;                  | 2         |  11.9977 ns | 0.1335 ns | 0.1114 ns |      - |         - |
| &#39;[FASTEST SAFE] Resize FastArraySafe&#39;            | 2         |   0.6662 ns | 0.0130 ns | 0.0121 ns |      - |         - |
| &#39;[UNSAFE] Assignment NativeArrayUnsafe&#39;          | 2         |   0.0144 ns | 0.0149 ns | 0.0124 ns |      - |         - |
| &#39;[SAFE] Assignment NativeArray&#39;                  | 2         |   7.8043 ns | 0.0677 ns | 0.0600 ns | 0.0076 |      64 B |
| &#39;[FASTEST] Assignment FastestArray&#39;              | 2         |   1.4915 ns | 0.0143 ns | 0.0134 ns |      - |         - |
| &#39;[FASTEST SAFE] Assignment FastArraySafe&#39;        | 2         |   0.2793 ns | 0.0061 ns | 0.0054 ns |      - |         - |
| &#39;[UNSAFE] Sequential Access NativeArrayUnsafe&#39;   | 2         |   0.0179 ns | 0.0072 ns | 0.0064 ns |      - |         - |
| &#39;[SAFE] Sequential Access NativeArray&#39;           | 2         |   7.2195 ns | 0.1227 ns | 0.1025 ns | 0.0076 |      64 B |
| &#39;[FASTEST] Sequential Access FastestArray&#39;       | 2         |   1.4380 ns | 0.0258 ns | 0.0242 ns |      - |         - |
| &#39;[FASTEST SAFE] Sequential Access FastArraySafe&#39; | 2         |   0.2793 ns | 0.0098 ns | 0.0087 ns |      - |         - |
| &#39;[UNSAFE] Random Access NativeArrayUnsafe&#39;       | 2         | 194.4250 ns | 1.5570 ns | 1.3802 ns | 0.0086 |      72 B |
| &#39;[SAFE] Random Access NativeArray&#39;               | 2         | 201.0394 ns | 1.5784 ns | 1.4765 ns | 0.0162 |     136 B |
| &#39;[FASTEST] Random Access FastestArray&#39;           | 2         | 197.0772 ns | 1.5413 ns | 1.3664 ns | 0.0086 |      72 B |
| &#39;[FASTEST SAFE] Random Access FastArraySafe&#39;     | 2         | 194.8108 ns | 1.9604 ns | 1.8337 ns | 0.0086 |      72 B |
| &#39;[UNSAFE] Dispose NativeArrayUnsafe&#39;             | 2         |   2.5757 ns | 0.0502 ns | 0.0470 ns |      - |         - |
| &#39;[SAFE] Dispose NativeArray&#39;                     | 2         |   1.4095 ns | 0.0166 ns | 0.0147 ns |      - |         - |
| &#39;[FASTEST] Dispose FastestArray&#39;                 | 2         |   0.2684 ns | 0.0089 ns | 0.0083 ns |      - |         - |
| &#39;[FASTEST SAFE] Dispose FastArraySafe&#39;           | 2         |   0.3469 ns | 0.0069 ns | 0.0058 ns |      - |         - |
| &#39;[UNSAFE] AsSpan NativeArrayUnsafe&#39;              | 2         |   0.2779 ns | 0.0194 ns | 0.0181 ns |      - |         - |
| &#39;[SAFE] AsSpan NativeArray&#39;                      | 2         |   3.5853 ns | 0.0886 ns | 0.1242 ns | 0.0038 |      32 B |
| &#39;[FASTEST] AsSpan FastestArray&#39;                  | 2         |   0.7004 ns | 0.0144 ns | 0.0135 ns |      - |         - |
| &#39;[FASTEST SAFE] AsSpan FastArraySafe&#39;            | 2         |   0.2624 ns | 0.0072 ns | 0.0067 ns |      - |         - |
| &#39;[UNSAFE] AsSpanLen NativeArrayUnsafe&#39;           | 2         |   0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| &#39;[SAFE] AsSpanLen NativeArray&#39;                   | 2         |   3.7968 ns | 0.0256 ns | 0.0227 ns | 0.0038 |      32 B |
| &#39;[FASTEST] AsSpanLen FastestArray&#39;               | 2         |   0.8631 ns | 0.0106 ns | 0.0083 ns |      - |         - |
| &#39;[FASTEST SAFE] AsSpanLen FastArraySafe&#39;         | 2         |   0.2829 ns | 0.0178 ns | 0.0166 ns |      - |         - |
