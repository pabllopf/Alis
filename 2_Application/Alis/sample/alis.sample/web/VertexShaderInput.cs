using System.Numerics;
using System.Runtime.InteropServices;

namespace Alis.Sample.Web
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "POD")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct VertexShaderInput
    {
        public Vector2 Vertex;
        public Vector3 Color;
    };
}