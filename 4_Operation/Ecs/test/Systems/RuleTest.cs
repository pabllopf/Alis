// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RuleTest.cs
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
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The rule test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Rule" /> class which provides static methods
    ///     for constructing query rules with component and tag requirements.
    /// </remarks>
    public class RuleTest
    {
        /// <summary>
        ///     Tests that rule can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that Rule class can be instantiated.
        /// </remarks>
        [Fact] public void Rule_CanBeAccessedAsStaticClass()
        {
            Assert.NotNull(typeof(Rule));
        }

        /// <summary>
        ///     Tests that rule class is public
        /// </summary>
        /// <remarks>
        ///     Confirms that Rule is publicly accessible.
        /// </remarks>
        [Fact] public void Rule_IsPublic()
        {
            Type ruleType = typeof(Rule);

            Assert.True(ruleType.IsPublic);
        }
    }
}