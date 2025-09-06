using System;
using Xunit;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    public class ClockTests
    {
        [Fact(Skip = "Cannot test Clock without native SFML dependencies.")]
        public void Constructor_CreatesClock()
        {
            Clock clock = new Clock();
            Assert.NotNull(clock);
        }

        [Fact(Skip = "Cannot test Clock without native SFML dependencies.")]
        public void ElapsedTime_ReturnsTime()
        {
            Clock clock = new Clock();
            Time elapsed = clock.ElapsedTime;
            Assert.IsType<Time>(elapsed);
        }

        [Fact(Skip = "Cannot test Clock without native SFML dependencies.")]
        public void Restart_ReturnsTime()
        {
            Clock clock = new Clock();
            Time time = clock.Restart();
            Assert.IsType<Time>(time);
        }
    }
}

