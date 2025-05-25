// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbiJpeg.cs
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

using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stbi jpeg class
    /// </summary>
    public class StbiJpeg
    {
        /// <summary>
        ///     The app14 color transform
        /// </summary>
        public int App14ColorTransform;

        /// <summary>
        ///     The code bits
        /// </summary>
        public int CodeBits;

        /// <summary>
        ///     The code buffer
        /// </summary>
        public uint CodeBuffer;

        /// <summary>
        ///     The create array
        /// </summary>
        public ushort[][] Dequant = Utility.CreateArray<ushort>(4, 64);

        /// <summary>
        ///     The eob run
        /// </summary>
        public int EobRun;

        /// <summary>
        ///     The create array
        /// </summary>
        public short[][] FastAc = Utility.CreateArray<short>(4, 512);

        /// <summary>
        ///     The stbi huffman
        /// </summary>
        public StbiHuffman[] HuffAc = new StbiHuffman[4];

        /// <summary>
        ///     The stbi huffman
        /// </summary>
        public StbiHuffman[] HuffDc = new StbiHuffman[4];

        /// <summary>
        ///     The idct block kernel
        /// </summary>
        public StbImage.Delegate0 IdctBlockKernel;

        /// <summary>
        ///     The unnamed
        /// </summary>
        public Unnamed1[] ImgComp = new Unnamed1[4];

        /// <summary>
        ///     The img max
        /// </summary>
        public int ImgHMax;

        /// <summary>
        ///     The img mcu
        /// </summary>
        public int ImgMcuH;

        /// <summary>
        ///     The img mcu
        /// </summary>
        public int ImgMcuW;

        /// <summary>
        ///     The img mcu
        /// </summary>
        public int ImgMcuX;

        /// <summary>
        ///     The img mcu
        /// </summary>
        public int ImgMcuY;

        /// <summary>
        ///     The img max
        /// </summary>
        public int ImgVMax;

        /// <summary>
        ///     The jfif
        /// </summary>
        public int Jfif;

        /// <summary>
        ///     The marker
        /// </summary>
        public byte Marker;

        /// <summary>
        ///     The nomore
        /// </summary>
        public int Nomore;

        /// <summary>
        ///     The order
        /// </summary>
        public int[] Order = new int[4];

        /// <summary>
        ///     The progressive
        /// </summary>
        public int Progressive;

        /// <summary>
        ///     The resample row hv kernel
        /// </summary>
        public StbImage.Delegate2 ResampleRowHv2Kernel;

        /// <summary>
        ///     The restart interval
        /// </summary>
        public int RestartInterval;

        /// <summary>
        ///     The rgb
        /// </summary>
        public int Rgb;

        /// <summary>
        ///     The
        /// </summary>
        public StbImage.StbiContext S;

        /// <summary>
        ///     The scan
        /// </summary>
        public int ScanN;

        /// <summary>
        ///     The spec end
        /// </summary>
        public int SpecEnd;

        /// <summary>
        ///     The spec start
        /// </summary>
        public int SpecStart;

        /// <summary>
        ///     The succ high
        /// </summary>
        public int SuccHigh;

        /// <summary>
        ///     The succ low
        /// </summary>
        public int SuccLow;

        /// <summary>
        ///     The todo
        /// </summary>
        public int Todo;

        /// <summary>
        ///     The ycbcr to rgb kernel
        /// </summary>
        public StbImage.Delegate1 YCbCrToRgbKernel;
    }
}