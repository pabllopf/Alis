using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Alis.Benchmark.EntityComponentSystem.Others
{
    /// <summary>
    /// The benchmark operations class
    /// </summary>
    internal static class BenchmarkOperations
    {
        /// <summary>
        /// The dispose
        /// </summary>
        private static readonly MethodInfo _disposeMethod = typeof(IDisposable).GetMethod(nameof(IDisposable.Dispose));

        /// <summary>
        /// Gets the context fields
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>An enumerable of field info</returns>
        private static IEnumerable<FieldInfo> GetContextFields<T>() => typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f => f.GetCustomAttribute<ContextAttribute>() != null);

        /// <summary>
        /// Setup the contexts using the specified benchmark
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="benchmark">The benchmark</param>
        /// <param name="args">The args</param>
        public static void SetupContexts<T>(T benchmark, params object[] args)
        {
            foreach (FieldInfo field in GetContextFields<T>())
            {
                field.SetValue(benchmark, Activator.CreateInstance(field.FieldType, args));
            }
        }

        /// <summary>
        /// Cleanups the contexts using the specified benchmark
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="benchmark">The benchmark</param>
        public static void CleanupContexts<T>(T benchmark)
        {
            foreach (FieldInfo field in GetContextFields<T>())
            {
                _disposeMethod.Invoke(field.GetValue(benchmark), null);
            }
        }
    }
}
