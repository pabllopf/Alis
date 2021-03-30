//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Config.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
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
        private TimeManager timeManager;

        /// <summary>Initializes a new instance of the <see cref="Config" /> class.</summary>
        /// <param name="name">The name of videogame.</param>
        [JsonConstructor]
        public Config([NotNull] string name)
        {
            this.name = name;
            timeManager = new TimeManager(0.01f, 0.03f, 1.00f, 30.00f, 120.00f);

            OnCreate += Config_OnCreate;
            OnDestroy += Config_OnDestroy;
            OnChangeName += Config_OnChangeName;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Finalizes an instance of the <see cref="Config" /> class.</summary>
        ~Config() => OnDestroy?.Invoke(null, true);

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnCreate;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnDestroy;

        /// <summary>Occurs when [on change name].</summary>
        public event EventHandler<bool> OnChangeName;

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>  
        [NotNull]
        [JsonProperty("Name")]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnChangeName.Invoke(this, true);
            }
        }

        [NotNull]
        [JsonProperty("TimeManager")]
        public TimeManager TimeManager { get => timeManager; set => timeManager = value; }

        #region Events

        /// <summary>Configurations the on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Config_OnCreate([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Configurations the on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Config_OnDestroy([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Configurations the name of the on change.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Config_OnChangeName([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion
    }
}