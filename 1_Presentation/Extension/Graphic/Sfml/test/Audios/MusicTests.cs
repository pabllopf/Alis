// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MusicTests.cs
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

using Alis.Extension.Graphic.Sfml.Audios;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    ///     The music tests class
    /// </summary>
    public class MusicTests
    {
        /// <summary>
        ///     Tests that constructor from file throws if file not found
        /// </summary>
        [Fact(Skip = "Cannot test Music without native SFML dependencies and audio files.")]
        public void Constructor_FromFile_ThrowsIfFileNotFound()
        {
            Assert.Throws<LoadingFailedException>(() => new Music("notfound.ogg"));
        }

        /// <summary>
        ///     Tests that to string returns music
        /// </summary>
        [Fact(Skip = "Cannot test Music without native SFML dependencies.")]
        public void ToString_ReturnsMusic()
        {
            Music music = new Music("somefile.ogg");
            Assert.Equal("Music", music.ToString());
        }
    }
}