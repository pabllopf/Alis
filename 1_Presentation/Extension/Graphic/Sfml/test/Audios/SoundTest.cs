// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SoundTest.cs
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
using Alis.Extension.Graphic.Sfml.Audios;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    ///     Unit tests for the Sound class.
    /// </summary>
    public class SoundTest
    {
        /// <summary>
        ///     Tests that Sound type is accessible.
        /// </summary>
        [Fact]
        public void Sound_Type_ShouldBeAccessible()
        {
            Assert.NotNull(typeof(Sound));
        }

        /// <summary>
        ///     Tests that Sound implements IDisposable via type check.
        /// </summary>
        [Fact]
        public void Sound_ShouldImplementIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(Sound)));
        }

        /// <summary>
        ///     Tests that Sound inherits from ObjectBase.
        /// </summary>
        [Fact]
        public void Sound_ShouldInheritFromObjectBase()
        {
            Assert.Equal("ObjectBase", typeof(Sound).BaseType.Name);
        }

        /// <summary>
        ///     Tests that SoundStatus enum values are defined.
        /// </summary>
        [Fact]
        public void SoundStatus_ShouldHaveDefinedValues()
        {
            Assert.True(Enum.IsDefined(typeof(SoundStatus), SoundStatus.Stopped));
            Assert.True(Enum.IsDefined(typeof(SoundStatus), SoundStatus.Paused));
            Assert.True(Enum.IsDefined(typeof(SoundStatus), SoundStatus.Playing));
        }

        /// <summary>
        ///     Tests that Sound namespace exposes Audio types.
        /// </summary>
        [Fact]
        public void Sound_Namespace_ShouldContainSound()
        {
            Assert.Equal("Alis.Extension.Graphic.Sfml.Audios", typeof(Sound).Namespace);
        }
    }
}