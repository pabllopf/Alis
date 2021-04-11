//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Program.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Benchmarks
{
    using Alis.Core;
    using Alis.Core.SFML;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;
    using System;
    using System.Runtime.InteropServices;

    /// <summary>Define the main program.</summary>
    public class Program
    {
        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        [System.Obsolete]
        public static void Main(string[] args)
        {
            /*Console.WriteLine("Start");
            var ejempl = new Test_Update_Multiple_Scenes();
            ejempl.Setup();
            ejempl.Test_Update_Custom_Method_Mix();

            Console.WriteLine("Start");
            */

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);



            /*
        

            Console.WriteLine("SIZE VARIABLES ON MEMORY: ");
            Console.WriteLine("Int32  {0} byte", Marshal.SizeOf(typeof(Byte)));
            Console.WriteLine("SBYTE  {0} byte", Marshal.SizeOf(typeof(sbyte)));
            Console.WriteLine("BYTE   {0} byte", Marshal.SizeOf(typeof(byte)));
            Console.WriteLine("CHAR   {0} byte", Marshal.SizeOf(typeof(char)));
            Console.WriteLine("UINT   {0} bytes", Marshal.SizeOf(typeof(uint)));
            Console.WriteLine("INT    {0} bytes", Marshal.SizeOf(typeof(int)));
            Console.WriteLine("BOOL   {0} bytes", Marshal.SizeOf(typeof(bool)));
            Console.WriteLine("LONG   {0} bytes", Marshal.SizeOf(typeof(long)));*/
        }
    }
}
