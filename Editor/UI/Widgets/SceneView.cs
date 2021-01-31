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
    using Alis.Tools;

    /// <summary>Render the core scene.</summary>
    public class SceneView : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "Scene";

        private Image<Rgba32> image;

        private ImageSharpTexture imageSharpTexture;

        private Texture texture;

        private ImGuiController imGuiController;

        private System.IntPtr intPtr;

        public SceneView() 
        {
            imGuiController = MainWindow.imGuiController;

            Project.OnChangeProject += Project_OnChangeProject;
        }

        /// <summary>Projects the on change project.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Project_OnChangeProject(object sender, bool e)
        {
            image = Image.LoadPixelData<Rgba32>(Project.VideoGame.PreviewRender(), 512, 512);
            imageSharpTexture = new ImageSharpTexture(image, true);
            texture = imageSharpTexture.CreateDeviceTexture(imGuiController.graphicsDevice, imGuiController.graphicsDevice.ResourceFactory);
            intPtr = imGuiController.GetOrCreateImGuiBinding(imGuiController.graphicsDevice.ResourceFactory, texture);
        }

        /// <summary>Closes this instance.</summary>
        public override void Close()
        {
        }

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(650, 20), ImGuiCond.FirstUseEver);

            if (ImGui.Begin(Name))
            {
                if (Project.VideoGame != null) 
                {
                    image = Image.LoadPixelData<Rgba32>(Project.VideoGame.PreviewRender(), 512, 512);
                    ImGui.Image(intPtr, ImGui.GetContentRegionAvail());
                }
            }

            ImGui.End();
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
        }
    }
}
