

using Alis.App.Engine.Core;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Windows.Settings
{
    /// <summary>
    ///     The settings window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class SettingsWindow : IWindow
    {
        /// <summary>
        ///     The music
        /// </summary>
        public static readonly string WindowName = $"{FontAwesome5.Wrench} Settings";

        /// <summary>
        ///     The is open
        /// </summary>
        private bool isOpen = true;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SettingsWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public SettingsWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

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
            if (!isOpen)
            {
                return;
            }

            /*
            object[] settings =
            {
                SpaceWork.VideoGame.Context.Setting.General,
                SpaceWork.VideoGame.Context.Setting.Graphic,
                SpaceWork.VideoGame.Context.Setting.Audio,
                SpaceWork.VideoGame.Context.Setting.Input,
                SpaceWork.VideoGame.Context.Setting.Network,
                SpaceWork.VideoGame.Context.Setting.Physic,
                SpaceWork.VideoGame.Context.Setting.Scene
            };*/

            if (ImGui.Begin(WindowName, ref isOpen))
            {
                //RenderSettings(settings);
            }

            ImGui.End();
        }

        /// <summary>
        ///     Renders the settings using the specified settings
        /// </summary>
        /// <param name="settings">The settings</param>
        private void RenderSettings(object[] settings)
        {
        }
    }
}