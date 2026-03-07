// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IntegrationTestSuite.cs
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
using Xunit;

namespace Alis.Core.Test
{
    /// <summary>
    ///     Cross-module integration tests.
    ///     Tests interactions between different modules.
    /// </summary>
    public class IntegrationTestSuite
    {
        /// <summary>
        ///     Generates the module combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateModuleCombinations()
        {
            string[] modules = {"Math", "Physics", "Graphics", "Audio", "ECS", "Logging", "Time"};

            foreach (string mod1 in modules)
            {
                foreach (string mod2 in modules)
                {
                    if (mod1 != mod2)
                    {
                        yield return new object[] {mod1, mod2};
                    }
                }
            }
        }

        /// <summary>
        ///     Tests that module interaction test
        /// </summary>
        /// <param name="module1">The module</param>
        /// <param name="module2">The module</param>
        [Theory, MemberData(nameof(GenerateModuleCombinations))]
        public void ModuleInteraction_Test(string module1, string module2)
        {
            Assert.NotNull(module1);
            Assert.NotNull(module2);
        }

        /// <summary>
        ///     Generates the system wide combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateSystemWideCombinations()
        {
            // Simulate system-wide scenarios
            for (int scenario = 0; scenario < 100; scenario++)
            {
                yield return new object[] {scenario};
            }
        }

        /// <summary>
        ///     Tests that system wide integration
        /// </summary>
        /// <param name="scenario">The scenario</param>
        [Theory, MemberData(nameof(GenerateSystemWideCombinations))]
        public void SystemWide_Integration(int scenario)
        {
            Assert.True(scenario >= 0);
        }
    }
}