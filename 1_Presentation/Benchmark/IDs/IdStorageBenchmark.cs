// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IdStorageBenchmark.cs
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

using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.IDs
{
    /// <summary>
    ///     This class demonstrates the performance and memory usage differences
    ///     when using different data types (byte, uint, and string) to store a unique identifier (ID).
    /// </summary>
    [ Config(typeof(CustomConfig))]
    public class IdStorageBenchmark
    {
        // Number of iterations to run for the benchmark
        /// <summary>
        ///     The iterations
        /// </summary>
        private const int Iterations = 1000000;

        // Unique identifier values for each type
        /// <summary>
        ///     The byte id
        /// </summary>
        private readonly byte byteId = 255; // A byte can store values from 0 to 255

        /// <summary>
        ///     The string id
        /// </summary>
        private readonly string stringId = "ID_1234567890"; // A string to store a unique identifier

        /// <summary>
        ///     The uint id
        /// </summary>
        private readonly uint uintId = 123456789; // A uint can store values from 0 to 4,294,967,295

        /// <summary>
        ///     Benchmark using byte to store the unique identifier.
        ///     This will measure both speed and memory usage.
        /// </summary>
        [Benchmark]
        public byte ByteIdStorage()
        {
            byte result = 0;
            for (int i = 0; i < Iterations; i++)
            {
                result = byteId;
            }

            return result;
        }

        /// <summary>
        ///     Benchmark using uint to store the unique identifier.
        ///     This will measure both speed and memory usage.
        /// </summary>
        [Benchmark]
        public uint UintIdStorage()
        {
            uint result = 0;
            for (int i = 0; i < Iterations; i++)
            {
                result = uintId;
            }

            return result;
        }

        /// <summary>
        ///     Benchmark using string to store the unique identifier.
        ///     This will measure both speed and memory usage.
        /// </summary>
        [Benchmark]
        public string StringIdStorage()
        {
            string result = string.Empty;
            for (int i = 0; i < Iterations; i++)
            {
                result = stringId;
            }

            return result;
        }
    }
}