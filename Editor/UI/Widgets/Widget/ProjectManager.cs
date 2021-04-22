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
    using Alis.Core.SFML;
    using Alis.Editor.Utils;
    using Alis.Tools;
    using ImGuiNET;

    /// <summary>Create new project. </summary>
    public class ProjectManager : Widget
    {
        #region General Vars

        private const string nameFileToSave = "ListProjects";

        /// <summary>The name</summary>
        private readonly string name = "Project Manager";

        /// <summary>The is open</summary>
        private bool isOpen;

        /// <summary>The show recent projects</summary>
        private bool showRecentProjects;

        /// <summary>The projects</summary>
        private List<Project> projects;

        #endregion

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

        private FileDialog fileDialog;

        private FileDialog directoryDialog;

        /// <summary>The name field</summary>
        private string nameField = "AlysProject";

        /// <summary>The directory field</summary>
        private string directoryField = Application.DesktopFolder;

        /// <summary>The modes</summary>
        private string[] modes = new string[] { "2D Videogame SFML-Alis" };

        /// <summary>The current mode</summary>
        private string currentMode = "2D Videogame SFML-Alis";

        /// <summary>The selected</summary>
        private bool selected = true;

        #endregion

        #region Colors

        /// <summary>The red color</summary>
        private Vector4 redColor = new Vector4(0.654f, 0.070f, 0.070f, 1.000f);

        /// <summary>The white color</summary>
        private Vector4 whiteColor = new Vector4(1, 1, 1, 1);

        /// <summary>The child background</summary>
        private Vector4 childBackground = new Vector4(0, 0, 0, 0);

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="ProjectManager" /> class.</summary>
        /// <param name="showRecentProjects">show this</param>
        public ProjectManager(bool showRecentProjects)
        {
            isOpen = true;
            this.showRecentProjects = showRecentProjects;
            projects = LocalData.Load(nameFileToSave, new List<Project>());


            fileDialog = new FileDialog(Environment.CurrentDirectory, true, ".json", new string[] { "*", ".json" });
            directoryDialog = new FileDialog(Environment.CurrentDirectory, false, "*", new string[] { "*"});

            Logger.Info();
        }

        #endregion

        #region Draw

        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            if (fileDialog.ConfirmedElement)
            {
                Console.Log(Path.GetFileNameWithoutExtension(fileDialog.ElementTaked));
                Console.Log(Path.GetDirectoryName(fileDialog.ElementTaked));

                string nameTemp = Path.GetFileNameWithoutExtension(fileDialog.ElementTaked);
                string pathTemp = Path.GetDirectoryName(fileDialog.ElementTaked);
                
                Project project = LocalData.Load<Project>(nameTemp, pathTemp);
                if (project != null) 
                {
                    if (projects.Find(i => i.Name.Equals(project.Name) && i.Directory.Equals(project.Directory)) != null)
                    {
                        Console.Error("Project alredy exits.");
                    }
                    else 
                    {
                        pathTemp = Directory.GetParent(pathTemp).ToString();
                        Console.Log(pathTemp);

                        Console.Warning("Try to load " + project.Directory + "/" + project.Name);

                        if (!Directory.Exists(project.Directory + "/" + project.Name))
                        {
                            string nameProject = project.Name;
                            project = new Project(nameProject,  pathTemp);
                            LocalData.Save<Project>("Project", project.Directory + "/" + project.Name, project);
                        }

                        projects.Add(project);
                        LocalData.Save(nameFileToSave, projects);
                        Project.Set(project);

                        Console.Log("Data file on " + project.DataPath1 + "/Data.json");

                        Project.VideoGame = LocalData.Load<VideoGame>("Data", project.DataPath1);

                        Console.Warning("Loaded project: " + project.Name);
                        Console.Warning("Loaded VIDEOGAME: " + Project.VideoGame.Config.Name);
                       
                        Close();
                    }
                }
            }

            if (directoryDialog.ConfirmedElement) 
            {
                directoryField = directoryDialog.ElementTaked;
                Console.Warning("Select the direcotry " + directoryDialog.ElementTaked);
            }


            PushStyle();

            ImGui.OpenPopup(name);
            if (ImGui.BeginPopupModal(name, ref isOpen, configPopup))
            {
                if (ImGui.BeginChild("Master", sizeWidget, false))
                {
                    ShowRecentProjects();
                    ShowCreateProject();

                    ImGui.EndChild();
                }
            }

            PopStyle();
        }

        #endregion

        #region Show Recent Projects
        
        private void ShowRecentProjects() 
        {
            if (showRecentProjects)
            {
                ImGui.BeginGroup();
                ImGui.PushStyleColor(ImGuiCol.Border, whiteColor);
                if (ImGui.BeginChild("Master-Child-Left", new Vector2(ImGui.GetContentRegionAvail().X / 3, ImGui.GetContentRegionAvail().Y - 70), true))
                {
                    ImGui.PopStyleColor();

                    ImGui.Text("Recent Projects: ");

                    foreach (Project project in projects.ToList())
                    {
                        ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 7.0f));
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

                    if (ImGui.Button("Open Project", new Vector2(ImGui.GetContentRegionAvail().X / 3, 50.0f)))
                    {
                        OpenProject();
                    }

                    ImGui.EndGroup();
                }

                ImGui.SameLine();
            }
        }

        #endregion

        #region ShowCreateProject

        private void ShowCreateProject()
        {
            ImGui.PushStyleColor(ImGuiCol.Border, whiteColor);
            if (ImGui.BeginChild("Master-Child-Right", new Vector2(ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y), true))
            {
                ImGui.PopStyleColor();

                #region Name project

                ImGui.Text("Name: ");
                ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
                ImGui.InputText("##Name", ref nameField, 256);
                ImGui.PopItemWidth();

                #endregion

                #region Directory select

                ImGui.Text("Directory: ");
                ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 3));
                ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X - 27.0f);
                ImGui.BeginGroup();
                ImGui.InputText("##Path", ref directoryField, 256);
                ImGui.SameLine();

                if (ImGui.Button("...", new Vector2(27.0f)))
                {
                    DirectorySelector();
                }

                ImGui.PopStyleVar();
                ImGui.PopItemWidth();
                ImGui.EndGroup();

                #endregion

                #region Mode Videogame

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

                #endregion

                #region Error Control

                if (Directory.Exists(directoryField + "/" + nameField))
                {
                    ImGui.TextColored(redColor, "The project '" + nameField + "' already exists.");
                }

                if (projects.Find(i => i.Name.Equals(nameField) && i.Directory.Equals(directoryField)) is not null) 
                {
                    ImGui.TextColored(redColor, "The project '" + nameField + "' already exits on the list.");
                }

                #endregion

                #region Cancel Create Project Button

                if (!showRecentProjects)
                {
                    if (ImGui.Button("Cancel ", new Vector2(ImGui.GetContentRegionAvail().X / 2, 50.0f)))
                    {
                        CancelCreateProject();
                    }

                    ImGui.SameLine();
                }

                #endregion

                #region Create Project Button

                if (ImGui.Button("Create Project", new Vector2(ImGui.GetContentRegionAvail().X, 50.0f)))
                {
                    CreateProject(new Project(nameField, directoryField));
                }

                #endregion

                ImGui.EndChild();
            }
        }

        private void DirectorySelector()
        {
            directoryDialog = new FileDialog(Environment.CurrentDirectory, false, "*", new string[] { "*" });
            directoryDialog.OpenDialog();

        }

        #endregion


        private void CreateProject(Project project)
        {
            if (projects.Find(i => i.Name.Equals(project.Name) && i.Directory.Equals(project.Directory)) is null)
            {
                projects.Add(project);
                LocalData.Save(nameFileToSave, projects);

                GenerateFiles(project);


                Console.Log("Created project '" + project.Name + "'on: " + project.Directory);
            }
            else 
            {
                Console.Warning("You can create a project that alredy exits.");
            }
        }

        private void GenerateFiles(Project project)
        {
            string dir = project.Directory + "/" + project.Name;
            Directory.CreateDirectory(dir);
            Directory.CreateDirectory(project.AssetPath);
            Directory.CreateDirectory(project.ConfigPath1);
            Directory.CreateDirectory(project.DataPath1);
            Directory.CreateDirectory(project.LibPath);

            string projectFile = File.ReadAllText(Application.ProjectFolder + "/Resources/DefaultPr.txt", Encoding.UTF8);
            File.WriteAllText(dir + "/" + name + ".csproj", projectFile, Encoding.UTF8);
            Logger.Log("Created .csproj");

            string solutionFile = File.ReadAllText(Application.ProjectFolder + "/Resources/DefaultSl.txt", Encoding.UTF8).Replace("Example", name);
            File.WriteAllText(dir + "/" + name + ".sln", solutionFile, Encoding.UTF8);
            Logger.Log("Created .sln");

            string program = File.ReadAllText(Application.ProjectFolder + "/Resources/Program.txt", Encoding.UTF8);
            File.WriteAllText(dir + "/" + "Program" + ".cs", program, Encoding.UTF8);
            Logger.Log("Created Program.cs");

            File.Copy(Environment.CurrentDirectory + "/Core-SFML.dll", project.LibPath + "/" + "Core-SFML" + ".dll");
            File.Copy(Environment.CurrentDirectory + "/Core.dll", project.LibPath + "/" + "Core" + ".dll");
            File.Copy(Environment.CurrentDirectory + "/Tools.dll", project.LibPath + "/" + "Tools" + ".dll");

            VideoGame game = VideoGame.Builder()
                                            .Config(Config.Builder().Name("Alis Game").Build())
                                            .SceneManager(SceneManager.Builder().Scene(new Scene("Default")).Build())
                                            .Build();

            LocalData.Save("Data", project.DataPath1, game);

            LocalData.Save("Project", dir, project);

            Logger.Log("Saved default game");

            Project.Set(project);
            Project.VideoGame = game;

            Close();
        }

        private void OpenProject()
        {
            Console.Log("OpenProject");

            fileDialog = new FileDialog(Environment.CurrentDirectory, true, ".json" , new string[] { "*", ".json"});

            fileDialog.OpenDialog();

            
        }

        private void OpenProject(Project project) 
        {
            Project temp = projects.Find(i => i.Name.Equals(project.Name) && i.Directory.Equals(project.Directory));
            if (temp != null)
            {
                if (!Directory.Exists(temp.Directory + "/" + temp.Name)) 
                {
                    projects.Remove(temp);
                    LocalData.Save(nameFileToSave, projects);
                    return;
                }

                Project.Set(project);

                Project.VideoGame = LocalData.Load<VideoGame>("Data", project.DataPath1);

                Console.Warning("Loaded project: " + project.Name);
                Console.Warning("Loaded VIDEOGAME: " + Project.VideoGame.Config.Name);

                Close();
            }
        }

        private void CancelCreateProject() 
        {


            Close();
            Console.Log("CancelCreateProject");
        }

        private void DeleteProject(Project project)
        {
            if (projects.Find(i => i.Name.Equals(project.Name) && i.Directory.Equals(project.Directory)) is not null)
            {
                projects.RemoveAt(projects.IndexOf(project));
                LocalData.Save(nameFileToSave, projects);
                Console.Warning("Delete");
            }
        }

        /// <summary>Closes this instance.</summary>
        private void Close()
        {
            isOpen = false;
            WidgetManager.Delete(this);
        }

        /// <summary>Pushes the style.</summary>
        private void PushStyle() 
        {
            ImGui.PushStyleColor(ImGuiCol.ChildBg, childBackground);

            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, itemSpacing);
            ImGui.PushStyleVar(ImGuiStyleVar.ChildBorderSize, childBorderSize);

            ImGui.SetNextWindowPos(new Vector2(ImGui.GetMainViewport().Size.X / 4, ImGui.GetMainViewport().Size.Y / 4));
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
       
            /*if (!Directory.Exists(directory + "/" + name)) 
            {
                string dir = directory + "/" + name;
                string assetPath = directory + "/" + name + "/Assets";
                string configPath = directory + "/" + name + "/Config";
                string dataPath = directory + "/" + name + "/Data";
                string libPath = directory + "/" + name + "/Lib";

                Project project = new Project(name, dir);
                Logger.Log("Create project " + " name: " + name + " directory: " + dir);


                projects.Add(project);
                LocalData.Save<List<Project>>("Projects", projects);
                Logger.Log("Saves the project in file");



                Directory.CreateDirectory(dir);
                Directory.CreateDirectory(assetPath);
                Directory.CreateDirectory(configPath);
                Directory.CreateDirectory(dataPath);
                Directory.CreateDirectory(libPath);

                Logger.Log("Create directorys of project.");

                string projectFile = File.ReadAllText(Application.ProjectFolder + "/Resources/DefaultPr.txt", Encoding.UTF8);
                File.WriteAllText(dir + "/" + name + ".csproj", projectFile, Encoding.UTF8);
                Logger.Log("Created .csproj");

                string solutionFile = File.ReadAllText(Application.ProjectFolder + "/Resources/DefaultSl.txt", Encoding.UTF8).Replace("Example", name);
                File.WriteAllText(dir + "/" + name + ".sln", solutionFile, Encoding.UTF8);
                Logger.Log("Created .sln");

                string program = File.ReadAllText(Application.ProjectFolder + "/Resources/Program.txt", Encoding.UTF8);
                File.WriteAllText(dir + "/" + "Program" + ".cs", program, Encoding.UTF8);
                Logger.Log("Created Program.cs");

                File.Copy(Application.ProjectFolder + "/Resources/Core-SFML.dll", libPath + "/" + "Core-SFML" + ".dll");
                File.Copy(Application.ProjectFolder + "/Resources/Core.dll", libPath + "/" + "Core" + ".dll");
                File.Copy(Application.ProjectFolder + "/Resources/Tools.dll", libPath + "/" + "Tools" + ".dll");
                Logger.Log("Copied .DLLS");

                VideoGame game = VideoGame.Builder()
                                            .Config(Config.Builder().Name(name).Build())
                                            .SceneManager(SceneManager.Builder().Scene(new Scene("Default")).Build())
                                            .Build();

                Logger.Log("Created default game");

                LocalData.Save<VideoGame>("Data", dataPath, game);

                Logger.Log("Saved default game");

                Project.Current = project;
                Project.VideoGame = game;
            }
            */
        

        /// <summary>Opens the project.</summary>
        /// <param name="project">The project.</param>
        /*private void OpenProject(Project project) 
        {
            /*if (Directory.Exists(project.Directory))
            {
                Logger.Warning("Open " + project.Name + project.DataPath + project.Directory + project.AssetsPath + project.ConfigPath + project.LibraryPath);

                Asset.SetWorkPath(project.AssetsPath + "/");

                VideoGame game = LocalData.Load<VideoGame>("Data", project.DataPath, new VideoGame(new Config("default")));

                Logger.Warning("Videogame: " + game.Config.Name);

                //Project.ChangeProject(project, game);
            }
            else 
            {
                DeleteProject(project);
            }*/

        /// <summary>Deletes the project.</summary>
        /// <param name="project">project to delete</param>

           /* List<Project> temp = LocalData.Load<List<Project>>("Projects");

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
            }*/
        
    }

}