

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Glfw.Structs
{
    /// <summary>
    ///     Wrapper around a EGL surface pointer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EglSurface : IEquatable<EglSurface>
    {
        /// <summary>
        ///     Describes a default/null instance.
        /// </summary>
        public static readonly EglSurface None;

        /// <summary>
        ///     Internal pointer.
        /// </summary>
        private readonly IntPtr handle;

        /// <summary>
        ///     Performs an implicit conversion from <see cref="EglSurface" /> to <see cref="IntPtr" />.
        /// </summary>
        /// <param name="surface">The surface.</param>
        /// <returns>
        ///     The result of the conversion.
        /// </returns>
        public static implicit operator IntPtr(EglSurface surface) => surface.handle;

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => handle.ToString();

        /// <summary>
        ///     Determines whether the specified <see cref="EglSurface" />, is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="EglSurface" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="EglSurface" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(EglSurface other) => handle.Equals(other.handle);

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is EglSurface surface)
            {
                return Equals(surface);
            }

            return false;
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => handle.GetHashCode();

        /// <summary>
        ///     Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator ==(EglSurface left, EglSurface right) => left.Equals(right);

        /// <summary>
        ///     Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator !=(EglSurface left, EglSurface right) => !left.Equals(right);
    }
}