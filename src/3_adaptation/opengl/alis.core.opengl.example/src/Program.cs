using System;

namespace Alis.Core.OpenGL.Example
{
    /// <summary>
    /// The program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
        {
            /*using (VideoGame_ game = new VideoGame_(new GameWindowSettings(), new NativeWindowSettings()))
            {
                //Run takes a double, which is how many frames per second it should strive to reach.
                //You can leave that out and it'll just update as fast as the hardware will allow it.
                game.Run();
            }*/


            Console.WriteLine("Press any key to close the windows.");
            Console.ReadKey();
        }
    }
}