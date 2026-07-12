// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RandomUtilsSonarComplianceTest.cs
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

using System.Reflection;
using Alis.Core.Aspect.Math.Util;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Util
{
    /// <summary>
    ///     Regression tests preventing SonarCloud S1144 (unused private members) from reappearing.
    /// </summary>
    public class RandomUtilsSonarComplianceTest
    {
        /// <summary>
        ///     Tests that Rng field exists only on target frameworks where it's needed.
        ///     On NET6.0+ the field should be excluded by conditional compilation.
        /// </summary>
        [Fact]
        public void RngField_ConditionalCompilation_CorrectlyApplied()
        {
            FieldInfo rngField = typeof(RandomUtils).GetField("Rng", BindingFlags.NonPublic | BindingFlags.Static);

#if NET6_0_OR_GREATER
            Assert.Null(rngField);
#else
            Assert.NotNull(rngField);
#endif
        }
    }
}
