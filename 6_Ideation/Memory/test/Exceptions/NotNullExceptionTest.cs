// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NotNullExceptionTest.cs
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

using Alis.Core.Aspect.Memory.Exceptions;
using Xunit;

namespace Alis.Core.Aspect.Memory.Test.Exceptions
{
    /// <summary>
    ///     The not null exception test class
    /// </summary>
    public class NotNullExceptionTest
    {
        /// <summary>
        ///     Tests that not null exception with message should set message
        /// </summary>
        [Fact]
        public void NotNullException_WithMessage_ShouldSetMessage()
        {
            // Arrange
            const string message = "Test message";

            // Act
            NotNullException exception = new NotNullException(message);

            // Assert
            Assert.Equal(message, exception.Message);
        }
    }
}