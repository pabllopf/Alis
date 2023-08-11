using System;

namespace Veldrid
{
    /// <summary>
    /// The mapped resource cache key
    /// </summary>
    internal struct MappedResourceCacheKey : IEquatable<MappedResourceCacheKey>
    {
        /// <summary>
        /// The resource
        /// </summary>
        public readonly MappableResource Resource;
        /// <summary>
        /// The subresource
        /// </summary>
        public readonly uint Subresource;

        /// <summary>
        /// Initializes a new instance of the <see cref="MappedResourceCacheKey"/> class
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="subresource">The subresource</param>
        public MappedResourceCacheKey(MappableResource resource, uint subresource)
        {
            Resource = resource;
            Subresource = subresource;
        }

        /// <summary>
        /// Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(MappedResourceCacheKey other)
        {
            return Resource.Equals(other.Resource)
                && Subresource.Equals(other.Subresource);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode()
        {
            return HashHelper.Combine(Resource.GetHashCode(), Subresource.GetHashCode());
        }
    }
}
