// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EncoderOptionsBuilder.cs
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

namespace Alis.Extension.FFMeg.Encoding
{
    /// <summary>
    ///     Base class for EncoderOptions builders. Implement this for separate encoders.
    /// </summary>
    public abstract class EncoderOptionsBuilder
    {
        /// <summary>
        ///     FFmpeg format name (container format)
        /// </summary>
        public abstract string Format { get; set; }

        /// <summary>
        ///     FFmpeg encoder name
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        ///     Create an EncoderOptions object from FFmpeg based on the configuration
        /// </summary>
        public abstract EncoderOptions Create();
    }
}