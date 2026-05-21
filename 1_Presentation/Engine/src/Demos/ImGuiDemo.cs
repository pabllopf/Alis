

using System.Diagnostics;
using Alis.Extension.Graphic.Ui;

namespace Alis.App.Engine.Demos
{
    /// <summary>
    ///     The im gui demo class
    /// </summary>
    /// <seealso cref="IDemo" />
    public class ImGuiDemo : IDemo
    {
        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            DefaultDemo();
        }

        /// <summary>
        ///     Defaults the demo
        /// </summary>
        [Conditional("DEBUG")]
        private void DefaultDemo()
        {
            ImGui.ShowDemoWindow();
        }
    }
}