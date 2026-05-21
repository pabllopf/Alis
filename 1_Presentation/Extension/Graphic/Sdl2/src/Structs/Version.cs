

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl version
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Version
    {
        /// <summary>
        ///     The major
        /// </summary>
        [FieldOffset(0)] public byte major;


        /// <summary>
        ///     The minor
        /// </summary>
        [FieldOffset(1)] public byte minor;


        /// <summary>
        ///     The patch
        /// </summary>
        [FieldOffset(2)] public byte patch;


        /// <summary>
        ///     Initializes a new instance of the <see cref="Version" /> class
        /// </summary>
        /// <param name="sdlTtfMajorVersion">The sdl ttf major version</param>
        /// <param name="sdlTtfMinorVersion">The sdl ttf minor version</param>
        /// <param name="sdlTtfPatchLevel">The sdl ttf patch level</param>
        public Version(int sdlTtfMajorVersion, int sdlTtfMinorVersion, int sdlTtfPatchLevel)
        {
            major = (byte) sdlTtfMajorVersion;
            minor = (byte) sdlTtfMinorVersion;
            patch = (byte) sdlTtfPatchLevel;
        }
    }
}