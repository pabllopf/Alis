#if !EXCLUDE_METAL_BACKEND
using System.Collections.ObjectModel;
using System.Linq;
using Veldrid.MetalBindings;
using Veldrid.MTL;

namespace Veldrid
{
    /// <summary>
    /// Exposes Metal-specific functionality,
    /// useful for interoperating with native components which interface directly with Metal.
    /// Can only be used on <see cref="GraphicsBackend.Metal"/>.
    /// </summary>
    public class BackendInfoMetal
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly MTLGraphicsDevice _gd;
        /// <summary>
        /// The feature set
        /// </summary>
        private ReadOnlyCollection<MTLFeatureSet> _featureSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackendInfoMetal"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        internal BackendInfoMetal(MTLGraphicsDevice gd)
        {
            _gd = gd;
            _featureSet = new ReadOnlyCollection<MTLFeatureSet>(_gd.MetalFeatures.ToArray());
        }

        /// <summary>
        /// Gets the value of the feature set
        /// </summary>
        public ReadOnlyCollection<MTLFeatureSet> FeatureSet => _featureSet;

        /// <summary>
        /// Gets the value of the max feature set
        /// </summary>
        public MTLFeatureSet MaxFeatureSet => _gd.MetalFeatures.MaxFeatureSet;
    }
}
#endif
