namespace Veldrid.D3D11
{
    /// <summary>
    /// The 11 resource set class
    /// </summary>
    /// <seealso cref="ResourceSet"/>
    internal class D3D11ResourceSet : ResourceSet
    {
        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the resources
        /// </summary>
        public new BindableResource[] Resources { get; }
        /// <summary>
        /// Gets the value of the layout
        /// </summary>
        public new D3D11ResourceLayout Layout { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11ResourceSet"/> class
        /// </summary>
        /// <param name="description">The description</param>
        public D3D11ResourceSet(ref ResourceSetDescription description) : base(ref description)
        {
            Resources = Util.ShallowClone(description.BoundResources);
            Layout = Util.AssertSubtype<ResourceLayout, D3D11ResourceLayout>(description.Layout);
        }

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
    }
}
