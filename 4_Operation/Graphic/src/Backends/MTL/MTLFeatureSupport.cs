using System;
using System.Collections;
using System.Collections.Generic;
using Alis.Core.Graphic.Backends.Metal;

namespace Alis.Core.Graphic.Backends.MTL
{
    /// <summary>
    /// The mtl feature support class
    /// </summary>
    /// <seealso cref="IReadOnlyCollection{MTLFeatureSet}"/>
    internal class MTLFeatureSupport : IReadOnlyCollection<MTLFeatureSet>
    {
        /// <summary>
        /// The mtl feature set
        /// </summary>
        private readonly HashSet<MTLFeatureSet> _supportedFeatureSets = new HashSet<MTLFeatureSet>();

        /// <summary>
        /// Gets the value of the is mac os
        /// </summary>
        public bool IsMacOS { get; }

        /// <summary>
        /// Gets the value of the max feature set
        /// </summary>
        public MTLFeatureSet MaxFeatureSet { get; }

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public int Count => _supportedFeatureSets.Count;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLFeatureSupport"/> class
        /// </summary>
        /// <param name="device">The device</param>
        public MTLFeatureSupport(MTLDevice device)
        {
            foreach (MTLFeatureSet set in Enum.GetValues(typeof(MTLFeatureSet)))
            {
                if (device.supportsFeatureSet(set))
                {
                    _supportedFeatureSets.Add(set);
                    MaxFeatureSet = set;
                }
            }

            IsMacOS = IsSupported(MTLFeatureSet.macOS_GPUFamily1_v1)
                || IsSupported(MTLFeatureSet.macOS_GPUFamily1_v2)
                || IsSupported(MTLFeatureSet.macOS_GPUFamily1_v3);
        }

        /// <summary>
        /// Describes whether this instance is supported
        /// </summary>
        /// <param name="featureSet">The feature set</param>
        /// <returns>The bool</returns>
        public bool IsSupported(MTLFeatureSet featureSet) => _supportedFeatureSets.Contains(featureSet);

        /// <summary>
        /// Describes whether this instance is draw base vertex instance supported
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsDrawBaseVertexInstanceSupported()
        {
            return IsSupported(MTLFeatureSet.iOS_GPUFamily3_v1)
                || IsSupported(MTLFeatureSet.iOS_GPUFamily3_v2)
                || IsSupported(MTLFeatureSet.iOS_GPUFamily3_v3)
                || IsSupported(MTLFeatureSet.iOS_GPUFamily4_v1)
                || IsSupported(MTLFeatureSet.tvOS_GPUFamily2_v1)
                || IsMacOS;
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of mtl feature set</returns>
        public IEnumerator<MTLFeatureSet> GetEnumerator()
        {
            return _supportedFeatureSets.GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
