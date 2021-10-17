using System;
using Alis.Core.OpenGL;
using OpenTK.Windowing.Desktop;

namespace Alis.Core.OpenGL.Example
{
    class Program
    {
        static void Main(string[] args)
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
