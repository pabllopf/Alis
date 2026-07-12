// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentNotFoundExceptionRemainingCoverageTests.cs
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
using Alis.Core.Ecs.Exceptions;
using Xunit;

namespace Alis.Core.Ecs.Test.Exceptions
{
    /// <summary>
    ///     The component not found exception remaining coverage tests class
    /// </summary>
    /// <remarks>
    ///     Provides coverage for the uncovered constructors of the
    ///     <see cref="ComponentNotFoundException" /> class.
    /// </remarks>
    public class ComponentNotFoundExceptionRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that the type constructor sets the default message
        /// </summary>
        [Fact]
        public void TypeConstructor_SetsDefaultMessage()
        {
            ComponentNotFoundException ex = new ComponentNotFoundException(typeof(int));

            Assert.Equal("Component not found", ex.Message);
        }

        /// <summary>
        ///     Tests that the message constructor sets a custom message
        /// </summary>
        [Fact]
        public void MessageConstructor_SetsCustomMessage()
        {
            ComponentNotFoundException ex = new ComponentNotFoundException("Custom");

            Assert.Equal("Custom", ex.Message);
        }

        /// <summary>
        ///     Tests that the type constructor is assignable from exception
        /// </summary>
        [Fact]
        public void TypeConstructor_IsException()
        {
            ComponentNotFoundException ex = new ComponentNotFoundException(typeof(string));

            Assert.IsAssignableFrom<Exception>(ex);
        }

        /// <summary>
        ///     Tests that the type constructor accepts a null type
        /// </summary>
        [Fact]
        public void TypeConstructor_AcceptsNullType()
        {
            ComponentNotFoundException ex = new ComponentNotFoundException((Type)null);

            Assert.Equal("Component not found", ex.Message);
        }

        /// <summary>
        ///     Tests that the type constructor can be thrown
        /// </summary>
        [Fact]
        public void TypeConstructor_CanBeThrown()
        {
            Assert.Throws<ComponentNotFoundException>(new Action(() => { throw new ComponentNotFoundException(typeof(int)); }));
        }

        /// <summary>
        ///     Tests that the message constructor can be thrown
        /// </summary>
        [Fact]
        public void MessageConstructor_CanBeThrown()
        {
            Assert.Throws<ComponentNotFoundException>(new Action(() => { throw new ComponentNotFoundException("err"); }));
        }
    }
}