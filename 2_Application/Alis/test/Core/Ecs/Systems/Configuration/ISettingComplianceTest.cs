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
    /// <summary>
    /// The setting compliance test class
    /// </summary>
    public class ISettingComplianceTest
    {
        /// <summary>
        /// Tests that interface is implemented by setting
        /// </summary>
        [Fact]
        public void Interface_IsImplementedBySetting()
        {
            Setting setting = new Setting();
            Assert.IsAssignableFrom<ISetting>(setting);
        }

        /// <summary>
        /// Tests that interface has all setting properties
        /// </summary>
        [Fact]
        public void Interface_HasAllSettingProperties()
        {
            Setting setting = new Setting();
            Assert.NotNull(setting.General);
            Assert.NotNull(setting.Audio);
            Assert.NotNull(setting.Graphic);
            Assert.NotNull(setting.Input);
            Assert.NotNull(setting.Network);
            Assert.NotNull(setting.Physic);
        }

        /// <summary>
        /// Tests that i audio setting is implemented
        /// </summary>
        [Fact]
        public void IAudioSetting_IsImplemented()
        {
            AudioSetting audio = new AudioSetting();
            Assert.IsAssignableFrom<IAudioSetting>(audio);
        }

        /// <summary>
        /// Tests that i general setting is implemented
        /// </summary>
        [Fact]
        public void IGeneralSetting_IsImplemented()
        {
            GeneralSetting general = new GeneralSetting();
            Assert.IsAssignableFrom<IGeneralSetting>(general);
        }

        /// <summary>
        /// Tests that i graphic setting is implemented
        /// </summary>
        [Fact]
        public void IGraphicSetting_IsImplemented()
        {
            GraphicSetting graphic = new GraphicSetting();
            Assert.IsAssignableFrom<IGraphicSetting>(graphic);
        }

        /// <summary>
        /// Tests that i input setting is implemented
        /// </summary>
        [Fact]
        public void IInputSetting_IsImplemented()
        {
            InputSetting input = new InputSetting();
            Assert.IsAssignableFrom<IInputSetting>(input);
        }

        /// <summary>
        /// Tests that i network setting is implemented
        /// </summary>
        [Fact]
        public void INetworkSetting_IsImplemented()
        {
            NetworkSetting network = new NetworkSetting();
            Assert.IsAssignableFrom<INetworkSetting>(network);
        }

        /// <summary>
        /// Tests that i physic setting is implemented
        /// </summary>
        [Fact]
        public void IPhysicSetting_IsImplemented()
        {
            PhysicSetting physic = new PhysicSetting();
            Assert.IsAssignableFrom<IPhysicSetting>(physic);
        }
    }
}
