

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Builder.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The camera builder class
    /// </summary>
    /// <seealso cref="IBuild{Camera}" />
    public class CameraBuilder : IBuild<Camera>
    {
        /// <summary>
        ///     The context
        /// </summary>
        private readonly Context context;

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2F cameraPosition = new Vector2F(0, 0);

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2F resolution = new Vector2F(1920, 1080);

        /// <summary>
        ///     Initializes a new instance of the <see cref="CameraBuilder" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public CameraBuilder(Context context) => this.context = context;

        /// <summary>
        ///     Gets or sets the value of the background color
        /// </summary>
        private Color backgroundColor { get; set; } = Color.Black;

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The camera</returns>
        public Camera Build() => new Camera(context, cameraPosition, resolution);

        /// <summary>
        ///     Resolutions the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The camera builder</returns>
        public CameraBuilder Resolution(int x, int y)
        {
            resolution = new Vector2F(x, y);
            return this;
        }

        /// <summary>
        ///     Positions the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The camera builder</returns>
        public CameraBuilder Position(float x, float y)
        {
            cameraPosition = new Vector2F(x, y);
            return this;
        }

        /// <summary>
        ///     Backgrounds the color using the specified black
        /// </summary>
        /// <param name="black">The black</param>
        /// <returns>The camera builder</returns>
        public CameraBuilder BackgroundColor(Color black)
        {
            backgroundColor = black;
            return this;
        }
    }
}