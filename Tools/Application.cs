//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Application.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Tools
{
    using System;

    /// <summary>Application definitions. </summary>
    public class Application
    {
        /// <summary>Gets the assets path.</summary>
        /// <value>The assets path.</value>
        public static string AssetsPath 
        { 
            get => Environment.SystemDirectory;
        }
    }
}