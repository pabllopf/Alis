// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSourceSonarComplianceTest.cs
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

using System.Reflection;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Systems.Scope;
using Moq;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Audio
{
    /// <summary>
    ///     Regression tests preventing SonarCloud S2292 (trivial properties) from reappearing.
    /// </summary>
    public class AudioSourceSonarComplianceTest
    {
        /// <summary>
        ///     Tests that PlayerForTest is an auto-property with no explicit backing field.
        /// </summary>
        [Fact]
        public void PlayerForTest_IsAutoProperty_NoBackingFieldExists()
        {
            FieldInfo playerField = typeof(AudioSource).GetField("player", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.Null(playerField);
        }

        /// <summary>
        ///     Tests that PlayerForTest property exists with both getter and setter.
        /// </summary>
        [Fact]
        public void PlayerForTest_Property_HasGetterAndSetter()
        {
            PropertyInfo property = typeof(AudioSource).GetProperty("PlayerForTest", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotNull(property);
            Assert.True(property.CanRead);
            Assert.True(property.CanWrite);
        }

        /// <summary>
        ///     Tests that PlayerForTest can be set with a mock and operations use the property.
        /// </summary>
        [Fact]
        public void PlayerForTest_SetAndGet_WorksCorrectly()
        {
            Context context = new Context();
            AudioSource source = new AudioSource(context);
            Mock<IPlayer> mock = new Mock<IPlayer>();

            source.PlayerForTest = mock.Object;

            Assert.Same(mock.Object, source.PlayerForTest);
        }
    }
}
