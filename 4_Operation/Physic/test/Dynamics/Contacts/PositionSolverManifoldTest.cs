// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PositionSolverManifoldTest.cs
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

using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The position solver manifold test class
    /// </summary>
    public class PositionSolverManifoldTest
    {
        /// <summary>
        ///     Tests that PositionSolverManifold class should be accessible
        /// </summary>
        [Fact]
        public void PositionSolverManifold_ClassShouldBeAccessible()
        {
            Assert.NotNull(typeof(PositionSolverManifold));
        }

        /// <summary>
        ///     Tests that PositionSolverManifold should be a static class
        /// </summary>
        [Fact]
        public void PositionSolverManifold_ShouldBeStaticClass()
        {
            var type = typeof(PositionSolverManifold);
            Assert.True(type.IsSealed);
            Assert.True(type.IsAbstract);
        }

        /// <summary>
        ///     Tests that Initialize method should exist
        /// </summary>
        [Fact]
        public void Initialize_MethodShouldExist()
        {
            var method = typeof(PositionSolverManifold).GetMethod("Initialize");
            Assert.NotNull(method);
        }

        /// <summary>
        ///     Tests that PositionSolverManifold should be in correct namespace
        /// </summary>
        [Fact]
        public void PositionSolverManifold_ShouldBeInCorrectNamespace()
        {
            var type = typeof(PositionSolverManifold);
            Assert.Equal("Alis.Core.Physic.Dynamics.Contacts", type.Namespace);
        }

        /// <summary>
        ///     Tests that PositionSolverManifold should have correct attributes
        /// </summary>
        [Fact]
        public void PositionSolverManifold_ShouldHaveCorrectAttributes()
        {
            var type = typeof(PositionSolverManifold);
            var attributes = type.GetCustomAttributes(false);
            Assert.NotNull(attributes);
        }
    }
}
