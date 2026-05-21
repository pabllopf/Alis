

using Alis.App.Engine.Core;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The window interface
    /// </summary>
    internal interface IWindow : IRenderable, IHasSpaceWork
    {
        /// <summary>
        ///     Initializes this instance
        /// </summary>
        void Initialize();

        /// <summary>
        ///     Starts this instance
        /// </summary>
        void Start();
    }
}