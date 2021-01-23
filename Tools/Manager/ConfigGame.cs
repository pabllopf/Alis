//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="ConfigGame.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    /// <summary>Define a config. </summary>
    public class ConfigGame
    {
        /// <summary>The name project</summary>
        private string nameProject = "DefaultName";

        /// <summary>Initializes a new instance of the <see cref="ConfigGame" /> class.</summary>
        /// <param name="nameProject">The name project.</param>
        public ConfigGame(string nameProject)
        {
            this.nameProject = nameProject;

            Debug.Log("Created a new " + GetType() + ".");
        }

        /// <summary>Gets or sets the name project.</summary>
        /// <value>The name project.</value>
        public string NameProject { get => nameProject; set => nameProject = value; }
    }
}