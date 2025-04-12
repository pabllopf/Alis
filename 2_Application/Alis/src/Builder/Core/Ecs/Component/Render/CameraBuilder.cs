using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Builder.Core.Ecs.Component.Render
{
    public class CameraBuilder : IBuild<Camera>
    {
        private Vector2F cameraPosition = new Vector2F(0, 0);
        private Vector2F resolution = new Vector2F(1920, 1080);
    
        public CameraBuilder Resolution(int x, int y)
        {
            resolution = new Vector2F(x, y);
            return this;
        }

        public CameraBuilder Position(float x, float y)
        {
            cameraPosition = new Vector2F(x, y);
            return this;
        }

        public Camera Build() => new Camera(cameraPosition, resolution);
    }
}