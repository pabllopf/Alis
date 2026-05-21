

using Alis.App.Engine.Core;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The solution window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class SolutionWindow : IWindow
    {
        /// <summary>
        ///     The name window
        /// </summary>
        internal static readonly string NameWindow = $"{FontAwesome5.AddressCard} Solution";

        /// <summary>
        ///     Initializes a new instance of the <see cref="SolutionWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public SolutionWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

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
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            if (ImGui.Begin(NameWindow))
            {
            }

            ImGui.End();
        }

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
    }
}