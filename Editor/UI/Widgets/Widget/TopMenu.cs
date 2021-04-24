//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="TopMenu.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Numerics;
    using System.Reflection;
    using System.Runtime.Loader;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Alis.Editor.Utils;
    using Alis.Tools;
    using ImGuiNET;
    using Microsoft.Extensions.DependencyModel;

    /// <summary>
    /// Menu of editor
    /// </summary>
    /// <seealso cref="Alis.Editor.UI.Widgets.Widget" />
    public class TopMenu : Widget
    {
        #region Texts UI

        /// <summary>The new project</summary>
        [NotNull]
        private static string newProject;

        /// <summary>The open project</summary>
        [NotNull]
        private static string openProject;

        /// <summary>The save project</summary>
        [NotNull]
        private static string saveProject;

        /// <summary>The automatic save</summary>
        [NotNull]
        private static string autoSave;

        /// <summary>The build settings</summary>
        [NotNull]
        private static string build;

        /// <summary>The build and run</summary>
        [NotNull]
        private static string buildAndRun;

        /// <summary>The exit</summary>
        [NotNull]
        private static string exit;

        /// <summary>The exit</summary>
        [NotNull]
        private static string messageSaveGame;

        /// <summary>The exit</summary>
        [NotNull]
        private static string messageExit;

        /// <summary>The yes</summary>
        [NotNull]
        private static string yes;

        /// <summary>The no</summary>
        [NotNull]
        private static string no;

        #endregion

        #region State Vars

        /// <summary>The process</summary>
        [NotNull]
        private Process process;

        /// <summary>The start information</summary>
        [NotNull]
        private ProcessStartInfo startInfo;

        /// <summary>The information</summary>
        [NotNull]
        private Info info;

        /// <summary>The time span</summary>
        [NotNull]
        private Stopwatch watch;

        /// <summary>The exit state</summary>
        [NotNull]
        private bool exitState;

        /// <summary>The is autosave active</summary>
        [NotNull]
        private bool autosaveMode;

        /// <summary>The timer automatic save</summary>
        [NotNull]
        private int timerAutoSave;

        /// <summary>The is saved pressed</summary>
        [NotNull]
        private bool aboutState = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TopMenu"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        public TopMenu(Info info)
        {
            this.info = info;

            startInfo = new ProcessStartInfo();
            process = new Process();

            watch = new Stopwatch();
            watch.Start();

            timerAutoSave = 60;

            TextManager.OnChangeIdiom += TextManager_OnChangeIdiom;

            autosaveMode = LocalData.Load("Autosave", false);

            exitState = false;

            LoadTexts();


        }

        #endregion

        #region Draw

        /// <summary>
        /// Draws this instance.
        /// </summary>
        /// <returns>Return none</returns>
        public override void Draw()
        {
            CheckShortCuts();
            CheckIsExit();
            CheckIsAbout();
            CheckAutoSaveMode();

            if (ImGui.BeginMainMenuBar())
            {

                #region File Menu
                
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem(label: newProject, shortcut: "Ctrl+N"))
                    {
                        NewProject();
                    }

                    if (ImGui.MenuItem(label: openProject, shortcut: "Ctrl+O"))
                    {
                        OpenProject();
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(label: saveProject, shortcut: "Ctrl+S"))
                    {
                        SaveProject(true);
                    }

                    if (ImGui.MenuItem(label: autoSave + (autosaveMode ? timerAutoSave - (int)watch.Elapsed.TotalSeconds + "s": ""), "Ctrl+Alt+S", autosaveMode))
                    {
                        AutoSaveProject();
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(build, "Ctrl+B"))
                    {
                        Build();
                    }

                    if (ImGui.MenuItem(buildAndRun, "Ctrl+Alt+B"))
                    {
                        BuildAndRun();
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(exit, "Alt+F4"))
                    {
                        Exit();
                    }

                    ImGui.EndMenu();
                }

                #endregion

                #region Edit Menu

                if (ImGui.BeginMenu("Edit"))
                {
                    if (ImGui.MenuItem(Icon.UNDO + " Undo -SOON-", false))
                    {
                        Cut();
                    }

                    if (ImGui.MenuItem(Icon.REPEAT + " Redo -SOON-", false))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.SCISSORS + " Cut -SOON-", false))
                    {
                    }

                    if (ImGui.MenuItem(Icon.FILESO + " Copy -SOON-", false))
                    {
                    }

                    if (ImGui.MenuItem(Icon.CLIPBOARD + " Paste -SOON-", false))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.WRENCH + " Projects Settings -SOON- ", false))
                    {
                    }

                    if (ImGui.MenuItem(Icon.COG + " Preferences -SOON-", false))
                    {
                    }

                    ImGui.EndMenu();
                }

                #endregion

                #region Tools Menu

                if (ImGui.BeginMenu("Tools"))
                {
                    if (ImGui.MenuItem(Icon.TERMINAL + " Terminal", "Ctrl+T"))
                    {
                        OpenTerminal();
                    }

                    if (ImGui.MenuItem(Icon.LISTALT + " Visual Studio", "Ctrl+Alt+V"))
                    {
                        OpenVisualStudio();
                    }

                    ImGui.EndMenu();
                }

                #endregion

                #region Window Menu

                if (ImGui.BeginMenu("Window"))
                {
                    if (ImGui.BeginMenu(Icon.WINDOWMAXIMIZE + " Layouts"))
                    {
                        if (ImGui.MenuItem("Default"))
                        {
                            DefaultView();
                        }

                        if (ImGui.MenuItem("Tall"))
                        {
                            TallView();
                        }

                        if (ImGui.MenuItem("Wide"))
                        {
                            WideView();
                        }

                        ImGui.EndMenu();
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.ARCHIVE + " Package Manager"))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.BeginMenu(Icon.COGS + " General"))
                    {
                        if (ImGui.MenuItem("Hierarchy"))
                        {
                        }

                        if (ImGui.MenuItem("Scene"))
                        {
                        }

                        if (ImGui.MenuItem("Console"))
                        {
                        }

                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu(Icon.VIDEOCAMERA + " Rendering"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu(Icon.FILM + " Animation"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu(Icon.HEADPHONES + " Audio"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu(Icon.BARCHART + " Analysis"))
                    {
                        ImGui.EndMenu();
                    }

                    ImGui.EndMenu();
                }

                #endregion

                #region Help Menu

                if (ImGui.BeginMenu("Help"))
                {
                    if (ImGui.MenuItem(Icon.QUESTIONCIRCLE + " Manual"))
                    {
                        Task.Run(() => Process.Start("explorer", "https://pabllopf.github.io/Alis/"));
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.SUPERPOWERS + " Check for Updates -SOON- ", false))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.INFOCIRCLE + " About"))
                    {
                        aboutState = true;
                    }

                    ImGui.EndMenu();
                }

                #endregion

            }

            ImGui.EndMainMenuBar();
        }

        #endregion

        #region Load Texts

        /// <summary>
        /// Loads the texts.
        /// </summary>
        /// <returns>Return none</returns>
        private void LoadTexts()
        {
            newProject = Icon.FILEO + TextManager.Get(Sentence.NewProject);
            openProject = Icon.FOLDEROPEN + TextManager.Get(Sentence.OpenProject);
            saveProject = Icon.FLOPPYO + TextManager.Get(Sentence.SaveProject);
            autoSave = Icon.REFRESH + TextManager.Get(Sentence.AutoSave);
            build = Icon.GAMEPAD + TextManager.Get(Sentence.Build);
            buildAndRun = Icon.GAMEPAD + TextManager.Get(Sentence.BuildAndRun);
            exit = Icon.POWEROFF + TextManager.Get(Sentence.Exit);

            messageSaveGame = TextManager.Get(Sentence.MessageSaveGame);
            messageExit = TextManager.Get(Sentence.MessageExit);

            yes = TextManager.Get(Sentence.Yes);
            no = TextManager.Get(Sentence.No);
        }

        #endregion

        #region File Menu

        /// <summary>
        /// Creates new project.
        /// </summary>
        /// <returns>Return none</returns>
        private void NewProject()
        {
            Console.Log("New Project");
            WidgetManager.Add(new ProjectManager(false, info));
        }

        /// <summary>
        /// Opens the project.
        /// </summary>
        /// <returns>Return none</returns>
        private void OpenProject()
        {
            Console.Log("Open Project");
            WidgetManager.Add(new ProjectManager(true, info));
            
        }

        /// <summary>
        /// Saves the project.
        /// </summary>
        /// <returns>Return none</returns>
        private void SaveProject(bool build)
        {
            if (Project.VideoGame is not null) 
            {
                Task.Run(()=> 
                {
                    BottomMenu.Loading(true, "Saving");

                    LocalData.Save("Data", Project.Get().DataPath1, Project.VideoGame);
                    Console.Log(string.Format(messageSaveGame, Project.VideoGame.Config.Name));
                    ImGui.SaveIniSettingsToDisk(Environment.CurrentDirectory + "/custom.ini");

                    Task.Delay(1000).Wait();
                    BottomMenu.Loading(false, "");

                    if (build)
                    {
                        Build();
                    }
                });

              

            }
            else
            {
                ImGui.SaveIniSettingsToDisk(Environment.CurrentDirectory + "/custom.ini");
                Console.Error(string.Format(messageSaveGame, "'Game not loaded'"));
            }
        }


        private void LoadAsembly()
        {
            string workDirRun = Project.Get().Directory + "/" + Project.Get().Name + "/bin/Windows/net5.0/" + Project.Get().Name + ".dll";

            if (info.Platform.Equals(Platform.Linux))
            {
                workDirRun = Project.Get().Directory + "/" + Project.Get().Name + "/bin/Linux/net5.0/" + Project.Get().Name + ".dll";
            }

            if (info.Platform.Equals(Platform.MacOS))
            {
                workDirRun = Project.Get().Directory + "/" + Project.Get().Name + "/bin/MacOS/net5.0/" + Project.Get().Name + ".dll";
            }

            if (File.Exists(workDirRun))
            {
                Project.Get().DLL1 = Assembly.Load(File.ReadAllBytes(workDirRun));
            }
        }

        class SimpleUnloadableAssemblyLoadContext : AssemblyLoadContext
        {
            public SimpleUnloadableAssemblyLoadContext()
               : base(isCollectible: true)
            {
            }

            protected override Assembly Load(AssemblyName assemblyName) => null;
        }

        /// <summary>
        /// Automatics the save project.
        /// </summary>
        /// <returns>Return none</returns>
        private void AutoSaveProject()
        {
            autosaveMode = !autosaveMode;
            LocalData.Save("Autosave", autosaveMode);
        }

        /// <summary>
        /// Checks the automatic save mode.
        /// </summary>
        /// <returns>Return none</returns>
        private void CheckAutoSaveMode() 
        {
            if (autosaveMode)
            {
                if (watch.Elapsed.TotalSeconds >= timerAutoSave)
                {
                    watch.Restart();
                    SaveProject(true);
                }
            }
        }

        /// <summary>
        /// Builds the settings.
        /// </summary>
        /// <returns>Return none</returns>
        private void Build()
        {
            Console.Log("Build");
            SaveProject(false);

            if (Project.VideoGame is not null)
            {
                Task.Run(() =>
                {
                    string fileName = "cmd.exe";
                    string cleanCommand = "dotnet restore";
                    string buildCommand = "dotnet build --configuration Windows";

                    if (info.Platform.Equals(Platform.Linux))
                    {
                        fileName = "/bin/bash";
                        cleanCommand = "dotnet restore";
                        buildCommand = "dotnet build --configuration Linux";
                    }

                    if (info.Platform.Equals(Platform.MacOS))
                    {
                        fileName = @"/System/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
                        cleanCommand = "dotnet restore";
                        buildCommand = "dotnet build --configuration MacOS";
                    }

                    RunCommand("Building", fileName, buildCommand, Project.Get().Directory + "/" + Project.Get().Name + "/", true);

                    LoadAsembly();
                });
            }
            else
            {
                Console.Warning("Project not loaded.");
            }
        }

        /// <summary>
        /// Builds the and run.
        /// </summary>
        /// <returns>Return none</returns>
        private void BuildAndRun()
        {
            Console.Log("Build And Run");

            if (Project.VideoGame is not null)
            {
                Task.Run(() =>
                {
                    string fileName = "cmd.exe";
                    string cleanCommand = "dotnet restore";
                    string buildCommand = "dotnet build --configuration Windows";

                    string workDirRun = Project.Get().Directory + "/" + Project.Get().Name + "/bin/Windows/net5.0";
                    string runCommand = Project.Get().Name + ".exe";

                    if (info.Platform.Equals(Platform.Linux))
                    {
                        fileName = "/bin/bash";
                        cleanCommand = "dotnet restore";
                        buildCommand = "dotnet build --configuration Linux";

                        workDirRun = Project.Get().Directory + "/" + Project.Get().Name + "/bin/Linux/net5.0";
                        runCommand = "./" + Project.Get().Name;
                    }

                    if (info.Platform.Equals(Platform.MacOS))
                    {
                        fileName = @"/System/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
                        cleanCommand = "dotnet restore";
                        buildCommand = "dotnet build --configuration MacOS";

                        workDirRun = Project.Get().Directory + "/" + Project.Get().Name + "/bin/MacOS/net5.0";
                        runCommand = "./" + Project.Get().Name;
                    }

                    RunCommand("Cleaning", fileName, cleanCommand, Project.Get().Directory + "/" + Project.Get().Name + "/", true);
                    RunCommand("Building", fileName, buildCommand, Project.Get().Directory + "/" + Project.Get().Name + "/", true);

                    LoadAsembly();

                    RunCommand("Running", fileName, runCommand, workDirRun, true);


                });
            }
            else
            {
                Console.Warning("Project not loaded.");
            }
        }

        /// <summary>
        /// Exits this instance.
        /// </summary>
        /// <returns>Return none</returns>
        private void Exit()
        {
            Console.Log("Exit to Editor");
            exitState = !exitState;
        }

        /// <summary>
        /// Checks the is exit.
        /// </summary>
        /// <returns>Return none</returns>
        private void CheckIsExit() 
        {
            if (exitState)
            {
                ImGui.OpenPopup(exit);
            }

            if (ImGui.BeginPopupModal(exit, ref exitState, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings))
            {
                ImGui.Text(messageExit);
                if (ImGui.Button(yes, new Vector2((ImGui.GetContentRegionAvail().X / 2) - 5.0f, 35.0f)))
                {
                    exitState = false;
                    ImGui.CloseCurrentPopup();
                    Environment.Exit(1);
                }

                ImGui.SameLine();

                if (ImGui.Button(no, new Vector2(ImGui.GetContentRegionAvail().X, 35.0f)))
                {
                    exitState = false;
                    ImGui.CloseCurrentPopup();
                }

                ImGui.EndPopup();
            }
        }

        #endregion

        #region Edit Menu

        /// <summary>
        /// Cuts this instance.
        /// </summary>
        /// <returns>return none</returns>
        private void Cut() 
        {
        }

        #endregion

        #region Tools Menu

        /// <summary>
        /// Opens the terminal.
        /// </summary>
        /// <returns>return none</returns>
        private void OpenTerminal()
        {
            string fileName = "cmd.exe";
            string comand = "start cmd";
            string workDirRun = Environment.CurrentDirectory;

            if (info.Platform.Equals(Platform.Linux))
            {
                fileName = "/bin/bash";
                comand = "-c \" " + "exo-open --launch TerminalEmulator" + " \"";
            }

            if (info.Platform.Equals(Platform.MacOS))
            {
                fileName = @"/System/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
            }

            Task.Run(() => RunCommand("Open Terminal", fileName, comand, workDirRun, false));
        }

        #endregion

        #region Window Menu

        /// <summary>
        /// Defaults the view.
        /// </summary>
        /// <returns>return none</returns>
        private void DefaultView() 
        {
            string file = Environment.CurrentDirectory + "/Resources/Default.ini";
            if (File.Exists(file))
            {
                ImGui.LoadIniSettingsFromDisk(file);
                Console.Log("Default View");
            }
            else 
            {
                Console.Warning("Default View cant be loaded because file dont exits " + file);
            }
        }

        /// <summary>
        /// Wides the view.
        /// </summary>
        /// <returns>return none</returns>
        private void WideView() 
        {
            string file = Environment.CurrentDirectory + "/Resources/Wide.ini";
            if (File.Exists(file))
            {
                ImGui.LoadIniSettingsFromDisk(file);
                Console.Log("Wide View");
            }
            else
            {
                Console.Warning("Wide View cant be loaded because file dont exits " + file);
            }
        }

        /// <summary>
        /// Talls the view.
        /// </summary>
        /// <returns>return none</returns>
        private void TallView() 
        {
            string file = Environment.CurrentDirectory + "/Resources/Tall.ini";
            if (File.Exists(file))
            {
                ImGui.LoadIniSettingsFromDisk(file);
                Console.Log("Tall View");
            }
            else
            {
                Console.Warning("Tall View cant be loaded because file dont exits " + file);
            }
        }

        #endregion

        #region Help Menu

        /// <summary>
        /// Checks the is about.
        /// </summary>
        /// <returns></returns>
        private void CheckIsAbout()
        {
            if (aboutState)
            {
                ImGui.OpenPopup("About");
            }

            if (ImGui.BeginPopupModal("About", ref aboutState, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings))
            {
                ImGui.Text("Version: 1.2.8");
                ImGui.Text("Author: Pablo Perdomo Falcón");
                ImGui.Text("Licence: General Public License v3.0");

                ImGui.EndPopup();
            }
        }

        #endregion

        #region Shortcuts

        /// <summary>
        /// Checks the short cuts.
        /// </summary>
        /// <returns>return none</returns>
        private void CheckShortCuts() 
        {
            ShortNewProject();
            ShortOpenProject();
            ShortSaveGame();
            ShortAutosave();
            ShortBuild();
            ShortBuildAndRun();
        }

        /// <summary>
        /// Shorts the new project.
        /// </summary>
        /// <returns>return none</returns>
        private void ShortNewProject() 
        {
            if (ImGui.IsKeyDown(3) && ImGui.IsKeyReleased(96))
            {
                NewProject();
            }
        }

        /// <summary>
        /// Shorts the save game.
        /// </summary>
        /// <returns>return none</returns>
        private void ShortSaveGame() 
        {
            if (ImGui.IsKeyDown(3) && !ImGui.IsKeyDown(5) && ImGui.IsKeyReleased(101))
            {
                SaveProject(true);
            }
        }

        /// <summary>
        /// Shorts the open project.
        /// </summary>
        /// <returns>return none</returns>
        private void ShortOpenProject() 
        {
            if (ImGui.IsKeyDown(3) && ImGui.IsKeyReleased(97))
            {
                OpenProject();
            }
        }

        /// <summary>
        /// Shorts the build.
        /// </summary>
        /// <returns>Return game</returns>
        private void ShortBuild()
        {
            if (ImGui.IsKeyDown(3) && ImGui.IsKeyReleased(84))
            {
                Build();
            }
        }

        /// <summary>
        /// Shorts the automatic save.
        /// </summary>
        /// <returns>return none</returns>
        private void ShortBuildAndRun() 
        {
            if (ImGui.IsKeyDown(3) && ImGui.IsKeyDown(5) && ImGui.IsKeyReleased(84))
            {
                BuildAndRun();
            }
        }

        /// <summary>
        /// Shorts the autosave.
        /// </summary>
        /// <returns></returns>
        private void ShortAutosave()
        {
            if (ImGui.IsKeyDown(3) && ImGui.IsKeyDown(5) && ImGui.IsKeyReleased(101))
            {
                autosaveMode = !autosaveMode;
                Console.Log("Autosave mode: " + autosaveMode);
            }
        }

        #endregion

        #region Run CMD 

        /// <summary>
        /// Runs the command.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="commandBuild">The command build.</param>
        /// <param name="WorkingDirectory">The working directory.</param>
        /// <returns>Return none</returns>
        private void RunCommand(string message, string fileName, string commandBuild, string WorkingDirectory, bool messages)
        {
            if (messages) 
            {
                BottomMenu.Loading(true, message);
            }

            Process buildProcess = new Process();

            buildProcess.StartInfo.FileName = fileName;
            buildProcess.StartInfo.WorkingDirectory = WorkingDirectory;
            buildProcess.StartInfo.CreateNoWindow = false;
            buildProcess.StartInfo.RedirectStandardInput = true;
            buildProcess.StartInfo.RedirectStandardOutput = true;
            buildProcess.StartInfo.UseShellExecute = false;
            buildProcess.Start();
            buildProcess.StandardInput.WriteLine(commandBuild);
            buildProcess.StandardInput.Flush();
            buildProcess.StandardInput.Close();
            buildProcess.WaitForExit();

            string[] sentences = buildProcess.StandardOutput.ReadToEnd().Split("\n");
            for (int i = 0; i < sentences.Length; i++)
            {
                if (sentences[i].Contains("warning"))
                {
                    Console.Warning(sentences[i]);
                    continue;
                }

                if (sentences[i].Contains("error") || sentences[i].Contains("failed") || sentences[i].Contains("exception"))
                {
                    Console.Error(sentences[i]);
                    continue;
                }

                Console.Log(sentences[i], false);
            }

            if (messages)
            {
                BottomMenu.Loading(false, "");
            }
        }

        #endregion

        #region OPEN VISUAL STUDIO

        private void OpenVisualStudio()
        {
            Console.Warning("Open VISUAL STUDIO");

            Task.Run(() =>
            {
                string fileName = "cmd.exe";
                string RUN = Project.Get().Name + ".sln";

                if (info.Platform.Equals(Platform.Linux))
                {
                    fileName = "/bin/bash";
                    RUN = Project.Get().Name + ".sln";
                }

                if (info.Platform.Equals(Platform.MacOS))
                {
                    fileName = @"/System/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
                    RUN = Project.Get().Name + ".sln";
                }

                RunCommand("Building", fileName, RUN, Project.Get().Directory + "/" + Project.Get().Name + "/", true);
            });

        }

        #endregion


        #region Directory Copy 

        /// <summary>
        /// Directories the copy.
        /// </summary>
        /// <param name="sourceDirName">Name of the source dir.</param>
        /// <param name="destDirName">Name of the dest dir.</param>
        /// <param name="copySubDirs">if set to <c>true</c> [copy sub dirs].</param>
        /// <returns></returns>
        /// <exception cref="DirectoryInfo">sourceDirName</exception>
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        #endregion

        #region Events

        /// <summary>Texts the manager on change idiom.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        /// <returns>Run the event</returns>
        private void TextManager_OnChangeIdiom([NotNull] object sender, [NotNull] bool e) => LoadTexts();

        #endregion
    }
}