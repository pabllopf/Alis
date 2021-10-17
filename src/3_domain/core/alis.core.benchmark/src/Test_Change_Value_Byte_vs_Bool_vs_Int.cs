using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alis.Core.Benchmark
{

    public class Test_Change_Value_Byte_vs_Bool_vs_Int
    {
        private const byte truevalue = 1;
        private const byte falseValue = 0;
        public byte isStatic;
        public bool isActive;

        private int isInt = 0;

        [Params(1000)]
        public int repetition;

        [GlobalSetup]
        public void Setup()
        {
            isStatic = 0;
            isActive = false;
        }

        [Benchmark]
        public void Test_Change_Value_Byte() 
        {
            isStatic = (isStatic & truevalue) == truevalue ? falseValue : truevalue;
        }

        [Benchmark]
        public void Test_Change_Value_Bool()
        {
            isActive = !isActive;
        }

        [Benchmark]
        public void Test_Change_Value_Int()
        {
            isInt = isInt == 0 ? 1 : 0; 
        }
    }
}
