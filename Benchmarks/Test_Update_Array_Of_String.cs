namespace Benchmarks
{
    using System;
    using System.Threading.Tasks;
    using BenchmarkDotNet.Attributes;

    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    public class Test_Update_Array_Of_String
    {
        private string[] listOfStrings;

        [Params(10)]
        public int SizeList;

        [GlobalSetup]
        public void Setup()
        {
            listOfStrings = new string[SizeList];
            for (int i = 0; i < SizeList; i++)
            {
                listOfStrings[i] = "new string " + i;
            }
        }

        [Benchmark]
        public void Test_Custom()
        {
            int processorCount = Environment.ProcessorCount;
            Task[] tasks = new Task[processorCount];
            int lastElement = tasks.Length - 1;

            int limitOfTasksByProcessor = (listOfStrings.Length / processorCount) + 1;
            int init = 0;
            int end = 0;

            for (int i = 0; i < tasks.Length; i++)
            {
                init = i * limitOfTasksByProcessor;
                end = lastElement.Equals(i) ? listOfStrings.Length : (i + 1) * limitOfTasksByProcessor;

                tasks[i] = Task.Run(() =>
                {
                    for (int j = init; j < end; j++)
                    {
                        listOfStrings[j].ToString();
                    }
                });
            }

            Task.WaitAll(tasks);
        }

        [Benchmark]
        public void Test_Simple_For()
        {
            for (int i = 0; i < listOfStrings.Length; i++)
            {
                listOfStrings[i].ToString();
            }
        }

        [Benchmark]
        public void Test_Simple_Foreach()
        {
            foreach (string example in listOfStrings)
            {
                example.ToString();
            }
        }

        [Benchmark]
        public void Test_Task_For()
        {
            Task.Run(() =>
            {
                for (int i = 0; i < listOfStrings.Length; i++)
                {
                    listOfStrings[i].ToString();
                }
            }).Wait();
        }

        [Benchmark]
        public void Test_Task_foreach()
        {
            Task.Run(() =>
            {
                foreach (string example in listOfStrings)
                {
                    example.ToString();
                }
            }).Wait();
        }


        [Benchmark]
        public void Test_Parallel_And_ForEach() => Parallel.ForEach(listOfStrings, scene => scene.ToString());
    }
}
