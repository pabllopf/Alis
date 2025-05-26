using System;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Components
{
    /// <summary>
    /// The write action
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct WriteAction : IAction<int>
    {
        /// <summary>
        /// Runs the x
        /// </summary>
        /// <param name="x">The </param>
        public void Run(ref int x) => Console.Write($"{x++}, ");
    }
}