namespace Alis.Core.Graphic.Backends.MTL
{
    /// <summary>
    /// The mtl resource set class
    /// </summary>
    /// <seealso cref="ResourceSet"/>
    internal class MTLResourceSet : ResourceSet
    {
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;
        /// <summary>
        /// Gets the value of the resources
        /// </summary>
        public BindableResource[] Resources { get; }
        /// <summary>
        /// Gets the value of the layout
        /// </summary>
        public MTLResourceLayout Layout { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLResourceSet"/> class
        /// </summary>
        /// <param name="description">The description</param>
        /// <param name="gd">The gd</param>
        public MTLResourceSet(ref ResourceSetDescription description, MTLGraphicsDevice gd) : base(ref description)
        {
            Resources = Util.ShallowClone(description.BoundResources);
            Layout = Util.AssertSubtype<ResourceLayout, MTLResourceLayout>(description.Layout);
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
    }
}
