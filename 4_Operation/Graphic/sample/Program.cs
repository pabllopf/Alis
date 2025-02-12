using System;

namespace Alis.Core.Graphic.Sample
{
    /// <summary>
    /// The program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of the sample you want to run:");
            Console.WriteLine("1. Triangle Sample");
            Console.WriteLine("2. Cube Sample");
            Console.WriteLine("3. Texture Sample");
            Console.WriteLine("4. Rotate 3D Object Sample");
            Console.WriteLine("5. Load BMP Image");
            Console.WriteLine("6. Render a square unfilled");
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
                    TextureSample textureSample = new TextureSample();
                    textureSample.Run();
                    break;
                case 4:
                    Rotate3DObjectSample rotate3DObjectSampleSample = new Rotate3DObjectSample();
                    rotate3DObjectSampleSample.Run();
                    break;
                
                case 5:
                    LoadBmpImagenSample loadBmpImagen = new LoadBmpImagenSample();
                    loadBmpImagen.Run();
                    break;
                
                case 6:
                    RenderSquareUnfilled unfilled = new RenderSquareUnfilled();
                    unfilled.Run();
                    break;

            }
        }
    }
}