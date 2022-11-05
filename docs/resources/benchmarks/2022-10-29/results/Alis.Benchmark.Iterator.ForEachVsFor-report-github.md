``` ini

BenchmarkDotNet=v0.13.2, OS=macOS Monterey 12.6 (21G115) [Darwin 21.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), Arm64 RyuJIT AdvSIMD
  Job-ZQBDCE : .NET 6.0.10 (6.0.1022.47605), Arm64 RyuJIT AdvSIMD DEBUG

BuildConfiguration=Debug  

```
|  Method |      Mean |     Error |    StdDev |
|-------- |----------:|----------:|----------:|
| Foreach | 0.0535 ns | 0.0059 ns | 0.0050 ns |
|     For | 0.0000 ns | 0.0000 ns | 0.0000 ns |
