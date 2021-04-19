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
    using System.Text;
    using System.Threading;
    using Alis.Core.SFML;
    using Alis.Editor.Utils;
    using Alis.Tools;
    using ImGuiNET;

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
        private static string buildSettings;

        /// <summary>The build and run</summary>
        [NotNull]
        private static string buildAndRun;

        /// <summary>The exit</summary>
        [NotNull]
        private static string exit;

        /// <summary>The exit</summary>
        [NotNull]
        private static string messageSaveGame;

        #endregion

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

        #region State Vars

        /// <summary>The is autosave active</summary>
        [NotNull]
        private bool autosaveMode;

        /// <summary>The timer automatic save</summary>
        [NotNull]
        private int timerAutoSave;

        #endregion

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

            LoadTexts();
        }

        /// <summary>
        /// Draws this instance.
        /// </summary>
        /// <returns>Return none</returns>
        public override void Draw()
        {
            if (autosaveMode) 
            {
                CheckAutoSaveMode();
            }

            if (ImGui.BeginMainMenuBar())
            {
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
                        SaveProject();
                    }

                    if (ImGui.MenuItem(label: autoSave + (autosaveMode ? timerAutoSave - (int)watch.Elapsed.TotalSeconds + "s": ""), "", autosaveMode))
                    {
                        AutoSaveProject();
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(buildSettings, false))
                    {
                        BuildSettings();
                    }

                    if (ImGui.MenuItem(buildAndRun, "Ctrl+B"))
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

                ImGui.EndMainMenuBar();
            }
        }

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
            buildSettings = Icon.GAMEPAD + TextManager.Get(Sentence.BuildSettings);
            buildAndRun = Icon.GAMEPAD + TextManager.Get(Sentence.BuildAndRun);
            exit = Icon.POWEROFF + TextManager.Get(Sentence.Exit);

            messageSaveGame = TextManager.Get(Sentence.MessageSaveGame);
        }

        #endregion

        #region File Menu

        /// <summary>
        /// Creates new project.
        /// </summary>
        /// <returns>Return none</returns>
        private void NewProject()
        {

        }

        /// <summary>
        /// Opens the project.
        /// </summary>
        /// <returns>Return none</returns>
        private void OpenProject()
        {

        }

        /// <summary>
        /// Saves the project.
        /// </summary>
        /// <returns>Return none</returns>
        private void SaveProject()
        {
            if (Project.VideoGame is not null)
            {
                LocalData.Save("Data", Project.Current.DataPath, Project.VideoGame);
                Console.Log(string.Format(messageSaveGame, Project.VideoGame.Config.Name));
            }
            else 
            {
                Console.Error(string.Format(messageSaveGame, "'Game not loaded'"));
            }
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
            if (watch.Elapsed.TotalSeconds >= timerAutoSave) 
            {
                watch.Restart();
                SaveProject();
            }
        }

        /// <summary>
        /// Builds the settings.
        /// </summary>
        /// <returns>Return none</returns>
        private void BuildSettings()
        {

        }

        /// <summary>
        /// Builds the and run.
        /// </summary>
        /// <returns>Return none</returns>
        private void BuildAndRun()
        {

        }

        /// <summary>
        /// Exits this instance.
        /// </summary>
        /// <returns>Return none</returns>
        private void Exit()
        {
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

            

            /*
            ProcessShortcuts();

            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {

                    if (ImGui.MenuItem(Icon.FILEO + " New Project", "Ctrl+N"))
                    {
                    }

                    if (ImGui.MenuItem(Icon.FOLDEROPEN + " Open Project", "Ctrl+O"))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.FLOPPYO + " Save", "Ctrl+S"))
                    {
                        SaveProject();
                    }

                    if (ImGui.MenuItem(Icon.REFRESH + " AutoSave -SOON-", false))
                    {
                        AutoSaveProject();
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.GAMEPAD + " Build Settings -SOON-", false))
                    {
                    }

                    if (ImGui.MenuItem(Icon.PLAYCIRCLEO + " Build and Run", "Ctrl+B"))
                    {
                        BuildAndRun();
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.POWEROFF + " Exit", "Alt+F4"))
                    {
                        exitState = true;
                    }

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Edit"))
                {
                    if (ImGui.MenuItem(Icon.UNDO + " Undo -SOON-", false))
                    {
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

                    if (ImGui.MenuItem(Icon.COG + " Preferences -SOON-", false  ))
                    {
                    }

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Tools"))
                {
                    if (ImGui.MenuItem(Icon.TERMINAL + " Terminal", "Ctrl+T"))
                    {
                        OpenTerminal();
                    }

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Window"))
                {
                    if (ImGui.BeginMenu(Icon.WINDOWMAXIMIZE + " Layouts"))
                    {
                        if (ImGui.MenuItem("Default"))
                        {
                        }

                        if (ImGui.MenuItem("Tall"))
                        {
                        }

                        if (ImGui.MenuItem("Wide"))
                        {
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
                            //eventHandler?.Invoke(this, EventType.OpenConsole);
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

                if (ImGui.BeginMenu("Help"))
                {
                    if (ImGui.MenuItem(Icon.QUESTIONCIRCLE + " Manual"))
                    {
                        System.Diagnostics.Process.Start("explorer", "https://pabllopf.github.io/Alis/");
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.SUPERPOWERS + " Check for Updates -SOON- ", false ))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem
            
            (Icon.INFOCIRCLE + " About"))
                    {
                        aboutState = true;
                    }

                    ImGui.EndMenu();
                }

                ImGui.EndMainMenuBar();
            }

            ShowAboutPopup();
            ShowExitPopup();*/
        /*}


        private void ProcessShortcuts()
        {*/
            /*
            if (ImGui.IsKeyPressed(3) && ImGui.IsKeyDown(101) && !isSavedPressed)
            {
                SaveProject();
                isSavedPressed = true;
            }

            if (!ImGui.IsKeyPressed(3) && !ImGui.IsKeyDown(101) && isSavedPressed)
            {
                isSavedPressed = false;
            }

            if (ImGui.IsKeyPressed(3) && ImGui.IsKeyDown(96) && !isSavedPressed)
            {
                //eventHandler.Invoke(null, EventType.OpenCreateProject);
                isOpenNewProject = true;
            }

            if (!ImGui.IsKeyPressed(3) && !ImGui.IsKeyDown(96) && isSavedPressed)
            {
                isOpenNewProject = false;
            }

            if (ImGui.IsKeyPressed(3) && ImGui.IsKeyDown(97) && !isSavedPressed)
            {
                //eventHandler.Invoke(null, EventType.OpenProject);
                isOpenProject = true;
            }

            if (!ImGui.IsKeyPressed(3) && !ImGui.IsKeyDown(97) && isSavedPressed)
            {
                isOpenProject = false;
            }

            if (ImGui.IsKeyPressed(3) && ImGui.IsKeyDown(84) && !isSavedPressed)
            {
                BuildAndRun();
                isBuildAndRun = true;
            }

            if (!ImGui.IsKeyPressed(3) && !ImGui.IsKeyDown(84) && isSavedPressed)
            {
                isBuildAndRun = false;
            }*/
        //}
        /*
        private void BuildAndRun()
        {
            LocalData.Save<VideoGame>("Data", Project.Current.DataPath, Project.VideoGame);
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                BuildAsync(info);
            }).Start();
        }

        private void BuildAsync(Info info)
        {
            LocalData.Save("Data", Project.VideoGame);

            string fileName = "cmd.exe";
            string cleanCommand = "dotnet restore";
            string buildCommand = "dotnet build --configuration Windows";
            string runCommand = Project.Current.Name + ".exe";
            string workDirRun = Project.Current.Directory + "/bin/Windows/net5.0";


            if (info.Platform.Equals(Platform.Linux)) 
            {
                fileName = "/bin/bash";
                cleanCommand = "dotnet restore";
                buildCommand = "dotnet build --configuration Linux";
                runCommand = "./" + Project.Current.Name;
                workDirRun = Project.Current.Directory + "/bin/Linux/net5.0";
            }

            if (info.Platform.Equals(Platform.MacOS))
            {
                fileName = @"/System/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
                cleanCommand = "dotnet restore";
                buildCommand = "dotnet build --configuration MacOS";
                runCommand = "./" + Project.Current.Name;
                workDirRun = Project.Current.Directory + "/bin/MacOS/net5.0";
            }

            string projectFile = File.ReadAllText(Application.ProjectFolder + "/Resources/DefaultPr.txt", Encoding.UTF8);
            File.WriteAllText(Project.Current.Directory + "/" + Project.Current.Name + ".csproj", projectFile, Encoding.UTF8);

            string solutionFile = File.ReadAllText(Application.ProjectFolder + "/Resources/DefaultSl.txt", Encoding.UTF8).Replace("Example", Project.Current.Name);
            File.WriteAllText(Project.Current.Directory + "/" + Project.Current.Name + ".sln", solutionFile, Encoding.UTF8);

            string program = File.ReadAllText(Application.ProjectFolder + "/Resources/Program.txt", Encoding.UTF8);
            File.WriteAllText(Project.Current.Directory + "/" + "Program" + ".cs", program, Encoding.UTF8);

            DirectoryCopy(Application.ProjectFolder + "/Runtimes", Project.Current.Directory + "/Runtimes", true);

            File.Copy(Application.ProjectFolder + "/Core.dll", Project.Current.LibraryPath + "/" + "Core" + ".dll", true);
            File.Copy(Application.ProjectFolder + "/Tools.dll", Project.Current.LibraryPath + "/" + "Tools" + ".dll", true);
            File.Copy(Application.ProjectFolder + "/Core-SFML.dll", Project.Current.LibraryPath + "/" + "Core-SFML.dll", true);


            RunCommand("Cleaning", fileName, cleanCommand, Project.Current.Directory);
            RunCommand("Building", fileName, buildCommand, Project.Current.Directory);
            RunCommand("Running", fileName, runCommand, workDirRun);
        }

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


        private void RunCommand(string message, string fileName, string commandBuild, string WorkingDirectory) 
        {
            BottomMenu.Current.Loading(true, message);

            System.Diagnostics.Process buildProcess = new System.Diagnostics.Process();

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
                    Console.Current.Warning(sentences[i]);
                    continue;
                }

                if (sentences[i].Contains("error") || sentences[i].Contains("failed") || sentences[i].Contains("exception"))
                {
                    Console.Current.Error(sentences[i]);
                    continue;
                }

                Console.Current.Log(sentences[i], false);
            }

            BottomMenu.Current.Loading(false, "");
        }



        /// <summary>Opens the terminal.</summary>
        private void OpenTerminal()
        {
            process.Start();
        }

        private void ShowAboutPopup()
        {
          /*  if (aboutState)
            {
                ImGui.OpenPopup("About");
            }

            if (ImGui.BeginPopupModal("About", ref aboutState, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings))
            {
                ImGui.Text("Version: 1.0.0");
                ImGui.Text("Author: Pablo Perdomo Falcón");
                ImGui.Text("Licence: General Public License v3.0");

                ImGui.EndPopup();
            }*/
        //}

        /// <summary>Shows the exit popup.</summary>
        /*private void ShowExitPopup()
        {*/
           /* if (exitState) 
            {
                ImGui.OpenPopup("Exit?");
            }

            if (ImGui.BeginPopupModal("Exit?", ref exitState, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings))
            {
                ImGui.Text("Are you sure you want to exit?, Please remenber save the project.");
                if (ImGui.Button("Accept", new System.Numerics.Vector2((ImGui.GetContentRegionAvail().X / 2) - 5.0f, 35.0f)))
                {
                    //eventHandler.Invoke(this, EventType.ExitEditor);
                    exitState = false;
                    ImGui.CloseCurrentPopup();
                }

                ImGui.SameLine();

                if (ImGui.Button("Cancel", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, 35.0f)))
                {
                    exitState = false;
                    ImGui.CloseCurrentPopup();
                }

                ImGui.EndPopup();
            }*/
        /*}
    }
}
*/

/*
 

if (info.Platform.Equals(Platform.Windows))
            {
                startInfo.FileName = "cmd";
            }

            if (info.Platform.Equals(Platform.MacOS))
            {
                startInfo.FileName = @"/System/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
            }

            if (info.Platform.Equals(Platform.Linux))
            {
                startInfo.FileName = "/bin/bash";
                startInfo.Arguments = "-c \" " + "exo-open --launch TerminalEmulator" + " \"";
            }

 startInfo.UseShellExecute = true;
            process.StartInfo = startInfo;

 * */