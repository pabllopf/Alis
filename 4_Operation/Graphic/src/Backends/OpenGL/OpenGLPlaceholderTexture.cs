namespace Veldrid.OpenGL
{
    /// <summary>
    /// The open gl placeholder texture class
    /// </summary>
    /// <seealso cref="Texture"/>
    internal class OpenGLPlaceholderTexture : Texture
    {
        /// <summary>
        /// The height
        /// </summary>
        private uint _height;
        /// <summary>
        /// The width
        /// </summary>
        private uint _width;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLPlaceholderTexture"/> class
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="format">The format</param>
        /// <param name="usage">The usage</param>
        /// <param name="sampleCount">The sample count</param>
        public OpenGLPlaceholderTexture(
            uint width,
            uint height,
            PixelFormat format,
            TextureUsage usage,
            TextureSampleCount sampleCount)
        {
            _width = width;
            _height = height;
            Format = format;
            Usage = usage;
            SampleCount = sampleCount;
        }

        /// <summary>
        /// Resizes the width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void Resize(uint width, uint height)
        {
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Gets the value of the format
        /// </summary>
        public override PixelFormat Format { get; }

        /// <summary>
        /// Gets the value of the width
        /// </summary>
        public override uint Width => _width;

        /// <summary>
        /// Gets the value of the height
        /// </summary>
        public override uint Height => _height;

        /// <summary>
        /// Gets the value of the depth
        /// </summary>
        public override uint Depth => 1;

        /// <summary>
        /// Gets the value of the mip levels
        /// </summary>
        public override uint MipLevels => 1;

        /// <summary>
        /// Gets the value of the array layers
        /// </summary>
        public override uint ArrayLayers => 1;

        /// <summary>
        /// Gets the value of the usage
        /// </summary>
        public override TextureUsage Usage { get; }

        /// <summary>
        /// Gets the value of the sample count
        /// </summary>
        public override TextureSampleCount SampleCount { get; }

        /// <summary>
        /// Gets the value of the type
        /// </summary>
        public override TextureType Type => TextureType.Texture2D;

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Disposes the core
        /// </summary>
        private protected override void DisposeCore()
        {
            _disposed = true;
        }
    }
}
