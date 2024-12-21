// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetsWindow.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Alis.App.Engine.Core;
using Alis.App.Engine.Entity;
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The assets window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class AssetsWindow : IWindow
    {
        /// <summary>
        /// The folder open
        /// </summary>
        private static readonly string WindowName = $"{FontAwesome5.FolderOpen} Assets";

        /// <summary>
        ///     The command ptr
        /// </summary>
        private IntPtr commandPtr;

        /// <summary>
        ///     The is open
        /// </summary>
        private bool isOpen = true;

        /// <summary>
        /// The directory separator char
        /// </summary>
        private string CurrentPath = $"{Path.DirectorySeparatorChar}Assets";

        /// <summary>
        /// The file audio
        /// </summary>
        private Dictionary<string, string> fileIcons = new Dictionary<string, string>
        {
            {".png", FontAwesome5.FileImage},
            {".jpg", FontAwesome5.FileImage},
            {".jpeg", FontAwesome5.FileImage},
            {".bmp", FontAwesome5.FileImage},
            {".gif", FontAwesome5.FileImage},
            {".mp3", FontAwesome5.FileAudio},
            {".wav", FontAwesome5.FileAudio},
            {".ogg", FontAwesome5.FileAudio},
            {".cs", FontAwesome5.FileCode},
            {".txt", FontAwesome5.FileAlt},
            {".pdf", FontAwesome5.FilePdf},
            {".doc", FontAwesome5.FileWord},
            {".docx", FontAwesome5.FileWord},
            {".xls", FontAwesome5.FileExcel},
            {".xlsx", FontAwesome5.FileExcel},
            {".ppt", FontAwesome5.FilePowerpoint},
            {".pptx", FontAwesome5.FilePowerpoint},
            {".zip", FontAwesome5.FileArchive},
            {".rar", FontAwesome5.FileArchive},
            {".7z", FontAwesome5.FileArchive},
            {".tar", FontAwesome5.FileArchive},
            {".gz", FontAwesome5.FileArchive},
            {".html", FontAwesome5.FileCode},
            {".css", FontAwesome5.FileCode},
            {".js", FontAwesome5.FileCode},
            {".json", FontAwesome5.FileCode},
            {".xml", FontAwesome5.FileCode},
            {".md", FontAwesome5.FileAlt},
            {".cpp", FontAwesome5.FileCode},
            {".h", FontAwesome5.FileCode},
            {".hpp", FontAwesome5.FileCode},
            {".py", FontAwesome5.FileCode},
            {".java", FontAwesome5.FileCode},
            {".rb", FontAwesome5.FileCode},
            {".php", FontAwesome5.FileCode},
            {".sql", FontAwesome5.FileCode},
            {".exe", FontAwesome5.File},
            {".dll", FontAwesome5.File},
            {".bat", FontAwesome5.File},
            {".sh", FontAwesome5.File},
            {".iso", FontAwesome5.FileArchive},
            {".dmg", FontAwesome5.FileArchive},
            {".svg", FontAwesome5.FileImage},
            {".psd", FontAwesome5.FileImage},
            {".ai", FontAwesome5.FileImage},
            {".eps", FontAwesome5.FileImage},
            {".ttf", FontAwesome5.Font},
            {".otf", FontAwesome5.Font},
            {".woff", FontAwesome5.Font},
            {".woff2", FontAwesome5.Font},
            {".eot", FontAwesome5.Font},
            {".mp4", FontAwesome5.FileVideo},
            {".avi", FontAwesome5.FileVideo},
            {".mkv", FontAwesome5.FileVideo},
            {".mov", FontAwesome5.FileVideo},
            {".wmv", FontAwesome5.FileVideo},
            {".flv", FontAwesome5.FileVideo},
            {".webm", FontAwesome5.FileVideo},
            {".m4v", FontAwesome5.FileVideo},
            {".3gp", FontAwesome5.FileVideo},
            {".3g2", FontAwesome5.FileVideo},
            {".m4a", FontAwesome5.FileAudio},
            {".aac", FontAwesome5.FileAudio},
            {".flac", FontAwesome5.FileAudio},
            {".aiff", FontAwesome5.FileAudio},
            {".wma", FontAwesome5.FileAudio},
            {".mid", FontAwesome5.FileAudio},
            {".midi", FontAwesome5.FileAudio},
        };

        /// <summary>
        /// The ignore patterns
        /// </summary>
        private string[] ignorePatterns = new[] {"*.meta", "*.tmp", ".DS_Store"};

        /// <summary>
        ///     Initializes a new instance of the <see cref="AssetsWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public AssetsWindow(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;
            commandPtr = Marshal.AllocHGlobal(256);
        }

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            if (!isOpen)
            {
                return;
            }

            if (ImGui.Begin(WindowName, ref isOpen))
            {
                ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.13f, 0.14f, 0.15f, 1.0f));
                ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.13f, 0.14f, 0.15f, 1.0f));

                ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f);

                ImGui.SetNextItemWidth(32);
                if (ImGui.BeginCombo("##Plus", $"{FontAwesome5.Plus}", ImGuiComboFlags.HeightLargest | ImGuiComboFlags.NoArrowButton))
                {
                    ImGui.Separator();

                    // Opciones principales
                    if (ImGui.Selectable("Folder"))
                    {
                    }

                    if (ImGui.Selectable("Material"))
                    {
                    }

                    if (ImGui.Selectable("MonoBehaviour Script"))
                    {
                    }

                    ImGui.TextDisabled("Prefab Variant"); // Opción deshabilitada

                    ImGui.Separator();

                    // Submenús
                    if (ImGui.BeginMenu("2D"))
                    {
                        // Agrega opciones específicas de 2D aquí si es necesario
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Animation"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Audio"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Rendering"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Scene"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Scripting"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Search"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Shader"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Shader Graph"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Testing"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Terrain"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Text Core"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("TextMeshPro"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Tutorials"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("Timeline"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("UI Toolkit"))
                    {
                        ImGui.EndMenu();
                    }

                    ImGui.Separator();

                    // Opciones finales
                    if (ImGui.Selectable("Physics Material"))
                    {
                    }

                    if (ImGui.Selectable("GUI Skin"))
                    {
                    }

                    if (ImGui.Selectable("Custom Font"))
                    {
                    }

                    ImGui.EndCombo();
                }


                ImGui.PopStyleVar(1);
                ImGui.PopStyleColor(2);

                RenderAssets();

                //ImGui.EndColumns(); // Finalizar las columnas
            }

            ImGui.End();
        }


        /// <summary>
        /// Renders the search bar
        /// </summary>
        private void RenderSearchBar()
        {
            ImGui.SameLine();
            ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X - 30);

            // Renderiza el cuadro de texto personalizado
            
            
            if (ImGui.InputText("##SearchBar",  commandPtr, 256, ImGuiInputTextFlags.AlwaysOverwrite))
            {
                searchText = Marshal.PtrToStringAnsi(commandPtr);
                Console.WriteLine(searchText);
            }
            
            ImGui.SameLine();
            ImGui.Text($"{FontAwesome5.Search}");
            
            ImGui.Separator();
        }


        /// <summary>
        /// Renders the files on folder using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        private void RenderFilesOnFolder(string text)
        {
            string path = $"{SpaceWork.Project.Path}{CurrentPath}";

            // Get all directories and files in the directory
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            // Filter out the files that match the ignore patterns
            files = files.Where(file => !ignorePatterns.Any(pattern => Path.GetFileName(file).Equals(pattern, StringComparison.OrdinalIgnoreCase))).ToArray();

            // Filter directories and files based on search text
            directories = directories.Where(d => Path.GetFileName(d).Contains(text, StringComparison.OrdinalIgnoreCase)).ToArray();
            files = files.Where(f => Path.GetFileName(f).Contains(text, StringComparison.OrdinalIgnoreCase)).ToArray();

            // Create a child window for scrolling
            ImGui.BeginChild("FilesAndFoldersRegion", ImGui.GetContentRegionAvail(), true, ImGuiWindowFlags.HorizontalScrollbar);

            // Set the width and height of each item (button + icon)
            float itemWidth = 50.0f; // Width of each item
            float itemHeight = 50.0f; // Height of each item
            float itemPadding = 20.0f; // Padding between items
            int minColumns = 1; // Número mínimo de columnas
            int columns = Math.Max(minColumns, (int) (ImGui.GetContentRegionAvail().X / (itemWidth + itemPadding))); // Número de columnas

            // Create a table to render items in multiple lines
            if (ImGui.BeginTable("FilesAndFoldersTable", columns, ImGuiTableFlags.SizingStretchProp))
            {
                // Render directories
                foreach (string directory in directories)
                {
                    ImGui.TableNextColumn();
                    string folderName = Path.GetFileName(directory);

                    ImGui.PushFont(SpaceWork.fontLoaded45Bold);
                    ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0, 0, 0, 0)); // Transparent background
                    ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(0, 0)); // No padding
                    ImGui.PushStyleVar(ImGuiStyleVar.SelectableTextAlign, new Vector2F(0.5f, 0.5f)); // Center text
                    ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f); // No border

                    if (ImGui.Selectable($"{FontAwesome5.Folder}##{folderName}", false, ImGuiSelectableFlags.AllowDoubleClick, new Vector2F(itemWidth, itemHeight)))
                    {
                        if (ImGui.IsItemHovered() && ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                        {
                            CurrentPath = Path.Combine(CurrentPath, folderName);
                        }
                    }

                    ImGui.PopStyleVar(3);
                    ImGui.PopStyleColor();
                    ImGui.PopFont();

                    ImGui.PushFont(SpaceWork.fontLoaded10Solid);
                    float textWidth = ImGui.CalcTextSize(folderName).X;
                    ImGui.SetCursorPosX(ImGui.GetCursorPosX() + (itemWidth - textWidth) * 0.05f);
                    ImGui.TextWrapped(folderName);
                    ImGui.Dummy(new Vector2F(0, itemPadding)); // Add padding between items
                    ImGui.PopFont();
                }

                // Render files
                foreach (string file in files)
                {
                    ImGui.TableNextColumn();
                    string extension = Path.GetExtension(file).ToLower();
                    string icon = fileIcons.ContainsKey(extension) ? fileIcons[extension] : FontAwesome5.File;

                    ImGui.PushFont(SpaceWork.fontLoaded45Bold);
                    ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0, 0, 0, 0)); // Transparent background
                    ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(0, 0)); // No padding
                    ImGui.PushStyleVar(ImGuiStyleVar.SelectableTextAlign, new Vector2F(0.5f, 0.5f)); // Center text
                    ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f); // No border

                    if (ImGui.Selectable($"{icon}##{Path.GetFileName(file)}", false, ImGuiSelectableFlags.AllowDoubleClick, new Vector2F(itemWidth, itemHeight)))
                    {
                        if (ImGui.IsItemHovered() && ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                        {
                            // Acción a realizar al hacer doble clic en el archivo
                        }
                    }

                    ImGui.PopStyleVar(3);
                    ImGui.PopStyleColor();
                    ImGui.PopFont();

                    ImGui.PushFont(SpaceWork.fontLoaded10Solid);
                    float textWidth = ImGui.CalcTextSize(Path.GetFileName(file)).X;
                    ImGui.SetCursorPosX(ImGui.GetCursorPosX() + (itemWidth - textWidth) * 0.05f);
                    ImGui.TextWrapped(Path.GetFileNameWithoutExtension(file));
                    ImGui.Dummy(new Vector2F(0, itemPadding)); // Add padding between items
                    ImGui.PopFont();
                }

                // Fill remaining columns with invisible items
                int totalItems = directories.Length + files.Length;
                int emptyItems = columns - (totalItems % columns);
                if (emptyItems < columns)
                {
                    for (int i = 0; i < emptyItems; i++)
                    {
                        ImGui.TableNextColumn();
                        ImGui.Dummy(new Vector2F(itemWidth, itemHeight)); // Invisible item to fill space
                    }
                }

                ImGui.EndTable();
            }

            ImGui.EndChild();
        }


        /// <summary>
        /// Renders the assets
        /// </summary>
        private void RenderAssets()
        {
            ImGui.SameLine();
            ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X - 30);
            //ImGui.InputText($"{FontAwesome5.Search}", commandPtr, 256);
            RenderSearchBar();

            ImGui.Separator();

            ImGui.Columns(2);

            if (IsDefaultSize)
            {
                ImGui.SetColumnWidth(0, 200);
                IsDefaultSize = false;
            }

            float currentWidth = ImGui.GetColumnWidth(0);

            // Configurar límites de la columna
            float minWidth = 200.0f;
            float maxWidth = 350.0f;

            // Ajustar el ancho dentro de los límites
            if (currentWidth < minWidth)
            {
                ImGui.SetColumnWidth(0, minWidth);
            }

            if (currentWidth > maxWidth)
            {
                ImGui.SetColumnWidth(0, maxWidth);
            }

            RenderFolders();

            ImGui.NextColumn();

            // Contenido de la segunda columna
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.13f, 0.14f, 0.15f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.13f, 0.14f, 0.15f, 1.0f));

            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(0, 7));
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2F(2, 5));

            RenderPathOfFolder();

            ImGui.PopStyleVar(3);
            ImGui.PopStyleColor(2);

            ImGui.BeginChild("ScrollingRegion", ImGui.GetContentRegionAvail(), false, ImGuiWindowFlags.HorizontalScrollbar);

            if (string.IsNullOrEmpty(searchText))
            {
                RenderFilesOnFolder();
            }
            else
            {
                RenderFilesOnFolder(searchText);
            }

            ImGui.EndChild();
        }

        /// <summary>
        /// Gets or sets the value of the is default size
        /// </summary>
        public bool IsDefaultSize { get; set; } = true;

        /// <summary>
        /// Renders the folders
        /// </summary>
        private void RenderFolders()
        {
            string path = Path.Combine(SpaceWork.Project.Path, "Assets");

            // Create a child window for scrolling
            ImGui.BeginChild("FoldersRegion", ImGui.GetContentRegionAvail(), true, ImGuiWindowFlags.HorizontalScrollbar);

            RenderDirectory(path, true);

            ImGui.EndChild();
        }

        /// <summary>
        /// The is move directory
        /// </summary>
        private bool IsMoveDirectory = false;
        /// <summary>
        /// The search text
        /// </summary>
        private string searchText = "";

        /// <summary>
        /// Renders the directory using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="isRoot">The is root</param>
        private void RenderDirectory(string path, bool isRoot = false)
        {
            if (isRoot)
            {
                ImGui.TreeNodeEx($"{FontAwesome5.FolderOpen} Assets", ImGuiTreeNodeFlags.Leaf | ImGuiTreeNodeFlags.DefaultOpen);
                if (ImGui.IsItemHovered() && ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                {
                    CurrentPath = $"{Path.DirectorySeparatorChar}Assets";
                }

                RenderSubDirectories(path);
                IsMoveDirectory = false;
                ImGui.TreePop();
            }
            else
            {
                string folderName = Path.GetFileName(path);
                string[] subDirectories = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);

                if (subDirectories.Length > 0)
                {
                    if (ImGui.TreeNodeEx($"{FontAwesome5.Folder} {folderName}", ImGuiTreeNodeFlags.DefaultOpen | ImGuiTreeNodeFlags.OpenOnArrow))
                    {
                        if (ImGui.IsItemHovered() && ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left) && !IsMoveDirectory)
                        {
                            string relativePath = path.Replace(SpaceWork.Project.Path, "");
                            CurrentPath = relativePath.StartsWith($"{Path.DirectorySeparatorChar}") ? relativePath : $"{Path.DirectorySeparatorChar}{relativePath}";
                            IsMoveDirectory = true;
                        }
                        
                        RenderSubDirectories(path);
                        ImGui.TreePop();
                    }
                }
                else
                {
                    ImGui.TreeNodeEx($"{FontAwesome5.Folder} {folderName}", ImGuiTreeNodeFlags.Leaf | ImGuiTreeNodeFlags.NoTreePushOnOpen);
                    if (ImGui.IsItemHovered() && ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left) && !IsMoveDirectory)
                    {
                        string relativePath = path.Replace(SpaceWork.Project.Path, "");
                        CurrentPath = relativePath.StartsWith($"{Path.DirectorySeparatorChar}") ? relativePath : $"{Path.DirectorySeparatorChar}{relativePath}";
                        IsMoveDirectory = true;
                    }
                }

                
            }
        }

        /// <summary>
        /// Renders the sub directories using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        private void RenderSubDirectories(string path)
        {
            string[] folders = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);

            foreach (string folder in folders)
            {
                RenderDirectory(folder);
            }
        }

        /// <summary>
        /// Renders the path of folder
        /// </summary>
        private void RenderPathOfFolder()
        {
            // Divide the path into folders:
            string[] folders = CurrentPath.Split(new[] {Path.DirectorySeparatorChar}, StringSplitOptions.RemoveEmptyEntries);

            // If only the "Assets" folder is present, render a button with the name "Assets"
            if (folders.Length == 1 && folders[0] == "Assets")
            {
                if (ImGui.Button("Assets"))
                {
                    CurrentPath = $"{Path.DirectorySeparatorChar}Assets";
                }
            }
            else
            {
                string path = "";
                for (int i = 0; i < folders.Length; i++)
                {
                    path = Path.Combine(path, folders[i]);

                    if (ImGui.Button(folders[i]))
                    {
                        CurrentPath = $"{Path.DirectorySeparatorChar}{path}";
                    }

                    if (i < folders.Length - 1)
                    {
                        ImGui.SameLine();
                        ImGui.Text($"{Path.DirectorySeparatorChar}");
                        ImGui.SameLine();
                    }
                }
            }
        }

        /// <summary>
        /// Renders the files on folder
        /// </summary>
        private void RenderFilesOnFolder()
        {
            string path = $"{SpaceWork.Project.Path}{CurrentPath}";

            // Get all directories and files in the directory
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            // Filter out the files that match the ignore patterns
            files = files.Where(file => !ignorePatterns.Any(pattern => Path.GetFileName(file).Equals(pattern, StringComparison.OrdinalIgnoreCase))).ToArray();

            // Create a child window for scrolling
            if (ImGui.BeginChild("FilesAndFoldersRegion", ImGui.GetContentRegionAvail(), true, ImGuiWindowFlags.HorizontalScrollbar))
            {

                // Set the width and height of each item (button + icon)
                float itemWidth = 50.0f; // Width of each item
                float itemHeight = 50.0f; // Height of each item
                float itemPadding = 20.0f; // Padding between items
                int minColumns = 1; // Número mínimo de columnas
                int columns = Math.Max(minColumns, (int) (ImGui.GetContentRegionAvail().X / (itemWidth + itemPadding))); // Número de columnas

                // Create a table to render items in multiple lines
                if (ImGui.BeginTable("FilesAndFoldersTable", columns, ImGuiTableFlags.SizingStretchProp))
                {
                    // Render directories
                    foreach (string directory in directories)
                    {
                        ImGui.TableNextColumn();
                        string folderName = Path.GetFileName(directory);

                        ImGui.PushFont(SpaceWork.fontLoaded45Bold);
                        ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0, 0, 0, 0)); // Transparent background
                        ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(0, 0)); // No padding
                        ImGui.PushStyleVar(ImGuiStyleVar.SelectableTextAlign, new Vector2F(0.5f, 0.5f)); // Center text
                        ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f); // No border

                        if (ImGui.Selectable($"{FontAwesome5.Folder}##{folderName}", false, ImGuiSelectableFlags.AllowDoubleClick, new Vector2F(itemWidth, itemHeight)))
                        {
                            if (ImGui.IsItemHovered() && ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                            {
                                CurrentPath = Path.Combine(CurrentPath, folderName);
                            }
                        }

                        ImGui.PopStyleVar(3);
                        ImGui.PopStyleColor();
                        ImGui.PopFont();

                        ImGui.PushFont(SpaceWork.fontLoaded10Solid);
                        float textWidth = ImGui.CalcTextSize(folderName).X;
                        ImGui.SetCursorPosX(ImGui.GetCursorPosX() + (itemWidth - textWidth) * 0.05f);
                        ImGui.TextWrapped(folderName);
                        ImGui.Dummy(new Vector2F(0, itemPadding)); // Add padding between items
                        ImGui.PopFont();
                    }

                    // Render files
                    foreach (string file in files)
                    {
                        ImGui.TableNextColumn();
                        string extension = Path.GetExtension(file).ToLower();
                        string icon = fileIcons.ContainsKey(extension) ? fileIcons[extension] : FontAwesome5.File;

                        ImGui.PushFont(SpaceWork.fontLoaded45Bold);
                        ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0, 0, 0, 0)); // Transparent background
                        ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(0, 0)); // No padding
                        ImGui.PushStyleVar(ImGuiStyleVar.SelectableTextAlign, new Vector2F(0.5f, 0.5f)); // Center text
                        ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f); // No border

                        if (ImGui.Selectable($"{icon}##{Path.GetFileName(file)}", false, ImGuiSelectableFlags.AllowDoubleClick, new Vector2F(itemWidth, itemHeight)))
                        {
                            if (ImGui.IsItemHovered() && ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                            {
                                // Acción a realizar al hacer doble clic en el archivo
                            }
                        }

                        ImGui.PopStyleVar(3);
                        ImGui.PopStyleColor();
                        ImGui.PopFont();

                        ImGui.PushFont(SpaceWork.fontLoaded10Solid);
                        float textWidth = ImGui.CalcTextSize(Path.GetFileName(file)).X;
                        ImGui.SetCursorPosX(ImGui.GetCursorPosX() + (itemWidth - textWidth) * 0.05f);
                        ImGui.TextWrapped(Path.GetFileNameWithoutExtension(file));
                        ImGui.Dummy(new Vector2F(0, itemPadding)); // Add padding between items
                        ImGui.PopFont();
                    }

                    // Fill remaining columns with invisible items
                    int totalItems = directories.Length + files.Length;
                    int emptyItems = columns - (totalItems % columns);
                    if (emptyItems < columns)
                    {
                        for (int i = 0; i < emptyItems; i++)
                        {
                            ImGui.TableNextColumn();
                            ImGui.Dummy(new Vector2F(itemWidth, itemHeight)); // Invisible item to fill space
                        }
                    }

                    ImGui.EndTable();
                }
            }

            ImGui.EndChild();
        }
    }
}