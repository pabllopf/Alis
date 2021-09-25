//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="SceneView.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Core;
    using ImGuiNET;
    using SixLabors.ImageSharp.PixelFormats;
    using SixLabors.ImageSharp;
    using Veldrid.ImageSharp;
    using Veldrid;

    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using Alis.Tools;
    using Alis.Core.SFML;

    /// <summary>Render the core scene.</summary>
    public class SceneView : Widget
    {
        private static SceneView current;

        /// <summary>The name</summary>
        private const string Name = "Scene";

        private bool disable = false;

        private Image<Rgba32> image;

        private byte[] data;

        private ImageSharpTexture imageSharpTexture;

        private Texture texture;

        private ImGuiController imGuiController;

        private System.IntPtr intPtr;

        private bool isOpen = true;

        private bool focus = false;

        public static bool Disable
        {
            get => current.disable; 
            set
            {
                current.disable = value;

                if (!current.disable) 
                {
                    Project.VideoGame.StopPreviewRenderGame();
                    Project.VideoGame.SceneManager = LocalData.Load<SceneManager>("tempgame");
                }
            }
        }

        public SceneView(ImGuiController imGuiController) 
        {
            this.imGuiController = imGuiController;

            current = this;

            Project.OnChange += Project_OnChangeProject;
        }

        /// <summary>Projects the on change project.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Project_OnChangeProject(object sender, bool e)
        {
            data = null;
            image = null;
        }

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            
            if (!isOpen)
            {
                WidgetManager.Delete(this);
                return;
            }


            if (Project.VideoGame is not null && data is null && image is null)
            {
                Console.Warning("Create image of" + Project.Get().Name);
                data = Project.VideoGame.PreviewRender();
                image = Image.LoadPixelData<Rgba32>(data, 512, 512);
                imageSharpTexture = new ImageSharpTexture(image, true);
                texture = imageSharpTexture.CreateDeviceTexture(imGuiController.graphicsDevice, imGuiController.graphicsDevice.ResourceFactory);
                intPtr = imGuiController.GetOrCreateImGuiBinding(imGuiController.graphicsDevice.ResourceFactory, texture);
            }

            if (focus)
            {
                focus = false;
                ImGui.SetNextWindowFocus();
            }


            if (ImGui.Begin(Name, ref isOpen))
            {
                if (!disable)
                {
                    if (Project.Get() != null && Project.VideoGame != null)
                    {
                        image = Image.LoadPixelData<Rgba32>(Project.VideoGame.PreviewRender(), 512, 512);
                        imageSharpTexture.Images[0] = image;

                        unsafe
                        {
                            for (int level = 0; level < imageSharpTexture.MipLevels; level++)
                            {
                                Image<Rgba32> image = imageSharpTexture.Images[level];
                                if (!image.TryGetSinglePixelSpan(out Span<Rgba32> pixelSpan))
                                {
                                    throw new VeldridException("Unable to get image pixelspan.");
                                }
                                fixed (void* pin = &MemoryMarshal.GetReference(pixelSpan))
                                {
                                    imGuiController.graphicsDevice.UpdateTexture(
                                        texture,
                                        (IntPtr)pin,
                                        (uint)(imageSharpTexture.PixelSizeInBytes * image.Width * image.Height),
                                        0,
                                        0,
                                        0,
                                        (uint)image.Width,
                                        (uint)image.Height,
                                        1,
                                        (uint)level,
                                        0);
                                }
                            }
                        }

                        //intPtr = imGuiController.GetOrCreateImGuiBinding(imGuiController.graphicsDevice.ResourceFactory, texture);
                        ImGui.Image(intPtr, ImGui.GetContentRegionAvail());
                    }
                }
            }
            ImGui.End();
        }

        internal static void Focus()
        {
            if (current != null) 
            {
                current.focus = true;
            }
           
        }
    }
}
