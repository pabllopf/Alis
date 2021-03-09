//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Level.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    /// <summary>Define level of the logs</summary>
    internal enum Level
    {
        /// <summary>Include file options</summary>
        Verbose,

        /// <summary>The information</summary>
        Info,

        /// <summary>The normal log</summary>
        Normal,

        /// <summary>The critical</summary>
        Critical,
    }
}