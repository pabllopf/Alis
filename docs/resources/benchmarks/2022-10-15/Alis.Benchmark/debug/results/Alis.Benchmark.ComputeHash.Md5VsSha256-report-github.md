``` ini

BenchmarkDotNet=v0.13.2, OS=macOS Monterey 12.6 (21G115) [Darwin 21.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.401
  [Host]     : .NET 6.0.9 (6.0.922.41905), Arm64 RyuJIT AdvSIMD DEBUG
  Job-LNZMTJ : .NET 6.0.9 (6.0.922.41905), Arm64 RyuJIT AdvSIMD DEBUG

BuildConfiguration=Debug  

```
| Method |      Mean |     Error |    StdDev |
|------- |----------:|----------:|----------:|
| Sha256 |  4.318 μs | 0.0056 μs | 0.0050 μs |
|    Md5 | 19.011 μs | 0.0096 μs | 0.0085 μs |
