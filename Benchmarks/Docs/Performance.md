# 1. Performance


## Use bytes or use bool
If you want to control true or false is best option a bool value.


## Size Variables on Memory
This a simple example of the size of the main variables:

### Solution

```
SIZE VARIABLES ON MEMORY:
SBYTE  1 byte
BYTE   1 byte
CHAR   1 byte
UINT   4 bytes
INT    4 bytes
BOOL   4 bytes
LONG   8 bytes
```

#### Benchmark:

```
    Console.WriteLine("SIZE VARIABLES ON MEMORY: ");
    Console.WriteLine("SBYTE  {0} byte", Marshal.SizeOf(typeof(sbyte)));
    Console.WriteLine("BYTE   {0} byte", Marshal.SizeOf(typeof(byte)));
    Console.WriteLine("CHAR   {0} byte", Marshal.SizeOf(typeof(char)));
    Console.WriteLine("UINT   {0} bytes", Marshal.SizeOf(typeof(uint)));
    Console.WriteLine("INT    {0} bytes", Marshal.SizeOf(typeof(int)));
    Console.WriteLine("BOOL   {0} bytes", Marshal.SizeOf(typeof(bool)));
    Console.WriteLine("LONG   {0} bytes", Marshal.SizeOf(typeof(long)));
```


## Array
### GameObjects
> Problem: update every frame the gameobjets of the current scene.

#### "Best" Solution:


#### Benchmark:


#### Code:


## Strings

### Concat Strings

#### "Best" Solution:

```

// For 2 simples strings:
public string StringConcat(string _stringA, string _stringB) => string.Concat(_stringA, _stringB);

// For 2 arrays of strings:
public string StringConcat(string[] _stringA, string[] _stringB) => string.Concat(_stringA, _stringB);

```


#### Benchmark:

|                               Method | numOfStrings |            Mean |          Error |         StdDev |             Min |             Max |          Median | Iterations |      Gen 0 |  Gen 1 | Gen 2 |  Allocated |
|------------------------------------- |------------- |----------------:|---------------:|---------------:|----------------:|----------------:|----------------:|-----------:|-----------:|-------:|------:|-----------:|
|        Test_String_Concat_2_Elements |         1000 |        31.65 ns |       0.672 ns |       0.986 ns |        30.30 ns |        33.71 ns |        31.40 ns |      29.00 |     0.0408 |      - |     - |       64 B |
|    Test_String_Concat_Ref_2_Elements |         1000 |        34.28 ns |       0.716 ns |       1.363 ns |        32.27 ns |        37.60 ns |        34.07 ns |      45.00 |     0.0408 |      - |     - |       64 B |
|        Test_String_Format_2_Elements |         1000 |       127.89 ns |       2.575 ns |       6.120 ns |       117.83 ns |       142.82 ns |       126.38 ns |      67.00 |     0.0408 |      - |     - |       64 B |
|           Test_String_Add_2_Elements |         1000 |        32.59 ns |       0.687 ns |       1.419 ns |        30.50 ns |        36.10 ns |        32.27 ns |      52.00 |     0.0408 |      - |     - |       64 B |
|        Test_StringBuilder_2_Elements |         1000 |       124.56 ns |       2.511 ns |       3.176 ns |       118.02 ns |       130.10 ns |       125.06 ns |      23.00 |     0.1733 |      - |     - |      272 B |
|     Test_String_Concat_1000_Elements |         1000 |        56.75 ns |       1.030 ns |       1.265 ns |        54.74 ns |        59.60 ns |        56.47 ns |      22.00 |     0.0561 | 0.0002 |     - |       88 B |
| Test_String_Concat_REF_1000_Elements |         1000 |        57.29 ns |       1.073 ns |       1.763 ns |        54.64 ns |        62.78 ns |        56.98 ns |      35.00 |     0.0561 | 0.0002 |     - |       88 B |
|     Test_String_Format_1000_Elements |         1000 |       167.71 ns |       3.146 ns |       2.789 ns |       162.00 ns |       172.12 ns |       168.16 ns |      14.00 |     0.0560 |      - |     - |       88 B |
|        Test_String_Add_1000_Elements |         1000 | 7,219,031.38 ns | 144,222.763 ns | 134,906.062 ns | 6,997,523.83 ns | 7,430,037.89 ns | 7,265,760.55 ns |      15.00 | 27398.4375 |      - |     - | 43432120 B |
|     Test_StringBuilder_1000_Elements |         1000 |       154.87 ns |       3.072 ns |       4.405 ns |       147.98 ns |       162.87 ns |       154.94 ns |      28.00 |     0.1886 |      - |     - |      296 B |

  + **numOfStrings** : Value of the 'numOfStrings' parameter
  + **Mean**         : Arithmetic mean of all measurements
  + **Error**        : Half of 99.9% confidence interval
  + **StdDev**       : Standard deviation of all measurements
  + **Min**          : Minimum
  + **Max**          : Maximum
  + **Median**       : Value separating the higher half of all measurements (50th percentile)
  + **Iterations**   : Number of target iterations
  + **Gen 0**        : GC Generation 0 collects per 1000 operations
  + **Gen 1**        : GC Generation 1 collects per 1000 operations
  + **Gen 2**        : GC Generation 2 collects per 1000 operations
  + **Allocated**    : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  + **1 ns**        : 1 Nanosecond (0.000000001 sec)

