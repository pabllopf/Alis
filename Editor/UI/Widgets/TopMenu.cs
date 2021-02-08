//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="TopMenu.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using Alis.Core;
    using Alis.Editor.Utils;
    using Alis.Tools;
    using ImGuiNET;

    /// <summary>Menu of editor</summary>
    public class TopMenu : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "TopMenu";

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        /// <summary>The process</summary>
        private System.Diagnostics.Process process = new System.Diagnostics.Process();

        /// <summary>The start information</summary>
        private System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

        /// <summary>The about state</summary>
        private bool aboutState = false;

        /// <summary>The exit state</summary>
        private bool exitState = false;

        /// <summary>The is saved pressed</summary>
        private bool isSavedPressed = false;

        /// <summary>The automatic save selected</summary>
        private bool autoSaveSelected = false;

        private Info info;

        /// <summary>Initializes a new instance of the <see cref="TopMenu" /> class.</summary>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="info">The information.</param>
        public TopMenu(EventHandler<EventType> eventHandler, Info info)
        {
            this.eventHandler = eventHandler;
            this.info = info;

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
        }

        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            ProcessShortcuts();

            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {

                    if (ImGui.MenuItem(Icon.FILEO + " New Project", "Ctrl+N"))
                    {
                        eventHandler.Invoke(null, EventType.OpenCreateProject);
                    }

                    if (ImGui.MenuItem(Icon.FOLDEROPEN + " Open Project", "Ctrl+O"))
                    {
                        eventHandler.Invoke(null, EventType.OpenProject);
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
                            eventHandler?.Invoke(this, EventType.OpenConsole);
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

                    if (ImGui.MenuItem(Icon.INFOCIRCLE + " About"))
                    {
                        aboutState = true;
                    }

                    ImGui.EndMenu();
                }

                ImGui.EndMainMenuBar();
            }

            ShowAboutPopup();
            ShowExitPopup();
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
        }

        /// <summary>Close this instance.</summary>
        public override void Close()
        {
        }

        private bool isOpenNewProject = false;

        private bool isOpenProject = false;

        private bool isBuildAndRun = false;

        private void ProcessShortcuts()
        {
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
                eventHandler.Invoke(null, EventType.OpenCreateProject);
                isOpenNewProject = true;
            }

            if (!ImGui.IsKeyPressed(3) && !ImGui.IsKeyDown(96) && isSavedPressed)
            {
                isOpenNewProject = false;
            }

            if (ImGui.IsKeyPressed(3) && ImGui.IsKeyDown(97) && !isSavedPressed)
            {
                eventHandler.Invoke(null, EventType.OpenProject);
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
            }
        }

        private void BuildAndRun()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                BuildAsync(info);
            }).Start();


            




            /*System.Diagnostics.Process processto = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfogod = new System.Diagnostics.ProcessStartInfo();

            System.Diagnostics.Process processRun = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfoRun = new System.Diagnostics.ProcessStartInfo();

            if (info.Platform.Equals(Platform.Windows))
            {
                startInfogod.FileName = "cmd";
                startInfogod.Arguments = "/C dotnet build --configuration Windows";
                startInfogod.WorkingDirectory = Project.Current.Directory;
                startInfogod.UseShellExecute = true;
                processto.StartInfo = startInfogod;
                processto.Start();
                Console.Current.Log("Builded");

                processto.WaitForExit();

                startInfoRun.FileName = "cmd";
                startInfoRun.Arguments = "/C " + Project.Current.Name + ".exe";
                startInfoRun.WorkingDirectory = Project.Current.Directory + "/bin/Windows/netcoreapp3.1";
                startInfoRun.UseShellExecute = true;
                processRun.StartInfo = startInfoRun;
                processRun.Start();
                Console.Current.Log("Running");
            }

            if (info.Platform.Equals(Platform.MacOS))
            {
                startInfogod.FileName = @"/System/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
            }

            if (info.Platform.Equals(Platform.Linux))
            {
                startInfogod.FileName = "/bin/bash";
                startInfogod.Arguments = "-c \" " + "exo-open --launch TerminalEmulator  && dotnet publish -r debian.8-x64 -c Linux  -o ./bin/Linux/debian --self-contained true" + " \" ";
                startInfogod.WorkingDirectory = Project.Current.Directory;
                startInfogod.UseShellExecute = true;
                processto.StartInfo = startInfogod;
                processto.Start();
                Console.Current.Log("Builded");

                processto.WaitForExit();

                startInfoRun.FileName = "/bin/bash";
                startInfoRun.Arguments = "-c \" " + "exo-open --launch TerminalEmulator  && ./" + Project.Current.Name + " \" ";
                startInfoRun.WorkingDirectory = Project.Current.Directory + "/bin/Linux/debian";
                startInfoRun.UseShellExecute = true;
                processRun.StartInfo = startInfoRun;
                processRun.Start();
                Console.Current.Log("Running");
            }*/
        }

        private void BuildAsync(Info info)
        {
            string fileName = "cmd.exe";
            string cleanCommand = "dotnet restore";
            string buildCommand = "dotnet build --configuration Windows";
            string runCommand = Project.Current.Name + ".exe";
            string workDirRun = Project.Current.Directory + "/bin/Windows/netcoreapp3.1";


            if (info.Platform.Equals(Platform.Linux)) 
            {
                fileName = "/bin/bash";
                cleanCommand = "dotnet restore";
                buildCommand = "dotnet build --configuration Linux";
                runCommand = "./" + Project.Current.Name;
                workDirRun = Project.Current.Directory + "/bin/Linux/netcoreapp3.1";
            }

            if (info.Platform.Equals(Platform.MacOS))
            {
                fileName = @"/System/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
                cleanCommand = "dotnet restore";
                buildCommand = "dotnet build --configuration MacOS";
                runCommand = "./" + Project.Current.Name;
                workDirRun = Project.Current.Directory + "/bin/MacOS/netcoreapp3.1";
            }

            string projectFile = File.ReadAllText(Application.ProjectPath + "/Resources/DefaultPr.txt", Encoding.UTF8);
            File.WriteAllText(Project.Current.Directory + "/" + Project.Current.Name + ".csproj", projectFile, Encoding.UTF8);

            string solutionFile = File.ReadAllText(Application.ProjectPath + "/Resources/DefaultSl.txt", Encoding.UTF8).Replace("Example", Project.Current.Name);
            File.WriteAllText(Project.Current.Directory + "/" + Project.Current.Name + ".sln", solutionFile, Encoding.UTF8);

            string program = File.ReadAllText(Application.ProjectPath + "/Resources/Program.txt", Encoding.UTF8);
            File.WriteAllText(Project.Current.Directory + "/" + "Program" + ".cs", program, Encoding.UTF8);

            DirectoryCopy(Application.ProjectPath + "/Runtimes", Project.Current.Directory + "/Runtimes", true);

            File.Copy(Application.ProjectPath + "/Core.dll", Project.Current.LibraryPath + "/" + "Core" + ".dll", true);
            File.Copy(Application.ProjectPath + "/Tools.dll", Project.Current.LibraryPath + "/" + "Tools" + ".dll", true);
            File.Copy(Application.ProjectPath + "/Core-SFML.dll", Project.Current.LibraryPath + "/" + "Core-SFML.dll", true);


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

        private void AutoSaveProject()
        {
        }

        private void SaveProject() 
        {
            Console.Current.Log("Saved " + Project.VideoGame.Config.NameProject);
            LocalData.Save<VideoGame>("Data", Project.Current.DataPath, Project.VideoGame);
        }

        /// <summary>Opens the terminal.</summary>
        private void OpenTerminal()
        {
            process.Start();
        }

        private void ShowAboutPopup()
        {
            if (aboutState)
            {
                ImGui.OpenPopup("About");
            }

            if (ImGui.BeginPopupModal("About", ref aboutState, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings))
            {
                ImGui.Text("Version: 1.0.0");
                ImGui.Text("Author: Pablo Perdomo Falcón");
                ImGui.Text("Licence: General Public License v3.0");

                ImGui.EndPopup();
            }
        }

        /// <summary>Shows the exit popup.</summary>
        private void ShowExitPopup()
        {
            if (exitState) 
            {
                ImGui.OpenPopup("Exit?");
            }

            if (ImGui.BeginPopupModal("Exit?", ref exitState, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings))
            {
                ImGui.Text("Are you sure you want to exit?, Please remenber save the project.");
                if (ImGui.Button("Accept", new System.Numerics.Vector2((ImGui.GetContentRegionAvail().X / 2) - 5.0f, 35.0f)))
                {
                    eventHandler.Invoke(this, EventType.ExitEditor);
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
            }
        }
    }
}
