using System;
using System.IO;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Hub.Utils
{
    /// <summary>
    /// Clase encargada de renderizar la interfaz gráfica del navegador de archivos.
    /// </summary>
    public class FileBrowserView
    {
        /// <summary>
        /// The is open
        /// </summary>
        private bool IsOpen = false;
        /// <summary>
        /// The model
        /// </summary>
        private readonly FileBrowserModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileBrowserView"/> class
        /// </summary>
        /// <param name="model">The model</param>
        public FileBrowserView(FileBrowserModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Renders this instance
        /// </summary>
        public void Render()
        {
            ImGui.SetNextWindowSize(new Vector2F(600, 400));
            if (ImGui.BeginPopupModal("File Browser", ref IsOpen, ImGuiWindowFlags.NoResize))
            {
                RenderNavigationBar();
                ImGui.Separator();
                RenderDirectoryContents();
                ImGui.Separator();
                RenderBottomButtons();
                ImGui.EndPopup();
            }
        }

        /// <summary>
        /// Renders the navigation bar
        /// </summary>
        private void RenderNavigationBar()
        {
            if (ImGui.Button("Back"))
            {
                string parent = Directory.GetParent(model.CurrentPath)?.FullName;
                if (parent != null)
                    model.NavigateTo(parent);
            }

            ImGui.SameLine();
            ImGui.Text($"Current: {model.CurrentPath}");
        }

        /// <summary>
        /// Renders the directory contents
        /// </summary>
        private void RenderDirectoryContents()
        {
            ImGui.BeginChild("DirectoryContents", new Vector2F(0, 300), true);
            foreach (var item in model.DirectoryContents)
            {
                if (Directory.Exists(item))
                {
                    if (ImGui.Selectable($"{Path.GetFileName(item)}/"))
                    {
                        model.NavigateTo(item);
                    }
                }
                else
                {
                    ImGui.Text(Path.GetFileName(item));
                }
            }
            ImGui.EndChild();
        }

        /// <summary>
        /// Renders the bottom buttons
        /// </summary>
        private void RenderBottomButtons()
        {
            if (ImGui.Button("Select"))
            {
                Console.WriteLine($"Selected: {model.CurrentPath}");
                ImGui.CloseCurrentPopup();
            }

            ImGui.SameLine();

            if (ImGui.Button("Cancel"))
            {
                ImGui.CloseCurrentPopup();
            }
        }
    }
}