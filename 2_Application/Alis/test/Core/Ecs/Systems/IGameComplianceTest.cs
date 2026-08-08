using System.Reflection;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems
{
    /// <summary>
    /// The game compliance test class
    /// </summary>
    public class IGameComplianceTest
    {
        /// <summary>
        /// Tests that interface is implemented by video game
        /// </summary>
        [Fact]
        public void Interface_IsImplementedByVideoGame()
        {
            VideoGame game = new VideoGame();
            Assert.IsAssignableFrom<IGame>(game);
        }

        /// <summary>
        /// Tests that interface has run and exit methods
        /// </summary>
        [Fact]
        public void Interface_HasRunAndExitMethods()
        {
            MethodInfo[] methods = typeof(IGame).GetMethods();
            Assert.Contains(methods, m => m.Name == "Run");
            Assert.Contains(methods, m => m.Name == "Exit");
        }
    }
}
