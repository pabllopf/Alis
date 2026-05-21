

using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Sample.Asteroid.Web
{
    /// <summary>
    ///     The health controller class
    /// </summary>
    public class HealthController : IOnInit, IOnUpdate
    {
        /*
        /// <summary>
        /// The font manager
        /// </summary>
        //public FontManager fontManager;

        /// <summary>
        /// The health
        /// </summary>
        public int health = 1;

        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
        }

        /// <summary>
        /// Ons the gui
        /// </summary>
        public override void OnGui()
        {
            //if (fontManager == null) return;

            if (health == 3)
            {
                return;
            }

            if (health == 2)
            {
                return;
            }

            if (health == 1)
            {
                return;
            }

            if (health >= 0)
            {
                Context.SceneManager.CurrentScene.GetByTag("Soundtrack").Get<AudioSource>().Stop();
            }
        }

        /// <summary>
        /// Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressKey(Keys key)
        {
            if (health <= 0 && key != Keys.Space && key != Keys.S && key != Keys.W && key != Keys.A && key != Keys.D)
            {
                Context.SceneManager.LoadScene(0);
                Console.WriteLine("Restarting game");
            }
        }

        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            if (health <= 0)
            {
                Context.SceneManager.CurrentScene.GetByTag("Points").Get<CounterManager>().counter = 0;
                Context.SceneManager.DestroyGameObject(Context.SceneManager.CurrentScene.GetByTag("Player"));
            }
        }

        /// <summary>
        /// Decrements this instance
        /// </summary>
        public void Decrement()
        {
            health--;
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