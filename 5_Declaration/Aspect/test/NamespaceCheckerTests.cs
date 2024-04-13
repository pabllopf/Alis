// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NamespaceCheckerTests.cs
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
using System.Linq;
using System.Reflection;
using Xunit;

namespace Alis.Core.Aspect.Test
{
    /// <summary>
    ///     The namespace checker tests class
    /// </summary>
    public class NamespaceCheckerTests
    {
        /// <summary>
        ///     Tests that check namespace no types in namespace returns true
        /// </summary>
        [Fact]
        public void CheckNamespace_NoTypesInNamespace_ReturnsTrue()
        {
            // Arrange
            const string namespaceToCheck = "Alis.Core.Aspect";
            
            // Act
            bool result = CheckNamespace(namespaceToCheck);
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        ///     Describes whether this instance check namespace
        /// </summary>
        /// <param name="namespaceToCheck">The namespace to check</param>
        /// <returns>The bool</returns>
        private static bool CheckNamespace(string namespaceToCheck)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return assemblies.Select(assembly => assembly.GetTypes().Where(t => string.Equals(t.Namespace, namespaceToCheck, StringComparison.Ordinal))).All(types => !types.Any());
        }
    }
}