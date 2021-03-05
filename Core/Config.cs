//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Config.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using Alis.Tools;
    using Newtonsoft.Json;
    
    /// <summary>Define the config of videogame</summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Config 
    {
        /// <summary>The name</summary>
        private string name;

        /// <summary>Initializes a new instance of the <see cref="Config" /> class.</summary>
        /// <param name="name">The name of videogame.</param>
        [JsonConstructor]
        public Config(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));

            OnCreate += Config_OnCreate;
            OnDestroy += Config_OnDestroy;
            OnChangeName += Config_OnChangeName;

            OnCreate?.Invoke(null, true);
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
        [JsonProperty]
        public string Name
        {
            get => name;
            set
            {
                OnChangeName?.Invoke(null, true);
                name = value;
            }
        }

        #region Events

        /// <summary>Configurations the on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Config_OnCreate(object sender, bool e) => Debug.Event(this);

        /// <summary>Configurations the on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Config_OnDestroy(object sender, bool e) => Debug.Event(this);

        /// <summary>Configurations the name of the on change.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Config_OnChangeName(object sender, bool e) => Debug.Event(this);

        #endregion
    }
}