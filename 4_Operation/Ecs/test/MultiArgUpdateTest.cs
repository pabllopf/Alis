using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The multi arg update test class
    /// </summary>
    public class MultiArgUpdateTest
    {
        /// <summary>
        /// Tests that update with 6 args works
        /// </summary>
        [Fact] public void Update_With6Args_Works()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                    new TestComponent(), new AnotherComponent(), new Damage());
                for (int f = 0; f < 3; f++)
                    scene.Update();
            }
        }

        /// <summary>
        /// Tests that update with 7 args works
        /// </summary>
        [Fact] public void Update_With7Args_Works()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                    new TestComponent(), new AnotherComponent(), new Damage(), new Armor());
                for (int f = 0; f < 3; f++)
                    scene.Update();
            }
        }
    }
}
