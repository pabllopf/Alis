//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Config.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using Newtonsoft.Json;
    using System.Diagnostics;

    /// <summary>Define a config. </summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Config
    {
        /// <summary>
        /// The name proyect
        /// </summary>
        private string name = "DefaultName";

        /// <summary>Initializes a new instance of the <see cref="Config" /> class.</summary>
        /// <param name="name">The name of videogame.</param>
        [JsonConstructor()]
        public Config(string name)
        {
            this.name = name;
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get => name; set => name = value; }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Return message</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}