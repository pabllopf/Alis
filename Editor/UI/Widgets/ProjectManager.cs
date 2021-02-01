//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="ProjectManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using Alis.Core;
    using Alis.Editor.Utils;
    using Alis.Tools;
    using ImGuiNET;

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
        /// <param name="eventHandler">Controller event</param>
        /// <param name="showRecentProjects">show this</param>
        public ProjectManager(EventHandler<EventType> eventHandler, bool showRecentProjects)
        {
            this.eventHandler = eventHandler;
            isOpen = true;
            currentMode = modes[0];
            this.showRecentProjects = showRecentProjects;

            projects = LocalData.Load<List<Project>>("Projects");
            if (projects == null) 
            {
                projects = new List<Project>();
            }

            Project.OnChangeProject += Project_OnChangeProject;
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

                ImGui.SetNextWindowPos(new Vector2(ImGui.GetMainViewport().Size.X / 4, ImGui.GetMainViewport().Size.Y / 4));
                ImGui.OpenPopup(name);
                if (ImGui.BeginPopupModal(name, ref isOpen, configPopup))
                {
                    if (ImGui.BeginChild("Master", sizeWidget, false))
                    {
                        sizeChild.X = ImGui.GetContentRegionAvail().X / 3;
                        sizeChild.Y = ImGui.GetContentRegionAvail().Y - 70;

                        if (showRecentProjects)
                        {
                            ImGui.BeginGroup();
                            ImGui.PushStyleColor(ImGuiCol.Border, whiteColor);
                            if (ImGui.BeginChild("Master-Child-Left", sizeChild, true))
                            {
                                ImGui.PopStyleColor();

                                ImGui.Text("Recent Projects: ");

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

                                    if (ImGui.Button(Icon.TIMESCIRCLEO + "##" + projects.IndexOf(project), new Vector2(30.0f, 30.0f)))
                                    {
                                        DeleteProject(project);
                                    }

                                    ImGui.EndGroup();
                                    ImGui.PopStyleVar(2);
                                }

                                ImGui.EndChild();

                                sizeChild.Y = 50.0f;

                                if (ImGui.Button("Open Project", sizeChild)) 
                                {
                                }

                                ImGui.EndGroup();
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
                                    selected = currentMode == modes[n];
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

                            if (!showRecentProjects) 
                            {
                                if (ImGui.Button("Cancel ", new Vector2(ImGui.GetContentRegionAvail().X / 2, 50.0f)))
                                {
                                    Close();
                                }

                                ImGui.SameLine();
                            }
                            

                            if (ImGui.Button("Create Project", new Vector2(ImGui.GetContentRegionAvail().X, 50.0f)))
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
                eventHandler?.Invoke(this, EventType.CloseCreateProject);
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
                    string dir = directory + "/" + name;
                    string assetPath = directory + "/" + name + "/Assets";
                    string configPath = directory + "/" + name + "/Config";
                    string dataPath = directory + "/" + name + "/Data";
                    string libPath = directory + "/" + name + "/Lib";

                    Project project = new Project(name, dir, assetPath, configPath, dataPath, libPath);
                    Debug.Warning("Project: " + name + " at " + dir);

                    projects.Add(project);
                    LocalData.Save<List<Project>>("Projects", projects);

                    Directory.CreateDirectory(dir);
                    Directory.CreateDirectory(assetPath);
                    Directory.CreateDirectory(configPath);
                    Directory.CreateDirectory(dataPath);
                    Directory.CreateDirectory(libPath);

                    string projectFile = File.ReadAllText(Application.ProjectPath + "/Resources/DefaultPr.txt", Encoding.UTF8);
                    File.WriteAllText(dir + "/" + name + ".csproj", projectFile, Encoding.UTF8);

                    string solutionFile = File.ReadAllText(Application.ProjectPath + "/Resources/DefaultSl.txt", Encoding.UTF8).Replace("Example", name);
                    File.WriteAllText(dir + "/" + name + ".sln", solutionFile, Encoding.UTF8);

                    string program = File.ReadAllText(Application.ProjectPath + "/Resources/Program.txt", Encoding.UTF8);
                    File.WriteAllText(dir + "/" + "Program" + ".cs", program, Encoding.UTF8);


                    File.Copy(Application.ProjectPath + "/Resources/Core.dll", libPath + "/" + "Core" + ".dll");
                    File.Copy(Application.ProjectPath + "/Resources/Tools.dll", libPath + "/" + "Tools" + ".dll");

                    VideoGame game = new VideoGame(new ConfigGame(name));
                    LocalData.Save<VideoGame>("Data", dataPath, game);

                    Project.ChangeProject(project, game);

                    LocalData.Save<Project>(name, dir, project);

                    Close();
                }
            }
        }

        /// <summary>Opens the project.</summary>
        /// <param name="project">The project.</param>
        private void OpenProject(Project project) 
        {
            if (Directory.Exists(project.Directory))
            {
                Debug.Warning("Open " + project.Name + project.DataPath + project.Directory + project.AssetsPath + project.ConfigPath + project.LibraryPath);

                VideoGame game = LocalData.Load<VideoGame>("Data", project.DataPath);

                Debug.Warning("Videogame: " + game.Config.NameProject);

                Project.ChangeProject(project, game);
                Close();
            }
            else 
            {
                DeleteProject(project);
            }
        }

        /// <summary>Deletes the project.</summary>
        /// <param name="project">project to delete</param>
        private void DeleteProject(Project project) 
        {
            List<Project> temp = LocalData.Load<List<Project>>("Projects");

            if (temp == null)
            {
                temp = new List<Project>();
            }

            Project projectDelete = temp.Find(i => i.Name.Equals(project.Name));
            if (projectDelete != null) 
            {
                temp.Remove(projectDelete);
                LocalData.Save("Projects", temp);
                projects = temp;
            }
        }

        /// <summary>Projects the on change project.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Project_OnChangeProject(object sender, bool e)
        {
            Console.Current.Log("Open " + Project.Current.Name + " at " + Project.Current.Directory);
            Debug.Log("EVENT: project " + Project.Current.Name + " at " + Project.Current.Directory);
        }
    }
}