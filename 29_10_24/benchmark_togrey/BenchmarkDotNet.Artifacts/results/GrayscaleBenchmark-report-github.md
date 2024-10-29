```

BenchmarkDotNet v0.14.0, Fedora Linux 40 (Workstation Edition)
AMD Ryzen 7 6800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 6.0.135
  [Host]     : .NET 6.0.35 (6.0.3524.51101), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.35 (6.0.3524.51101), X64 RyuJIT AVX2


```
| Method       | ImageSize | Mean         | Error      | StdDev     |
|------------- |---------- |-------------:|-----------:|-----------:|
| **ToGrayscale1** | **100**       |     **42.54 μs** |   **0.463 μs** |   **0.387 μs** |
| ToGrayscale2 | 100       |     53.43 μs |   0.870 μs |   0.813 μs |
| ToGrayscale3 | 100       |     47.32 μs |   0.481 μs |   0.426 μs |
| **ToGrayscale1** | **500**       |  **1,469.17 μs** |  **22.323 μs** |  **18.641 μs** |
| ToGrayscale2 | 500       |  1,719.05 μs |  14.613 μs |  12.954 μs |
| ToGrayscale3 | 500       |  1,591.58 μs |  26.326 μs |  24.625 μs |
| **ToGrayscale1** | **1000**      | **13,386.15 μs** | **259.148 μs** | **345.955 μs** |
| ToGrayscale2 | 1000      | 14,665.91 μs |  94.379 μs |  83.665 μs |
| ToGrayscale3 | 1000      | 13,843.31 μs | 168.608 μs | 157.716 μs |
