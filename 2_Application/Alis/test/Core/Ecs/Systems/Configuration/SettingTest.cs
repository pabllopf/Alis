// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingTest.cs
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

using Alis.Core.Ecs.Systems.Configuration;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Configuration
{
    /// <summary>
    ///     Tests for the <see cref="Setting" /> class.
    /// </summary>
    public class SettingTest
    {
        /// <summary>
        ///     Tests that default constructor creates all nested settings.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldCreateAllNestedSettings()
        {
            Setting setting = new Setting();
        }

        /// <summary>
        ///     Tests that Setting implements ISetting.
        /// </summary>
        [Fact]
        public void ShouldImplementISetting()
        {
            Setting setting = new Setting();

            Assert.IsAssignableFrom<ISetting>(setting);
        }
    }
}
