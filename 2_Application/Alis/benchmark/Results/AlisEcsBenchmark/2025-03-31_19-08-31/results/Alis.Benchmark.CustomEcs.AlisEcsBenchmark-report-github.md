```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.3.2 (24D81) [Darwin 24.3.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  InvocationCount=1  IterationCount=3  
LaunchCount=1  UnrollFactor=1  WarmupCount=3  

```
| Method                                                     | EntityCount | Mean       | Error       | StdDev    | Allocated |
|----------------------------------------------------------- |------------ |-----------:|------------:|----------:|----------:|
| Alis_Create_With_One_Component                             | 1000000     |   7.124 ms |   1.6287 ms | 0.0893 ms |   24.8 MB |
| Alis_Create_Bulk_With_One_Component                        | 1000000     |   4.635 ms |   3.6507 ms | 0.2001 ms |   24.8 MB |
| Alis_Create_With_Two_Component                             | 1000000     |   7.653 ms |   7.8052 ms | 0.4278 ms |   52.8 MB |
| Alis_Create_Bulk_With_Two_Component                        | 1000000     |   5.900 ms |  25.3275 ms | 1.3883 ms |  28.61 MB |
| Alis_Create_With_Three_Component                           | 1000000     |   9.088 ms |   3.9497 ms | 0.2165 ms |   60.8 MB |
| Alis_Create_Bulk_With_Thre_Component                       | 1000000     |   5.789 ms |   1.5905 ms | 0.0872 ms |  32.43 MB |
| Alis_Create_With_Four_Component                            | 1000000     |  10.122 ms |   9.3882 ms | 0.5146 ms |   68.8 MB |
| Alis_Create_Bulk_With_Four_Component                       | 1000000     |   6.416 ms |   2.7606 ms | 0.1513 ms |  36.24 MB |
| Alis_Create_With_Five_Component                            | 1000000     |  11.853 ms |  10.2581 ms | 0.5623 ms |   76.8 MB |
| Alis_Create_Bulk_With_Five_Component                       | 1000000     |   6.978 ms |   5.7235 ms | 0.3137 ms |  40.06 MB |
| Alis_Create_With_Six_Component                             | 1000000     |  13.047 ms |  27.2377 ms | 1.4930 ms |   84.8 MB |
| Alis_Create_Bulk_With_Six_Component                        | 1000000     |   7.319 ms |   1.8945 ms | 0.1038 ms |  43.87 MB |
| Alis_Create_With_Seven_Component                           | 1000000     |  13.709 ms |   5.7579 ms | 0.3156 ms |   92.8 MB |
| Alis_Create_Bulk_With_Seven_Component                      | 1000000     |   8.071 ms |   7.1937 ms | 0.3943 ms |  47.69 MB |
| Alis_Create_With_Eight_Component                           | 1000000     |  15.950 ms |   6.7807 ms | 0.3717 ms |  100.8 MB |
| Alis_Create_Bulk_With_Eight_Component                      | 1000000     |   8.706 ms |   4.2273 ms | 0.2317 ms |   51.5 MB |
| Alis_Create_With_Nine_Component                            | 1000000     |  17.793 ms |   6.4312 ms | 0.3525 ms |  108.8 MB |
| Alis_Create_Bulk_With_Nine_Component                       | 1000000     |   9.996 ms |   8.6859 ms | 0.4761 ms |  55.32 MB |
| Alis_Create_With_Ten_Component                             | 1000000     |  21.417 ms |   8.4592 ms | 0.4637 ms |  116.8 MB |
| Alis_Create_Bulk_With_Ten_Component                        | 1000000     |   9.919 ms |   3.5849 ms | 0.1965 ms |  59.13 MB |
| Alis_Create_With_Eleven_Component                          | 1000000     |  25.264 ms |  17.9910 ms | 0.9861 ms |  124.8 MB |
| Alis_Create_Bulk_With_Eleven_Component                     | 1000000     |  10.266 ms |   1.4379 ms | 0.0788 ms |  62.94 MB |
| Alis_Create_With_Twelve_Component                          | 1000000     |  26.233 ms |  13.4277 ms | 0.7360 ms |  132.8 MB |
| Alis_Create_Bulk_With_Twelve_Component                     | 1000000     |  10.859 ms |   3.4221 ms | 0.1876 ms |  66.76 MB |
| Alis_Create_With_Thirteen_Component                        | 1000000     |  29.015 ms |   5.0639 ms | 0.2776 ms |  140.8 MB |
| Alis_Create_Bulk_With_Thirteen_Component                   | 1000000     |  11.602 ms |   2.1685 ms | 0.1189 ms |  70.57 MB |
| Alis_Create_With_Fourteen_Component                        | 1000000     |  32.248 ms |  28.5057 ms | 1.5625 ms |  148.8 MB |
| Alis_Create_Bulk_With_Fourteen_Component                   | 1000000     |  12.216 ms |   6.6622 ms | 0.3652 ms |  74.39 MB |
| Alis_Create_With_Fifteen_Component                         | 1000000     |  34.545 ms |  58.0437 ms | 3.1816 ms | 156.81 MB |
| Alis_Create_Bulk_With_Fifteen_Component                    | 1000000     |  12.597 ms |   6.6130 ms | 0.3625 ms |   78.2 MB |
| Alis_Create_With_Sixteen_Component                         | 1000000     |  41.855 ms |  67.2095 ms | 3.6840 ms | 164.81 MB |
| Alis_Create_Bulk_With_Sixteen_Component                    | 1000000     |  13.806 ms |   6.4644 ms | 0.3543 ms |  82.02 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_0     | 1000000     |   9.677 ms |   4.9258 ms | 0.2700 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_0   | 1000000     |   8.129 ms |   7.5757 ms | 0.4153 ms |  51.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_0            | 1000000     |   8.086 ms |   4.8868 ms | 0.2679 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_10    | 1000000     |  95.764 ms |  47.6426 ms | 2.6115 ms | 723.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_10  | 1000000     |  94.038 ms |   7.5706 ms | 0.4150 ms | 723.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_10           | 1000000     |  95.517 ms | 123.9686 ms | 6.7951 ms | 723.99 MB |
| Frent_Create_With_One_Component                            | 1000000     |  14.277 ms |   5.5772 ms | 0.3057 ms |   24.8 MB |
| Frent_Create_Bulk_With_One_Component                       | 1000000     |   4.826 ms |   1.6956 ms | 0.0929 ms |   24.8 MB |
| Frent_Create_With_Two_Component                            | 1000000     |  18.377 ms |   7.7880 ms | 0.4269 ms |   52.8 MB |
| Frent_Create_Bulk_With_Two_Component                       | 1000000     |   5.312 ms |   1.9519 ms | 0.1070 ms |  28.61 MB |
| Frent_Create_With_Three_Component                          | 1000000     |  20.724 ms |  11.2937 ms | 0.6190 ms |   60.8 MB |
| Frent_Create_Bulk_With_Thre_Component                      | 1000000     |   5.875 ms |   1.3708 ms | 0.0751 ms |  32.43 MB |
| Frent_Create_With_Four_Component                           | 1000000     |  27.147 ms | 124.9239 ms | 6.8475 ms |   68.8 MB |
| Frent_Create_Bulk_With_Four_Component                      | 1000000     |   6.407 ms |   0.2533 ms | 0.0139 ms |  36.24 MB |
| Frent_Create_With_Five_Component                           | 1000000     |  16.649 ms |  17.4489 ms | 0.9564 ms |   76.8 MB |
| Frent_Create_Bulk_With_Five_Component                      | 1000000     |   7.021 ms |   2.6459 ms | 0.1450 ms |  40.06 MB |
| Frent_Create_With_Six_Component                            | 1000000     |  19.067 ms |  27.0531 ms | 1.4829 ms |   84.8 MB |
| Frent_Create_Bulk_With_Six_Component                       | 1000000     |   7.543 ms |   4.6907 ms | 0.2571 ms |  43.87 MB |
| Frent_Create_With_Seven_Component                          | 1000000     |  20.225 ms |  10.1015 ms | 0.5537 ms |   92.8 MB |
| Frent_Create_Bulk_With_Seven_Component                     | 1000000     |   8.318 ms |   4.8290 ms | 0.2647 ms |  47.69 MB |
| Create_With_Eight_Component                                | 1000000     |  21.631 ms |   3.7082 ms | 0.2033 ms |  100.8 MB |
| Frent_Create_Bulk_With_Eight_Component                     | 1000000     |   8.987 ms |   5.4738 ms | 0.3000 ms |   51.5 MB |
| Frent_Create_With_Nine_Component                           | 1000000     |  23.608 ms |  15.0039 ms | 0.8224 ms |  108.8 MB |
| Frent_Create_Bulk_With_Nine_Component                      | 1000000     |   9.569 ms |   8.5399 ms | 0.4681 ms |  55.32 MB |
| Frent_Create_With_Ten_Component                            | 1000000     |  22.003 ms |  13.6953 ms | 0.7507 ms |  116.8 MB |
| Frent_Create_Bulk_With_Ten_Component                       | 1000000     |   9.847 ms |   3.7629 ms | 0.2063 ms |  59.13 MB |
| Frent_Create_With_Eleven_Component                         | 1000000     |  22.458 ms |   5.5213 ms | 0.3026 ms |  124.8 MB |
| Frent_Create_Bulk_With_Eleven_Component                    | 1000000     |  10.538 ms |   5.5036 ms | 0.3017 ms |  62.94 MB |
| Frent_Create_With_Twelve_Component                         | 1000000     |  18.845 ms |  10.7081 ms | 0.5869 ms |  132.8 MB |
| Frent_Create_Bulk_With_Twelve_Component                    | 1000000     |  11.334 ms |   8.0025 ms | 0.4386 ms |  66.76 MB |
| Frent_Create_With_Thirteen_Component                       | 1000000     |  22.201 ms |   9.1857 ms | 0.5035 ms |  140.8 MB |
| Frent_Create_Bulk_With_Thirteen_Component                  | 1000000     |  11.703 ms |   3.7814 ms | 0.2073 ms |  70.57 MB |
| Frent_Create_With_Fourteen_Component                       | 1000000     |  27.428 ms |  20.7488 ms | 1.1373 ms |  148.8 MB |
| Frent_Create_Bulk_With_Fourteen_Component                  | 1000000     |  12.418 ms |   2.4194 ms | 0.1326 ms |  74.39 MB |
| Frent_Create_With_Fifteen_Component                        | 1000000     |  28.992 ms |  60.3021 ms | 3.3054 ms | 156.81 MB |
| Frent_Create_Bulk_With_Fifteen_Component                   | 1000000     |  12.958 ms |   6.7001 ms | 0.3673 ms |   78.2 MB |
| Frent_Create_With_Sixteen_Component                        | 1000000     |  33.026 ms |  80.4449 ms | 4.4095 ms | 164.81 MB |
| Frent_Create_Bulk_With_Sixteen_Component                   | 1000000     |  13.592 ms |   8.6790 ms | 0.4757 ms |  82.02 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_0    | 1000000     |  17.174 ms |   2.6979 ms | 0.1479 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_0  | 1000000     |  16.860 ms |   2.6830 ms | 0.1471 ms |  51.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_0           | 1000000     |   6.681 ms |   2.6090 ms | 0.1430 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_10   | 1000000     | 100.368 ms |  28.9912 ms | 1.5891 ms | 723.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_10 | 1000000     | 103.144 ms |  71.6544 ms | 3.9276 ms | 723.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_10          | 1000000     |  95.859 ms |  58.7076 ms | 3.2180 ms | 723.99 MB |