#### Code:

```
//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Test_Concat_Strings.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using System.Text;

    /// <summary>Test strings</summary>
    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn, IterationsColumn]
    public class Test_Concat_Strings
    {
        /// <summary>The number of strings</summary>
        [Params(1000)]
        public int numOfStrings;

        /// <summary>The strings 1</summary>
        private string[] strings_1;

        /// <summary>The strings 2</summary>
        private string[] strings_2;

        /// <summary>Setups this instance.</summary>
        [GlobalSetup]
        public void Setup()
        {
            strings_1 = new string[numOfStrings];
            strings_2 = new string[numOfStrings];

            for (int i = 0; i < strings_1.Length;i++) 
            {
                strings_1[i] = "String_1" + i;
                strings_2[i] = "String_2" + i;
            }
        }

        /// <summary>Strings the concat.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string StringConcat(string _stringA, string _stringB) => string.Concat(_stringA, _stringB);

        /// <summary>Strings the concat reference.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string StringConcatRef(ref string _stringA, ref string _stringB) => string.Concat(_stringA, _stringB);

        /// <summary>Strings the format.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string StringFormat(string _stringA, string _stringB) => string.Format("{0}{1}", _stringA, _stringB);

        /// <summary>Strings the add.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string StringAdd(string _stringA, string _stringB) => _stringA + _stringB;

        /// <summary>Strings the builder.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string StringBuilder( string _stringA,  string _stringB) => new StringBuilder().Append(_stringA).Append(_stringB).ToString();

        /// <summary>Strings the concat.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string StringConcat(string[] _stringA, string[] _stringB) => string.Concat(_stringA, _stringB);

        /// <summary>Strings the concat reference.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string StringConcatRef(ref string[] _stringA, ref string[] _stringB) => string.Concat(_stringA, _stringB);

        /// <summary>Strings the format.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string StringFormat(string[] _stringA, string[] _stringB) => string.Format("{0}{1}", _stringA, _stringB);

        /// <summary>Strings the add.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string StringAdd(string[] _stringA, string[] _stringB)
        {
            string result = "";
            for (int i = 0; i < _stringA.Length; i++) 
            {
                result += _stringA[i];
            }

            for (int i = 0; i < _stringB.Length; i++)
            {
                result += _stringB[i];
            }

            return result;
        }

        /// <summary>Strings the builder.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string StringBuilder(string[] _stringA, string[] _stringB) => new StringBuilder().Append(_stringA).Append(_stringB).ToString();

        /// <summary>Tests the string concat 2 elements.</summary>
        [Benchmark]
        public void Test_String_Concat_2_Elements() 
        {
            _ = StringConcat(strings_1[0], strings_2[0]);
        }

        /// <summary>Tests the string concat 2 elements.</summary>
        [Benchmark]
        public void Test_String_Concat_Ref_2_Elements()
        {
            _ = StringConcatRef(ref strings_1[0], ref strings_2[0]);
        }

        /// <summary>Tests the string format 2 elements.</summary>
        [Benchmark]
        public void Test_String_Format_2_Elements()
        {
            _ = StringFormat(strings_1[0], strings_2[0]);
        }

        /// <summary>Tests the string add 2 elements.</summary>
        [Benchmark]
        public void Test_String_Add_2_Elements()
        {
            _ = StringAdd(strings_1[0], strings_2[0]);
        }

        /// <summary>Tests the string builder 2 elements.</summary>
        [Benchmark]
        public void Test_StringBuilder_2_Elements()
        {
            _ = StringBuilder(strings_1[0], strings_2[0]);
        }

        /// <summary>Tests the string concat 1000 elements.</summary>
        [Benchmark]
        public void Test_String_Concat_1000_Elements()
        {
            _ = StringConcat(strings_1, strings_2);
        }

        /// <summary>Tests the string concat reference 1000 elements.</summary>
        [Benchmark]
        public void Test_String_Concat_REF_1000_Elements()
        {
            _ = StringConcatRef(ref strings_1, ref strings_2);
        }

        /// <summary>Tests the string format 1000 elements.</summary>
        [Benchmark]
        public void Test_String_Format_1000_Elements()
        {
            _ = StringFormat(strings_1, strings_2);
        }

        /// <summary>Tests the string add 1000 elements.</summary>
        [Benchmark]
        public void Test_String_Add_1000_Elements()
        {
            _ = StringAdd(strings_1, strings_2);
        }

        /// <summary>Tests the string builder 1000 elements.</summary>
        [Benchmark]
        public void Test_StringBuilder_1000_Elements()
        {
            _ = StringBuilder(strings_1, strings_2);
        }
    }
}
```