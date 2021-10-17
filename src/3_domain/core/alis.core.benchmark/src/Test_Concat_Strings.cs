using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alis.Core.Benchmark
{

    /// <summary>Test strings</summary>
    public class Test_Concat_Strings
    {
        /// <summary>The number of strings</summary>
        [Params(10, 1_000, 100_000)]
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
        public string String_Concat(string _stringA, string _stringB) => string.Concat(_stringA, _stringB);

        /// <summary>Strings the concat reference.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string String_Concat_With_Ref(ref string _stringA, ref string _stringB) => string.Concat(_stringA, _stringB);

        /// <summary>Strings the format.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string String_Format(string _stringA, string _stringB) => string.Format("{0}{1}", _stringA, _stringB);

        /// <summary>Strings the builder.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string String_Builder( string _stringA,  string _stringB) => new StringBuilder().Append(_stringA).Append(_stringB).ToString();

        /// <summary>Strings the concat.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string String_Array_Concat(string[] _stringA, string[] _stringB) => string.Concat(_stringA, _stringB);

        /// <summary>Strings the concat reference.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string String_Array_Concat_Ref(ref string[] _stringA, ref string[] _stringB) => string.Concat(_stringA, _stringB);

        /// <summary>Strings the format.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string String_Array_Format(string[] _stringA, string[] _stringB) => string.Format("{0}{1}", _stringA, _stringB);

        /// <summary>Strings the builder.</summary>
        /// <param name="_stringA">The string a.</param>
        /// <param name="_stringB">The string b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public string String_Array_Builder(string[] _stringA, string[] _stringB) => new StringBuilder().Append(_stringA).Append(_stringB).ToString();

        /// <summary>Tests the string concat 2 elements.</summary>
        [Benchmark]
        public void Test_String_Concat_2_Elements() 
        {
            _ = String_Concat(strings_1[0], strings_2[0]);
        }

        /// <summary>Tests the string concat 2 elements.</summary>
        [Benchmark]
        public void Test_String_Concat_Ref_2_Elements()
        {
            _ = String_Concat_With_Ref(ref strings_1[0], ref strings_2[0]);
        }

        /// <summary>Tests the string format 2 elements.</summary>
        [Benchmark]
        public void Test_String_Format_2_Elements()
        {
            _ = String_Format(strings_1[0], strings_2[0]);
        }

        /// <summary>Tests the string builder 2 elements.</summary>
        [Benchmark]
        public void Test_StringBuilder_2_Elements()
        {
            _ = String_Builder(strings_1[0], strings_2[0]);
        }

        /// <summary>Tests the string concat 1000 elements.</summary>
        [Benchmark]
        public void Test_String_Concat()
        {
            _ = String_Array_Concat(strings_1, strings_2);
        }

        /// <summary>Tests the string concat reference 1000 elements.</summary>
        [Benchmark]
        public void Test_String_Concat_REF()
        {
            _ = String_Array_Concat_Ref(ref strings_1, ref strings_2);
        }

        /// <summary>Tests the string format 1000 elements.</summary>
        [Benchmark]
        public void Test_String_Format()
        {
            _ = String_Array_Format(strings_1, strings_2);
        }

        /// <summary>Tests the string builder 1000 elements.</summary>
        [Benchmark]
        public void Test_StringBuilder()
        {
            _ = String_Array_Builder(strings_1, strings_2);
        }
    }
}