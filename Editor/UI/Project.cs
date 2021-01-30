using Alis.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Editor.UI
{
    public class Project
    {
        private string name;
        private string directory;
        
        private static Project current;
        private static VideoGame videoGame;

        public Project(string name, string directory)
        {
            this.name = name;
            this.directory = directory;
        }

        public static event EventHandler<bool> OnChangeProject;

        public static Project Current { get => current; set => current = value; }
        
        public static VideoGame VideoGame { get => videoGame; set => videoGame = value; }
        public string Name { get => name; set => name = value; }
        public string Directory { get => directory; set => directory = value; }

        internal static void ChangeProject()
        {
            if (OnChangeProject != null)
            {
                OnChangeProject.Invoke(null, true);
            }
        }
    }
}
