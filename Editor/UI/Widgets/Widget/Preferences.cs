//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Preferences.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using ImGuiNET;
    using System;

    /// <summary>Set preferences of alis editor. </summary>
    public class Preferences : Widget
    {
        /// <summary>The focus</summary>
        private static bool focus;

        /// <summary>The is open</summary>
        private bool isOpen;

        /// <summary>Initializes a new instance of the <see cref="Preferences" /> class.</summary>
        public Preferences()
        {
            isOpen = true;
            focus = false;
        }

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            if (!isOpen)
            {
                WidgetManager.Delete(this);
                return;
            }

            if (focus)
            {
                focus = false;
                ImGui.SetNextWindowFocus();
            }

            if (ImGui.Begin("Preferences", ref isOpen))
            {

            }

            ImGui.End();
        }

        /// <summary>Focuses this instance.</summary>
        public static void Focus() => focus = true;

        /// <summary>Sets the style.</summary>
        public void SetStyle() 
        {
        
        }
    }
}
