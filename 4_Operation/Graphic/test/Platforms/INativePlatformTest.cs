// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INativePlatformTest.cs
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
using Alis.Core.Graphic.Platforms;

namespace Alis.Core.Graphic.Test.Platforms
{
    /// <summary>
    /// Tests for the INativePlatform interface validating cross-platform window management.
    /// </summary>
    public class INativePlatformTest
    {
        /// <summary>
        /// Tests that INativePlatform is an interface type.
        /// </summary>
        [Fact]
        public void INativePlatform_IsInterface_TypeIsCorrect()
        {
            // Arrange & Act
            Type interfaceType = typeof(INativePlatform);

            // Assert
            Assert.True(interfaceType.IsInterface);
        }

        /// <summary>
        /// Tests that INativePlatform is public.
        /// </summary>
        [Fact]
        public void INativePlatform_IsPublic_CanBeAccessed()
        {
            // Arrange & Act
            Type interfaceType = typeof(INativePlatform);

            // Assert
            Assert.True(interfaceType.IsPublic);
        }
        

   

      

        /// <summary>
        /// Tests that INativePlatform ShowWindow returns void.
        /// </summary>
        [Fact]
        public void INativePlatform_ShowWindow_ReturnsVoid()
        {
            // Arrange & Act
            MethodInfo method = typeof(INativePlatform).GetMethod("ShowWindow");

            // Assert
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that INativePlatform HideWindow returns void.
        /// </summary>
        [Fact]
        public void INativePlatform_HideWindow_ReturnsVoid()
        {
            // Arrange & Act
            MethodInfo method = typeof(INativePlatform).GetMethod("HideWindow");

            // Assert
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that INativePlatform SetTitle returns void.
        /// </summary>
        [Fact]
        public void INativePlatform_SetTitle_ReturnsVoid()
        {
            // Arrange & Act
            MethodInfo method = typeof(INativePlatform).GetMethod("SetTitle");

            // Assert
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that INativePlatform SetSize returns void.
        /// </summary>
        [Fact]
        public void INativePlatform_SetSize_ReturnsVoid()
        {
            // Arrange & Act
            MethodInfo method = typeof(INativePlatform).GetMethod("SetSize");

            // Assert
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that INativePlatform IsWindowVisible returns bool.
        /// </summary>
        [Fact]
        public void INativePlatform_IsWindowVisible_ReturnsBoolean()
        {
            // Arrange & Act
            MethodInfo method = typeof(INativePlatform).GetMethod("IsWindowVisible");

            // Assert
            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that INativePlatform PollEvents returns bool.
        /// </summary>
        [Fact]
        public void INativePlatform_PollEvents_ReturnsBoolean()
        {
            // Arrange & Act
            MethodInfo method = typeof(INativePlatform).GetMethod("PollEvents");

            // Assert
            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }
        
    }
}

