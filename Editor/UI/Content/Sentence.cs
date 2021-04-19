//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Sentence.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI
{
    /// <summary>Define reference text key. </summary>
    public enum Sentence
    {
        /// <summary>Creates new project.</summary>
        NewProject = 0,

        /// <summary>The open project</summary>
        OpenProject = 1,

        /// <summary>The save project</summary>
        SaveProject = 2,

        /// <summary>The automatic save</summary>
        AutoSave = 3,

        /// <summary>The build settings</summary>
        BuildSettings = 4,

        /// <summary>The build and run</summary>
        BuildAndRun = 5,

        /// <summary>The exit</summary>
        Exit = 6,

        /// <summary>The message save game</summary>
        MessageSaveGame = 7,

        /// <summary>The message exit</summary>
        MessageExit = 8,

        /// <summary>The yes</summary>
        Yes = 9,

        /// <summary>The no</summary>
        No = 10,
    }
}