
using Alis.Core.Aspect.Math;
using Alis.Core.Ecs.Component;
using Vector2 = Alis.Core.Aspect.Math.Vector.Vector2;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    /// The bird idle class
    /// </summary>
    /// <seealso cref="Component"/>
    public class BirdIdle : Component
    {
        /// <summary>
        /// The default position
        /// </summary>
        private Vector2 defaultPosition;

        /// <summary>
        /// The range movement
        /// </summary>
        private const float RangeMovement = 8.0f;
        
        /// <summary>
        /// The go up
        /// </summary>
        private bool goUp = true;
        
        /// <summary>
        /// The go down
        /// </summary>
        private bool goDown = false;

        /// <summary>
        /// Ons the init
        /// </summary>
        public override void OnInit()
        {
            defaultPosition = GameObject.Transform.Position;
        }

        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            // get the x position of game object:
            float x = GameObject.Transform.Position.X;
            
            // get the y position of game object:
            float y = GameObject.Transform.Position.Y;
            
            Vector2 scale = GameObject.Transform.Scale;
            
            Rotation rotation = GameObject.Transform.Rotation;

            // create a new position:
            Vector2 newPosition;
            
            if (goUp && !goDown)
            {
                newPosition = new Vector2(x, y - 0.05f);
                Transform transform = new Transform()
                {
                    Position = newPosition,
                    Rotation = rotation,
                    Scale = scale
                };
            
                GameObject.Transform = transform;
            }
            else if (goDown && !goUp)
            {
                newPosition = new Vector2(x, y + 0.05f);
                Transform transform = new Transform()
                {
                    Position = newPosition,
                    Rotation = rotation,
                    Scale = scale
                };
            
                GameObject.Transform = transform;
            }
            
            if (y < defaultPosition.Y - RangeMovement)
            {
                goUp = false;
                goDown = true;
            }
            
            if (y > defaultPosition.Y + RangeMovement)
            {
                goUp = true;
                goDown = false;
            }
        }
    }
}