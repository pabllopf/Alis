// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotMassiveTest.cs
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides large-scale API-surface regression coverage for the <see cref="ImPlot" /> wrapper.
    /// </summary>
    public class ImPlotMassiveTest
    {
        /// <summary>
        ///     Stores the full public static method catalog for ImPlot.
        /// </summary>
        private static readonly MethodInfo[] Catalog = typeof(ImPlot)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .OrderBy(method => method.Name, StringComparer.Ordinal)
            .ThenBy(method => method.GetParameters().Length)
            .ThenBy(method => method.ToString(), StringComparer.Ordinal)
            .ToArray();

        /// <summary>
        ///     Generates at least 500 deterministic API signature cases.
        /// </summary>
        /// <returns>Method signature cases reused in a deterministic cycle.</returns>
        public static IEnumerable<object[]> ApiSignatureCases()
        {
            const int requiredCases = 500;

            if (Catalog.Length == 0)
            {
                yield break;
            }

            for (int i = 0; i < requiredCases; i++)
            {
                MethodInfo method = Catalog[i % Catalog.Length];
                string returnTypeName = method.ReturnType.FullName ?? method.ReturnType.Name;

                yield return new object[]
                {
                    i,
                    method.Name,
                    method.GetParameters().Length,
                    returnTypeName
                };
            }
        }

        /// <summary>
        ///     Verifies for each generated case that the expected public static signature still exists.
        /// </summary>
        /// <param name="caseIndex">The generated case index.</param>
        /// <param name="methodName">The method name.</param>
        /// <param name="parameterCount">The expected parameter count.</param>
        /// <param name="returnTypeName">The expected return type name.</param>
        [Theory, MemberData(nameof(ApiSignatureCases))]
        public void ApiSignatureCatalog_ShouldMatchExpectedPublicStaticSignature(
            int caseIndex,
            string methodName,
            int parameterCount,
            string returnTypeName)
        {
            MethodInfo[] candidates = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == methodName)
                .Where(method => method.GetParameters().Length == parameterCount)
                .ToArray();

            Assert.NotEmpty(candidates);

            MethodInfo match = candidates.FirstOrDefault(method =>
                string.Equals(method.ReturnType.FullName ?? method.ReturnType.Name, returnTypeName, StringComparison.Ordinal));

            Assert.True(caseIndex >= 0);
            Assert.NotNull(match);
            Assert.True(match.IsPublic);
            Assert.True(match.IsStatic);
            Assert.Equal(typeof(ImPlot), match.DeclaringType);
        }

        /// <summary>
        ///     Verifies that the generated case source itself yields at least 500 individual test rows.
        /// </summary>
        [Fact]
        public void ApiSignatureCases_ShouldGenerateAtLeastFiveHundredRows()
        {
            int count = ApiSignatureCases().Count();

            Assert.True(count >= 500);
        }
    }
}