//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="ConfigGame.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    /// <summary>Define a config. </summary>
    public class Config
    {
        /// <summary>
        /// The name proyect
        /// </summary>
        private string name = "DefaultName";

        /// <summary>Initializes a new instance of the <see cref="Config" /> class.</summary>
        /// <param name="nameProject">The name project.</param>
        public Config(string nameProject)
        {
            this.name = nameProject;

            Debug.Log("Created a new " + GetType() + ".");
        }

        /// <summary>Gets or sets the name project.</summary>
        /// <value>The name project.</value>
        public string NameProject { get => name; set => name = value; }
    }
}