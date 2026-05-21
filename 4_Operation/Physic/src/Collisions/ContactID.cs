

using System.Runtime.InteropServices;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Uniquely identifies a contact point between two colliding shapes to facilitate warm starting.
    /// </summary>
    /// <remarks>
    ///     Provides both structured feature data and a fast comparison key for contact persistence.
    ///     The union allows efficient equality checking while maintaining detailed feature information
    ///     needed for accurate collision response across simulation steps.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit)]
    public struct ContactId
    {
        /// <summary>
        ///     Gets or sets the structured contact features that define this contact point.
        /// </summary>
        /// <value>The <see cref="ContactFeature"/> describing the geometric intersection.</value>
        [FieldOffset(0)] public ContactFeature Features;

        /// <summary>
        ///     Gets or sets the packed integer key used for fast contact comparison and hashing.
        /// </summary>
        /// <value>A 32-bit unsigned integer representing the contact identity.</value>
        [FieldOffset(0)] public uint Key;
    }
}