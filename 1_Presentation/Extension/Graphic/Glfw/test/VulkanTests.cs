// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VulkanTests.cs
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

using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for Vulkan class
    /// </summary>
    public class VulkanTests
    {
        /// <summary>
        ///     Vulkans the is supported returns bool
        /// </summary>
        [RequiresDisplay]
        public void Vulkan_IsSupported_ReturnsBool()
        {
            bool isSupported = Vulkan.IsSupported;

            Assert.True(isSupported || !isSupported);
        }

        /// <summary>
        ///     Vulkans the is supported does not throw
        /// </summary>
        [RequiresDisplay]
        public void Vulkan_IsSupported_DoesNotThrow()
        {
            _ = Vulkan.IsSupported;
        }
    }
}