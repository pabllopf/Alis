

using System;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Collider;

namespace Alis.Sample.Flappy.Bird.Desktop
{
    /// <summary>
    ///     The bird controller class
    /// </summary>
    public class BirdController : IOnStart, IOnUpdate, IOnPressKey
    {
        /// <summary>
        ///     The audio source
        /// </summary>
        private AudioSource audioSource;

        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider boxCollider;

        /// <summary>
        ///     Gets or sets the value of the is dead
        /// </summary>
        public bool IsDead { get; set; } = false;

        /// <summary>
        ///     Ons the press key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnPressKey(KeyEventInfo info)
        {
            if (info.Key == ConsoleKey.Spacebar)
            {
                boxCollider.Body.ApplyLinearImpulse(new Vector2F(0, 7));
                Logger.Info("Go up!");
            }
        }

        /// <summary>
        ///     Ons the start using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
            audioSource = self.Get<AudioSource>();
            boxCollider = self.Get<BoxCollider>();
            boxCollider.Body.Position = new Vector2F(-3, 0);
        }

        /// <summary>
        ///     Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
        }
    }
}