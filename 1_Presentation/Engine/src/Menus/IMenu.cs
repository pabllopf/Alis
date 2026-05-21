

using Alis.App.Engine.Core;

namespace Alis.App.Engine.Menus
{
    /// <summary>
    ///     The menu interface
    /// </summary>
    internal interface IMenu : IRenderable, IHasSpaceWork, IRuntime
    {
        /// <summary>
        ///     Starts this instance
        /// </summary>
        void Start();
    }
}