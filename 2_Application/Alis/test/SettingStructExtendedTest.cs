// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingStructExtendedTest.cs
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
using Alis.Core.Ecs.Systems.Configuration.Audio;
using Alis.Core.Ecs.Systems.Configuration.General;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Alis.Core.Ecs.Systems.Configuration.Input;
using Alis.Core.Ecs.Systems.Configuration.Network;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Xunit;

namespace Alis.Test
{
    public class SettingStructExtendedTest
    {
        [Fact]
        public void CustomConstructor_ShouldStoreAllSettings()
        {
            GeneralSetting general = new GeneralSetting(true, "App", "Desc", "1.0", "Me", "MIT", "icon.ico");
            AudioSetting audio = new AudioSetting(80, true);
            GraphicSetting graphic = new GraphicSetting(120, "Vulkan", false, Alis.Core.Aspect.Math.Definition.Color.White, true, Alis.Core.Aspect.Math.Definition.Color.Black, new Alis.Core.Aspect.Math.Vector.Vector2F(1920, 1080), false);
            InputSetting input = new InputSetting(2.0f);
            NetworkSetting network = new NetworkSetting(9090, "0.0.0.0", "srv", "tcp");
            PhysicSetting physic = new PhysicSetting(new Alis.Core.Aspect.Math.Vector.Vector2F(0, -5f), true, Alis.Core.Aspect.Math.Definition.Color.Blue);

            Setting setting = new Setting(general, audio, graphic, input, network, physic);
            Assert.Equal("App", setting.General.Name);
            Assert.Equal(80, setting.Audio.Volume);
            Assert.Equal("Vulkan", setting.Graphic.Target);
            Assert.Equal(2.0f, setting.Input.MouseSensitivity);
            Assert.Equal(9090, setting.Network.Port);
            Assert.Equal(new Alis.Core.Aspect.Math.Vector.Vector2F(0, -5f), setting.Physic.Gravity);
        }

        [Fact]
        public void Settings_ShouldBeSettable()
        {
            Setting setting = new Setting();
            setting.General = new GeneralSetting(true, "Changed", "NewDesc", "2.0", "You", "Apache", "new.ico");
            Assert.Equal("Changed", setting.General.Name);
            Assert.True(setting.General.Debug);
        }
    }
}
