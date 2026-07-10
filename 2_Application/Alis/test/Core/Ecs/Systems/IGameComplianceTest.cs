using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems
{
    public class IGameComplianceTest
    {
        [Fact]
        public void Interface_IsImplementedByVideoGame()
        {
            var game = new VideoGame();
            Assert.IsAssignableFrom<IGame>(game);
        }

        [Fact]
        public void Interface_HasRunAndExitMethods()
        {
            var methods = typeof(IGame).GetMethods();
            Assert.Contains(methods, m => m.Name == "Run");
            Assert.Contains(methods, m => m.Name == "Exit");
        }
    }
}
