

namespace Alis.App.Hub.Core
{
    /// <summary>
    ///     The runtime interface
    /// </summary>
    public interface IRuntime
    {
        /// <summary>
        ///     Ons the init
        /// </summary>
        void OnInit();

        /// <summary>
        ///     Ons the start
        /// </summary>
        void OnStart();

        /// <summary>
        ///     Ons the update
        /// </summary>
        void OnUpdate();

        /// <summary>
        ///     Ons the render
        /// </summary>
        void OnRender(float scale);

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        void OnDestroy();
    }
}