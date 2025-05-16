﻿using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Alis.Core.Ecs.Systems;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Alis.Core.Ecs.Benchmark
{
    public class Program
    {
        static void Main(string[] args) => RunBenchmark<MicroBenchmark>(m => m.Equals(null));
    
        #region Bench Helpers
        private static void RunBenchmark<T>(Action<T> disasmCall)
        {
            if (Environment.GetEnvironmentVariable("DISASM") == "TRUE" ||
#if DEBUG
            true
#else
                false
#endif
               )
            {
                JitTest(disasmCall);
            }
            else
            {
                BenchmarkRunner.Run<T>();
                JitTest(disasmCall);
            }
        }

        private static void JitTest<T>(Action<T> call)
        {
            T t = Activator.CreateInstance<T>();
            t.GetType()
                .GetMethods()
                .FirstOrDefault(m => m.GetCustomAttribute<GlobalSetupAttribute>() is not null)
                ?.Invoke(t, []);

            //jit warmup
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 32; j++)
                    call(t);
                Thread.Sleep(100);  
            }
        }

        //agg opt because i suspect pgo devirtualizes the call
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static void ProfileTest<T>(Action<T> call)
        {
            T t = Activator.CreateInstance<T>();
            t.GetType()
                .GetMethods()
                .FirstOrDefault(m => m.GetCustomAttribute<GlobalSetupAttribute>() is not null)
                ?.Invoke(t, []);

            while(true)
            {
                call(t);
            }
        }
        #endregion

        internal struct Increment : IAction<Component1>
        {
            public void Run(ref Component1 arg) => arg.Value++;
        }

        internal record struct Component1(int Value);

        internal record struct Component2(int Value);

        internal record struct Component3(int Value);

        internal record struct Component4(int Value);

        internal record struct Component5(int Value);
    }
}