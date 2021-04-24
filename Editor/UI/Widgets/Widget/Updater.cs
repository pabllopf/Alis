//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Updater.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System;
    using ImGuiNET;
    using Alis.Tools;

    /// <summary>Show the game running</summary>
    public class Updater : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "Updater";

        /// <summary>The is open</summary>
        private bool isOpen = true;

        /// <summary>Initializes a new instance of the <see cref="Updater" /> class.</summary>
        public Updater()
        {
            Logger.Info();
        }

        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            if (ImGui.Begin(Name, ref isOpen))
            {
            }

            ImGui.End();
        }
    }
}