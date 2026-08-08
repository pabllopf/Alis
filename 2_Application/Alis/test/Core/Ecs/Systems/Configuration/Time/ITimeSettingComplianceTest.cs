using Alis.Core.Ecs.Systems.Configuration.Time;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Configuration.Time
{
    /// <summary>
    /// The time setting compliance test class
    /// </summary>
    public class ITimeSettingComplianceTest
    {
        /// <summary>
        /// Tests that interface is implemented by time setting
        /// </summary>
        [Fact]
        public void Interface_IsImplementedByTimeSetting()
        {
            TimeSetting timeSetting = new TimeSetting();
            Assert.IsAssignableFrom<ITimeSetting>(timeSetting);
        }
    }
}
