// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Program.cs
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
using System.Threading.Tasks;
using Alis.Core.Multiplayer.Example.Client.Complex;
using Alis.Core.Multiplayer.Example.Client.Simple;

namespace Alis.Core.Multiplayer.Example.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RunComplexTest(args);
            /*
            if (args.Length == 0)
            {
                RunSimpleTest().Wait();
            }
            else if (args.Length == 5)
            {
                // TODO: allow buffer pool to grow its buffers
                // ws://localhost:27416/echo 5 1000 5000 40000
                
            }
            else
            {
                Console.WriteLine("Wrong number of arguments. 0 for simple test. 5 for complex test.");
                Console.WriteLine(
                    "Complex Test: uri numThreads numItemsPerThread minNumBytesPerMessage maxNumBytesPerMessage");
                Console.WriteLine("e.g: ws://localhost:27416/chat/echo 5 100 4 4");
            }
*/
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }

        private static async Task RunLoadTest()
        {
            LoadTest client = new LoadTest();
            await client.Run();
        }

        private static void RunComplexTest(string[] args)
        {
            Uri uri = new Uri("ws://localhost:27416/chat");
            int.TryParse("3", out int numThreads);
            int.TryParse("4", out int numItemsPerThread);
            int.TryParse("256", out int minNumBytesPerMessage);
            int.TryParse("1024", out int maxNumBytesPerMessage);

            Console.WriteLine(
                $"Started DemoClient with Uri '{uri}' numThreads '{numThreads}' numItemsPerThread '{numItemsPerThread}' minNumBytesPerMessage '{minNumBytesPerMessage}' maxNumBytesPerMessage '{maxNumBytesPerMessage}'");

            TestRunner runner = new TestRunner(uri, numThreads, numItemsPerThread, minNumBytesPerMessage,
                maxNumBytesPerMessage);
            runner.Run();
        }

        private static async Task RunSimpleTest()
        {
            SimpleClient client = new SimpleClient();
            await client.Run();
        }
    }
}