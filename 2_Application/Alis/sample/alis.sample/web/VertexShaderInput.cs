using System.Numerics;
using System.Runtime.InteropServices;

namespace Alis.Sample.Web
{
    /// <summary>
    /// The vertex shader input
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "POD")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct VertexShaderInput
    {
        /// <summary>
        /// The vertex
        /// </summary>
        public Vector2 Vertex;
        /// <summary>
        /// The color
        /// </summary>
        public Vector3 Color;
    };
}