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
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Alis.Core.Input.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static async Task Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var samples = assembly
                .GetTypes()
                .Where(t => !t.IsAbstract &&
                            (t.IsValueType ||
                             (t.GetInterfaces().Contains(typeof(ISample)) &&
                              t.GetConstructor(Type.EmptyTypes) != null)))
                .Select(Activator.CreateInstance)
                .OfType<ISample>()
                .ToArray();

            ISample sample;
            if (args.Length != 1 ||
                (sample = Array.Find(samples, s => s.ShortNames.Contains(args[0]))) is null)
            {
                var assemblyName = assembly.GetName().Name;
                // We appear to have a cry for help!
                //Console.WriteLine(Resources.SampleExecutor, assemblyName);
                Console.WriteLine();

                do
                {
                    //Console.WriteLine(Resources.SelectSample);

                    // Create instances of all sample classes
                    foreach (var s in samples)
                    {
                        Console.WriteLine(
                            //Resources.SampleDescription, Environment.NewLine,
                            string.Join('|', s.ShortNames),
                            s.FullName,
                            s.Description);
                    }

                    if (!Environment.UserInteractive)
                    {
                        return;
                    }

                    var option = Console.ReadLine();
                    sample = Array.Find(samples, s => s.ShortNames.Contains(option));
                } while (sample is null);
            }

            //Console.WriteLine(Resources.RunningSample, sample.FullName);
            Console.WriteLine();
            await sample.ExecuteAsync().ConfigureAwait(false);
        }
    }
}