// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentAlreadyExistsExceptionRemainingCoverageTests.cs
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
    ///     The component already exists exception remaining coverage tests class
    /// </summary>
    /// <remarks>
    ///     Provides coverage for the uncovered constructors of the
    ///     <see cref="ComponentAlreadyExistsException" /> class.
    /// </remarks>
    public class ComponentAlreadyExistsExceptionRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that the default constructor sets the default message
        /// </summary>
        [Fact]
        public void DefaultConstructor_SetsDefaultMessage()
        {
            ComponentAlreadyExistsException ex = new ComponentAlreadyExistsException();

            Assert.Equal("Component already exists on gameObject!", ex.Message);
        }

        /// <summary>
        ///     Tests that the message constructor sets a custom message
        /// </summary>
        [Fact]
        public void MessageConstructor_SetsCustomMessage()
        {
            ComponentAlreadyExistsException ex = new ComponentAlreadyExistsException("Custom error");

            Assert.Equal("Custom error", ex.Message);
        }

        /// <summary>
        ///     Tests that the default constructor is assignable from exception
        /// </summary>
        [Fact]
        public void DefaultConstructor_IsException()
        {
            ComponentAlreadyExistsException ex = new ComponentAlreadyExistsException();

            Assert.IsAssignableFrom<Exception>(ex);
        }

        /// <summary>
        ///     Tests that the message constructor with empty string sets an empty message
        /// </summary>
        [Fact]
        public void MessageConstructor_WithEmptyString_SetsEmptyMessage()
        {
            ComponentAlreadyExistsException ex = new ComponentAlreadyExistsException("");

            Assert.Equal("", ex.Message);
        }

        /// <summary>
        ///     Tests that the default constructor can be thrown
        /// </summary>
        [Fact]
        public void DefaultConstructor_CanBeThrown()
        {
            Assert.Throws<ComponentAlreadyExistsException>(new Action(() => { throw new ComponentAlreadyExistsException(); }));
        }

        /// <summary>
        ///     Tests that the message constructor can be thrown
        /// </summary>
        [Fact]
        public void MessageConstructor_CanBeThrown()
        {
            Assert.Throws<ComponentAlreadyExistsException>(new Action(() => { throw new ComponentAlreadyExistsException("boom"); }));
        }
    }
}