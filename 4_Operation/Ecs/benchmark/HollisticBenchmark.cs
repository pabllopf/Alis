using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using Alis;

namespace Alis.Core.Ecs.Benchmark
{
    /// <summary>
    /// The hollistic benchmark class
    /// </summary>
    [MemoryDiagnoser]
    [DisassemblyDiagnoser(5)]
    internal class HollisticBenchmark : IDisposable
    {
        /// <summary>
        /// The scene
        /// </summary>
        private Scene _scene;
        /// <summary>
        /// The component types
        /// </summary>
        private Type[] _componentTypes;
        
        /// <summary>
        /// Setup this instance
        /// </summary>
        public void Setup()
        {
            Random random = new Random();

            _scene = new Scene();
            _componentTypes = typeof(HollisticBenchmark)
                .Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IDummyComponent)) && t.IsValueType)
                .ToArray();

            BuildEntityCreationDelegates(random);
        }


        /// <summary>
        /// Builds the gameObject creation delegates using the specified random
        /// </summary>
        /// <param name="random">The random</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A func of gameObject array</returns>
        private Func<GameObject>[] BuildEntityCreationDelegates(Random random)
        {
            var x = typeof(Scene).GetMethods();
            MethodInfo[] method = typeof(Scene).GetMethods().Where(m => m.Name == "CreateNoArgs").ToArray();
            Type[] componentTypes = _componentTypes;
            HashSet<int> chosenIndidies = new HashSet<int>();

            const int DelegateCount = 200;
            Func<GameObject>[] finalDelegates = new Func<GameObject>[componentTypes.Length];

            //unqiue gameObject types
            for (int i = 0; i < DelegateCount; i++)
            {
                int componentCount = (int)(random.NextSingle() * random.NextSingle() * 16);//[0..15]
                Console.WriteLine(componentCount);
                while (chosenIndidies.Count < componentCount)
                    chosenIndidies.Add(random.Next(componentTypes.Length));

                MethodInfo rightArity = method[i];
                rightArity.MakeGenericMethod(chosenIndidies.Select(i => componentTypes[i]).ToArray());
            }


            return null;
        }

        /// <summary>
        /// The categories class
        /// </summary>
        internal class Categories
        {
            /// <summary>
            /// The creation
            /// </summary>
            public const string Creation = "Creation";
            /// <summary>
            /// The deletion
            /// </summary>
            public const string Deletion = "Deletion";
            /// <summary>
            /// The get component
            /// </summary>
            public const string GetComponent = "GetComponent";
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _scene?.Dispose();
        }
    }
}
