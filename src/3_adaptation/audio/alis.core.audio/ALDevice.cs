// 

using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Systems.Audio
{
    /// <summary>
    ///     Opaque handle to an OpenAL device.
    /// </summary>
    public struct ALDevice : IEquatable<ALDevice>
    {
        public static readonly ALDevice Null = new ALDevice(IntPtr.Zero);

        public IntPtr Handle;

        public ALDevice(IntPtr handle) => Handle = handle;

        public override bool Equals(object obj) => obj is ALDevice device && Equals(device);

        public bool Equals([AllowNull] ALDevice other) => Handle.Equals(other.Handle);

        public override int GetHashCode() => HashCode.Combine(Handle);

        public static bool operator ==(ALDevice left, ALDevice right) => left.Equals(right);

        public static bool operator !=(ALDevice left, ALDevice right) => !(left == right);

        public static implicit operator IntPtr(ALDevice device) => device.Handle;
    }
}