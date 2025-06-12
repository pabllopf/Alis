using System;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using Alis;
using Alis.Core.Ecs.Systems;
using static Alis.Core.Ecs.Benchmark.Program;

namespace Alis.Core.Ecs.Benchmark
{
    /// <summary>
    /// The micro benchmark class
    /// </summary>
    [ShortRunJob]
    [MemoryDiagnoser]
    public class MicroBenchmark :IDisposable
    {
        /// <summary>
        /// The categories class
        /// </summary>
        public class Categories
        {
            /// <summary>
            /// The create
            /// </summary>
            public const string Create = "Create";
            /// <summary>
            /// The has
            /// </summary>
            public const string Has = "Has";
            /// <summary>
            /// The get
            /// </summary>
            public const string Get = "Get";
            /// <summary>
            /// The add
            /// </summary>
            public const string Add = "Add";
        }

        /// <summary>
        /// The scene
        /// </summary>
        private Scene _scene;
        /// <summary>
        /// The gameObject
        /// </summary>
        private GameObject _gameObject;

        /// <summary>
        /// The entities
        /// </summary>
        private GameObject[] _entities;

        //[Params(1, 100, 10_000, 100_000)]
        /// <summary>
        /// Gets or sets the value of the count
        /// </summary>
        public int Count { get; set; } = 100_000;

        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            _scene = new Scene();
            _gameObject = _scene.Create<Component1, Component2, Component3>(default, default, default);
            _entities = new GameObject[Count];
            for (int i = 0; i < _entities.Length; i++)
            {
                _entities[i] = _scene.Create<Component1, Component2, Component3>(default, default, default);
            }

            foreach (var entity in _entities)
            {
                entity.Remove<Component1>();
                entity.Add<Component1>(default);
            }
        }

        /// <summary>
        /// Decons this instance
        /// </summary>
        [Benchmark]
        public void Decon()
        {
            foreach(var entity in _entities)
            {
                entity.Deconstruct<Component1, Component2, Component3>(out var _, out var _, out var _);
            }
        }
        
        /// <summary>
        /// Creates this instance
        /// </summary>
        [Benchmark]
        [BenchmarkCategory(Categories.Add)]
        public void Create()
        {
            for(int i = 0; i < 100; i++)
            {
                _scene.Create(0);
            }
        }

        /// <summary>
        /// Adds the rem
        /// </summary>
        [Benchmark]
        [BenchmarkCategory(Categories.Add)]
        public void AddRem()
        {
            foreach (var entity in _entities)
            {
                entity.Remove<int>();
                entity.Add(0);
            }
        }

        
        /// <summary>
        /// Hases this instance
        /// </summary>
        [Benchmark]
        [BenchmarkCategory(Categories.Has)]
        public void Has()
        {
            _gameObject.Has<int>();
        }
        

        /// <summary>
        /// The increment
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Increment : IAction<Program.Component1>
        {
            /// <summary>
            /// Runs the arg
            /// </summary>
            /// <param name="arg">The arg</param>
            public void Run(ref Component1 arg) => arg.Value++;
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