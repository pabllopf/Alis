

using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Graphic.Sfml.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
        {
            Logger.Info("Press ESC key to close window");
            SimpleWindow window = new SimpleWindow();
            window.Run();

            Logger.Info("All done");
        }
    }
}