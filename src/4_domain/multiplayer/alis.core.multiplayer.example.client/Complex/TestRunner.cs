// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TestRunner.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Alis.Core.Multiplayer.Example.Client.Complex
{
    internal class TestRunner
    {
        private readonly int _maxNumBytesPerMessage;
        private readonly int _minNumBytesPerMessage;
        private readonly int _numItemsPerThread;
        private readonly int _numThreads;
        private readonly Uri _uri;

        public TestRunner(Uri uri, int numThreads, int numItemsPerThread, int minNumBytesPerMessage,
            int maxNumBytesPerMessage)
        {
            _uri = uri;
            _numThreads = numThreads;
            _numItemsPerThread = numItemsPerThread;
            _minNumBytesPerMessage = minNumBytesPerMessage;
            _maxNumBytesPerMessage = maxNumBytesPerMessage;
        }

        public void Run()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.For(0, _numThreads, Run);
            Console.WriteLine($"Completed in {stopwatch.Elapsed.TotalMilliseconds:#,##0.00} ms");
        }

        public void Run(int index, ParallelLoopState state)
        {
            StressTest test = new StressTest(index, _uri, _numItemsPerThread, _minNumBytesPerMessage,
                _maxNumBytesPerMessage);
            test.Run().Wait();
        }
    }
}