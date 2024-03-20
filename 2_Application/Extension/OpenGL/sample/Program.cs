using System;

namespace Alis.Extension.OpenGL.Sample
{
    /// <summary>
    /// The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Enter the number of the sample you want to run:");
            Console.WriteLine("1. Triangle Sample");
            Console.WriteLine("2. Cube Sample");
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
            }
        }
    }
}