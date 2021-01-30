//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="About.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Editor.Utils;
    using Alis.Core;
    using ImGuiNET;
    using System;

    /// <summary>Show the game running</summary>
    public class About : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "About";

        /// <summary>The is open</summary>
        private bool isOpen = true;

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        /// <summary>Initializes a new instance of the <see cref="About" /> class.</summary>
        /// <param name="eventHandler">The event handler.</param>
        public About(EventHandler<EventType> eventHandler)
        {
            this.eventHandler = eventHandler;
        }

        /// <summary>Load this instance.</summary>
        public override void OnLoad()
        {
            Debug.Log("Game view loaded");
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
            Debug.Log("Game view Opened");
            isOpen = true;
        }

        /// <summary>Close this instance.</summary>
        public override void Close()
        {
            Debug.Log("Game view closed");
            isOpen = false;
        }

        /// <summary>Gets the name.</summary>
        /// <returns>Return name widget</returns>
        public override string GetName()
        {
            return Name;
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
