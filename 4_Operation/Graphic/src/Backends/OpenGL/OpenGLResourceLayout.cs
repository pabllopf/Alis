namespace Alis.Core.Graphic.Backends.OpenGL
{
    /// <summary>
    /// The open gl resource layout class
    /// </summary>
    /// <seealso cref="ResourceLayout"/>
    internal class OpenGLResourceLayout : ResourceLayout
    {
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the elements
        /// </summary>
        public ResourceLayoutElementDescription[] Elements { get; }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLResourceLayout"/> class
        /// </summary>
        /// <param name="description">The description</param>
        public OpenGLResourceLayout(ref ResourceLayoutDescription description)
            : base(ref description)
        {
            Elements = Util.ShallowClone(description.Elements);
        }

        /// <summary>
        /// Describes whether this instance is dynamic buffer
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <returns>The bool</returns>
        public bool IsDynamicBuffer(uint slot)
        {
            return (Elements[slot].Options & ResourceLayoutElementOptions.DynamicBinding) != 0;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            _disposed = true;
        }
    }
}
