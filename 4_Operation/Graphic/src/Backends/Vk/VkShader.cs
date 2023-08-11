using Vulkan;
using static Vulkan.VulkanNative;
using static Veldrid.Vk.VulkanUtil;
using System;

namespace Veldrid.Vk
{
    /// <summary>
    /// The vk shader class
    /// </summary>
    /// <seealso cref="Shader"/>
    internal unsafe class VkShader : Shader
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The shader module
        /// </summary>
        private readonly VkShaderModule _shaderModule;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the value of the shader module
        /// </summary>
        public VkShaderModule ShaderModule => _shaderModule;

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="VkShader"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public VkShader(VkGraphicsDevice gd, ref ShaderDescription description)
            : base(description.Stage, description.EntryPoint)
        {
            _gd = gd;

            VkShaderModuleCreateInfo shaderModuleCI = VkShaderModuleCreateInfo.New();
            fixed (byte* codePtr = description.ShaderBytes)
            {
                shaderModuleCI.codeSize = (UIntPtr)description.ShaderBytes.Length;
                shaderModuleCI.pCode = (uint*)codePtr;
                VkResult result = vkCreateShaderModule(gd.Device, ref shaderModuleCI, null, out _shaderModule);
                CheckResult(result);
            }
        }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name
        {
            get => _name;
            set
            {
                _name = value;
                _gd.SetResourceName(this, value);
            }
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                vkDestroyShaderModule(_gd.Device, ShaderModule, null);
            }
        }
    }
}
