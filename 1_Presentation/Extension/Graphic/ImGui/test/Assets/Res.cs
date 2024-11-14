// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Res.cs
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
using System.IO;

namespace Alis.Extension.Graphic.ImGui.Test.Assets
{
    /// <summary>
    ///     The res class
    /// </summary>
    public static class Res
    {
        /// <summary>
        ///     The directory
        /// </summary>
        public const string Directory = "Assets";

        /// <summary>
        ///     The video mp4
        /// </summary>
        public const string Video_Mp4 = "small.mp4";

        /// <summary>
        ///     The video webm
        /// </summary>
        public const string Video_Webm = "small.webm";

        /// <summary>
        ///     The video flv
        /// </summary>
        public const string Video_Flv = "small.flv";

        /// <summary>
        ///     The audio mp3
        /// </summary>
        public const string Audio_Mp3 = "horse.mp3";

        /// <summary>
        ///     The audio ogg
        /// </summary>
        public const string Audio_Ogg = "horse.ogg";

        /// <summary>
        ///     Gets the path using the specified resource name
        /// </summary>
        /// <param name="resourceName">The resource name</param>
        /// <returns>The string</returns>
        public static string GetPath(string resourceName) => Path.Combine(Path.Combine(Environment.CurrentDirectory, Directory), resourceName);
    }
}