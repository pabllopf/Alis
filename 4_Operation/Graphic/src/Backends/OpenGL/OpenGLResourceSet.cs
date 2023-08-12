namespace Alis.Core.Graphic.Backends.OpenGL
{
    /// <summary>
    /// The open gl resource set class
    /// </summary>
    /// <seealso cref="ResourceSet"/>
    internal class OpenGLResourceSet : ResourceSet
    {
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the layout
        /// </summary>
        public new OpenGLResourceLayout Layout { get; }
        /// <summary>
        /// Gets the value of the resources
        /// </summary>
        public new BindableResource[] Resources { get; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLResourceSet"/> class
        /// </summary>
        /// <param name="description">The description</param>
        public OpenGLResourceSet(ref ResourceSetDescription description) : base(ref description)
        {
            Layout = Util.AssertSubtype<ResourceLayout, OpenGLResourceLayout>(description.Layout);
            Resources = Util.ShallowClone(description.BoundResources);
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
