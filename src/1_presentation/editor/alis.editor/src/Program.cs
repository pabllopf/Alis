//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Program.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>Run the engine</summary>
    public class Program
    {
        /// <summary>Mains the specified arguments.</summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Return -1 or 0</returns>
        [STAThread]
        public static int Main(string[] args)
        {
            Console.WriteLine("Hello world");
            return 0;
        }
    }
}