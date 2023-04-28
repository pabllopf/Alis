``` ini

BenchmarkDotNet=v0.13.2, OS=macOS 13.2.1 (22D68) [Darwin 22.3.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=6.0.405
  [Host]     : .NET 6.0.13 (6.0.1322.58009), Arm64 RyuJIT AdvSIMD DEBUG
  Job-TXELPQ : .NET 6.0.13 (6.0.1322.58009), Arm64 RyuJIT AdvSIMD DEBUG

BuildConfiguration=Debug  

```
| Method |      Mean |     Error |    StdDev |
|------- |----------:|----------:|----------:|
| Sha256 |  4.336 μs | 0.0299 μs | 0.0279 μs |
|    Md5 | 18.997 μs | 0.1072 μs | 0.0896 μs |
