//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="FileDialog.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Numerics;
    using Alis.Editor.Utils;
    using ImGuiNET;

    /// <summary>File Dialog</summary>
    public class FileDialog : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "Dialog";

        /// <summary>The is open</summary>
        private bool isOpen;

        /// <summary>The current dir</summary>
        private string currentDirRight = string.Empty;

        private string elementTaked = string.Empty;

        private string[] formats;

        private string currentFormat = "*";

        private bool selected = true;

        private bool takeFile;

       

        #region Components

        /// <summary>The filter</summary>
        private ImGuiTextFilterPtr filter;

        private List<string> templist = new List<string>();

        private List<string> directAcces = new List<string>() { Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) , Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) };

        #endregion


        #region Config

        /// <summary>The size widget</summary>
        private Vector2 sizeWidget = new Vector2(640, 480);

        /// <summary>The size child </summary>
        private Vector2 sizeChild = new Vector2(0f, 0f);

        /// <summary>The configuration popup</summary>
        private ImGuiWindowFlags configPopup = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoSavedSettings | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoDecoration;

        /// <summary>The item spacing</summary>
        private Vector2 itemSpacing = new Vector2(8.0f, 8.0f);

        /// <summary>The child border size</summary>
        private float childBorderSize = 2.0f;

        #endregion

        #region Colors

        /// <summary>The red color</summary>
        private Vector4 redColor = new Vector4(0.654f, 0.070f, 0.070f, 1.000f);

        /// <summary>The white color</summary>
        private Vector4 whiteColor = new Vector4(1, 1, 1, 1);

        /// <summary>The child background</summary>
        private Vector4 childBackground = new Vector4(0, 0, 0, 0);

        public string ElementTaked { get => elementTaked; set => elementTaked = value; }

        private bool confirmedElement = false;

        public bool ConfirmedElement
        {
            get
            {
                if (confirmedElement)
                {
                    confirmedElement = false;
                    return true;
                }
                else 
                {
                    return false;
                }
            }
        }

        #endregion

        public FileDialog(string defaultDir, bool takeFile, string defaultFormat, string[] formats)
        {
            this.takeFile = takeFile;
            isOpen = true;
            currentDirRight = defaultDir;
            this.formats = formats;
            this.currentFormat = defaultFormat;

            unsafe
            {
                ImGuiTextFilter* filterPtr = ImGuiNative.ImGuiTextFilter_ImGuiTextFilter(null);
                filter = new ImGuiTextFilterPtr(filterPtr);
            }
        }

        public void OpenDialog() 
        {
            WidgetManager.Add(this);
        }

        public override void Draw()
        {
            PushStyle();

            ImGui.OpenPopup(Name);
            if (ImGui.BeginPopupModal(Name, ref isOpen, configPopup))
            {
                if (ImGui.BeginChild("Master", sizeWidget, false))
                {
                    ShowLeftSize();
                    ShowRightSize();
                    ShowElementTaker();
                    ImGui.EndChild();
                }
            }

            PopStyle();
            
        }

        private void ShowElementTaker()
        {
            if (!takeFile) 
            {
                elementTaked = currentDirRight.Replace("\\", "/"); ;
            }

            ImGui.InputText(takeFile ? "File" : "Directory",ref elementTaked, 128);
            
            ImGui.SameLine();

            ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
            if (ImGui.BeginCombo("##Mode", currentFormat))
            {
                for (int n = 0; n < formats.Length; n++)
                {
                    selected = currentFormat == formats[n];
                    if (ImGui.Selectable(formats[n], selected))
                    {
                        currentFormat = formats[n];
                    }

                    if (selected)
                    {
                        ImGui.SetItemDefaultFocus();
                    }
                }

                ImGui.EndCombo();
            }

            ImGui.PopItemWidth();

            #region Cancel Create Project Button

            if (ImGui.Button("Cancel ", new Vector2(ImGui.GetContentRegionAvail().X / 2, 40.0f)))
            {
                CancelFileDialog();
            }

            ImGui.SameLine();

            #endregion

            #region Create Project Button

            if (ImGui.Button(takeFile ? "Open Project" : "Open Folder", new Vector2(ImGui.GetContentRegionAvail().X, 40.0f)))
            {
                OpenSelected(elementTaked);
            }

            #endregion

        }

        private void OpenSelected(string elementTaked)
        {
            if (takeFile)
            {

                if (!elementTaked.Equals(string.Empty))
                {
                    confirmedElement = true;
                    Close();
                }
            }
            else 
            {
                elementTaked = currentDirRight.Replace("\\", "/");
                confirmedElement = true;
                Close();
            }
        }

        private void CancelFileDialog()
        {
            confirmedElement = false;
            elementTaked = string.Empty;
            Close();
        }

        private void Close()
        {
            isOpen = false;
            WidgetManager.Delete(this);
        }

        private void ShowLeftSize()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(1.0f, 3.0f));
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0, 0, 0, 0));
            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0f);

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

            ImGui.PopStyleVar(2);
            ImGui.PopStyleColor();

            ImGui.NewLine();

            filter.Draw(Icon.SEARCH + string.Empty, ImGui.GetContentRegionAvail().X - 20.0f);

            if (filter.IsActive() && !currentFormat.Equals("*"))
            {
                templist.Clear();

                foreach (string directory in Directory.GetDirectories(currentDirRight))
                {
                    if (filter.PassFilter(Path.GetDirectoryName(directory)))
                    {
                        templist.Add(directory);
                    }
                }


                foreach (string file in Directory.GetFiles(currentDirRight))
                {
                    if (filter.PassFilter(Path.GetFileName(file)))
                    {
                        templist.Add(file);
                    }
                }
            }

            ImGui.Separator();

            ImGui.PushStyleColor(ImGuiCol.Border, whiteColor);
            if (ImGui.BeginChild("Master-Child-Left", new Vector2(ImGui.GetContentRegionAvail().X / 3, ImGui.GetContentRegionAvail().Y - 100), true))
            {
                ImGui.PopStyleColor();

                ImGui.Text("Quick access: ");

                foreach (string directory in directAcces)
                {
                    ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 7.0f));
                    ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 0.0f);
                    ImGui.BeginGroup();

                    ImGui.PushStyleVar(ImGuiStyleVar.ButtonTextAlign, new Vector2(0f, 0.5f));

                    if (ImGui.Button(Icon.FOLDER + " " + new DirectoryInfo(directory).Name, new Vector2(ImGui.GetContentRegionAvail().X - 30.0f, 30.0f)))
                    {
                        ChangeDir(directory);
                    }

                    ImGui.PopStyleVar();

                    ImGui.EndGroup();
                    ImGui.PopStyleVar(2);
                }

                ImGui.EndChild();
            }

            ImGui.SameLine();
        }

        private void ShowRightSize()
        {
            ImGui.PushStyleColor(ImGuiCol.Border, whiteColor);
            if (ImGui.BeginChild("Master-Child-Right", new Vector2(ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y - 100), true))
            {
                ImGui.PopStyleColor();

                if (filter.IsActive())
                {
                    if (templist.Count > 0) 
                    {
                        foreach (string element in templist) 
                        {
                            if (Path.GetExtension(element) != null)
                            {
                                PrintFile(element);
                            }
                            else 
                            {
                                if (currentFormat.Equals("*"))
                                {
                                    PrintFile(element);
                                }
                                else
                                {
                                    if (Path.GetExtension(element).Equals(currentFormat))
                                    {
                                        PrintFile(element);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (string directory in Directory.GetDirectories(currentDirRight))
                    {
                        PrintDir(directory);
                    }

                    foreach (string file in Directory.GetFiles(currentDirRight))
                    {
                        if (currentFormat.Equals("*"))
                        {
                            PrintFile(file);
                        }
                        else 
                        {
                            if (Path.GetExtension(file).Equals(currentFormat)) 
                            {
                                PrintFile(file);
                            }
                        }                       
                    }
                }

                ImGui.EndChild();
            }
        }

        private void PrintDir(string directory) 
        {
            if (!directory.Equals(string.Empty))
            {
                ImGui.PushStyleVar(ImGuiStyleVar.ButtonTextAlign, new Vector2(0f, 0.5f));

                if (ImGui.Button(Icon.FOLDERO + " " + new DirectoryInfo(directory).Name, new Vector2(ImGui.GetContentRegionAvail().X, 25.0f)))
                {
                    ChangeDir(directory);
                }

                ImGui.PopStyleVar();
            }
        }

        private void PrintFile(string file) 
        {
            if (!file.Equals(string.Empty))
            {
                ImGui.PushStyleVar(ImGuiStyleVar.ButtonTextAlign, new Vector2(0f, 0.5f));

                if (ImGui.Button(Icon.FILETEXT + " " + Path.GetFileName(file), new Vector2(ImGui.GetContentRegionAvail().X, 25.0f)))
                {
                    if (takeFile) 
                    {
                        elementTaked = file;
                    }
                }

                ImGui.PopStyleVar();
            }
        }

        #region GetNameDir

        private List<string> GetNameDir(string directory)
        {
            List<string> list = new List<string>();
            string pathrelative = directory.Replace("\\", "/");

            if (!pathrelative.Equals(string.Empty))
            {
                string[] path = pathrelative.Split("/");
                for (int i = 0; i < path.Length; i++)
                {
                    if (!path[i].Equals(""))
                    {
                        list.Add(path[i]);
                    }

                }
            }

            return list;
        }

        #endregion

        #region MoveToDir

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

        #endregion

        private void ChangeDir(string directory)
        {
            currentDirRight = directory;
        }

        #region Style

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

        #endregion
    }
}
