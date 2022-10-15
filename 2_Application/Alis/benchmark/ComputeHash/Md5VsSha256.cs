// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Md5VsSha256.cs
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
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ComputeHash
{
    /// <summary>
    /// The md vs sha 256 class
    /// </summary>
    public class Md5VsSha256
    {
        /// <summary>
        /// The 
        /// </summary>
        private const int N = 10000;
        /// <summary>
        /// The data
        /// </summary>
        private readonly byte[] data;

        /// <summary>
        /// The create
        /// </summary>
        private readonly SHA256 sha256 = SHA256.Create();
        /// <summary>
        /// The create
        /// </summary>
        private readonly MD5 md5 = MD5.Create();

        /// <summary>
        /// Initializes a new instance of the <see cref="Md5VsSha256"/> class
        /// </summary>
        public Md5VsSha256()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        /// <summary>
        /// Shas the 256
        /// </summary>
        /// <returns>The byte array</returns>
        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

        /// <summary>
        /// Mds the 5
        /// </summary>
        /// <returns>The byte array</returns>
        [Benchmark]
        public byte[] Md5() => md5.ComputeHash(data);
    }
}