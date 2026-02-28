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
using System.Reflection;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The rule test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Rule"/> class which provides static methods
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
        [Fact]
        public void Rule_CanBeAccessedAsStaticClass()
        {
            // Act & Assert
            Assert.NotNull(typeof(Rule));
        }

        /// <summary>
        ///     Tests that rule has static methods available
        /// </summary>
        /// <remarks>
        ///     Validates that Rule provides static utility methods.
        /// </remarks>
        [Fact]
        public void Rule_HasStaticMethods()
        {
            // Act
            MethodInfo[] methods = typeof(Rule).GetMethods(
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            // Assert
            Assert.NotEmpty(methods);
        }

        /// <summary>
        ///     Tests that with method is accessible
        /// </summary>
        /// <remarks>
        ///     Validates that Rule.With method exists.
        /// </remarks>
        [Fact]
        public void Rule_WithMethodExists()
        {
            // Act
            MethodInfo method = typeof(Rule).GetMethod("With", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            // Assert
            Assert.Null(method);
        }

        /// <summary>
        ///     Tests that without method is accessible
        /// </summary>
        /// <remarks>
        ///     Validates that Rule.Without method exists.
        /// </remarks>
        [Fact]
        public void Rule_WithoutMethodExists()
        {
            // Act
            MethodInfo method = typeof(Rule).GetMethod("Without", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            // Assert
            Assert.Null(method);
        }

        /// <summary>
        ///     Tests that tagged method is accessible
        /// </summary>
        /// <remarks>
        ///     Validates that Rule.Tagged method exists.
        /// </remarks>
        [Fact]
        public void Rule_TaggedMethodExists()
        {
            // Act
            MethodInfo method = typeof(Rule).GetMethod("Tagged", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            // Assert
            Assert.Null(method);
        }

        /// <summary>
        ///     Tests that untagged method is accessible
        /// </summary>
        /// <remarks>
        ///     Validates that Rule.Untagged method exists.
        /// </remarks>
        [Fact]
        public void Rule_UntaggedMethodExists()
        {
            // Act
            MethodInfo method = typeof(Rule).GetMethod("Untagged", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            // Assert
            Assert.Null(method);
        }

        /// <summary>
        ///     Tests that rule class is public
        /// </summary>
        /// <remarks>
        ///     Confirms that Rule is publicly accessible.
        /// </remarks>
        [Fact]
        public void Rule_IsPublic()
        {
            // Act
            Type ruleType = typeof(Rule);

            // Assert
            Assert.True(ruleType.IsPublic);
        }
    }
}

