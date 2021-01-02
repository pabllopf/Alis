//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Graphics.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor
{
    /// <summary>Define the compatible graphics</summary>
    public enum Graphics
    {
        /// <summary>The unsupported graphics</summary>
        Unsupported,

        /// <summary>The graphics 1</summary>
        OpenGL,

        /// <summary>The graphics 2</summary>
        Directx11,

        /// <summary>The graphics 3</summary>
        Metal,

        /// <summary>The graphics 4</summary>
        Vulkan
    }
}
