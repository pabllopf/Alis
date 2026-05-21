

namespace Alis.App.Engine.Core
{
    /// <summary>
    ///     The runtime interface
    /// </summary>
    public interface IRuntime
    {
        /// <summary>
        ///     Initializes this instance
        /// </summary>
        void Initialize();

        /// <summary>
        ///     Updates this instance
        /// </summary>
        void Update();

        /// <summary>
        ///     Renders this instance
        /// </summary>
        void Render();
    }
}