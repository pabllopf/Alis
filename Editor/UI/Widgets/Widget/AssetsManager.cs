//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="AssetsManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Core;
    using Alis.Editor.Utils;
    using Alis.Tools;
    using ImGuiNET;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Numerics;
    using System.Threading.Tasks;

    /// <summary>Manage files of project.</summary>
    public class AssetsManager : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "Assets";

        private Info info;

        /// <summary>The filter</summary>
        private ImGuiTextFilterPtr filter;

        /// <summary>The is open</summary>
        private bool isOpen = true;

        /// <summary>The path example</summary>
        private string assetPath = string.Empty;

        /// <summary>The current dir</summary>
        private string currentDirRight = string.Empty;

        /// <summary>The path folders</summary>
        private List<string> pathFolders = new List<string>();

        private string[] imagesFormat = new string[] { ".jpg", ".png"};

        private string[] audiosFormat = new string[] { ".wav" };

        private string[] filesFormat = new string[] { ".txt" };

        private string[] videoFormat = new string[] { ".mp4" };

        private List<string> templist = new List<string>();

        private bool stateOfView = true;

        /// <summary>Initializes a new instance of the <see cref="AssetsManager" /> class.</summary>
        public AssetsManager(Info info)
        {
            this.info = info;

            unsafe
            {
                ImGuiTextFilter* filterPtr = ImGuiNative.ImGuiTextFilter_ImGuiTextFilter(null);
                filter = new ImGuiTextFilterPtr(filterPtr);
            }

            Project.OnChange += Project_OnChange;
        }

        private void Project_OnChange(object sender, bool e)
        {
            if (Project.Get() is not null) 
            {
                assetPath = Project.Get().AssetPath;
                currentDirRight = assetPath;
            }
        }

        public void ButtonSpecial() 
        {
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0, 0, 0, 0));
            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0f);
            if (ImGui.Button((stateOfView ? Icon.LOWVISION : Icon.EYE) + ""))
            {
                stateOfView = !stateOfView;
            }
            ImGui.PopStyleVar();
            ImGui.PopStyleColor();
            ImGui.SameLine();
        }

        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            if (!isOpen)
            {
                WidgetManager.Delete(this);
                return;
            }

            if (ImGui.Begin(Name, ref isOpen)) 
            {
                ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(1.0f, 3.0f));
                ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0, 0, 0, 0));
                ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0f);

                if (Project.Get() != null)
                {
                    foreach (string folderButton in GetNameDir(currentDirRight))
                    {
                        if (ImGui.Button(folderButton))
                        {
                            MoveToDir(folderButton);
                        }

                        ImGui.SameLine();

                        ImGui.Text("/");

                        ImGui.SameLine();
                    }
                }

                ImGui.PopStyleVar(2);
                ImGui.PopStyleColor();


                filter.Draw(Icon.SEARCH + string.Empty, ImGui.GetContentRegionAvail().X - 20.0f);

                if (filter.IsActive()) 
                {
                    templist.Clear();
                    foreach (string file in Directory.GetFiles(Project.Get().AssetPath,"*", SearchOption.AllDirectories)) 
                    {
                        if (filter.PassFilter(Path.GetFileName(file))) 
                        {
                            templist.Add(file);
                        }
                    }
                }

                ImGui.Separator();

                if (ImGui.BeginChild("Assets-Child-Master"))
                {

                    

                    if (ImGui.BeginChild("Assets-Child-Left", new Vector2((ImGui.GetWindowWidth() <= ImGui.GetWindowHeight()) ? ImGui.GetContentRegionAvail().X : ImGui.GetContentRegionAvail().X / 3, ImGui.GetContentRegionAvail().Y), true))
                    {
                        if (Project.Get() != null)
                        {
                            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0, 0, 0, 0));
                            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0f);

                            if (!filter.IsActive())
                            {
                                if (Project.Get() != null)
                                {
                                    ShowTree(Project.Get().AssetPath);

                                }
                            }
                            else 
                            {
                                foreach (string file in templist)
                                {
                                    ShowFile(file);
                                }
                            }

                            ImGui.PopStyleVar();
                            ImGui.PopStyleColor();
                        }
                    }

                    ImGui.EndChild();



                    ImGui.SameLine();

                    if (ImGui.GetWindowWidth() > ImGui.GetWindowHeight())
                    {

                        if (ImGui.BeginChild("Assets-Child-Right", new Vector2(ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y), true, ImGuiWindowFlags.AlwaysAutoResize))
                        {
                            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0, 0, 0, 0));
                            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0f);
                            if (Project.Get() != null)
                            {
                                if (!filter.IsActive())
                                {
                                    foreach (string directory in Directory.GetDirectories(currentDirRight))
                                    {
                                        ImGui.PushStyleVar(ImGuiStyleVar.ButtonTextAlign, new Vector2(0f, 0.5f));

                                        if (ImGui.Button(Icon.FOLDERO + " " + Path.GetFileName(Path.GetDirectoryName(directory + "/t.txt")), new Vector2(ImGui.GetContentRegionAvail().X, 25.0f)))
                                        {
                                            ChangeDir(directory);
                                        }

                                        ImGui.PopStyleVar();
                                    }


                                    ShowFiles(currentDirRight);
                                }
                                else
                                {
                                    foreach (string file in templist)
                                    {
                                        ShowFile(file);
                                    }
                                }
                            }

                            ImGui.PopStyleVar();
                            ImGui.PopStyleColor();
                        }

                        ImGui.EndChild();

                    }
                }

                ImGui.EndChild();
            }

            ImGui.End();
            
        }

        private void ShowFile(string file)
        {
            ImGui.BeginGroup();

            string icon = Icon.FILEO;

            for (int i = 0; i < audiosFormat.Length; i++)
            {
                if (Path.GetExtension(file).Contains(audiosFormat[i]))
                {
                    icon = Icon.FILEAUDIOO;
                }
            }

            for (int i = 0; i < filesFormat.Length; i++)
            {
                if (Path.GetExtension(file).Contains(filesFormat[i]))
                {
                    icon = Icon.FILETEXT;
                }
            }

            for (int i = 0; i < imagesFormat.Length; i++)
            {
                if (Path.GetExtension(file).Contains(imagesFormat[i]))
                {
                    icon = Icon.FILEIMAGEO;
                }
            }

            for (int i = 0; i < videoFormat.Length; i++)
            {
                if (Path.GetExtension(file).Contains(videoFormat[i]))
                {
                    icon = Icon.FILEVIDEOO;
                }
            }



            if (!icon.Equals(""))
            {
                ImGui.PushStyleVar(ImGuiStyleVar.ButtonTextAlign, new Vector2(0f, 0.5f));

                if (ImGui.Button(icon + " " + Path.GetFileName(file), new Vector2(ImGui.GetContentRegionAvail().X, 25.0f)))
                {
                }
                ImGui.PopStyleVar();
            }





            ImGui.EndGroup();
        }

        private void ShowFiles(string currentDir)
        {
            foreach (string file in Directory.GetFiles(currentDir, "*"))
            {
                ImGui.BeginGroup();

                string icon = Icon.FILEO;

                for (int i = 0; i < audiosFormat.Length; i++)
                {
                    if (Path.GetExtension(file).Contains(audiosFormat[i]))
                    {
                        icon = Icon.FILEAUDIOO;
                    }
                }

                for (int i = 0; i < filesFormat.Length; i++)
                {
                    if (Path.GetExtension(file).Contains(filesFormat[i]))
                    {
                        icon = Icon.FILETEXT;
                    }
                }

                for (int i = 0; i < imagesFormat.Length; i++)
                {
                    if (Path.GetExtension(file).Contains(imagesFormat[i]))
                    {
                        icon = Icon.FILEIMAGEO;
                    }
                }

                for (int i = 0; i < videoFormat.Length; i++)
                {
                    if (Path.GetExtension(file).Contains(videoFormat[i]))
                    {
                        icon = Icon.FILEVIDEOO;
                    }
                }

                

                if (!icon.Equals("")) 
                {
                    ImGui.PushStyleVar(ImGuiStyleVar.ButtonTextAlign, new Vector2(0f, 0.5f));

                    if (ImGui.Button(icon + " " + Path.GetFileName(file), new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, 25.0f)))
                    {
                        if (Path.GetExtension(file).Contains(".cs")) 
                        {
                            OpenVisualStudio();
                        }
                    }
                    ImGui.PopStyleVar();
                }

              

               

                ImGui.EndGroup();
            }
        }

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
                    RUN = "dotnet restore";
                }

                if (info.Platform.Equals(Platform.MacOS))
                {
                    fileName = @"/System/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
                    RUN = "dotnet restore";
                }

                RunCommand("Building", fileName, RUN, Project.Get().Directory + "/" + Project.Get().Name + "/", true);
            });

        }

        private void MoveToDir(string folderButton)
        {
            string[] path = currentDirRight.Replace("\\", "/").Split("/");
            string result = "";

            for (int i = 0; i < path.Length; i++)
            {
                if (!path[i].Equals(folderButton))
                {
                    result += path[i] + "/";
                }
                else 
                {
                    result += path[i] + "/";
                    break;
                }
            }

            currentDirRight = result;
        }

        private List<string> GetNameDir(string currentDirRight) 
        {
            string pathrelative = Path.GetRelativePath(Project.Get().AssetPath, currentDirRight).Replace("\\", "/").Replace(".", "");
            string[] path = pathrelative.Split("/");

            List<string> list = new List<string>();
            list.Add("Assets");

            for (int i = 0; i < path.Length;i++) 
            {
                if (!path[i].Equals("")) 
                {
                    list.Add(path[i]);
                }
                
            }

            return list;
        }

        private void ShowTree(string currentDir)
        {
            foreach (string directory in Directory.GetDirectories(currentDir))
            {
                if (ImGui.TreeNodeEx(Icon.FOLDERO + " " + Path.GetFileName(Path.GetDirectoryName(directory + "/t.txt")), ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick))
                {
                    if (ImGui.IsItemClicked() && (ImGui.GetMousePos().X - ImGui.GetItemRectMin().X) > ImGui.GetTreeNodeToLabelSpacing())
                    {
                        ChangeDir(directory);
                    }

                    ShowTree(directory);

                    ShowFiles(directory);

                    

                    ImGui.TreePop();
                }

               
            }

            ShowFiles(currentDir);
        }

        private void ChangeDir(string directory)
        {
            currentDirRight = directory;
            Logger.Log("CurrentDir:" + currentDirRight);
        }


        /// <summary>Gets the path list.</summary>
        /// <param name="path">The path.</param>
        /// <returns>Return list</returns>
        private List<string> GetPathList(string path)
        {
            pathFolders.Clear();
            string[] folders = path.Split("/");
            bool show = false;
            for (int i = 0; i < folders.Length ; i++)
            {
                if (folders[i].Equals("Assets")) 
                {
                    show = true;
                }

                if (show) 
                {
                    string directoryName = folders[i];
                    pathFolders.Add(directoryName);
                }
            }

            return pathFolders;
        }

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

    }
}
