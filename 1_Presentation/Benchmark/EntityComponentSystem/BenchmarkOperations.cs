// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BenchmarkOperations.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;


namespace Alis.Benchmark.EntityComponentSystem
{
    /// <summary>
    ///     The benchmark operations class
    /// </summary>
    internal static class BenchmarkOperations
    {
        /// <summary>
        ///     The dispose
        /// </summary>
        private static readonly MethodInfo _disposeMethod = typeof(IDisposable).GetMethod(nameof(IDisposable.Dispose));

        /// <summary>
        ///     Gets the context fields
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>An enumerable of field info</returns>
        private static IEnumerable<FieldInfo> GetContextFields<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicFields)] T>() => typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f => f.GetCustomAttribute<ContextAttribute>() != null);

        /// <summary>
        ///     Setup the contexts using the specified benchmark
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="benchmark">The benchmark</param>
        /// <param name="args">The args</param>
        public static void SetupContexts<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicFields)] T>(T benchmark, params object[] args)
        {
            foreach (FieldInfo field in GetContextFields<T>())
            {
                field.SetValue(benchmark, Activator.CreateInstance(field.FieldType, args));
            }
        }

        /// <summary>
        ///     Cleanups the contexts using the specified benchmark
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="benchmark">The benchmark</param>
        public static void CleanupContexts<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicFields)] T>(T benchmark)
        {
            foreach (FieldInfo field in GetContextFields<T>())
            {
                _disposeMethod.Invoke(field.GetValue(benchmark), null);
            }
        }
    }
}