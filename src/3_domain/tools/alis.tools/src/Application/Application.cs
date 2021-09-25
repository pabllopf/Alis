//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Application.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;

    /// <summary>Manage application data.</summary>
    public static class Application
    {
        /// <summary>Gets the desktop path.</summary>
        /// <value>The desktop path.</value>
        public static string DesktopFolder => Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Replace("\\", "/");

        /// <summary>Gets the documents path.</summary>
        /// <value>The documents path.</value>
        public static string DocumentsFolder => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Replace("\\", "/");

        /// <summary>Gets the assets path.</summary>
        /// <value>The assets path.</value>
        public static string AssetsFolder => (Environment.CurrentDirectory + "/Assets").Replace("\\", "/");

        /// <summary>Gets the project path.</summary>
        /// <value>The project path.</value>
        public static string ProjectFolder => Environment.CurrentDirectory.Replace("\\", "/");

        /// <summary>Gets the data path.</summary>
        /// <value>The data path.</value>
        public static string PersistenceDataFolder => (Environment.SystemDirectory + "/Data").Replace("\\", "/");

        /// <summary>Gets the temporary data folder.</summary>
        /// <value>The temporary data folder.</value>
        public static string TempDataFolder => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("\\", "/");
    }
}