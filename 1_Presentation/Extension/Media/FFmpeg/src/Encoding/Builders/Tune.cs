// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Tune.cs
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

namespace Alis.Extension.Media.FFmpeg.Encoding.Builders
{
    /// <summary>
    ///     The tune enum
    /// </summary>
    public enum Tune
    {
        /// <summary>
        ///     The auto tune
        /// </summary>
        Auto = 0,

        /// <summary>
        ///     Use for high quality movie content; lowers deblocking
        /// </summary>
        Film = 1,

        /// <summary>
        ///     Good for cartoons; uses higher deblocking and more reference frames
        /// </summary>
        Animation = 2,

        /// <summary>
        ///     Preserves the grain structure in old, grainy film material
        /// </summary>
        Grain = 3,

        /// <summary>
        ///     Good for slideshow-like content
        /// </summary>
        StillImage = 4,

        /// <summary>
        ///     Allows faster decoding by disabling certain filters
        /// </summary>
        FastDecode = 5,

        /// <summary>
        ///     Good for fast encoding and low-latency streaming
        /// </summary>
        ZeroLatency = 6
    }
}