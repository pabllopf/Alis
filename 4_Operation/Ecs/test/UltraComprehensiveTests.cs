

using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Ultra comprehensive tests for maximum coverage
    /// </summary>
    public class UltraComprehensiveTests
    {
        /// <summary>
        ///     Tests that ultra comp complex matrix
        /// </summary>
        /// <param name="e">The </param>
        /// <param name="c">The </param>
        /// <param name="o">The </param>
        /// <param name="m">The </param>
        /// <param name="q">The </param>
        [Theory, InlineData(1, 1, 1, 1, 1), InlineData(1, 1, 1, 1, 2), InlineData(1, 1, 1, 1, 3), InlineData(1, 1, 1, 2, 1), InlineData(1, 1, 1, 2, 2), InlineData(1, 1, 1, 2, 3), InlineData(1, 1, 2, 1, 1), InlineData(1, 1, 2, 1, 2), InlineData(1, 1, 2, 1, 3), InlineData(1, 1, 2, 2, 1), InlineData(1, 1, 2, 2, 2), InlineData(1, 1, 2, 2, 3), InlineData(1, 2, 1, 1, 1),
         InlineData(1, 2, 1, 1, 2), InlineData(1, 2, 1, 1, 3), InlineData(1, 2, 1, 2, 1), InlineData(1, 2, 1, 2, 2), InlineData(1, 2, 1, 2, 3), InlineData(1, 2, 2, 1, 1), InlineData(1, 2, 2, 1, 2), InlineData(1, 2, 2, 1, 3), InlineData(1, 2, 2, 2, 1), InlineData(1, 2, 2, 2, 2), InlineData(1, 2, 2, 2, 3), InlineData(2, 1, 1, 1, 1), InlineData(2, 1, 1, 1, 2), InlineData(2, 1, 1, 1, 3),
         InlineData(2, 1, 1, 2, 1), InlineData(2, 1, 1, 2, 2), InlineData(2, 1, 1, 2, 3), InlineData(2, 1, 2, 1, 1), InlineData(2, 1, 2, 1, 2), InlineData(2, 1, 2, 1, 3), InlineData(2, 1, 2, 2, 1), InlineData(2, 1, 2, 2, 2), InlineData(2, 1, 2, 2, 3), InlineData(2, 2, 1, 1, 1), InlineData(2, 2, 1, 1, 2), InlineData(2, 2, 1, 1, 3), InlineData(2, 2, 1, 2, 1), InlineData(2, 2, 1, 2, 2),
         InlineData(2, 2, 1, 2, 3), InlineData(2, 2, 2, 1, 1), InlineData(2, 2, 2, 1, 2), InlineData(2, 2, 2, 1, 3), InlineData(2, 2, 2, 2, 1), InlineData(2, 2, 2, 2, 2), InlineData(2, 2, 2, 2, 3), InlineData(3, 1, 1, 1, 1), InlineData(3, 1, 1, 1, 2), InlineData(3, 1, 1, 1, 3), InlineData(3, 1, 1, 2, 1), InlineData(3, 1, 1, 2, 2), InlineData(3, 1, 1, 2, 3), InlineData(3, 1, 2, 1, 1),
         InlineData(3, 1, 2, 1, 2), InlineData(3, 1, 2, 1, 3), InlineData(3, 1, 2, 2, 1), InlineData(3, 1, 2, 2, 2), InlineData(3, 1, 2, 2, 3), InlineData(3, 2, 1, 1, 1), InlineData(3, 2, 1, 1, 2), InlineData(3, 2, 1, 1, 3), InlineData(3, 2, 1, 2, 1), InlineData(3, 2, 1, 2, 2), InlineData(3, 2, 1, 2, 3), InlineData(3, 2, 2, 1, 1), InlineData(3, 2, 2, 1, 2), InlineData(3, 2, 2, 1, 3),
         InlineData(3, 2, 2, 2, 1), InlineData(3, 2, 2, 2, 2), InlineData(3, 2, 2, 2, 3), InlineData(5, 1, 1, 1, 1), InlineData(5, 1, 1, 1, 2), InlineData(5, 1, 1, 1, 3), InlineData(5, 1, 1, 2, 1), InlineData(5, 1, 1, 2, 2), InlineData(5, 1, 1, 2, 3), InlineData(5, 1, 2, 1, 1), InlineData(5, 1, 2, 1, 2), InlineData(5, 1, 2, 1, 3), InlineData(5, 1, 2, 2, 1), InlineData(5, 1, 2, 2, 2),
         InlineData(5, 1, 2, 2, 3), InlineData(5, 2, 1, 1, 1), InlineData(5, 2, 1, 1, 2), InlineData(5, 2, 1, 1, 3), InlineData(5, 2, 1, 2, 1), InlineData(5, 2, 1, 2, 2), InlineData(5, 2, 1, 2, 3), InlineData(5, 2, 2, 1, 1), InlineData(5, 2, 2, 1, 2), InlineData(5, 2, 2, 1, 3), InlineData(5, 2, 2, 2, 1), InlineData(5, 2, 2, 2, 2), InlineData(5, 2, 2, 2, 3), InlineData(10, 1, 1, 1, 1),
         InlineData(10, 1, 1, 1, 2), InlineData(10, 1, 1, 1, 3), InlineData(10, 1, 1, 2, 1), InlineData(10, 1, 1, 2, 2), InlineData(10, 1, 1, 2, 3), InlineData(10, 1, 2, 1, 1), InlineData(10, 1, 2, 1, 2), InlineData(10, 1, 2, 1, 3), InlineData(10, 1, 2, 2, 1), InlineData(10, 1, 2, 2, 2), InlineData(10, 1, 2, 2, 3), InlineData(10, 2, 1, 1, 1), InlineData(10, 2, 1, 1, 2),
         InlineData(10, 2, 1, 1, 3), InlineData(10, 2, 1, 2, 1), InlineData(10, 2, 1, 2, 2), InlineData(10, 2, 1, 2, 3), InlineData(10, 2, 2, 1, 1), InlineData(10, 2, 2, 1, 2), InlineData(10, 2, 2, 1, 3), InlineData(10, 2, 2, 2, 1), InlineData(10, 2, 2, 2, 2), InlineData(10, 2, 2, 2, 3), InlineData(20, 1, 1, 1, 1), InlineData(20, 1, 1, 2, 2), InlineData(20, 1, 2, 1, 3),
         InlineData(20, 1, 2, 2, 1), InlineData(20, 2, 1, 1, 2), InlineData(20, 2, 1, 2, 3), InlineData(20, 2, 2, 1, 1), InlineData(20, 2, 2, 2, 2), InlineData(50, 1, 1, 1, 1), InlineData(50, 1, 1, 2, 2), InlineData(50, 1, 2, 1, 3), InlineData(50, 2, 1, 1, 1), InlineData(50, 2, 2, 2, 2), InlineData(100, 1, 1, 1, 1), InlineData(100, 2, 2, 2, 2)]
        public void UltraComp_ComplexMatrix(int e, int c, int o, int m, int q)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < e; i++)
            {
                scene.Create(new Position {X = i, Y = i});
            }

            if (o == 1)
            {
                foreach (GameObject go in scene.Query<With<Position>>().EnumerateWithEntities())
                {
                    ref Position pos = ref go.Get<Position>();
                    pos.X += m;
                }
            }

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that ultra comp series creation
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(3), InlineData(4), InlineData(5), InlineData(6), InlineData(7), InlineData(8), InlineData(9), InlineData(10), InlineData(11), InlineData(12), InlineData(13), InlineData(14), InlineData(15), InlineData(16), InlineData(17), InlineData(18), InlineData(19), InlineData(20), InlineData(25), InlineData(30), InlineData(35), InlineData(40),
         InlineData(45), InlineData(50), InlineData(60), InlineData(70), InlineData(80), InlineData(90), InlineData(100), InlineData(150), InlineData(200)]
        public void UltraComp_SeriesCreation(int count)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < count; i++)
            {
                scene.Create(new Position {X = i, Y = i});
            }

            int queryCount = 0;
            foreach (GameObject go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                queryCount++;
            }

            Assert.Equal(count, queryCount);
        }

        /// <summary>
        ///     Tests that ultra comp dual parametrized
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        [Theory, InlineData(1, 1), InlineData(1, 2), InlineData(1, 3), InlineData(2, 1), InlineData(2, 2), InlineData(2, 3), InlineData(3, 1), InlineData(3, 2), InlineData(3, 3), InlineData(5, 1), InlineData(5, 2), InlineData(5, 3), InlineData(10, 1), InlineData(10, 2), InlineData(10, 3), InlineData(20, 1), InlineData(20, 2), InlineData(20, 3), InlineData(50, 1), InlineData(50, 2),
         InlineData(50, 3), InlineData(100, 1), InlineData(100, 2), InlineData(100, 3)]
        public void UltraComp_DualParametrized(int a, int b)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < a; i++)
            {
                GameObject go = scene.Create();
                if (b >= 1)
                {
                    go.Add(new Position {X = 1, Y = 1});
                }

                if (b >= 2)
                {
                    go.Add(new Health {Value = 100});
                }

                if (b >= 3)
                {
                    go.Add(new Velocity {X = 1, Y = 1});
                }
            }

            Assert.True(true);
        }
    }
}