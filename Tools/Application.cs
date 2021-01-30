//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Application.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;

    /// <summary>Manage application data.</summary>
    public struct Application
    {
        /// <summary>The name</summary>
        private static string name = "Alis";

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public static string Name 
        {
            get => name;
            set => name = value;
        }

        /// <summary>Gets the desktop path.</summary>
        /// <value>The desktop path.</value>
        public static string DesktopPath 
        {
            get => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        /// <summary>Gets the assets path.</summary>
        /// <value>The assets path.</value>
        public static string AssetsPath 
        { 
            get => Environment.CurrentDirectory + "/Assets/";
        }

        /// <summary>Gets the project path.</summary>
        /// <value>The project path.</value>
        public static string ProjectPath 
        {
            get => Environment.CurrentDirectory;
        }

        /// <summary>Gets the data path.</summary>
        /// <value>The data path.</value>
        public static string DataPath 
        {
            get => Environment.SystemDirectory + "/Data/";
        }
    }
}