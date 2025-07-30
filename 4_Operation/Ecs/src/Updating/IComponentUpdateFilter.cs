using System;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     The component update filter interface
    /// </summary>
    public interface IComponentUpdateFilter
    {
        /// <summary>
        ///     Updates the subset using the specified archetypes
        /// </summary>
        /// <param name="archetypes">The archetypes</param>
        public void UpdateSubset(ReadOnlySpan<ArchetypeDeferredUpdateRecord> archetypes);
    }
}