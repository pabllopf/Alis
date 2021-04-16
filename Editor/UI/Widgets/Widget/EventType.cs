//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="EventType.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    /// <summary>Event Type</summary>
    public enum EventType
    {
        /// <summary>Open Console</summary>
        OpenConsole,

        /// <summary>Close Console</summary>
        CloseConsole,

        /// <summary>The exit editor</summary>
        ExitEditor,

        /// <summary>The open creator project</summary>
        OpenCreateProject,

        /// <summary>The close creator project</summary>
        CloseCreateProject,

        /// <summary>The open project</summary>
        OpenProject,

        /// <summary>The close project</summary>
        CloseProject,
    }
}