using BenchmarkDotNet.Attributes;

namespace Alis.Core.Benchmark
{
    /// <summary>
    /// The test change value byte vs bool vs int class
    /// </summary>
    public class Test_Change_Value_Byte_vs_Bool_vs_Int
    {
        /// <summary>
        /// The truevalue
        /// </summary>
        private const byte truevalue = 1;
        /// <summary>
        /// The false value
        /// </summary>
        private const byte falseValue = 0;
        /// <summary>
        /// The is active
        /// </summary>
        public bool isActive;

        /// <summary>
        /// The is int
        /// </summary>
        private int isInt;
        /// <summary>
        /// The is static
        /// </summary>
        public byte isStatic;

        /// <summary>
        /// The repetition
        /// </summary>
        [Params(1000)] public int repetition;

        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            isStatic = 0;
            isActive = false;
        }

        /// <summary>
        /// Tests the change value byte
        /// </summary>
        [Benchmark]
        public void Test_Change_Value_Byte()
        {
            isStatic = (isStatic & truevalue) == truevalue ? falseValue : truevalue;
        }

        /// <summary>
        /// Tests the change value bool
        /// </summary>
        [Benchmark]
        public void Test_Change_Value_Bool()
        {
            isActive = !isActive;
        }

        /// <summary>
        /// Tests the change value int
        /// </summary>
        [Benchmark]
        public void Test_Change_Value_Int()
        {
            isInt = isInt == 0 ? 1 : 0;
        }
    }
}