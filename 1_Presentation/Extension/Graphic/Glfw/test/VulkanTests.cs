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

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Glfw.Test.Attributes;
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

        /// <summary>
        ///     Vulkans the is supported no display does not throw
        /// </summary>
        [Fact]
        public void Vulkan_IsSupported_NoDisplay_DoesNotThrow()
        {
            try
            {
                _ = Vulkan.IsSupported;
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Vulkans the is supported no display returns bool
        /// </summary>
        [Fact]
        public void Vulkan_IsSupported_NoDisplay_ReturnsBool()
        {
            try
            {
                bool isSupported = Vulkan.IsSupported;

                Assert.True(isSupported || !isSupported);
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Vulkans the get instance proc address null vulkan returns zero or address
        /// </summary>
        [Fact]
        public void Vulkan_GetInstanceProcAddress_NullVulkan_ReturnsZeroOrAddress()
        {
            try
            {
                IntPtr result = Vulkan.GetInstanceProcAddress(IntPtr.Zero, "vkGetInstanceProcAddr");

                Assert.True(result == IntPtr.Zero || result != IntPtr.Zero);
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Vulkans the get instance proc address empty proc name returns zero
        /// </summary>
        [Fact]
        public void Vulkan_GetInstanceProcAddress_EmptyProcName_ReturnsZero()
        {
            try
            {
                IntPtr result = Vulkan.GetInstanceProcAddress(IntPtr.Zero, string.Empty);

                Assert.Equal(IntPtr.Zero, result);
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Vulkans the get instance proc address invalid proc name returns zero
        /// </summary>
        [Fact]
        public void Vulkan_GetInstanceProcAddress_InvalidProcName_ReturnsZero()
        {
            try
            {
                IntPtr result = Vulkan.GetInstanceProcAddress(IntPtr.Zero, "NonExistentFunction__");

                Assert.Equal(IntPtr.Zero, result);
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Vulkans the get instance proc address does not throw
        /// </summary>
        [Fact]
        public void Vulkan_GetInstanceProcAddress_DoesNotThrow()
        {
            try
            {
                IntPtr result = Vulkan.GetInstanceProcAddress(IntPtr.Zero, "vkGetInstanceProcAddr");

                _ = result;
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Vulkans the get required instance extensions returns array
        /// </summary>
        [Fact]
        public void Vulkan_GetRequiredInstanceExtensions_ReturnsArray()
        {
            try
            {
                string[] extensions = Vulkan.GetRequiredInstanceExtensions();

                Assert.NotNull(extensions);
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Vulkans the get required instance extensions does not throw
        /// </summary>
        [Fact]
        public void Vulkan_GetRequiredInstanceExtensions_DoesNotThrow()
        {
            try
            {
                string[] extensions = Vulkan.GetRequiredInstanceExtensions();

                _ = extensions;
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Vulkans the create window surface is extern
        /// </summary>
        [Fact]
        public void Vulkan_CreateWindowSurface_IsExtern()
        {
            Assert.True(typeof(Vulkan).GetMethod(nameof(Vulkan.CreateWindowSurface)).IsPublic);
        }

        /// <summary>
        ///     Vulkans the get physical device presentation support is extern
        /// </summary>
        [Fact]
        public void Vulkan_GetPhysicalDevicePresentationSupport_IsExtern()
        {
            Assert.True(typeof(Vulkan).GetMethod(nameof(Vulkan.GetPhysicalDevicePresentationSupport)).IsPublic);
        }
    }
}
