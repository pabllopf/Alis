

using Alis.App.Engine.Core;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The game window class
    /// </summary>
    internal class GameWindow : IWindow
    {
        /// <summary>
        ///     The gamepad
        /// </summary>
        public static readonly string NameWindow = $"{FontAwesome5.Gamepad} Game";

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public GameWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

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