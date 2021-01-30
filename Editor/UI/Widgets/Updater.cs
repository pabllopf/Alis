//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Updater.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System;
    using Alis.Core;
    using ImGuiNET;

    /// <summary>Show the game running</summary>
    public class Updater : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "Updater";

        /// <summary>The is open</summary>
        private bool isOpen = true;

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        /// <summary>Initializes a new instance of the <see cref="Updater" /> class.</summary>
        /// <param name="eventHandler">The event handler.</param>
        public Updater(EventHandler<EventType> eventHandler)
        {
            this.eventHandler = eventHandler;
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