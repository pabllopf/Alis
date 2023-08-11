using System;
using System.Diagnostics;
using Vulkan;
using static Vulkan.VulkanNative;

namespace Veldrid.Vk
{
    /// <summary>
    /// The vulkan util class
    /// </summary>
    internal unsafe static class VulkanUtil
    {
        /// <summary>
        /// The try load vulkan
        /// </summary>
        private static Lazy<bool> s_isVulkanLoaded = new Lazy<bool>(TryLoadVulkan);
        /// <summary>
        /// The enumerate instance extensions
        /// </summary>
        private static readonly Lazy<string[]> s_instanceExtensions = new Lazy<string[]>(EnumerateInstanceExtensions);

        /// <summary>
        /// Checks the result using the specified result
        /// </summary>
        /// <param name="result">The result</param>
        /// <exception cref="VeldridException"></exception>
        [Conditional("DEBUG")]
        public static void CheckResult(VkResult result)
        {
            if (result != VkResult.Success)
            {
                throw new VeldridException("Unsuccessful VkResult: " + result);
            }
        }

        /// <summary>
        /// Describes whether try find memory type
        /// </summary>
        /// <param name="memProperties">The mem properties</param>
        /// <param name="typeFilter">The type filter</param>
        /// <param name="properties">The properties</param>
        /// <param name="typeIndex">The type index</param>
        /// <returns>The bool</returns>
        public static bool TryFindMemoryType(VkPhysicalDeviceMemoryProperties memProperties, uint typeFilter, VkMemoryPropertyFlags properties, out uint typeIndex)
        {
            typeIndex = 0;

            for (int i = 0; i < memProperties.memoryTypeCount; i++)
            {
                if (((typeFilter & (1 << i)) != 0)
                    && (memProperties.GetMemoryType((uint)i).propertyFlags & properties) == properties)
                {
                    typeIndex = (uint)i;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Enumerates the instance layers
        /// </summary>
        /// <returns>The ret</returns>
        public static string[] EnumerateInstanceLayers()
        {
            uint propCount = 0;
            VkResult result = vkEnumerateInstanceLayerProperties(ref propCount, null);
            CheckResult(result);
            if (propCount == 0)
            {
                return Array.Empty<string>();
            }

            VkLayerProperties[] props = new VkLayerProperties[propCount];
            vkEnumerateInstanceLayerProperties(ref propCount, ref props[0]);

            string[] ret = new string[propCount];
            for (int i = 0; i < propCount; i++)
            {
                fixed (byte* layerNamePtr = props[i].layerName)
                {
                    ret[i] = Util.GetString(layerNamePtr);
                }
            }

            return ret;
        }

        /// <summary>
        /// Gets the instance extensions
        /// </summary>
        /// <returns>The string array</returns>
        public static string[] GetInstanceExtensions() => s_instanceExtensions.Value;

        /// <summary>
        /// Enumerates the instance extensions
        /// </summary>
        /// <returns>The ret</returns>
        private static string[] EnumerateInstanceExtensions()
        {
            if (!IsVulkanLoaded())
            {
                return Array.Empty<string>();
            }

            uint propCount = 0;
            VkResult result = vkEnumerateInstanceExtensionProperties((byte*)null, ref propCount, null);
            if (result != VkResult.Success)
            {
                return Array.Empty<string>();
            }

            if (propCount == 0)
            {
                return Array.Empty<string>();
            }

            VkExtensionProperties[] props = new VkExtensionProperties[propCount];
            vkEnumerateInstanceExtensionProperties((byte*)null, ref propCount, ref props[0]);

            string[] ret = new string[propCount];
            for (int i = 0; i < propCount; i++)
            {
                fixed (byte* extensionNamePtr = props[i].extensionName)
                {
                    ret[i] = Util.GetString(extensionNamePtr);
                }
            }

            return ret;
        }

        /// <summary>
        /// Describes whether is vulkan loaded
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsVulkanLoaded() => s_isVulkanLoaded.Value;
        /// <summary>
        /// Describes whether try load vulkan
        /// </summary>
        /// <returns>The bool</returns>
        private static bool TryLoadVulkan()
        {
            try
            {
                uint propCount;
                vkEnumerateInstanceExtensionProperties((byte*)null, &propCount, null);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Transitions the image layout using the specified cb
        /// </summary>
        /// <param name="cb">The cb</param>
        /// <param name="image">The image</param>
        /// <param name="baseMipLevel">The base mip level</param>
        /// <param name="levelCount">The level count</param>
        /// <param name="baseArrayLayer">The base array layer</param>
        /// <param name="layerCount">The layer count</param>
        /// <param name="aspectMask">The aspect mask</param>
        /// <param name="oldLayout">The old layout</param>
        /// <param name="newLayout">The new layout</param>
        public static void TransitionImageLayout(
            VkCommandBuffer cb,
            VkImage image,
            uint baseMipLevel,
            uint levelCount,
            uint baseArrayLayer,
            uint layerCount,
            VkImageAspectFlags aspectMask,
            VkImageLayout oldLayout,
            VkImageLayout newLayout)
        {
            Debug.Assert(oldLayout != newLayout);
            VkImageMemoryBarrier barrier = VkImageMemoryBarrier.New();
            barrier.oldLayout = oldLayout;
            barrier.newLayout = newLayout;
            barrier.srcQueueFamilyIndex = QueueFamilyIgnored;
            barrier.dstQueueFamilyIndex = QueueFamilyIgnored;
            barrier.image = image;
            barrier.subresourceRange.aspectMask = aspectMask;
            barrier.subresourceRange.baseMipLevel = baseMipLevel;
            barrier.subresourceRange.levelCount = levelCount;
            barrier.subresourceRange.baseArrayLayer = baseArrayLayer;
            barrier.subresourceRange.layerCount = layerCount;

            VkPipelineStageFlags srcStageFlags = VkPipelineStageFlags.None;
            VkPipelineStageFlags dstStageFlags = VkPipelineStageFlags.None;

            if ((oldLayout == VkImageLayout.Undefined || oldLayout == VkImageLayout.Preinitialized) && newLayout == VkImageLayout.TransferDstOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.None;
                barrier.dstAccessMask = VkAccessFlags.TransferWrite;
                srcStageFlags = VkPipelineStageFlags.TopOfPipe;
                dstStageFlags = VkPipelineStageFlags.Transfer;
            }
            else if (oldLayout == VkImageLayout.ShaderReadOnlyOptimal && newLayout == VkImageLayout.TransferSrcOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.ShaderRead;
                barrier.dstAccessMask = VkAccessFlags.TransferRead;
                srcStageFlags = VkPipelineStageFlags.FragmentShader;
                dstStageFlags = VkPipelineStageFlags.Transfer;
            }
            else if (oldLayout == VkImageLayout.ShaderReadOnlyOptimal && newLayout == VkImageLayout.TransferDstOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.ShaderRead;
                barrier.dstAccessMask = VkAccessFlags.TransferWrite;
                srcStageFlags = VkPipelineStageFlags.FragmentShader;
                dstStageFlags = VkPipelineStageFlags.Transfer;
            }
            else if (oldLayout == VkImageLayout.Preinitialized && newLayout == VkImageLayout.TransferSrcOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.None;
                barrier.dstAccessMask = VkAccessFlags.TransferRead;
                srcStageFlags = VkPipelineStageFlags.TopOfPipe;
                dstStageFlags = VkPipelineStageFlags.Transfer;
            }
            else if (oldLayout == VkImageLayout.Preinitialized && newLayout == VkImageLayout.General)
            {
                barrier.srcAccessMask = VkAccessFlags.None;
                barrier.dstAccessMask = VkAccessFlags.ShaderRead;
                srcStageFlags = VkPipelineStageFlags.TopOfPipe;
                dstStageFlags = VkPipelineStageFlags.ComputeShader;
            }
            else if (oldLayout == VkImageLayout.Preinitialized && newLayout == VkImageLayout.ShaderReadOnlyOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.None;
                barrier.dstAccessMask = VkAccessFlags.ShaderRead;
                srcStageFlags = VkPipelineStageFlags.TopOfPipe;
                dstStageFlags = VkPipelineStageFlags.FragmentShader;
            }
            else if (oldLayout == VkImageLayout.General && newLayout == VkImageLayout.ShaderReadOnlyOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.TransferRead;
                barrier.dstAccessMask = VkAccessFlags.ShaderRead;
                srcStageFlags = VkPipelineStageFlags.Transfer;
                dstStageFlags = VkPipelineStageFlags.FragmentShader;
            }
            else if (oldLayout == VkImageLayout.ShaderReadOnlyOptimal && newLayout == VkImageLayout.General)
            {
                barrier.srcAccessMask = VkAccessFlags.ShaderRead;
                barrier.dstAccessMask = VkAccessFlags.ShaderRead;
                srcStageFlags = VkPipelineStageFlags.FragmentShader;
                dstStageFlags = VkPipelineStageFlags.ComputeShader;
            }

            else if (oldLayout == VkImageLayout.TransferSrcOptimal && newLayout == VkImageLayout.ShaderReadOnlyOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.TransferRead;
                barrier.dstAccessMask = VkAccessFlags.ShaderRead;
                srcStageFlags = VkPipelineStageFlags.Transfer;
                dstStageFlags = VkPipelineStageFlags.FragmentShader;
            }
            else if (oldLayout == VkImageLayout.TransferDstOptimal && newLayout == VkImageLayout.ShaderReadOnlyOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.TransferWrite;
                barrier.dstAccessMask = VkAccessFlags.ShaderRead;
                srcStageFlags = VkPipelineStageFlags.Transfer;
                dstStageFlags = VkPipelineStageFlags.FragmentShader;
            }
            else if (oldLayout == VkImageLayout.TransferSrcOptimal && newLayout == VkImageLayout.TransferDstOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.TransferRead;
                barrier.dstAccessMask = VkAccessFlags.TransferWrite;
                srcStageFlags = VkPipelineStageFlags.Transfer;
                dstStageFlags = VkPipelineStageFlags.Transfer;
            }
            else if (oldLayout == VkImageLayout.TransferDstOptimal && newLayout == VkImageLayout.TransferSrcOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.TransferWrite;
                barrier.dstAccessMask = VkAccessFlags.TransferRead;
                srcStageFlags = VkPipelineStageFlags.Transfer;
                dstStageFlags = VkPipelineStageFlags.Transfer;
            }
            else if (oldLayout == VkImageLayout.ColorAttachmentOptimal && newLayout == VkImageLayout.TransferSrcOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.ColorAttachmentWrite;
                barrier.dstAccessMask = VkAccessFlags.TransferRead;
                srcStageFlags = VkPipelineStageFlags.ColorAttachmentOutput;
                dstStageFlags = VkPipelineStageFlags.Transfer;
            }
            else if (oldLayout == VkImageLayout.ColorAttachmentOptimal && newLayout == VkImageLayout.TransferDstOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.ColorAttachmentWrite;
                barrier.dstAccessMask = VkAccessFlags.TransferWrite;
                srcStageFlags = VkPipelineStageFlags.ColorAttachmentOutput;
                dstStageFlags = VkPipelineStageFlags.Transfer;
            }
            else if (oldLayout == VkImageLayout.ColorAttachmentOptimal && newLayout == VkImageLayout.ShaderReadOnlyOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.ColorAttachmentWrite;
                barrier.dstAccessMask = VkAccessFlags.ShaderRead;
                srcStageFlags = VkPipelineStageFlags.ColorAttachmentOutput;
                dstStageFlags = VkPipelineStageFlags.FragmentShader;
            }
            else if (oldLayout == VkImageLayout.DepthStencilAttachmentOptimal && newLayout == VkImageLayout.ShaderReadOnlyOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.DepthStencilAttachmentWrite;
                barrier.dstAccessMask = VkAccessFlags.ShaderRead;
                srcStageFlags = VkPipelineStageFlags.LateFragmentTests;
                dstStageFlags = VkPipelineStageFlags.FragmentShader;
            }
            else if (oldLayout == VkImageLayout.ColorAttachmentOptimal && newLayout == VkImageLayout.PresentSrcKHR)
            {
                barrier.srcAccessMask = VkAccessFlags.ColorAttachmentWrite;
                barrier.dstAccessMask = VkAccessFlags.MemoryRead;
                srcStageFlags = VkPipelineStageFlags.ColorAttachmentOutput;
                dstStageFlags = VkPipelineStageFlags.BottomOfPipe;
            }
            else if (oldLayout == VkImageLayout.TransferDstOptimal && newLayout == VkImageLayout.PresentSrcKHR)
            {
                barrier.srcAccessMask = VkAccessFlags.TransferWrite;
                barrier.dstAccessMask = VkAccessFlags.MemoryRead;
                srcStageFlags = VkPipelineStageFlags.Transfer;
                dstStageFlags = VkPipelineStageFlags.BottomOfPipe;
            }
            else if (oldLayout == VkImageLayout.TransferDstOptimal && newLayout == VkImageLayout.ColorAttachmentOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.TransferWrite;
                barrier.dstAccessMask = VkAccessFlags.ColorAttachmentWrite;
                srcStageFlags = VkPipelineStageFlags.Transfer;
                dstStageFlags = VkPipelineStageFlags.ColorAttachmentOutput;
            }
            else if (oldLayout == VkImageLayout.TransferDstOptimal && newLayout == VkImageLayout.DepthStencilAttachmentOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.TransferWrite;
                barrier.dstAccessMask = VkAccessFlags.DepthStencilAttachmentWrite;
                srcStageFlags = VkPipelineStageFlags.Transfer;
                dstStageFlags = VkPipelineStageFlags.LateFragmentTests;
            }
            else if (oldLayout == VkImageLayout.General && newLayout == VkImageLayout.TransferSrcOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.ShaderWrite;
                barrier.dstAccessMask = VkAccessFlags.TransferRead;
                srcStageFlags = VkPipelineStageFlags.ComputeShader;
                dstStageFlags = VkPipelineStageFlags.Transfer;
            }
            else if (oldLayout == VkImageLayout.General && newLayout == VkImageLayout.TransferDstOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.ShaderWrite;
                barrier.dstAccessMask = VkAccessFlags.TransferWrite;
                srcStageFlags = VkPipelineStageFlags.ComputeShader;
                dstStageFlags = VkPipelineStageFlags.Transfer;
            }
            else if (oldLayout == VkImageLayout.PresentSrcKHR && newLayout == VkImageLayout.TransferSrcOptimal)
            {
                barrier.srcAccessMask = VkAccessFlags.MemoryRead;
                barrier.dstAccessMask = VkAccessFlags.TransferRead;
                srcStageFlags = VkPipelineStageFlags.BottomOfPipe;
                dstStageFlags = VkPipelineStageFlags.Transfer;
            }
            else
            {
                Debug.Fail("Invalid image layout transition.");
            }

            vkCmdPipelineBarrier(
                cb,
                srcStageFlags,
                dstStageFlags,
                VkDependencyFlags.None,
                0, null,
                0, null,
                1, &barrier);
        }
    }

    /// <summary>
    /// The vk physical device memory properties ex class
    /// </summary>
    internal unsafe static class VkPhysicalDeviceMemoryPropertiesEx
    {
        /// <summary>
        /// Gets the memory type using the specified memory properties
        /// </summary>
        /// <param name="memoryProperties">The memory properties</param>
        /// <param name="index">The index</param>
        /// <returns>The vk memory type</returns>
        public static VkMemoryType GetMemoryType(this VkPhysicalDeviceMemoryProperties memoryProperties, uint index)
        {
            return (&memoryProperties.memoryTypes_0)[index];
        }
    }
}
