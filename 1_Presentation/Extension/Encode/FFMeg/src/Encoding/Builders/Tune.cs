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

namespace Alis.Extension.Encode.FFMeg.Encoding.Builders
{
    /// <summary>
    ///     The tune enum
    /// </summary>
    public enum Tune
    {
        /// <summary>
        ///     The auto tune
        /// </summary>
        Auto,

        /// <summary>
        ///     Use for high quality movie content; lowers deblocking
        /// </summary>
        Film,

        /// <summary>
        ///     Good for cartoons; uses higher deblocking and more reference frames
        /// </summary>
        Animation,

        /// <summary>
        ///     Preserves the grain structure in old, grainy film material
        /// </summary>
        Grain,

        /// <summary>
        ///     Good for slideshow-like content
        /// </summary>
        StillImage,

        /// <summary>
        ///     Allows faster decoding by disabling certain filters
        /// </summary>
        FastDecode,

        /// <summary>
        ///     Good for fast encoding and low-latency streaming
        /// </summary>
        ZeroLatency
    }
}