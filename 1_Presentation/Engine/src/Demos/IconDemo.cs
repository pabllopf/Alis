

using System.Diagnostics;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Demos
{
    /// <summary>
    ///     The icon demo class
    /// </summary>
    /// <seealso cref="IDemo" />
    public class IconDemo : IDemo
    {
        /// <summary>
        ///     Gets the value of the name
        /// </summary>
        public static string Name => "Icon Demo";

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
            SimpleIcons();
        }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Simples the icons
        /// </summary>
        [Conditional("DEBUG")]
        private void SimpleIcons()
        {
            if (ImGui.Begin(Name))
            {
                ImGui.Separator();
                ImGui.Text("Font Awesome 5");
                ImGui.Text($" {FontAwesome5.Bug} {FontAwesome5.Bullhorn} {FontAwesome5.Bullseye} {FontAwesome5.Calendar}");
            }

            ImGui.End();
        }
    }
}