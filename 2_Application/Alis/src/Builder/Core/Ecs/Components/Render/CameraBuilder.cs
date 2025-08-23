using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Builder.Core.Ecs.Components.Render
{
    /// <summary>
    /// The camera builder class
    /// </summary>
    /// <seealso cref="IBuild{Camera}"/>
    public class CameraBuilder : IBuild<Camera>
    {
        /// <summary>
        /// The vector
        /// </summary>
        private Vector2F cameraPosition = new Vector2F(0, 0);
        /// <summary>
        /// The vector
        /// </summary>
        private Vector2F resolution = new Vector2F(1920, 1080);
    
        /// <summary>
        /// Resolutions the x
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
        /// Positions the x
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
        /// Builds this instance
        /// </summary>
        /// <returns>The camera</returns>
        public Camera Build() => new Camera(cameraPosition, resolution);
    }
}