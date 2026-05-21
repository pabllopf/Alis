

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.Systems.Configuration.Graphic
{
    /// <summary>
    ///     The graphic setting class
    /// </summary>
    /// <seealso cref="IGraphicSetting" />
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GraphicSetting(
        double targetFrames,
        string target,
        bool previewMode,
        Color gridColor,
        bool hasGrid,
        Color backgroundColor,
        Vector2F windowSize,
        bool isResizable) : IGraphicSetting
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicSetting" /> class
        /// </summary>
        public GraphicSetting() : this(
            60.0,
            "OpenGL",
            false,
            Color.White,
            false,
            Color.Black,
            new Vector2F(800, 600),
            true)
        {
        }

        /// <summary>
        ///     Gets or sets the value of the target frames
        /// </summary>
        public double TargetFrames { get; set; } = targetFrames;

        /// <summary>
        ///     Gets or sets the value of the target
        /// </summary>
        public string Target { get; set; } = target;

        /// <summary>
        ///     Gets or sets the value of the preview mode
        /// </summary>
        public bool PreviewMode { get; set; } = previewMode;

        /// <summary>
        ///     Gets or sets the value of the grid color
        /// </summary>
        public Color GridColor { get; set; } = gridColor;

        /// <summary>
        ///     Gets or sets the value of the has grid
        /// </summary>
        public bool HasGrid { get; set; } = hasGrid;

        /// <summary>
        ///     Gets or sets the value of the background color
        /// </summary>
        public Color BackgroundColor { get; set; } = backgroundColor;

        /// <summary>
        ///     Gets or sets the value of the window size
        /// </summary>
        public Vector2F WindowSize { get; set; } = windowSize;

        /// <summary>
        ///     Gets or sets the value of the is resizable
        /// </summary>
        public bool IsResizable { get; set; } = isResizable;
    }
}