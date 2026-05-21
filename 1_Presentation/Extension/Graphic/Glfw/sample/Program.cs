

using System;
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Graphic.Glfw.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
        {
            Logger.Log("Enter the number of the sample you want to run:");
            Logger.Log("1 - Triangle Sample");
            Logger.Log("2 - Cube Sample");
            Logger.Log("3 - Render Square Unfilled");
            Logger.Log("4 - Texture Sample Custom Bmp");
            int sampleNumber = Convert.ToInt32(Console.ReadLine());

            switch (sampleNumber)
            {
                case 1:
                    TriangleSample triangleSample = new TriangleSample();
                    triangleSample.Run();
                    break;

                case 2:
                    CubeSample cubeSample = new CubeSample();
                    cubeSample.Run();
                    break;

                case 3:
                    RenderSquareUnfilled unfilled = new RenderSquareUnfilled();
                    unfilled.Run();
                    break;

                case 4:
                    TextureSampleCustomBmp textureSampleCustomBmp = new TextureSampleCustomBmp();
                    textureSampleCustomBmp.Run();
                    break;
            }
        }
    }
}