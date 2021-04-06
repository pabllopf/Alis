//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Config.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;
    
    /// <summary>Define the config of videogame</summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Config 
    {
        /// <summary>The name</summary>
        [NotNull]      
        private string name;

        /// <summary>The time manager</summary>
        [NotNull]
        private Time timeManager;

        /// <summary>Initializes a new instance of the <see cref="Config" /> class.</summary>
        /// <param name="name">The name.</param>
        public Config([NotNull] string name)
        {
            this.name = name;
            timeManager = new Time(0.01f, 1.00f, 60.0f, false);
        }

        /// <summary>Initializes a new instance of the <see cref="Config" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="timeManager">The time manager.</param>
        [JsonConstructor]
        public Config([NotNull] string name, [NotNull] Time timeManager)
        {
            this.name = name;
            this.timeManager = timeManager;
        }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        [NotNull]
        [JsonProperty("_Name")]
        public string Name { get => name; }

        /// <summary>Gets the time manager.</summary>
        /// <value>The time manager.</value>
        [NotNull]
        [JsonProperty("_TimeManager")]
        public Time TimeManager { get => timeManager; }
    }
}