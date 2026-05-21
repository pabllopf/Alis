

namespace Alis.Extension.Graphic.Ui.Sample.Examples
{
    /// <summary>
    ///     The example interface
    /// </summary>
    internal interface IExample
    {
        /// <summary>
        ///     Initializes this instance
        /// </summary>
        void Initialize();

        /// <summary>
        ///     Draws this instance
        /// </summary>
        void Draw();

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        void Cleanup();
    }
}