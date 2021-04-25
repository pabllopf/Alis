//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="About.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
using ImGuiNET;

namespace Alis.Editor.UI.Widgets
{
    public class AudioPlayer : Widget
    {
        private bool isOpen = true;

        public override void Draw()
        {
            if (!isOpen)
            {
                WidgetManager.Delete(this);
                return;
            }

            if (ImGui.Begin("Audio Player", ref isOpen))
            {
            }

            ImGui.End();
        }
    }
}
