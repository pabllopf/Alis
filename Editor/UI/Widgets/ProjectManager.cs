//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="ProjectCreator.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Editor.Utils;
    using Alis.Core;
    using ImGuiNET;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Numerics;
    using System.Text;
    using Alis.Tools;
    using System.Linq;

    /// <summary>Create new project. </summary>
    public class ProjectManager : Widget
    {
        /// <summary>The name</summary>
        private readonly string name = "ProjectManager";

        /// <summary>The projects</summary>
        private List<Project> projects;

        /// <summary>The is open</summary>
        private bool isOpen = false;

        /// <summary>The show recent projects</summary>
        private bool showRecentProjects = false;

        /// <summary>The modes</summary>
        private string[] modes = new string[] { "2D Videogame -SFML Core- " };

        /// <summary>The current mode</summary>
        private string currentMode;

        /// <summary>The selected</summary>
        private bool selected;

        /// <summary>The already exist error</summary>
        private bool alreadyExistError;

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        #region Config

        /// <summary>The size widget</summary>
        private Vector2 sizeWidget = new Vector2(640, 280);

        /// <summary>The size child </summary>
        private Vector2 sizeChild = new Vector2(0f, 0f);

        /// <summary>The configuration popup</summary>
        private ImGuiWindowFlags configPopup = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoDecoration;

        /// <summary>The item spacing</summary>
        private Vector2 itemSpacing = new Vector2(8.0f, 8.0f);

        /// <summary>The child border size</summary>
        private float childBorderSize = 2.0f;

        #endregion

        #region Fields

        /// <summary>The name field</summary>
        private string nameField = "AlysProject";

        /// <summary>The directory field</summary>
        private string directoryField = Application.DesktopPath;

        #endregion

        #region Colors

        /// <summary>The red color</summary>
        private Vector4 redColor = new Vector4(0.654f, 0.070f, 0.070f, 1.000f);

        /// <summary>The white color</summary>
        private Vector4 whiteColor = new Vector4(1, 1, 1, 1);

        /// <summary>The child background</summary>
        private Vector4 childBackground = new Vector4(0, 0, 0, 0);

        #endregion

        /// <summary>Initializes a new instance of the <see cref="ProjectManager" /> class.</summary>
        public ProjectManager(EventHandler<EventType> eventHandler, bool showRecentProjects)
        {
            this.eventHandler = eventHandler;
            this.isOpen = true;
            this.currentMode = modes[0];
            this.showRecentProjects = showRecentProjects;

            this.projects = LocalData.Load<List<Project>>("Projects");
            if (projects == null) 
            {
                projects = new List<Project>();
            }
        }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        public string Name => name;

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
            Debug.Log(this.GetType() + ":Open");
            isOpen = true;
        }

        /// <summary>Close this instance.</summary>
        public override void Close()
        {
            Debug.Log(this.GetType() + ":Close");
            isOpen = false;
        }

        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            if (isOpen)
            {
                PushStyle();

                ImGui.OpenPopup(name);
                if (ImGui.BeginPopupModal(name, ref isOpen, configPopup))
                {
                    if (ImGui.BeginChild("Master", sizeWidget, false))
                    {
                        sizeChild.X = ImGui.GetContentRegionAvail().X / 3;
                        sizeChild.Y = ImGui.GetContentRegionAvail().Y;

                        if (showRecentProjects && projects.Count > 0)
                        {
                            ImGui.PushStyleColor(ImGuiCol.Border, whiteColor);
                            if (ImGui.BeginChild("Master-Child-Left", sizeChild, true))
                            {
                                ImGui.PopStyleColor();

                                foreach (Project project in projects)
                                {
                                    ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(0, 7.0f));
                                    ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 0.0f);
                                    ImGui.BeginGroup();

                                    if (ImGui.Button(project.Name, new Vector2(ImGui.GetContentRegionAvail().X - 30.0f, 30.0f)))
                                    {
                                        OpenProject(project);
                                    }

                                    ImGui.SameLine();

                                    if (ImGui.Button(Icon.TIMESCIRCLEO, new Vector2(30.0f, 30.0f)))
                                    {
                                        DeleteProject(projects.IndexOf(project));
                                    }

                                    ImGui.EndGroup();
                                    ImGui.PopStyleVar(2);
                                }


                                ImGui.EndChild();
                               
                            }

                            ImGui.SameLine();
                        }


                        ImGui.PushStyleColor(ImGuiCol.Border, whiteColor);
                        if (ImGui.BeginChild("Master-Child-Right", new Vector2(ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y), true))
                        {
                            ImGui.PopStyleColor();

                            ImGui.Text("Name: ");
                            ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
                            ImGui.InputText("##Name", ref nameField, 256);
                            ImGui.PopItemWidth();

                            ImGui.Text("Directory: ");
                            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 3));
                            ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X - 27.0f);
                            ImGui.BeginGroup();
                            ImGui.InputText("##Path", ref directoryField, 256);
                            ImGui.SameLine();
                            if (ImGui.Button("...", new Vector2(27.0f)))
                            {
                            }
                            ImGui.PopStyleVar();
                            ImGui.PopItemWidth();
                            ImGui.EndGroup();

                            ImGui.Text("Solution: ");
                            ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
                            if (ImGui.BeginCombo("##Mode", currentMode))
                            {
                                for (int n = 0; n < modes.Length; n++)
                                {
                                    selected = (currentMode == modes[n]);
                                    if (ImGui.Selectable(modes[n], selected))
                                    {
                                        currentMode = modes[n];
                                    }

                                    if (selected)
                                    {
                                        ImGui.SetItemDefaultFocus();
                                    }
                                }
                                ImGui.EndCombo();
                            }
                            ImGui.PopItemWidth();

                            if (Directory.Exists(directoryField + "/" + nameField))
                            {
                                ImGui.TextColored(redColor, "The project '" + nameField + "' already exists.");
                            }

                            sizeChild.X = ImGui.GetContentRegionAvail().X;
                            sizeChild.Y = 50.0f;

                            if (ImGui.Button("Create", sizeChild))
                            {
                                CreateProject(nameField, directoryField, currentMode);
                            }

                            ImGui.EndChild();
                        }
                    }

                    ImGui.EndChild();
                }
                
                PopStyle();
            }
            else
            {
                eventHandler?.Invoke(this, EventType.CloseCreatorProject);
            }
        }

        /// <summary>Pushes the style.</summary>
        private void PushStyle() 
        {
            ImGui.PushStyleColor(ImGuiCol.ChildBg, childBackground);

            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, itemSpacing);
            ImGui.PushStyleVar(ImGuiStyleVar.ChildBorderSize, childBorderSize);
        }

        /// <summary>Pops the style.</summary>
        private void PopStyle() 
        {
            ImGui.PopStyleColor();
            ImGui.PopStyleVar(2);
        }

        /// <summary>Creates the project.</summary>
        /// <param name="name">name project</param>
        /// <param name="directory">directory project</param>
        /// <param name="mode">mode project</param>
        private void CreateProject(string name, string directory, string mode) 
        {
            if (!Directory.Exists(directoryField + "/" + nameField))
            {
                List<Project> temp = LocalData.Load<List<Project>>("Projects");

                if (temp == null)
                {
                    temp = new List<Project>();
                }

                if (!temp.Any(i => (i.Directory + "/" + i.Name).Equals(directory + "/" + name)))
                {
                    Project.Current = new Project(name, directoryField);
                    projects.Add(Project.Current);
                    LocalData.Save<List<Project>>("Projects", projects);
                    Debug.Log(this.GetType() + ":CreateProject");
                    Console.Current.Log("Created: " + Project.Current.Name);

                    Directory.CreateDirectory(directory + "/" + name);
                    Directory.CreateDirectory(directory + "/" + name + "/Assets");
                    Directory.CreateDirectory(directory + "/" + name + "/Config");
                    Directory.CreateDirectory(directory + "/" + name + "/Lib");
                    Directory.CreateDirectory(directory + "/" + name + "/Data");

                    string content = File.ReadAllText(Application.ProjectPath + "/Resources/DefaultPr.txt", Encoding.UTF8);
                    File.WriteAllText(directory + "/" + name + "/" + name + ".csproj", content, Encoding.UTF8);

                    content = File.ReadAllText(Application.ProjectPath + "/Resources/DefaultSl.txt", Encoding.UTF8);
                    content = content.Replace("Example", name);
                    File.WriteAllText(directory + "/" + name + "/" + name + ".sln", content, Encoding.UTF8);

                    Project.ChangeProject();

                    

                    Close();
                }
            }
        }

        /// <summary>Opens the project.</summary>
        /// <param name="project">The project.</param>
        private void OpenProject(Project project) 
        {
            Debug.Warning("project.PathProject:" + project.Directory);
            if (Directory.Exists(project.Directory))
            {
                Project.Current = project;
                Project.ChangeProject();
                Console.Current.Log("Open: " + project.Name);
                Close();
                Debug.Log(this.GetType() + ":OpenProject");
            }
            else 
            {
                DeleteProject(projects.IndexOf(project));
            }
        }

        /// <summary>Deletes the project.</summary>
        /// <param name="project">The project.</param>
        private void DeleteProject(int index) 
        {
            List<Project> temp = LocalData.Load<List<Project>>("Projects");
            if (temp == null)
            {
                temp = new List<Project>();
            }

            if (temp[index] != null) 
            {
                temp.RemoveAt(index);
                LocalData.Save("Projects", temp);
                projects = temp;
            }

            Debug.Log(this.GetType() + ":DeleteProject");
        }
    }
}
        
        /*/// <summary>The name</summary>
        private readonly string name = "ProjectManager";

        /// <summary>The is open</summary>
        private bool isOpen = true;

        /// <summary>The is select2 d</summary>
        private bool isSelect2D = false;

        private string[] modes = new string[] { "2D Videogame -SFML Core- " };

        /// <summary>The item space</summary>
        private Vector2 itemSpace = new Vector2(-10.0f, 3.0f);

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        /// <summary>The red color</summary>
        private System.Numerics.Vector4 redColor = new System.Numerics.Vector4(0.654f, 0.070f, 0.070f, 1.000f);

        private string nameBuffer;

        /// <summary>The buffer</summary>
        private string pathBuffer;

        private Vector2 sizeMasterChild = new Vector2(640, 280);
        private Vector2 sizeChildLeft = new Vector2();
        private Vector2 sizeChildRight = new Vector2();

        private Vector2 createButton = new Vector2();

        List<Project> lastProjects;

        private bool messageError = false;

        bool isOpenNewProject;
        bool isCreateNewProject;
        bool isFirstOpen;

        /// <summary>Initializes a new instance of the <see cref="ProjectManager" /> class.</summary>
        public ProjectManager(EventHandler<EventType> eventHandler, bool isOpenNewProject, bool isCreateNewProject, bool isFirstOpen)
        {
            this.eventHandler = eventHandler;

            nameBuffer = "AlysProject";
            pathBuffer = Application.DesktopPath.Replace("\\", "/");

            current_item = modes[0];

            lastProjects = LocalData.Load<List<Project>>("Projects");

            if (lastProjects == null)
            {
                lastProjects = new List<Project>();
                LocalData.Save<List<Project>>("Projects", lastProjects);
            }



            List<Project> temp = new List<Project>();
            foreach (Project project in lastProjects) 
            {
                if (Directory.Exists(project.PathProject)) 
                {
                    temp.Add(project);
                }
            }

            lastProjects = temp;

            LocalData.Save<List<Project>>("Projects", temp);

            if (lastProjects != null)
            {
                if (lastProjects.Count > 0) 
                {
                    showLastProjects = true;
                }
               
            }

            this.isOpenNewProject = isOpenNewProject;
            this.isCreateNewProject = isCreateNewProject;
            this.isFirstOpen = isFirstOpen;
        }

        /// <summary>Load this instance.</summary>
        public override void OnLoad()
        {
            
        }

        
        string current_item = null;


        private bool state;

        private string contentDir;
        private bool showLastProjects = false;


        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            if (!isOpen)
            {
                eventHandler?.Invoke(this, EventType.CloseCreatorProject);
                return;
            }

            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(8.0f));
            ImGui.PushStyleColor(ImGuiCol.ChildBg, new Vector4(0,0,0,0));
            ImGui.PushStyleVar(ImGuiStyleVar.ChildBorderSize, 2.0f);

            string name = isCreateNewProject ? "Create Project" : "Project";

            if (isOpen)
            {
                ImGui.OpenPopup(name);
            }

            

            if (ImGui.BeginPopupModal(name, ref isOpen, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoDecoration))
            {

                if (ImGui.BeginChild("Master", sizeMasterChild, false))
                {
                    if (showLastProjects && isFirstOpen)
                    {
                        ImGui.PushStyleColor(ImGuiCol.Border, new Vector4(1, 1, 1, 1));
                        if (ImGui.BeginChild("Last Projetcs", new Vector2(ImGui.GetContentRegionAvail().X / 3, ImGui.GetContentRegionAvail().Y), true))
                        {
                            ImGui.PopStyleColor();

                            ImGui.Text("Recent Projects: ");

                            foreach (Project project in lastProjects)
                            {
                                if (Directory.Exists(project.PathProject) && Directory.Exists(project.AssetsProject) && Directory.Exists(project.ConfigPathProject))
                                {
                                    ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(0, 7.0f));
                                    ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 0.0f);
                                    ImGui.BeginGroup();

                                    if (ImGui.Button(project.NameProject, new Vector2(ImGui.GetContentRegionAvail().X - 30.0f, 30.0f)))
                                    {

                                        OpenProject(project);

                                    }


                                    ImGui.SameLine();

                                    if (ImGui.Button(Icon.TIMESCIRCLEO, new Vector2(30.0f, 30.0f)))
                                    {
                                        DeleteProject(lastProjects.IndexOf(project));
                                    }

                                    ImGui.EndGroup();
                                    ImGui.PopStyleVar(2);
                                }
                            }
                        }

                        ImGui.EndChild();

                        

                        ImGui.SameLine();
                    }

                    ImGui.PushStyleColor(ImGuiCol.Border, new Vector4(1, 1, 1, 1));
                    if (ImGui.BeginChild("Create Project", new Vector2(ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y), true))
                    {
                        ImGui.PopStyleColor();

                        ImGui.Text("Name: ");
                        ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
                        ImGui.InputText("##Name", ref nameBuffer, 256);
                        ImGui.PopItemWidth();



                        ImGui.Text("Location: ");
                        ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 3));
                        ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X - 27.0f);
                        ImGui.BeginGroup();
                        ImGui.InputText("##Path", ref pathBuffer, 256);
                        ImGui.SameLine();
                        createButton.X = 27.0f;
                        createButton.Y = 27.0f;
                        if (ImGui.Button("...", createButton))
                        {
                        }
                        ImGui.PopStyleVar();
                        ImGui.PopItemWidth();
                        ImGui.EndGroup();




                        ImGui.Text("Solution: ");
                        ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
                        if (ImGui.BeginCombo("##Mode", current_item))
                        {
                            for (int n = 0; n < modes.Length; n++)
                            {
                                bool is_selected = (current_item == modes[n]);
                                if (ImGui.Selectable(modes[n], is_selected))
                                {
                                    current_item = modes[n];
                                }

                                if (is_selected)
                                {
                                    ImGui.SetItemDefaultFocus();
                                }
                            }
                            ImGui.EndCombo();
                        }
                        ImGui.PopItemWidth();

                        if (messageError) 
                        {
                            ImGui.TextColored(redColor, "The project '" + nameBuffer + "' already exists.");
                        }

                        createButton.X = sizeMasterChild.X;
                        createButton.Y = 45.0f;

                        

                        float sixeX = isCreateNewProject ? ImGui.GetContentRegionAvail().X / 2 : ImGui.GetContentRegionAvail().X;

                        if (ImGui.Button("Create", new Vector2(sixeX, createButton.Y)))
                        {
                            CreateProject(nameBuffer, pathBuffer, current_item);
                        }

                        if (isCreateNewProject)
                        {
                            ImGui.SameLine();

                            if (ImGui.Button("Cancel", new Vector2(ImGui.GetContentRegionAvail().X, createButton.Y)))
                            {
                                Close();
                            }

                            
                        }


                    }

                    ImGui.EndChild();
                }

                ImGui.EndChild();
            }
            ImGui.EndPopup();

            ImGui.PopStyleVar(2);
            ImGui.PopStyleColor();
        }

        private void DeleteProject(int index)
        {
            List<Project> temp = LocalData.Load<List<Project>>("Projects");
            temp.RemoveAt(index);
            LocalData.Save<List<Project>>("Projects", temp);

            lastProjects = LocalData.Load<List<Project>>("Projects");

            if (lastProjects.Count <= 0) 
            {
                showLastProjects = false;
            }
        }

        private void OpenProject(Project project)
        {

            Project.AssetsPath = project.AssetsProject;
            Project.Name = project.NameProject;
            Project.CurrentPath = project.PathProject;
            Project.ConfigPath = project.ConfigPathProject;

            Console.Current.Log("Open Project: '" + Project.Name + "' at: " + Project.CurrentPath);
            Project.ChangeProject();
            Close();
        }

        private void CreateProject(string name, string directory, string current_item)
        {
            if (Directory.Exists(directory + "/" + name))
            {
                Debug.Error("The project(" + directory + "/" + name + ") already exists.");
                messageError = true;
            }
            else 
            {
                Directory.CreateDirectory(directory + "/" + name);
                Directory.CreateDirectory(directory + "/" + name + "/Assets");
                Directory.CreateDirectory(directory + "/" + name + "/Config");

                string content = File.ReadAllText(Application.ProjectPath + "/Resources/DefaultPr.txt", Encoding.UTF8);
                File.WriteAllText(directory + "/" + name + "/" + name + ".csproj", content, Encoding.UTF8);

                content = File.ReadAllText(Application.ProjectPath + "/Resources/DefaultSl.txt", Encoding.UTF8);
                content = content.Replace("Example", name);
                File.WriteAllText(directory + "/" + name + "/" + name + ".sln", content, Encoding.UTF8);

                Project.AssetsPath = directory + "/" + name + "/Assets";
                Project.Name = name;
                Project.CurrentPath = directory + "/" + name;
                Project.ConfigPath = directory + "/" + name + "/Config";

                Project project = new Project(name, directory + "/" + name, directory + "/" + name + "/Assets", directory + "/" + name + "/Config");

                List<Project> projects = LocalData.Load<List<Project>>("Projects");
                if (projects == null) 
                {
                    projects = new List<Project>();
                }

                projects.Add(project);

                LocalData.Save<List<Project>>("Projects", projects);

                Project.ChangeProject();

                Close();
            }
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
            isOpen = true;
        }

        /// <summary>Close this instance.</summary>
        public override void Close()
        {
            isOpen = false;
        }

        /// <summary>Gets the name.</summary>
        /// <returns>Return name widget</returns>
        public override string GetName()
        {
            return name;
        }
    }
}*/
