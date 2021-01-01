//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Inspector.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using ImGuiNET;

    /// <summary>Manage components of scene.</summary>
    public class Inspector : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "Inspector";

        /// <summary>Initializes a new instance of the <see cref="Inspector" /> class.</summary>
        public Inspector()
        {
        }

        /// <summary>Closes this instance.</summary>
        public override void Close()
        {
        }

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            if (ImGui.Begin("Inspector"))
            {
            }

            ImGui.End();
        }

        /// <summary>Gets the name.</summary>
        /// <returns>Return name widget</returns>
        public override string GetName()
        {
            return Name;
        }

        /// <summary>Called when [load].</summary>
        public override void OnLoad()
        {
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
        }
    }
}
