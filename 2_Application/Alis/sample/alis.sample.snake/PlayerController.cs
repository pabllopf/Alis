using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Entity;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Snake
{
    /// <summary>
    /// The player controller class
    /// </summary>
    /// <seealso cref="AComponent"/>
    public class PlayerController : AComponent
    {
        /// <summary>
        /// The box collider
        /// </summary>
        private BoxCollider _boxCollider;
        
        /// <summary>
        /// The snake body
        /// </summary>
        private List<GameObject> _snakeBody;
        
        /// <summary>
        /// The move timer
        /// </summary>
        private float _moveTimer;
        
        /// <summary>
        /// The move interval
        /// </summary>
        private float _moveInterval = 0.2f; 
        
        /// <summary>
        /// The vector
        /// </summary>
        private Vector2 _direction = new Vector2(1, 0); 

        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
            Console.WriteLine("PlayerController started");
            _boxCollider = GameObject.Get<BoxCollider>();
            _snakeBody = new List<GameObject> { GameObject };
        }

        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            _moveTimer += Context.TimeManager.DeltaTime;
            if (_moveTimer >= _moveInterval)
            {
                Move();
                _moveTimer = 0;
            }
        }

        /// <summary>
        /// Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressKey(KeyCodes key)
        {
            if (key == KeyCodes.W && _direction != new Vector2(0, -1))
                _direction = new Vector2(0, 1);
            else if (key == KeyCodes.S && _direction != new Vector2(0, 1))
                _direction = new Vector2(0, -1);
            else if (key == KeyCodes.A && _direction != new Vector2(1, 0))
                _direction = new Vector2(-1, 0);
            else if (key == KeyCodes.D && _direction != new Vector2(-1, 0))
                _direction = new Vector2(1, 0);
        }

        /// <summary>
        /// Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(KeyCodes key)
        {
            // No action needed on key release for this game
        }
        
       /// <summary>
       /// Moves this instance
       /// </summary>
       private void Move()
        {
            Vector2 newPosition = _boxCollider.Body.Position + _direction * 1; // Move by 1 meter (32 pixels)
            
            for (int i = _snakeBody.Count - 1; i > 0; i--)
            {
                if (_snakeBody[i].Get<BoxCollider>().Body != null && _snakeBody[i - 1].Get<BoxCollider>().Body != null)
                {
                    BoxCollider segmentCollider = _snakeBody[i].Get<BoxCollider>();
                    segmentCollider.GameObject.IsEnable = true;
                    segmentCollider.Body.Position = _snakeBody[i - 1].Get<BoxCollider>().Body.Position;
                }
            }
            
            _boxCollider.Body.Position = newPosition;
        }

        /// <summary>
        /// Grows this instance
        /// </summary>
        public void Grow()
        {
            // Create a new GameObject for the new segment
            GameObject newSegment = new GameObject();

            // Create and configure the BoxCollider for the new segment
            BoxCollider newSegmentCollider = new BoxCollider()
                .Builder()
                .IsActive(true)
                .BodyType(BodyType.Kinematic)
                .IsTrigger(false)
                .AutoTilling(false)
                .Size(1f, 1f)
                .Rotation(0.0f)
                .RelativePosition(0, 0)
                .Mass(1.0f)
                .Restitution(1f)
                .Friction(0f)
                .FixedRotation(true)
                .IgnoreGravity(true)
                .Build();
            
            // Add the BoxCollider to the new segment
            newSegment.Add(newSegmentCollider);

            // Add the new segment to the scene
            Context.SceneManager.CurrentScene.Add(newSegment);

            // Add the new segment to the snake body list
            _snakeBody.Add(newSegment);
            
            newSegment.Tag = "SnakeSegment";
            newSegment.IsEnable = false;
        }
    }
}