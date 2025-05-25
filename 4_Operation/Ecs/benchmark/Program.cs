using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Ecs.Systems;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Alis.Core.Ecs.Benchmark
{
    /// <summary>
    /// The program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        static void Main(string[] args)
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            BenchmarkSwitcher benchmark = BenchmarkSwitcher.FromTypes(new[]
            {
                typeof(MicroBenchmark)
            });

            IConfig configuration = DefaultConfig.Instance
                .WithOptions(ConfigOptions.DisableOptimizationsValidator);

            if (args.Length > 0)
            {
                benchmark.Run(args, configuration);
            }
            else
            {
                benchmark.Run(null, configuration);
            }
        }


        /// <summary>
        /// Runs the benchmark using the specified disasm call
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="disasmCall">The disasm call</param>
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
        }

        /// <summary>
        /// Jits the test using the specified call
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="call">The call</param>
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
        /// <summary>
        /// Profiles the test using the specified call
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="call">The call</param>
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


        /// <summary>
        /// The increment
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Increment : IAction<Component1>
        {
            /// <summary>
            /// Runs the arg
            /// </summary>
            /// <param name="arg">The arg</param>
            public void Run(ref Component1 arg) => arg.Value++;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct Component1(int Value);

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct Component2(int Value);

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct Component3(int Value);

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct Component4(int Value);

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct Component5(int Value);
    }
}