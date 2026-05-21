

using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Sdl2
{
    /// <summary>
    ///     The window interface
    /// </summary>
    public interface IWindow
    {
        /// <summary>
        ///     Gets or sets the value of the background
        /// </summary>
        Color Background { get; set; }

        /// <summary>
        ///     Gets or sets the value of the resolution
        /// </summary>
        Vector2F Resolution { get; set; }

        /// <summary>
        ///     Gets or sets the value of the is window resizable
        /// </summary>
        bool IsWindowResizable { get; set; }
    }
}