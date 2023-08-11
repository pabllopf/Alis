
namespace Veldrid
{
    /// <summary>
    /// The graphics api version
    /// </summary>
    public readonly struct GraphicsApiVersion
    {
        /// <summary>
        /// Gets the value of the unknown
        /// </summary>
        public static GraphicsApiVersion Unknown => default;

        /// <summary>
        /// Gets the value of the major
        /// </summary>
        public int Major { get; }
        /// <summary>
        /// Gets the value of the minor
        /// </summary>
        public int Minor { get; }
        /// <summary>
        /// Gets the value of the subminor
        /// </summary>
        public int Subminor { get; }
        /// <summary>
        /// Gets the value of the patch
        /// </summary>
        public int Patch { get; }

        /// <summary>
        /// Gets the value of the is known
        /// </summary>
        public bool IsKnown => Major != 0 && Minor != 0 && Subminor != 0 && Patch != 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicsApiVersion"/> class
        /// </summary>
        /// <param name="major">The major</param>
        /// <param name="minor">The minor</param>
        /// <param name="subminor">The subminor</param>
        /// <param name="patch">The patch</param>
        public GraphicsApiVersion(int major, int minor, int subminor, int patch)
        {
            Major = major;
            Minor = minor;
            Subminor = subminor;
            Patch = patch;
        }

        /// <summary>
        /// Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            return $"{Major}.{Minor}.{Subminor}.{Patch}";
        }

        /// <summary>
        /// Parses OpenGL version strings with either of following formats:
        /// <list type="bullet">
        ///   <item>
        ///     <description>major_number.minor_number</description>
        ///   </item>
        ///   <item>
        ///     <description>major_number.minor_number.release_number</description>
        ///   </item>
        /// </list>
        /// </summary>
        /// <param name="versionString">The OpenGL version string.</param>
        /// <param name="version">The parsed <see cref="GraphicsApiVersion"/>.</param>
        /// <returns>True whether the parse succeeded; otherwise false.</returns>
        public static bool TryParseGLVersion(string versionString, out GraphicsApiVersion version)
        {
            string[] versionParts = versionString.Split(' ')[0].Split('.');

            if (!int.TryParse(versionParts[0], out int major) ||
               !int.TryParse(versionParts[1], out int minor))
            {
                version = default;
                return false;
            }

            int releaseNumber = 0;
            if (versionParts.Length == 3)
            {
                if (!int.TryParse(versionParts[2], out releaseNumber))
                {
                    version = default;
                    return false;
                }
            }

            version = new GraphicsApiVersion(major, minor, 0, releaseNumber);
            return true;
        }
    }
}
