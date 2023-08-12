namespace Alis.Core.Graphic.Backends.OpenGL
{
    /// <summary>
    /// The open gl deferred resource interface
    /// </summary>
    internal interface OpenGLDeferredResource
    {
        /// <summary>
        /// Gets the value of the created
        /// </summary>
        bool Created { get; }
        /// <summary>
        /// Ensures the resources created
        /// </summary>
        void EnsureResourcesCreated();
        /// <summary>
        /// Destroys the gl resources
        /// </summary>
        void DestroyGLResources();
    }
}
