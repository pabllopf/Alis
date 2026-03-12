```

BenchmarkDotNet v0.14.0, macOS 26.3.1 (25D2128) [Darwin 25.3.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 10.0.103
  [Host] : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=Release  Runtime=.NET 8.0  Force=True  
Server=True  BuildConfiguration=Release  Toolchain=InProcessEmitToolchain  
InvocationCount=1  UnrollFactor=1  

```
| Method                                                     | EntityCount | Mean      | Error    | StdDev    | Median    | Allocated |
|----------------------------------------------------------- |------------ |----------:|---------:|----------:|----------:|----------:|
| Alis_Create_With_One_Component                             | 1000        |  60.70 μs | 2.308 μs |  6.732 μs |  60.04 μs |  35.26 KB |
| Alis_Create_Bulk_With_One_Component                        | 1000        |  49.75 μs | 2.674 μs |  7.715 μs |  48.65 μs |  35.26 KB |
| Alis_Create_With_Two_Component                             | 1000        |  89.41 μs | 4.287 μs | 12.574 μs |  87.02 μs |  64.31 KB |
| Alis_Create_Bulk_With_Two_Component                        | 1000        |  66.52 μs | 2.909 μs |  8.576 μs |  66.04 μs |  39.28 KB |
| Alis_Create_With_Three_Component                           | 1000        | 114.14 μs | 3.500 μs | 10.265 μs | 112.88 μs |  72.63 KB |
| Alis_Create_Bulk_With_Thre_Component                       | 1000        |  72.86 μs | 1.981 μs |  5.715 μs |  71.92 μs |   43.3 KB |
| Alis_Create_With_Four_Component                            | 1000        | 119.49 μs | 4.137 μs | 12.133 μs | 119.02 μs |  80.95 KB |
| Alis_Create_Bulk_With_Four_Component                       | 1000        |  73.93 μs | 1.959 μs |  5.682 μs |  72.92 μs |  47.33 KB |
| Alis_Create_With_Five_Component                            | 1000        | 111.01 μs | 2.879 μs |  8.260 μs | 111.62 μs |  89.27 KB |
| Alis_Create_Bulk_With_Five_Component                       | 1000        |  71.84 μs | 3.673 μs | 10.771 μs |  71.79 μs |  51.35 KB |
| Alis_Create_With_Six_Component                             | 1000        | 114.47 μs | 3.522 μs | 10.217 μs | 115.75 μs |  97.59 KB |
| Alis_Create_Bulk_With_Six_Component                        | 1000        |  54.83 μs | 3.533 μs | 10.305 μs |  55.31 μs |  55.38 KB |
| Alis_Create_With_Seven_Component                           | 1000        | 119.65 μs | 2.571 μs |  7.500 μs | 119.69 μs | 105.91 KB |
| Alis_Create_Bulk_With_Seven_Component                      | 1000        |  64.43 μs | 3.149 μs |  9.137 μs |  65.67 μs |   59.4 KB |
| Alis_Create_With_Eight_Component                           | 1000        |  73.85 μs | 6.163 μs | 18.074 μs |  76.88 μs | 114.23 KB |
| Alis_Create_Bulk_With_Eight_Component                      | 1000        |  59.72 μs | 2.633 μs |  7.555 μs |  60.33 μs |  63.42 KB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_0     | 1000        |  61.10 μs | 7.943 μs | 23.045 μs |  56.96 μs |  57.78 KB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_0   | 1000        |  59.30 μs | 7.070 μs | 20.623 μs |  59.33 μs |  57.78 KB |
| Alis_SystemWithOneComponent_Simd_With_Padding_0            | 1000        |  48.11 μs | 5.803 μs | 16.928 μs |  50.08 μs |  57.78 KB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_10    | 1000        | 170.48 μs | 5.583 μs | 16.287 μs | 168.83 μs |  970.2 KB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_10  | 1000        | 171.83 μs | 4.241 μs | 12.303 μs | 171.83 μs |  970.2 KB |
| Alis_SystemWithOneComponent_Simd_With_Padding_10           | 1000        | 170.04 μs | 4.695 μs | 13.620 μs | 170.79 μs |  970.2 KB |
| Frent_Create_With_One_Component                            | 1000        |  38.39 μs | 4.875 μs | 14.220 μs |  41.12 μs |  26.72 KB |
| Frent_Create_Bulk_With_One_Component                       | 1000        |  45.32 μs | 6.195 μs | 17.972 μs |  47.62 μs |  26.72 KB |
| Frent_Create_With_Two_Component                            | 1000        |  46.77 μs | 5.286 μs | 15.420 μs |  48.75 μs |  55.75 KB |
| Frent_Create_Bulk_With_Two_Component                       | 1000        |  37.09 μs | 5.040 μs | 14.782 μs |  40.33 μs |  30.74 KB |
| Frent_Create_With_Three_Component                          | 1000        |  55.28 μs | 5.468 μs | 15.951 μs |  57.19 μs |  64.07 KB |
| Frent_Create_Bulk_With_Thre_Component                      | 1000        |  37.68 μs | 4.666 μs | 13.538 μs |  40.00 μs |  34.77 KB |
| Frent_Create_With_Four_Component                           | 1000        |  54.78 μs | 4.983 μs | 14.456 μs |  57.17 μs |  72.39 KB |
| Frent_Create_Bulk_With_Four_Component                      | 1000        |  48.11 μs | 3.366 μs |  9.766 μs |  46.58 μs |  38.79 KB |
| Frent_Create_With_Five_Component                           | 1000        | 111.43 μs | 3.907 μs | 11.398 μs | 112.71 μs |  80.71 KB |
| Frent_Create_Bulk_With_Five_Component                      | 1000        |  51.82 μs | 2.956 μs |  8.716 μs |  54.96 μs |  42.81 KB |
| Frent_Create_With_Six_Component                            | 1000        | 123.24 μs | 2.449 μs |  6.744 μs | 124.50 μs |  89.03 KB |
| Frent_Create_Bulk_With_Six_Component                       | 1000        |  45.23 μs | 3.419 μs |  9.973 μs |  42.27 μs |  46.84 KB |
| Frent_Create_With_Seven_Component                          | 1000        |  71.56 μs | 3.354 μs |  9.730 μs |  73.37 μs |  97.35 KB |
| Frent_Create_Bulk_With_Seven_Component                     | 1000        |  48.35 μs | 4.856 μs | 14.087 μs |  49.79 μs |  50.86 KB |
| Create_With_Eight_Component                                | 1000        |  65.75 μs | 3.743 μs | 10.978 μs |  64.08 μs | 105.67 KB |
| Frent_Create_Bulk_With_Eight_Component                     | 1000        |  42.21 μs | 5.092 μs | 14.854 μs |  43.12 μs |  54.88 KB |
| Frent_Create_With_Nine_Component                           | 1000        |  76.29 μs | 3.246 μs |  9.313 μs |  76.17 μs | 113.99 KB |
| Frent_Create_Bulk_With_Nine_Component                      | 1000        |  51.65 μs | 5.236 μs | 15.355 μs |  53.06 μs |  58.91 KB |
| Frent_Create_With_Ten_Component                            | 1000        |  79.47 μs | 3.971 μs | 11.583 μs |  79.31 μs | 122.31 KB |
| Frent_Create_Bulk_With_Ten_Component                       | 1000        |  55.19 μs | 5.299 μs | 15.287 μs |  55.46 μs |  62.93 KB |
| Frent_Create_With_Eleven_Component                         | 1000        |  79.77 μs | 4.370 μs | 12.678 μs |  78.08 μs | 130.63 KB |
| Frent_Create_Bulk_With_Eleven_Component                    | 1000        |  59.29 μs | 5.651 μs | 16.306 μs |  58.29 μs |  66.95 KB |
| Frent_Create_With_Twelve_Component                         | 1000        |  76.40 μs | 4.967 μs | 14.410 μs |  76.21 μs | 138.95 KB |
| Frent_Create_Bulk_With_Twelve_Component                    | 1000        |  58.16 μs | 5.032 μs | 14.438 μs |  57.50 μs |  70.98 KB |
| Frent_Create_With_Thirteen_Component                       | 1000        |  84.37 μs | 4.975 μs | 14.355 μs |  84.25 μs | 147.27 KB |
| Frent_Create_Bulk_With_Thirteen_Component                  | 1000        |  58.11 μs | 5.205 μs | 15.100 μs |  55.04 μs |     75 KB |
| Frent_Create_With_Fourteen_Component                       | 1000        |  87.53 μs | 3.983 μs | 11.618 μs |  87.77 μs | 155.59 KB |
| Frent_Create_Bulk_With_Fourteen_Component                  | 1000        |  58.90 μs | 4.590 μs | 13.243 μs |  56.33 μs |  79.02 KB |
| Frent_Create_With_Fifteen_Component                        | 1000        |  89.32 μs | 4.321 μs | 12.673 μs |  88.21 μs | 163.91 KB |
| Frent_Create_Bulk_With_Fifteen_Component                   | 1000        |  64.71 μs | 4.671 μs | 13.402 μs |  62.29 μs |  83.05 KB |
| Frent_Create_With_Sixteen_Component                        | 1000        |  87.73 μs | 5.124 μs | 14.946 μs |  85.21 μs | 172.23 KB |
| Frent_Create_Bulk_With_Sixteen_Component                   | 1000        |  55.72 μs | 4.524 μs | 13.125 μs |  57.58 μs |  87.07 KB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_0    | 1000        |  37.90 μs | 7.227 μs | 20.850 μs |  41.08 μs |  45.76 KB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_0  | 1000        |  41.54 μs | 7.926 μs | 22.994 μs |  46.12 μs |  45.76 KB |
| Frent_SystemWithOneComponent_Simd_With_Padding_0           | 1000        |  44.44 μs | 5.419 μs | 15.807 μs |  47.04 μs |  45.76 KB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_10   | 1000        | 169.85 μs | 5.246 μs | 15.136 μs | 168.98 μs | 718.17 KB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_10 | 1000        | 170.66 μs | 3.942 μs | 11.311 μs | 170.33 μs | 718.17 KB |
| Frent_SystemWithOneComponent_Simd_With_Padding_10          | 1000        | 156.26 μs | 6.445 μs | 18.594 μs | 151.98 μs | 718.17 KB |
