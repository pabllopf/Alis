``` ini

BenchmarkDotNet=v0.13.2, OS=macOS Monterey 12.6 (21G115) [Darwin 21.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), Arm64 RyuJIT AdvSIMD
  Job-ZQBDCE : .NET 6.0.10 (6.0.1022.47605), Arm64 RyuJIT AdvSIMD DEBUG

BuildConfiguration=Debug  

```
| Method |      Mean |     Error |    StdDev |
|------- |----------:|----------:|----------:|
| Sha256 |  4.315 μs | 0.0045 μs | 0.0035 μs |
|    Md5 | 19.179 μs | 0.3489 μs | 0.3093 μs |
