

namespace Benchmarks
{
    using BenchmarkDotNet.Attributes;

    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn, IterationsColumn]
    public class Test_Byte_vs_Bool
    {
        private const byte truevalue = 1;
        private const byte falseValue = 0;
        public byte isStatic;
        public bool isActive;

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
    }
}
