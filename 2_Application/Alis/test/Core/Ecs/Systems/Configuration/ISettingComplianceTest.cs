using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.Audio;
using Alis.Core.Ecs.Systems.Configuration.General;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Alis.Core.Ecs.Systems.Configuration.Input;
using Alis.Core.Ecs.Systems.Configuration.Network;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Configuration
{
    public class ISettingComplianceTest
    {
        [Fact]
        public void Interface_IsImplementedBySetting()
        {
            var setting = new Setting();
            Assert.IsAssignableFrom<ISetting>(setting);
        }

        [Fact]
        public void Interface_HasAllSettingProperties()
        {
            var setting = new Setting();
            Assert.NotNull(setting.General);
            Assert.NotNull(setting.Audio);
            Assert.NotNull(setting.Graphic);
            Assert.NotNull(setting.Input);
            Assert.NotNull(setting.Network);
            Assert.NotNull(setting.Physic);
        }

        [Fact]
        public void IAudioSetting_IsImplemented()
        {
            var audio = new AudioSetting();
            Assert.IsAssignableFrom<IAudioSetting>(audio);
        }

        [Fact]
        public void IGeneralSetting_IsImplemented()
        {
            var general = new GeneralSetting();
            Assert.IsAssignableFrom<IGeneralSetting>(general);
        }

        [Fact]
        public void IGraphicSetting_IsImplemented()
        {
            var graphic = new GraphicSetting();
            Assert.IsAssignableFrom<IGraphicSetting>(graphic);
        }

        [Fact]
        public void IInputSetting_IsImplemented()
        {
            var input = new InputSetting();
            Assert.IsAssignableFrom<IInputSetting>(input);
        }

        [Fact]
        public void INetworkSetting_IsImplemented()
        {
            var network = new NetworkSetting();
            Assert.IsAssignableFrom<INetworkSetting>(network);
        }

        [Fact]
        public void IPhysicSetting_IsImplemented()
        {
            var physic = new PhysicSetting();
            Assert.IsAssignableFrom<IPhysicSetting>(physic);
        }
    }
}
