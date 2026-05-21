

namespace Alis.App.Engine.Demos
{
    /// <summary>
    ///     The demo interface
    /// </summary>
    public interface IDemo
    {
        /// <summary>
        ///     Initializes this instance
        /// </summary>
        void Initialize();

        /// <summary>
        ///     Starts this instance
        /// </summary>
        void Start();

        /// <summary>
        ///     Runs this instance
        /// </summary>
        void Run();
    }
}