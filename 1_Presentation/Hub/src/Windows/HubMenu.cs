// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HubMenu.cs
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
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Alis.App.Engine.Fonts;
using Alis.App.Hub.Core;
using Alis.App.Hub.Entity;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;
using Alis.Extension.Graphic.OpenGL;
using Alis.Extension.Graphic.OpenGL.Enums;
using Alis.Extension.Graphic.Sdl2Image;
using PixelFormat = Alis.Extension.Graphic.OpenGL.Enums.PixelFormat;

namespace Alis.App.Hub.Windows
{
    /// <summary>
    ///     The hub menu class
    /// </summary>
    public class HubMenu
    {
        /// <summary>
        /// The gallery
        /// </summary>
        private readonly Gallery2 gallery = new Gallery2();

        /// <summary>
        ///     The gamepad
        /// </summary>
        private readonly string[] menuItems =
        {
            $"{FontAwesome5.Cube} Projects",
            $"{FontAwesome5.Download} Installs",
            $"{FontAwesome5.Book} Learn",
            $"{FontAwesome5.Gamepad} Community"
        };

        /// <summary>
        ///     The project
        /// </summary>
        private readonly List<Project> projects = new List<Project>
        {
            new Project("MacOS Project", "/Users/pabllopf/Repositorios/Alis/1_Presentation/Engine/sample/alis.app.engine.sample", "NOT CONNECTED", "3 days ago", "0.4.5"),
            new Project("MacOS Project(latest)", "/Users/pabllopf/Repositorios/Alis/1_Presentation/Engine/sample/alis.app.engine.sample", "NOT CONNECTED", "3 days ago", "latest"),
            new Project("Windows Project", "C:/Repositorios/Alis/1_Presentation/Engine/sample/alis.app.engine.sample", "NOT CONNECTED", "5 minutes", "0.4.4")
        };

        /// <summary>
        ///     The space work
        /// </summary>
        private readonly SpaceWork spaceWork;

        /// <summary>
        /// The search query
        /// </summary>
        private string searchQuery = string.Empty;

        /// <summary>
        ///     The selected menu item
        /// </summary>
        private int selectedMenuItem;

        /// <summary>
        /// The selected project index
        /// </summary>
        private int selectedProjectIndex = -1;
        /// <summary>
        /// The show documentation
        /// </summary>
        private bool showDocumentation;
        /// <summary>
        /// The show tips
        /// </summary>
        private bool showTips;

        /// <summary>
        /// The show tutorials
        /// </summary>
        private bool showTutorials;

        /// <summary>
        /// The show videos
        /// </summary>
        private bool showVideos;
        //private string searchQuery = " ";  // Variable para el buscador

        /// <summary>
        ///     Initializes a new instance of the <see cref="HubMenu" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public HubMenu(SpaceWork spaceWork) => this.spaceWork = spaceWork;

        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            ImGuiIoPtr io = ImGui.GetIo();
            Vector2F screenSize = io.DisplaySize;

            ImGui.SetNextWindowPos(Vector2F.Zero);
            ImGui.SetNextWindowSize(screenSize);

            ImGui.Begin("##MainWindow", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove);

