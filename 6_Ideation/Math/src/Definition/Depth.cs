

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Alis.Core.Aspect.Math.Definition
{
    /// <summary>
    ///     Represents a depth value as a serializable structure, commonly used for Z-ordering or depth sorting in rendering.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Depth : ISerializable
    {
        /// <summary>
        ///     Gets or sets the depth value as an integer.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Depth" /> struct with the specified value.
        /// </summary>
        /// <param name="value">The depth value to assign.</param>
        public Depth(int value) => Value = value;

        /// <summary>
        ///     Populates a <see cref="SerializationInfo" /> with the data needed to serialize the depth value.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="StreamingContext" />) for this serialization.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("value", Value);
        }
    }
}
