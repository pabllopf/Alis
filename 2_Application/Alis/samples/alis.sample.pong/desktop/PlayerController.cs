

using System;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Collider;

namespace Alis.Sample.Pong.Desktop
{
    /// <summary>
    ///     The player controller class
    /// </summary>
    public struct PlayerController(int playerId = 0) : IOnInit, IOnUpdate, IOnHoldKey, IOnReleaseKey, IOnPressKey
    {
        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider boxCollider;

        /// <summary>
        ///     The player id
        /// </summary>
        public int PlayerId { get; set; } = playerId;

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnInit(IGameObject self)
        {
            boxCollider = self.Get<BoxCollider>();
        }

        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
        }

        /// <summary>
        ///     Ons the hold key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnHoldKey(KeyEventInfo info)
        {
        }

        /// <summary>
        ///     Ons the release key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnReleaseKey(KeyEventInfo info)
        {
            Vector2F velocity = boxCollider.Body.LinearVelocity;
            ConsoleKey key = info.Key;
            switch (PlayerId)
            {
                case 1:
                    switch (key)
                    {
                        case ConsoleKey.W:
                            velocity = new Vector2F(velocity.X, 0);
                            boxCollider.Body.LinearVelocity = velocity;
                            return;
                        case ConsoleKey.S:
                            velocity = new Vector2F(velocity.X, 0);
                            boxCollider.Body.LinearVelocity = velocity;
                            break;
                    }

                    break;
                case 2:
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            velocity = new Vector2F(velocity.X, 0);
                            boxCollider.Body.LinearVelocity = velocity;
                            return;
                        case ConsoleKey.DownArrow:
                            velocity = new Vector2F(velocity.X, 0);
                            boxCollider.Body.LinearVelocity = velocity;
                            break;
                    }

                    break;
            }
        }

        /// <summary>
        ///     Ons the press key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnPressKey(KeyEventInfo info)
        {
            Vector2F velocity = boxCollider.Body.LinearVelocity;

            ConsoleKey key = info.Key;
            switch (PlayerId)
            {
                case 1:
                    switch (key)
                    {
                        case ConsoleKey.W:
                            velocity = new Vector2F(velocity.X, 3);
                            boxCollider.Body.LinearVelocity = velocity;
                            return;
                        case ConsoleKey.S:
                            velocity = new Vector2F(velocity.X, -3);
                            boxCollider.Body.LinearVelocity = velocity;
                            break;
                    }

                    break;
                case 2:
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            velocity = new Vector2F(velocity.X, 3);
                            boxCollider.Body.LinearVelocity = velocity;
                            return;
                        case ConsoleKey.DownArrow:
                            velocity = new Vector2F(velocity.X, -3);
                            boxCollider.Body.LinearVelocity = velocity;
                            break;
                    }

                    break;
            }
        }
    }
}