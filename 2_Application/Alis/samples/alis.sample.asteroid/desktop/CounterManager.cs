

using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Sample.Asteroid.Desktop
{
    /// <summary>
    ///     The counter manager class
    /// </summary>
    public class CounterManager : IOnInit, IOnUpdate
    {
        /*
        /// <summary>
        /// The counter
        /// </summary>
        public int counter = 10;

        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
        }

        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
        }

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public override void OnGui()
        {
            if(this.Context.SceneManager.CurrentScene.GetByTag("HealthController").Get<HealthController>().health > 0)
            {
            }
        }

        /// <summary>
        ///     Increments this instance
        /// </summary>
        public void Increment()
        {
            counter += 10;
        }

        /// <summary>
        /// Decrements this instance
        /// </summary>
        public void Decrement()
        {
            counter -= 1;
            if (counter < 0)
            {
                counter = 15;
                this.Context.SceneManager.CurrentScene.GetByTag("HealthController").Get<HealthController>().Decrement();
            }
        }

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset()
        {
            counter = 0;
        }*/


        /// <summary>
        ///     Ons the init using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnInit(IGameObject self)
        {
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