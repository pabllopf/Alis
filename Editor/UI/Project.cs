using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Editor.UI
{
    public class Project
    {
        private string pathProject = string.Empty;

        private string assetsProject = string.Empty;

        private string nameProject = string.Empty;

        private string configPathProject = string.Empty;


        public static event EventHandler<bool> OnChangeProject;

        private static string currentPath = string.Empty;

        private static string assetsPath = string.Empty;

        private static string name = string.Empty;

        private static string configPath = string.Empty;

        public Project(string nameProject, string pathProject, string assetsProject, string configPathProject)
        {
            this.pathProject = pathProject;
            this.assetsProject = assetsProject;
            this.nameProject = nameProject;
            this.configPathProject = configPathProject;
        }

        public static string CurrentPath { get => currentPath; set => currentPath = value; }
        
        public static string AssetsPath { get => assetsPath; set => assetsPath = value; }
        public static string Name { get => name; set => name = value; }
        public static string ConfigPath { get => configPath; set => configPath = value; }
        public string PathProject { get => pathProject; set => pathProject = value; }
        public string AssetsProject { get => assetsProject; set => assetsProject = value; }
        public string NameProject { get => nameProject; set => nameProject = value; }
        public string ConfigPathProject { get => configPathProject; set => configPathProject = value; }

        internal static void ChangeProject()
        {
            if (OnChangeProject != null)
            {
                OnChangeProject.Invoke(null, true);
            }
        }
    }
}
