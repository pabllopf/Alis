using System.Collections.Generic;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// Adds a deterministic stress matrix for flag combinations and query hashing behavior.
    /// </summary>
    public class EcsMassiveNormalAndEdgeCasesTest
    {
        /// <summary>
        /// Generates the flags and hash cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateFlagsAndHashCases()
        {
            for (int i = 0; i < 2500; i++)
            {
                int leftMask = (i * 17) & 0x0FFF;
                int rightMask = (i * 29 + 7) & 0x0FFF;
                bool includeWorldCreate = (i & 1) == 0;
                yield return new object[] {leftMask, rightMask, includeWorldCreate};
            }
        }

        /// <summary>
        /// Tests that flags and query hash normal and edge cases are deterministic
        /// </summary>
        /// <param name="leftMask">The left mask</param>
        /// <param name="rightMask">The right mask</param>
        /// <param name="includeWorldCreate">The include world create</param>
        [Theory, MemberData(nameof(GenerateFlagsAndHashCases))]
        public void FlagsAndQueryHash_NormalAndEdgeCases_AreDeterministic(int leftMask, int rightMask, bool includeWorldCreate)
        {
            GameObjectFlags left = (GameObjectFlags) leftMask;
            GameObjectFlags right = (GameObjectFlags) rightMask;
            GameObjectFlags combined = left | right;

            Assert.Equal(leftMask | rightMask, (int) combined);

            if (includeWorldCreate)
            {
                combined |= GameObjectFlags.WorldCreate;
                Assert.True(combined.HasFlag(GameObjectFlags.WorldCreate));
            }

            QueryHash seed = QueryHash.New();
            QueryHash one = QueryHash.New().AddRule(default);
            QueryHash two = QueryHash.New().AddRule(default);
            QueryHash twiceA = QueryHash.New().AddRule(default).AddRule(default);
            QueryHash twiceB = QueryHash.New().AddRule(default).AddRule(default);

            Assert.NotEqual(0, seed.ToHashCode());
            Assert.Equal(one.ToHashCode(), two.ToHashCode());
            Assert.Equal(twiceA.ToHashCode(), twiceB.ToHashCode());
        }
    }
}

