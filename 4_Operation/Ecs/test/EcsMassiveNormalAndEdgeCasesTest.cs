// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EcsMassiveNormalAndEdgeCasesTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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

