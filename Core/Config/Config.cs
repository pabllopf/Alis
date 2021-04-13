//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Config.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Diagnostics.CodeAnalysis;
    using Alis.Tools;
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
        private Time time;

        /// <summary>Initializes a new instance of the <see cref="Config" /> class.</summary>
        /// <param name="name">The name.</param>
        public Config([NotNull] string name)
        {
            this.name = name;
            time = new Time(0.01f, 1.00f, 120.0f, false);
            Logger.Info();
        }

        /// <summary>Initializes a new instance of the <see cref="Config" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="timeManager">The time manager.</param>
        [JsonConstructor]
        public Config([NotNull] string name, [NotNull] Time time)
        {
            this.name = name;
            this.time = time;
            Logger.Warning("Build config with json");
        }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        [NotNull]
        [JsonProperty("_Name")]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets the time manager.</summary>
        /// <value>The time manager.</value>
        [NotNull]
        [JsonProperty("_Time")]
        public Time Time { get => time; set => time = value; }

    }
}