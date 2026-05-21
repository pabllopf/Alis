

using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.Systems.Configuration.Graphic
{
    /// <summary>
    ///     The graphic setting interface
    /// </summary>
    public interface IGraphicSetting
    {
        /// <summary>
        ///     Gets or sets the value of the target frames
        /// </summary>
        double TargetFrames { get; set; }

        /// <summary>
        ///     Gets or sets the value of the target
        /// </summary>
        string Target { get; set; }

        /// <summary>
        ///     Gets or sets the value of the preview mode
        /// </summary>
        bool PreviewMode { get; set; }

        /// <summary>
        ///     Gets or sets the value of the grid color
        /// </summary>
        Color GridColor { get; set; }

        /// <summary>
        ///     Gets or sets the value of the has grid
        /// </summary>
        bool HasGrid { get; set; }

        /// <summary>
        ///     Gets or sets the value of the background color
        /// </summary>
        Color BackgroundColor { get; set; }

        /// <summary>
        ///     Gets or sets the value of the window size
        /// </summary>
        Vector2F WindowSize { get; set; }

        /// <summary>
        ///     Gets or sets the value of the is resizable
        /// </summary>
        bool IsResizable { get; set; }
    }
}