

using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Components.Ui;

namespace Alis.Builder.Core.Ecs.Components.Ui
{
    /// <summary>
    ///     The canvas builder class
    /// </summary>
    /// <seealso cref="IBuild{Canvas}" />
    public class CanvasBuilder : IBuild<Canvas>
    {
        /// <summary>
        ///     The canvas
        /// </summary>
        private readonly Canvas canvas = new Canvas();

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The canvas</returns>
        public Canvas Build() => canvas;
    }
}