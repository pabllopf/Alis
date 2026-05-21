

using System;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Sample.Flappy.Bird.Desktop
{
    /// <summary>
    ///     The main menu controller class
    /// </summary>
    public class MainMenuController : IOnUpdate, IOnPressKey, IHasContext<Context>
    {
        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        ///     Ons the press key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnPressKey(KeyEventInfo info)
        {
            if (info.Key == ConsoleKey.Spacebar)
            {
                Logger.Info("Changing to game scene 'Game_Scene'...");
                Context.SceneManager.LoadScene(1);
            }
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