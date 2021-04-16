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