            ImGui.BeginChild("Sidebar", new Vector2F(220, screenSize.Y - 20), true);

            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(10, 10));
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2F(10, 10));

            // Mostrar el logo y el texto "ALIS"
            if (File.Exists(AssetManager.Find("Hub_logo.bmp")))
            {
                // Cargar y mostrar la imagen a una resolución más alta
                IntPtr textureId = LoadTextureFromFile(AssetManager.Find("Hub_logo.bmp"));
                float iconSize = 50; // Aumenta el tamaño de la imagen
                ImGui.Image(textureId, new Vector2F(iconSize, iconSize)); // Mostrar imagen más grande
                ImGui.SameLine();

                // Cambiar el tamaño de la fuente para que el texto sea más grande
                ImGui.PushFont(spaceWork.fontLoaded45Bold); // Asegúrate de usar una fuente adecuada

                // Centrar el texto "ALIS" vertical y horizontalmente con la imagen
                Vector2F textSize = ImGui.CalcTextSize("ALIS");
                float textX = (iconSize - textSize.X) / 2; // Centrado horizontal
                float textY = (iconSize - textSize.Y) / 2; // Centrado vertical

                //ImGui.SetCursorPosX(ImGui.GetCursorPosX() + textX); // Centrar en el eje X
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() + textY); // Centrar en el eje Y
                ImGui.Text("ALIS");

                ImGui.PopFont(); // Restaurar la fuente predeterminada
            }

            ImGui.Separator();
            ImGui.PopStyleVar(2);

            ButtonsLeftMenu();

            ImGui.SetCursorPosY(screenSize.Y - 70);
            if (ImGui.Button($"{FontAwesome5.Cog} Preferences", new Vector2F(200, 40)))
            {
            }

            ImGui.EndChild();

            ImGui.SameLine();
            ImGui.BeginChild("MainContent", new Vector2F(screenSize.X - 220, screenSize.Y - 20), false);
            RenderMainContent();
            ImGui.EndChild();

            ImGui.End();
        }

        /// <summary>
        ///     Buttonses the left menu
        /// </summary>
        private void ButtonsLeftMenu()
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                // Definir los estilos antes de cada botón
                ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 5.0f); // Redondear las esquinas
                ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2F(10, 10)); // Espaciado entre los items
                ImGui.PushStyleVar(ImGuiStyleVar.ButtonTextAlign, new Vector2F(0, 0.5f));

                // Crear el botón con la alineación adecuada
                if (ImGui.Button(menuItems[i], new Vector2F(200, 40)))
                {
                    selectedMenuItem = i; // Establecer el botón como seleccionado
                }

                // Restaurar los estilos después de cada botón
                ImGui.PopStyleVar(3); // Restaurar ItemSpacing y FrameRounding
            }
        }


        /// <summary>
        ///     Loads the texture from file using the specified file path
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <exception cref="Exception">Failed to load image: {Sdl.GetError()}</exception>
        /// <exception cref="FileNotFoundException">File not found: {filePath}</exception>
        /// <returns>The int ptr</returns>
        private IntPtr LoadTextureFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            // Load image using SDL_image
            IntPtr surface = SdlImage.LoadImg(filePath);
            if (surface == IntPtr.Zero)
            {
                throw new Exception($"Failed to load image: {Sdl.GetError()}");
            }

            // Get image dimensions
            Surface sdlSurface = Marshal.PtrToStructure<Surface>(surface);
            int width = sdlSurface.w;
            int height = sdlSurface.h;

            // Generate OpenGL texture
            uint textureId = Gl.GenTexture();
            Gl.GlBindTexture(TextureTarget.Texture2D, textureId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, sdlSurface.Pixels);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);

            return (IntPtr) textureId;
        }


        /// <summary>
        ///     Renders the main content
        /// </summary>
        private void RenderMainContent()
        {
            ImGui.PushStyleColor(ImGuiCol.ChildBg, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
            if (selectedMenuItem == 0) RenderProjectsSection();
            if (selectedMenuItem == 1) InstallsEditorSection();
            if (selectedMenuItem == 2) LearnSection();
            if (selectedMenuItem == 3) RenderCommunitySection();
            ImGui.PopStyleColor();
        }

        /// <summary>
        /// Learns the section
        /// </summary>
        private void LearnSection()
        {
            // Header for the section
            ImGui.Text("Learn and Explore");
            ImGui.Separator();

            // Apply custom styles for the buttons
            //ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.2f, 0.6f, 0.8f, 1.0f));  // Custom color for the button
            //ImGui.PushStyleColor(ImGuiCol.ButtonHovered, new Vector4F(0.4f, 0.8f, 1.0f, 1.0f));  // Hover color
            //ImGui.PushStyleColor(ImGuiCol.ButtonActive, new Vector4F(0.1f, 0.4f, 0.7f, 1.0f));  // Active color

            // Create buttons as tabs for each section
            if (ImGui.Button("📚 Tutorials"))
            {
                // Handle "Tutorials" tab logic
                showTutorials = true;
                showDocumentation = false;
                showVideos = false;
                showTips = false;
            }

            ImGui.SameLine(); // Place the next button on the same line

            if (ImGui.Button("📖 Documentation"))
            {
                // Handle "Documentation" tab logic
                showTutorials = false;
                showDocumentation = true;
                showVideos = false;
                showTips = false;
            }

            ImGui.SameLine(); // Place the next button on the same line

            if (ImGui.Button("🎥 Videos"))
            {
                // Handle "Videos" tab logic
                showTutorials = false;
                showDocumentation = false;
                showVideos = true;
                showTips = false;
            }

            ImGui.SameLine(); // Place the next button on the same line

            if (ImGui.Button("💡 Tips"))
            {
                // Handle "Tips" tab logic
                showTutorials = false;
                showDocumentation = false;
                showVideos = false;
                showTips = true;
            }

            //ImGui.PopStyleColor(3);  // Reset to default button styles

            // Add a separator
            ImGui.Separator();

            // Display content based on the selected "tab" (button)
            if (showTutorials)
            {
                DisplayTutorials();
            }

            if (showDocumentation)
            {
                DisplayDocumentation();
            }

            if (showVideos)
            {
                DisplayVideos();
            }

            if (showTips)
            {
                DisplayTips();
            }
        }

// Display tutorials in a card-style layout
        /// <summary>
        /// Displays the tutorials
        /// </summary>
        private void DisplayTutorials()
        {
            ImGui.Text("Step-by-Step Tutorials");
            ImGui.Separator();

            List<LearningResource> tutorials = new List<LearningResource>
            {
                new LearningResource("Getting Started", "Learn the basics of the platform", "tutorials/getting_started.html"),
                new LearningResource("Advanced Features", "Dive into advanced functionality", "tutorials/advanced_features.html"),
                new LearningResource("Customization", "Tailor the platform to your needs", "tutorials/customization.html")
            };

            foreach (LearningResource tutorial in tutorials)
            {
                ImGui.BulletText($"{tutorial.Title}: {tutorial.Description}");
                if (ImGui.Button($"Open##{tutorial.Title}"))
                {
                    Process.Start(new ProcessStartInfo(tutorial.Url) {UseShellExecute = true});
                }
            }
        }

// Display documentation with a search bar
        /// <summary>
        /// Displays the documentation
        /// </summary>
        private void DisplayDocumentation()
        {
            string searchQuery = string.Empty;

            ImGui.Text("Search Documentation");
            ImGui.InputText("Search", ref searchQuery, 100);

            ImGui.NewLine();
            ImGui.Text("Popular Topics:");
            ImGui.BulletText("API Reference");
            ImGui.BulletText("Configuration Guide");
            ImGui.BulletText("Deployment Guide");

            if (!string.IsNullOrEmpty(searchQuery))
            {
                ImGui.NewLine();
                ImGui.Text($"Search results for: {searchQuery}");
                ImGui.BulletText("Result 1");
                ImGui.BulletText("Result 2");
                ImGui.BulletText("Result 3");
            }
        }

// Display videos as clickable thumbnails
        /// <summary>
        /// Displays the videos
        /// </summary>
        private void DisplayVideos()
        {
            ImGui.Text("Learning Videos");
            ImGui.Separator();

            List<LearningResource> videos = new List<LearningResource>
            {
                new LearningResource("Introduction Video", "A quick introduction to the platform", "videos/introduction.mp4"),
                new LearningResource("Feature Overview", "Detailed explanation of features", "videos/features.mp4"),
                new LearningResource("Webinar Replay", "Watch a recent webinar", "videos/webinar.mp4")
            };

            foreach (LearningResource video in videos)
            {
                if (ImGui.Button($"▶ {video.Title}"))
                {
                    Process.Start(new ProcessStartInfo(video.Url) {UseShellExecute = true});
                }
            }
        }

// Display random tips
        /// <summary>
        /// Displays the tips
        /// </summary>
        private void DisplayTips()
        {
            List<string> tips = new List<string>
            {
                "Use keyboard shortcuts to speed up your workflow.",
                "Regularly check for updates to stay up-to-date.",
                "Explore community forums for additional support.",
                "Customize your settings for better performance."
            };

            ImGui.Text("Quick Tips");
            ImGui.Separator();

            Random random = new Random();
            ImGui.TextWrapped(tips[random.Next(tips.Count)]);
        }

// Helper class for learning resources


        /// <summary>
        /// Installses the editor section
        /// </summary>
        private void InstallsEditorSection()
        {
            // Display a header for the section
            ImGui.Text("Installed Versions");
            ImGui.Separator();

            // Button to install new versions
            if (ImGui.Button("Install New Version"))
            {
                // Implement the logic to handle new version installation
                InstallNewVersion();
            }

            ImGui.NewLine();

            // Display a table for installed versions
            if (ImGui.BeginTable("InstallsTable", 3, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg))
            {
                // Setup table columns
                ImGui.TableSetupColumn("Version", ImGuiTableColumnFlags.WidthFixed, 100);
                ImGui.TableSetupColumn("Release Date", ImGuiTableColumnFlags.WidthFixed, 150);
                ImGui.TableSetupColumn("Actions", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableHeadersRow();

                // Example installed versions data
                List<InstalledVersion> installedVersions = new List<InstalledVersion>
                {
                    new InstalledVersion("1.0.0", "2023-01-15", "/path/to/version1"),
                    new InstalledVersion("1.1.0", "2023-06-10", "/path/to/version2"),
                    new InstalledVersion("2.0.0", "2024-03-05", "/path/to/version3")
                };

                // Iterate through each installed version and display in the table
                foreach (InstalledVersion version in installedVersions)
                {
                    ImGui.TableNextRow();

                    // Version column
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text(version.Version);

                    // Release date column
                    ImGui.TableSetColumnIndex(1);
                    ImGui.Text(version.ReleaseDate);

                    // Actions column
                    ImGui.TableSetColumnIndex(2);

                    // Context menu for actions
                    if (ImGui.Button($"Actions##{version.Version}"))
                    {
                        ImGui.OpenPopup($"ActionsPopup##{version.Version}");
                    }

                    if (ImGui.BeginPopup($"ActionsPopup##{version.Version}"))
                    {
                        if (ImGui.MenuItem("Reveal in Finder"))
                        {
                            RevealInFinder(version.InstallPath);
                        }

                        if (ImGui.MenuItem("Open in Terminal"))
                        {
                            OpenInTerminal(version.InstallPath);
                        }

                        if (ImGui.MenuItem("Delete"))
                        {
                            DeleteInstallation(version.InstallPath);
                        }

                        ImGui.EndPopup();
                    }
                }

                ImGui.EndTable();
            }
        }

        /// <summary>
        /// Installs the new version
        /// </summary>
        private void InstallNewVersion()
        {
            // Logic to handle installing new versions
            Console.WriteLine("Install New Version button clicked.");
        }

        /// <summary>
        /// Reveals the in finder using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        private void RevealInFinder(string path)
        {
            // Open the installation path in Finder
            Process.Start(new ProcessStartInfo("open", path) {UseShellExecute = true});
        }

        /// <summary>
        /// Opens the in terminal using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        private void OpenInTerminal(string path)
        {
            // Open the installation path in Terminal
            Process.Start(new ProcessStartInfo("open", "-a Terminal " + path) {UseShellExecute = true});
        }

        /// <summary>
        /// Deletes the installation using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        private void DeleteInstallation(string path)
        {
            // Logic to delete the installation
            Console.WriteLine($"Delete installation at: {path}");
        }

        /// <summary>
        ///     Renders the projects section
        /// </summary>
        private void RenderProjectsSection()
        {
            // Variables para el tamaño ajustable
            float buttonWidth = 75;
            float elementHeight = 30; // Altura común para todos los elementos
            float spaceBetween = 10;

            ImGui.Separator();
            ImGui.Spacing();

            // Añadir un campo de búsqueda en lugar de "Projects"
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2F(spaceBetween, 20));
            //ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(10, 0));

            // Establecer el ancho de la barra de búsqueda para que ocupe el espacio restante
            float searchBarWidth = ImGui.GetContentRegionAvail().X - (buttonWidth * 4 + spaceBetween * 2);

            // Centrar el icono verticalmente respecto a la altura del elemento
            float iconHeight = ImGui.GetTextLineHeight(); // Obtener la altura del icono
            float verticalOffset = (elementHeight - iconHeight) / 2; // Desplazamiento vertical para centrar el icono

            // Mostrar icono de búsqueda con tamaño ajustado y centrado verticalmente
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() + verticalOffset + 10); // Ajustar la posición Y para centrar el icono
            ImGui.Text($"{FontAwesome5.Search}");

            ImGui.SameLine(); // Asegurarse de que el icono y el campo de texto estén en la misma línea

            // Establecer el campo de texto para el buscador
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() - verticalOffset);
            ImGui.SetNextItemWidth(searchBarWidth);

            // Ajustar la altura de la barra de búsqueda para que coincida con la de los botones
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(5, (elementHeight - iconHeight) / 2)); // Ajustar el padding para igualar la altura

            // Campo de búsqueda
            if (ImGui.InputTextWithHint("##Search", "Search...",  searchQuery, 256))
            {
                Console.WriteLine("Search query: " + searchQuery);
            }

            // Restaurar estilo
            ImGui.PopStyleVar(1); // Eliminar el estilo adicional

            // Alineación de los botones en la parte derecha de la línea
            ImGui.SameLine(); // Asegurarse de que los botones están alineados después de la barra de búsqueda

            // Cambiar estilo de los botones a gris y redondear las esquinas
            //ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.5f, 0.5f, 0.5f, 1.0f));
            //ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(1.0f, 1.0f, 1.0f, 1.0f));

            // Establecer el radio de las esquinas de los botones
            ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 5.0f); // Aquí estableces el radio de las esquinas

            // Botones
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() - verticalOffset);
            if (ImGui.Button("Create", new Vector2F(buttonWidth, elementHeight)))
            {
                // Acción para "New"
            }

            ImGui.SameLine();
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() - verticalOffset);
            if (ImGui.Button("Import", new Vector2F(buttonWidth, elementHeight)))
            {
                // Acción para "Add"
            }

            ImGui.SameLine();
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() - verticalOffset);
            if (ImGui.Button("Clone", new Vector2F(buttonWidth, elementHeight)))
            {
                // Acción para "Clone"
            }

            // Restaurar el estilo de los botones
            //ImGui.PopStyleColor(2); // Restaurar el estilo de los botones
            ImGui.PopStyleVar(2); // Restaurar el estilo de FrameRounding

            ImGui.SetCursorPosY(ImGui.GetCursorPosY() - verticalOffset);
            ImGui.Separator();
            //ImGui.Spacing();
            //ImGui.Spacing();

            ImGui.PushStyleVar(ImGuiStyleVar.CellPadding, new Vector2F(10, 15));

            if (ImGui.BeginTable("ProjectTable", 4, ImGuiTableFlags.Borders | ImGuiTableFlags.Resizable))
            {
                ImGui.TableSetupColumn("NAME", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("PATH", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("MODIFIED", ImGuiTableColumnFlags.WidthFixed, 120);
                ImGui.TableSetupColumn("EDITOR VERSION", ImGuiTableColumnFlags.WidthFixed, 150);
                ImGui.TableHeadersRow();

                for (int i = 0; i < projects.Count; i++)
                {
                    Project project = projects[i];
                    ImGui.TableNextRow();

                    // Selección de fila completa
                    ImGui.TableNextColumn();

                    // Ajustar el alto de la celda
                    float rowHeight = 50;
                    ImGui.SetCursorPosY(ImGui.GetCursorPosY() + (elementHeight - rowHeight) / 2);

                    if (ImGui.Selectable($"##Row{i}", selectedProjectIndex == i, ImGuiSelectableFlags.SpanAllColumns | ImGuiSelectableFlags.AllowDoubleClick, new Vector2F(0, rowHeight)))
                    {
                        selectedProjectIndex = i;

                        if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                        {
                            OpenProject(project);
                        }
                    }

                    // Menú contextual para la fila seleccionada
                    if (ImGui.IsItemHovered() && ImGui.IsMouseClicked(ImGuiMouseButton.Right))
                    {
                        ImGui.OpenPopup($"ContextMenu##{i}");
                        Console.WriteLine("Right-clicked on project: " + project.Name);
                    }

                    ImGui.SetCursorPosY(ImGui.GetCursorPosY() + (rowHeight - elementHeight) / 2);

                    ImGui.SameLine(); // Permite que el texto siga en la misma línea
                    ImGui.TextColored(new Vector4F(1.0f, 1.0f, 1.0f, 1.0f), project.Name);

                    // Columna 2: Ruta
                    ImGui.TableNextColumn();
                    ImGui.TextColored(new Vector4F(0.7f, 0.7f, 0.7f, 1.0f), project.Path);

                    // Columna 3: Fecha de modificación
                    ImGui.TableNextColumn();
                    ImGui.TextColored(new Vector4F(0.8f, 0.8f, 0.8f, 1.0f), project.ModifiedDate);

                    // Columna 4: Versión del editor
                    ImGui.TableNextColumn();
                    ImGui.TextColored(new Vector4F(0.8f, 0.8f, 0.8f, 1.0f), project.EditorVersion);

                    if (ImGui.BeginPopup($"ContextMenu##{i}"))
                    {
                        if (ImGui.MenuItem("Reveal in Finder"))
                        {
                            // Acción: Reveal in Finder
                            RevealInFinder(project.Path);
                        }

                        
                        if (ImGui.MenuItem("Open in Terminal"))
                        {
                            // Acción: Open in Terminal
                            OpenInTerminal(project.Path);
                        }

                        if (ImGui.MenuItem("Remove from List"))
                        {
                            projects.RemoveAt(i);
                        }

                        ImGui.EndPopup();
                    }
                }

                ImGui.EndTable();
            }

            ImGui.PopStyleVar(1); // Restaurar estilo
        }
        /// <summary>
        /// Opens the project using the specified project
        /// </summary>
        /// <param name="project">The project</param>
        private void OpenProject(Project project)
        {
            Console.WriteLine($"Opening project: {project.Name}");

            // Crear el JSON con la configuración del proyecto
            string projectConfig = JsonSerializer.Serialize(project);
            string configFilePath = Path.Combine(Path.GetTempPath(), "projectConfig.json");
            File.WriteAllText(configFilePath, projectConfig);

            // Determinar la ruta del ejecutable del engine
            string enginePath = string.Empty;
        #if DEBUG
            if (OperatingSystem.IsWindows())
            {
                enginePath = $"{AppDomain.CurrentDomain.BaseDirectory}Editor/{project.EditorVersion}/Alis.App.Engine.exe";
            }
            
            if (OperatingSystem.IsMacOS())
            {
                enginePath =  $"{AppDomain.CurrentDomain.BaseDirectory}Editor/{project.EditorVersion}/Alis.App.Engine";
            }
        #else
                    enginePath = $"{AppDomain.CurrentDomain.BaseDirectory}Editor/{project.EditorVersion}/Alis.App.Engine";
        #endif
            
            // Iniciar el proceso Alis.App.Engine con el archivo JSON como argumento
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = enginePath,
                Arguments = configFilePath,
                UseShellExecute = true,
                CreateNoWindow = true
            };
            
            Task.Run(() =>
            {
                using (Process process = Process.Start(startInfo))
                {
                    if (process != null)
                    {
                        process.WaitForExit();
                    }
                }
            });
        }

        /// <summary>
        /// Renders the community section
        /// </summary>
        private void RenderCommunitySection()
        {
            // Crear el menú de navegación horizontal
            if (ImGui.BeginMenuBar())
            {
                // Opción "Samples"
                if (ImGui.BeginMenu("Samples"))
                {
                    // Aquí agregas las acciones o la visualización de los recursos de la sección Samples
                    ImGui.EndMenu();
                }

                // Opción "Web"
                if (ImGui.BeginMenu("Web"))
                {
                    // Aquí agregas las acciones o la visualización de la sección Web
                    ImGui.EndMenu();
                }

                // Opción "Templates"
                if (ImGui.BeginMenu("Templates"))
                {
                    // Aquí agregas las acciones o la visualización de la sección Templates
                    ImGui.EndMenu();
                }

                ImGui.EndMenuBar();
            }

            // Espaciado entre el menú y la tabla
            ImGui.NewLine();

            // Crear la tabla para mostrar los recursos
            if (ImGui.BeginTable("ResourceTable", 4, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg))
            {
                // Definir las columnas de la tabla
                ImGui.TableSetupColumn("Image", ImGuiTableColumnFlags.WidthFixed, 100);
                ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("Description", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("Access", ImGuiTableColumnFlags.WidthFixed, 100);
                ImGui.TableHeadersRow();

                // Generar filas con los recursos (suponiendo que tienes una lista de recursos llamada 'Items')
                foreach (GalleryItem item in gallery.Items)
                {
                    ImGui.TableNextRow();

                    // Columna de la imagen
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Image(LoadTextureFromFile(item.ImagePath), new Vector2F(100, 100));

                    // Columna del nombre
                    ImGui.TableSetColumnIndex(1);
                    ImGui.Text(item.Title);

                    // Columna de la descripción
                    ImGui.TableSetColumnIndex(2);
                    ImGui.Text(item.Description);

                    // Columna del botón para acceder al recurso web
                    ImGui.TableSetColumnIndex(3);
                    if (ImGui.Button("Open"))
                    {
                        // Aquí puedes implementar la acción para abrir el recurso web
                        Process.Start(new ProcessStartInfo(item.Url) {UseShellExecute = true});
                    }
                }

                ImGui.EndTable();
            }
        }
    }
}