//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Project.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor
{
    using System;
    using System.IO;

    /// <summary>Project define.</summary>
    public class Project
    {
        /// <summary>The name project</summary>
        private string nameProject;

        /// <summary>The path project</summary>
        private string pathProject;

        /// <summary>The type project</summary>
        private TypeProject typeProject;

        /// <summary>Initializes a new instance of the <see cref="Project" /> class.</summary>
        /// <param name="nameProject"></param>
        /// <param name="pathProject">The path project.</param>
        /// <param name="typeProject">The type project.</param>
        public Project(string nameProject, string pathProject, TypeProject typeProject) 
        {
            this.nameProject = nameProject;
            this.pathProject = pathProject;
            this.typeProject = typeProject;
        }

        /// <summary>Loads this instance.</summary>
        public void Load() 
        {
        
        }

        /// <summary>Creates this instance.</summary>
        public void Create() 
        {
            if (!Directory.Exists(pathProject)) 
            {
                Directory.CreateDirectory(pathProject);
                Console.WriteLine("New directory for project: " + pathProject);
            }

            string projectFile = pathProject + "/" + nameProject + ".csproj";

            if (!File.Exists(projectFile)) 
            {
                string content = 
                    "<Project Sdk='Microsoft.NET.Sdk'> " +
                    "    < PropertyGroup >  " +
                    "        < OutputType > Exe </ OutputType > " +
                    "        < TargetFramework > netcoreapp3.1 </ TargetFramework > " +
                    "    </ PropertyGroup > " +
                    " </ Project > ";

                File.WriteAllText(path: projectFile, contents: content, System.Text.Encoding.UTF8);
            }


        }
    }
}
