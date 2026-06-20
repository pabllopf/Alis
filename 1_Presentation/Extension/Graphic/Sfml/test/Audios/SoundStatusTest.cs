// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SoundStatusTest.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    ///     Tests the <see cref="SoundStatus" /> enum.
    /// </summary>
    public class SoundStatusTest
    {
        [Fact]
        public void Stopped_HasValue0() => Assert.Equal(0, (int) SoundStatus.Stopped);

        [Fact]
        public void Paused_HasValue1() => Assert.Equal(1, (int) SoundStatus.Paused);

        [Fact]
        public void Playing_HasValue2() => Assert.Equal(2, (int) SoundStatus.Playing);
    }
}
