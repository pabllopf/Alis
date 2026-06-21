// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputSettingTest.cs
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

using Alis.Core.Ecs.Systems.Configuration.Input;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Configuration.Input
{
    /// <summary>
    ///     Tests for the InputSetting struct
    /// </summary>
    public class InputSettingTest
    {
        /// <summary>
        ///     Tests that default constructor sets default mouse sensitivity
        /// </summary>
        [Fact]
        public void InputSetting_DefaultConstructor_ShouldSetDefaultValue()
        {
            InputSetting setting = new InputSetting();

            Assert.Equal(0.1f, setting.MouseSensitivity);
        }

        /// <summary>
        ///     Tests that parameterized constructor sets the value
        /// </summary>
        [Fact]
        public void InputSetting_ParameterizedConstructor_ShouldSetValue()
        {
            InputSetting setting = new InputSetting(0.5f);

            Assert.Equal(0.5f, setting.MouseSensitivity);
        }

        /// <summary>
        ///     Tests that MouseSensitivity can be modified
        /// </summary>
        [Fact]
        public void InputSetting_MouseSensitivity_ShouldBeModifiable()
        {
            InputSetting setting = new InputSetting();

            setting.MouseSensitivity = 0.75f;
            Assert.Equal(0.75f, setting.MouseSensitivity);
        }

        /// <summary>
        ///     Tests that InputSetting implements IInputSetting interface
        /// </summary>
        [Fact]
        public void InputSetting_ShouldImplementIInputSetting()
        {
            InputSetting setting = new InputSetting();
            Assert.IsAssignableFrom<IInputSetting>(setting);
        }
    }
}
