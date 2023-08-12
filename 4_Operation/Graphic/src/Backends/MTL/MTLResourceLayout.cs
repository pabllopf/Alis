namespace Alis.Core.Graphic.Backends.MTL
{
    /// <summary>
    /// The mtl resource layout class
    /// </summary>
    /// <seealso cref="ResourceLayout"/>
    internal class MTLResourceLayout : ResourceLayout
    {
        /// <summary>
        /// The binding infos by vd index
        /// </summary>
        private readonly ResourceBindingInfo[] _bindingInfosByVdIndex;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;
        /// <summary>
        /// Gets the value of the buffer count
        /// </summary>
        public uint BufferCount { get; }
        /// <summary>
        /// Gets the value of the texture count
        /// </summary>
        public uint TextureCount { get; }
        /// <summary>
        /// Gets the value of the sampler count
        /// </summary>
        public uint SamplerCount { get; }
#if !VALIDATE_USAGE
        /// <summary>
        /// Gets the value of the resource kinds
        /// </summary>
        public ResourceKind[] ResourceKinds { get; }
#endif
        /// <summary>
        /// Gets the binding info using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The resource binding info</returns>
        public ResourceBindingInfo GetBindingInfo(int index) => _bindingInfosByVdIndex[index];

#if !VALIDATE_USAGE
        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public ResourceLayoutDescription Description { get; }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLResourceLayout"/> class
        /// </summary>
        /// <param name="description">The description</param>
        /// <param name="gd">The gd</param>
        public MTLResourceLayout(ref ResourceLayoutDescription description, MTLGraphicsDevice gd)
            : base(ref description)
        {
#if !VALIDATE_USAGE
            Description = description;
#endif

            ResourceLayoutElementDescription[] elements = description.Elements;
#if !VALIDATE_USAGE
            ResourceKinds = new ResourceKind[elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                ResourceKinds[i] = elements[i].Kind;
            }
#endif

            _bindingInfosByVdIndex = new ResourceBindingInfo[elements.Length];

            uint bufferIndex = 0;
            uint texIndex = 0;
            uint samplerIndex = 0;

            for (int i = 0; i < _bindingInfosByVdIndex.Length; i++)
            {
                uint slot;
                switch (elements[i].Kind)
                {
                    case ResourceKind.UniformBuffer:
                        slot = bufferIndex++;
                        break;
                    case ResourceKind.StructuredBufferReadOnly:
                        slot = bufferIndex++;
                        break;
                    case ResourceKind.StructuredBufferReadWrite:
                        slot = bufferIndex++;
                        break;
                    case ResourceKind.TextureReadOnly:
                        slot = texIndex++;
                        break;
                    case ResourceKind.TextureReadWrite:
                        slot = texIndex++;
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

            BufferCount = bufferIndex;
            TextureCount = texIndex;
            SamplerCount = samplerIndex;
        }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }

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
            public uint Slot;
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
            public ResourceBindingInfo(uint slot, ShaderStages stages, ResourceKind kind, bool dynamicBuffer)
            {
                Slot = slot;
                Stages = stages;
                Kind = kind;
                DynamicBuffer = dynamicBuffer;
            }
        }
    }
}
