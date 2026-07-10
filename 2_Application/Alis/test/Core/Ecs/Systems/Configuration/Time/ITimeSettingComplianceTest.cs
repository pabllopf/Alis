using Alis.Core.Ecs.Systems.Configuration.Time;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Configuration.Time
{
    public class ITimeSettingComplianceTest
    {
        [Fact]
        public void Interface_IsImplementedByTimeSetting()
        {
            var timeSetting = new TimeSetting();
            Assert.IsAssignableFrom<ITimeSetting>(timeSetting);
        }
    }
}
