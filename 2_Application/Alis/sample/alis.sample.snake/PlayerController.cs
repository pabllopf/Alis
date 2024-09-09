using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Entity;

namespace Alis.Sample.Snake
{
    public class PlayerController : AComponent
    {
        private BoxCollider _boxCollider;
        private List<GameObject> _snakeBody;
        private float _moveTimer;
        private float _moveInterval = 0.2f; 
        private Vector2 _direction = new Vector2(1, 0); 

        public override void OnStart()
        {
            Console.WriteLine("PlayerController started");
            _boxCollider = GameObject.Get<BoxCollider>();
            _snakeBody = new List<GameObject> { GameObject };
        }

        public override void OnUpdate()
        {
            _moveTimer += Context.TimeManager.DeltaTime;
            if (_moveTimer >= _moveInterval)
            {
                Move();
                _moveTimer = 0;
            }
        }

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

        public override void OnReleaseKey(KeyCodes key)
        {
            // No action needed on key release for this game
        }
        
       private void Move()
        {
            Vector2 newPosition = _boxCollider.Body.Position + _direction * 1; // Move by 1 meter (32 pixels)
            
            for (int i = _snakeBody.Count - 1; i > 0; i--)
            {
                BoxCollider segmentCollider = _snakeBody[i].Get<BoxCollider>();
                segmentCollider.Body.Position = _snakeBody[i - 1].Get<BoxCollider>().Body.Position;
            }
            
            _boxCollider.Body.Position = newPosition;
        }

        public void Grow()
        {
            GameObject newSegment = new GameObject();
            BoxCollider lastSegmentCollider = _snakeBody[_snakeBody.Count - 1].Get<BoxCollider>();
            BoxCollider newSegmentCollider = new BoxCollider()
                .Builder()
                .Size(1, 1)
                .Build();
            newSegment.Add(newSegmentCollider);
            newSegmentCollider.Body.Position = lastSegmentCollider.Body.Position;
            _snakeBody.Add(newSegment);
        }
    }
}