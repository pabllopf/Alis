namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl language version enum
    /// </summary>
    public enum MTLLanguageVersion : uint
    {
        /// <summary>
        /// The version1 mtl language version
        /// </summary>
        Version1_0 = (1 << 16),
        /// <summary>
        /// The version1 mtl language version
        /// </summary>
        Version1_1 = (1 << 16) + 1,
        /// <summary>
        /// The version1 mtl language version
        /// </summary>
        Version1_2 = (1 << 16) + 2,
    }
}