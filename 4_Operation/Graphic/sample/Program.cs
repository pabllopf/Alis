// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Diagnostics;
using Alis.Core.Aspect.Logging;

namespace Alis.Core.Graphic.Sample
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
            Logger.Log("1. Triangle Sample");
            Logger.Log("2. Cube Sample");
            Logger.Log("3. Texture Sample");
            Logger.Log("4. Rotate 3D Object Sample");
            Logger.Log("5. Load BMP Image");
            Logger.Log("6. Render a square unfilled");
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