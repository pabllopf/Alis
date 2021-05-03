namespace Benchmarks
{
    using Alis.Core;
    using Alis.Core.SFML;
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MedianColumn, IterationsColumn]
    public class Test_span_performance
    {
        private GameObject gameObject;

        /// <summary>The components</summary>
        [AllowNull]
        private Component[] components ;

        /// <summary>The span</summary>
        private Memory<Component> spanComponents;

        /// <summary>The active</summary>
        [NotNull]
        private bool isActive;

        /// <summary>The is static</summary>
        [NotNull]
        private bool isStatic;


        [GlobalSetup]
        public void Setup()
        {
            gameObject = new GameObject("example", new Transform(), new Sprite(""), new AudioSource(), new Animator());
            components = gameObject.Components;

            spanComponents = components.AsMemory();
            isActive = true;
            isStatic = false;
        }


        [Benchmark]
        public void Test_Span_v3_Performance()
        {
           Updatev3();
        }

        [Benchmark]
        public void Test_Span_V2_Performance()
        {
            Updatev2();
        }


        [Benchmark]
        public void Test_Array_V1_Performance()
        {
           Update();
        }


        public void Update()
        {
            if (isActive && !isStatic)
            {
                for (int i = 0; i < components.Length; i++)
                {
                    if (components[i] is not null)
                    {
                        components[i].Update();
                    }
                }
            }
        }

        public void Updatev2()
        {
            if (isActive && !isStatic)
            {
                foreach (ref readonly Component component in spanComponents.Span)
                {
                    component?.Update();
                }
            }
        }

        public void Updatev3()
        {
            if (isActive && !isStatic)
            {
                Span<Component> span = spanComponents.Span;
                for (int i = 0; i < span.Length; i++)
                {
                    span[i]?.Update();
                }
            }
        }
    }
}
