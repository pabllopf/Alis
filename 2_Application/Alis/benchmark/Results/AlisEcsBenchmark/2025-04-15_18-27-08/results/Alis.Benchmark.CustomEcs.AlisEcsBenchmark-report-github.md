```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.3.2 (24D81) [Darwin 24.3.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  InvocationCount=1  IterationCount=3  
LaunchCount=1  UnrollFactor=1  WarmupCount=3  

```
| Method                                                     | EntityCount | Mean       | Error       | StdDev     | Allocated |
|----------------------------------------------------------- |------------ |-----------:|------------:|-----------:|----------:|
| Alis_Create_With_One_Component                             | 1000000     |  11.672 ms |   3.5565 ms |  0.1949 ms |   24.8 MB |
| Alis_Create_Bulk_With_One_Component                        | 1000000     |   4.854 ms |  13.0525 ms |  0.7154 ms |   24.8 MB |
| Alis_Create_With_Two_Component                             | 1000000     |  10.336 ms |   3.9868 ms |  0.2185 ms |   52.8 MB |
| Alis_Create_Bulk_With_Two_Component                        | 1000000     |   5.459 ms |   3.0028 ms |  0.1646 ms |  28.61 MB |
| Alis_Create_With_Three_Component                           | 1000000     |  14.945 ms |   2.6127 ms |  0.1432 ms |   60.8 MB |
| Alis_Create_Bulk_With_Thre_Component                       | 1000000     |   5.498 ms |   2.4681 ms |  0.1353 ms |  32.43 MB |
| Alis_Create_With_Four_Component                            | 1000000     |  25.364 ms |   1.7479 ms |  0.0958 ms |   68.8 MB |
| Alis_Create_Bulk_With_Four_Component                       | 1000000     |   6.506 ms |   2.7971 ms |  0.1533 ms |  36.24 MB |
| Alis_Create_With_Five_Component                            | 1000000     |  10.902 ms |   7.0960 ms |  0.3890 ms |   76.8 MB |
| Alis_Create_Bulk_With_Five_Component                       | 1000000     |   6.591 ms |   3.4104 ms |  0.1869 ms |  40.06 MB |
| Alis_Create_With_Six_Component                             | 1000000     |  12.224 ms |   4.2374 ms |  0.2323 ms |   84.8 MB |
| Alis_Create_Bulk_With_Six_Component                        | 1000000     |   7.249 ms |   4.3755 ms |  0.2398 ms |  43.87 MB |
| Alis_Create_With_Seven_Component                           | 1000000     |  13.611 ms |   7.9952 ms |  0.4382 ms |   92.8 MB |
| Alis_Create_Bulk_With_Seven_Component                      | 1000000     |   8.065 ms |   2.2590 ms |  0.1238 ms |  47.69 MB |
| Alis_Create_With_Eight_Component                           | 1000000     |  15.299 ms |   2.2327 ms |  0.1224 ms |  100.8 MB |
| Alis_Create_Bulk_With_Eight_Component                      | 1000000     |   8.697 ms |   4.3503 ms |  0.2385 ms |   51.5 MB |
| Alis_Create_With_Nine_Component                            | 1000000     |  16.966 ms |   9.0684 ms |  0.4971 ms |  108.8 MB |
| Alis_Create_Bulk_With_Nine_Component                       | 1000000     |   9.036 ms |   1.2952 ms |  0.0710 ms |  55.32 MB |
| Alis_Create_With_Ten_Component                             | 1000000     |  17.766 ms |  11.9742 ms |  0.6563 ms |  116.8 MB |
| Alis_Create_Bulk_With_Ten_Component                        | 1000000     |   9.601 ms |   3.7924 ms |  0.2079 ms |  59.13 MB |
| Alis_Create_With_Eleven_Component                          | 1000000     |  21.032 ms |   8.6481 ms |  0.4740 ms |  124.8 MB |
| Alis_Create_Bulk_With_Eleven_Component                     | 1000000     |  10.187 ms |   2.7452 ms |  0.1505 ms |  62.94 MB |
| Alis_Create_With_Twelve_Component                          | 1000000     |  22.394 ms |  25.5261 ms |  1.3992 ms |  132.8 MB |
| Alis_Create_Bulk_With_Twelve_Component                     | 1000000     |  11.072 ms |   1.4526 ms |  0.0796 ms |  66.76 MB |
| Alis_Create_With_Thirteen_Component                        | 1000000     |  25.952 ms |   9.3090 ms |  0.5103 ms |  140.8 MB |
| Alis_Create_Bulk_With_Thirteen_Component                   | 1000000     |  11.323 ms |   2.8729 ms |  0.1575 ms |  70.57 MB |
| Alis_Create_With_Fourteen_Component                        | 1000000     |  32.162 ms |  17.9724 ms |  0.9851 ms |  148.8 MB |
| Alis_Create_Bulk_With_Fourteen_Component                   | 1000000     |  12.674 ms |  13.2140 ms |  0.7243 ms |  74.39 MB |
| Alis_Create_With_Fifteen_Component                         | 1000000     |  36.313 ms |  43.9368 ms |  2.4083 ms | 156.81 MB |
| Alis_Create_Bulk_With_Fifteen_Component                    | 1000000     |  12.833 ms |   4.0176 ms |  0.2202 ms |   78.2 MB |
| Alis_Create_With_Sixteen_Component                         | 1000000     |  40.642 ms |  48.3763 ms |  2.6517 ms | 164.81 MB |
| Alis_Create_Bulk_With_Sixteen_Component                    | 1000000     |  13.476 ms |   3.9562 ms |  0.2169 ms |  82.02 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_0     | 1000000     |   9.285 ms |   2.9366 ms |  0.1610 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_0   | 1000000     |   8.749 ms |  10.4027 ms |  0.5702 ms |  51.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_0            | 1000000     |   8.216 ms |   6.5462 ms |  0.3588 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_10    | 1000000     | 105.768 ms |  24.1371 ms |  1.3230 ms | 723.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_10  | 1000000     |  99.163 ms |  27.1033 ms |  1.4856 ms | 723.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_10           | 1000000     |  95.969 ms |  29.8310 ms |  1.6351 ms | 723.99 MB |
| Frent_Create_With_One_Component                            | 1000000     |  14.736 ms |   4.5666 ms |  0.2503 ms |   24.8 MB |
| Frent_Create_Bulk_With_One_Component                       | 1000000     |   4.623 ms |   0.7241 ms |  0.0397 ms |   24.8 MB |
| Frent_Create_With_Two_Component                            | 1000000     |  20.346 ms |   4.2006 ms |  0.2302 ms |   52.8 MB |
| Frent_Create_Bulk_With_Two_Component                       | 1000000     |   5.222 ms |   2.9472 ms |  0.1615 ms |  28.61 MB |
| Frent_Create_With_Three_Component                          | 1000000     |  23.313 ms |   4.9047 ms |  0.2688 ms |   60.8 MB |
| Frent_Create_Bulk_With_Thre_Component                      | 1000000     |   5.626 ms |   2.6793 ms |  0.1469 ms |  32.43 MB |
| Frent_Create_With_Four_Component                           | 1000000     |  26.492 ms |   4.6764 ms |  0.2563 ms |   68.8 MB |
| Frent_Create_Bulk_With_Four_Component                      | 1000000     |   6.487 ms |   3.9914 ms |  0.2188 ms |  36.24 MB |
| Frent_Create_With_Five_Component                           | 1000000     |  16.727 ms |   6.9563 ms |  0.3813 ms |   76.8 MB |
| Frent_Create_Bulk_With_Five_Component                      | 1000000     |   6.878 ms |   1.2778 ms |  0.0700 ms |  40.06 MB |
| Frent_Create_With_Six_Component                            | 1000000     |  17.745 ms |  11.1743 ms |  0.6125 ms |   84.8 MB |
| Frent_Create_Bulk_With_Six_Component                       | 1000000     |   7.585 ms |   2.6212 ms |  0.1437 ms |  43.87 MB |
| Frent_Create_With_Seven_Component                          | 1000000     |  20.197 ms |  24.8079 ms |  1.3598 ms |   92.8 MB |
| Frent_Create_Bulk_With_Seven_Component                     | 1000000     |   8.364 ms |  10.2567 ms |  0.5622 ms |  47.69 MB |
| Create_With_Eight_Component                                | 1000000     |  22.550 ms |   7.8008 ms |  0.4276 ms |  100.8 MB |
| Frent_Create_Bulk_With_Eight_Component                     | 1000000     |   8.813 ms |   7.5841 ms |  0.4157 ms |   51.5 MB |
| Frent_Create_With_Nine_Component                           | 1000000     |  23.871 ms |   9.0383 ms |  0.4954 ms |  108.8 MB |
| Frent_Create_Bulk_With_Nine_Component                      | 1000000     |   9.297 ms |   1.9388 ms |  0.1063 ms |  55.32 MB |
| Frent_Create_With_Ten_Component                            | 1000000     |  24.141 ms |   7.1349 ms |  0.3911 ms |  116.8 MB |
| Frent_Create_Bulk_With_Ten_Component                       | 1000000     |   9.698 ms |   4.6959 ms |  0.2574 ms |  59.13 MB |
| Frent_Create_With_Eleven_Component                         | 1000000     |  18.244 ms |   4.9016 ms |  0.2687 ms |  124.8 MB |
| Frent_Create_Bulk_With_Eleven_Component                    | 1000000     |  10.998 ms |   6.8686 ms |  0.3765 ms |  62.94 MB |
| Frent_Create_With_Twelve_Component                         | 1000000     |  19.759 ms |  13.1142 ms |  0.7188 ms |  132.8 MB |
| Frent_Create_Bulk_With_Twelve_Component                    | 1000000     |  12.588 ms |  45.1775 ms |  2.4763 ms |  66.76 MB |
| Frent_Create_With_Thirteen_Component                       | 1000000     |  22.288 ms |   1.9558 ms |  0.1072 ms |  140.8 MB |
| Frent_Create_Bulk_With_Thirteen_Component                  | 1000000     |  11.698 ms |   6.4072 ms |  0.3512 ms |  70.57 MB |
| Frent_Create_With_Fourteen_Component                       | 1000000     |  25.959 ms |  36.7706 ms |  2.0155 ms |  148.8 MB |
| Frent_Create_Bulk_With_Fourteen_Component                  | 1000000     |  12.566 ms |   3.0566 ms |  0.1675 ms |  74.39 MB |
| Frent_Create_With_Fifteen_Component                        | 1000000     |  30.737 ms |  52.0637 ms |  2.8538 ms | 156.81 MB |
| Frent_Create_Bulk_With_Fifteen_Component                   | 1000000     |  13.059 ms |   5.1181 ms |  0.2805 ms |   78.2 MB |
| Frent_Create_With_Sixteen_Component                        | 1000000     |  33.636 ms |  76.6862 ms |  4.2034 ms | 164.81 MB |
| Frent_Create_Bulk_With_Sixteen_Component                   | 1000000     |  13.390 ms |   4.8167 ms |  0.2640 ms |  82.02 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_0    | 1000000     |  15.624 ms |   1.7193 ms |  0.0942 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_0  | 1000000     |  13.864 ms |   7.9898 ms |  0.4379 ms |  51.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_0           | 1000000     |   6.767 ms |   2.5556 ms |  0.1401 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_10   | 1000000     | 101.127 ms |  15.1367 ms |  0.8297 ms | 723.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_10 | 1000000     | 111.492 ms | 412.8996 ms | 22.6324 ms | 723.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_10          | 1000000     |  94.751 ms |  17.4382 ms |  0.9558 ms | 723.99 MB |
