// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneralSettingStructTest.cs
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

using Alis.Core.Ecs.Systems.Configuration.General;
using Xunit;

namespace Alis.Test
{
    public class GeneralSettingStructTest
    {
        [Fact]
        public void DefaultValues_ShouldBeCorrect()
        {
            GeneralSetting setting = new GeneralSetting();
            Assert.False(setting.Debug);
            Assert.Equal("Default Name", setting.Name);
            Assert.Equal("Default Description", setting.Description);
            Assert.Equal("0.0.0", setting.Version);
            Assert.Equal("Pablo Perdomo Falcón", setting.Author);
            Assert.Equal("GPL-3.0 license", setting.License);
            Assert.Equal("app.ico", setting.Icon);
        }

        [Fact]
        public void CustomConstructor_ShouldStoreValues()
        {
            GeneralSetting setting = new GeneralSetting(true, "Test", "Desc", "1.0", "Author", "MIT", "icon.png");
            Assert.True(setting.Debug);
            Assert.Equal("Test", setting.Name);
            Assert.Equal("Desc", setting.Description);
            Assert.Equal("1.0", setting.Version);
            Assert.Equal("Author", setting.Author);
            Assert.Equal("MIT", setting.License);
            Assert.Equal("icon.png", setting.Icon);
        }

        [Fact]
        public void ShouldImplementIGeneralSetting()
        {
            GeneralSetting setting = new GeneralSetting();
            Assert.IsAssignableFrom<IGeneralSetting>(setting);
        }
    }
}
