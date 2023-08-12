namespace Alis.Core.Graphic.Backends.D3D11
{
    /// <summary>
    /// The 11 resource layout class
    /// </summary>
    /// <seealso cref="ResourceLayout"/>
    internal class D3D11ResourceLayout : ResourceLayout
    {
        /// <summary>
        /// The binding infos by vd index
        /// </summary>
        private readonly ResourceBindingInfo[] _bindingInfosByVdIndex;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the uniform buffer count
        /// </summary>
        public int UniformBufferCount { get; }
        /// <summary>
        /// Gets the value of the storage buffer count
        /// </summary>
        public int StorageBufferCount { get; }
        /// <summary>
        /// Gets the value of the texture count
        /// </summary>
        public int TextureCount { get; }
        /// <summary>
        /// Gets the value of the sampler count
        /// </summary>
        public int SamplerCount { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11ResourceLayout"/> class
        /// </summary>
        /// <param name="description">The description</param>
        public D3D11ResourceLayout(ref ResourceLayoutDescription description)
            : base(ref description)
        {
            ResourceLayoutElementDescription[] elements = description.Elements;
            _bindingInfosByVdIndex = new ResourceBindingInfo[elements.Length];

            int cbIndex = 0;
            int texIndex = 0;
            int samplerIndex = 0;
            int unorderedAccessIndex = 0;

            for (int i = 0; i < _bindingInfosByVdIndex.Length; i++)
            {
                int slot;
                switch (elements[i].Kind)
                {
                    case ResourceKind.UniformBuffer:
                        slot = cbIndex++;
                        break;
                    case ResourceKind.StructuredBufferReadOnly:
                        slot = texIndex++;
                        break;
                    case ResourceKind.StructuredBufferReadWrite:
                        slot = unorderedAccessIndex++;
                        break;
                    case ResourceKind.TextureReadOnly:
                        slot = texIndex++;
                        break;
                    case ResourceKind.TextureReadWrite:
                        slot = unorderedAccessIndex++;
                        break;
                    case ResourceKind.Sampler:
                        slot = samplerIndex++;
                        break;
                    default: throw Illegal.Value<ResourceKind>();
                }

                _bindingInfosByVdIndex[i] = new ResourceBindingInfo(
                    slot,
                    elements[i].Stages,
                    elements[i].Kind,
                    (elements[i].Options & ResourceLayoutElementOptions.DynamicBinding) != 0);
            }

            UniformBufferCount = cbIndex;
            StorageBufferCount = unorderedAccessIndex;
            TextureCount = texIndex;
            SamplerCount = samplerIndex;
        }

        /// <summary>
        /// Gets the device slot index using the specified resource layout index
        /// </summary>
        /// <param name="resourceLayoutIndex">The resource layout index</param>
        /// <exception cref="VeldridException">Invalid resource index: {resourceLayoutIndex}. Maximum is: {_bindingInfosByVdIndex.Length - 1}.</exception>
        /// <returns>The resource binding info</returns>
        public ResourceBindingInfo GetDeviceSlotIndex(int resourceLayoutIndex)
        {
            if (resourceLayoutIndex >= _bindingInfosByVdIndex.Length)
            {
                throw new VeldridException($"Invalid resource index: {resourceLayoutIndex}. Maximum is: {_bindingInfosByVdIndex.Length - 1}.");
            }

            return _bindingInfosByVdIndex[resourceLayoutIndex];
        }

        /// <summary>
        /// Describes whether this instance is dynamic buffer
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The bool</returns>
        public bool IsDynamicBuffer(int index) => _bindingInfosByVdIndex[index].DynamicBuffer;

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            _disposed = true;
        }

        /// <summary>
        /// The resource binding info
        /// </summary>
        internal struct ResourceBindingInfo
        {
            /// <summary>
            /// The slot
            /// </summary>
            public int Slot;
            /// <summary>
            /// The stages
            /// </summary>
            public ShaderStages Stages;
            /// <summary>
            /// The kind
            /// </summary>
            public ResourceKind Kind;
            /// <summary>
            /// The dynamic buffer
            /// </summary>
            public bool DynamicBuffer;

            /// <summary>
            /// Initializes a new instance of the <see cref="ResourceBindingInfo"/> class
            /// </summary>
            /// <param name="slot">The slot</param>
            /// <param name="stages">The stages</param>
            /// <param name="kind">The kind</param>
            /// <param name="dynamicBuffer">The dynamic buffer</param>
            public ResourceBindingInfo(int slot, ShaderStages stages, ResourceKind kind, bool dynamicBuffer)
            {
                Slot = slot;
                Stages = stages;
                Kind = kind;
                DynamicBuffer = dynamicBuffer;
            }
        }
    }
}
