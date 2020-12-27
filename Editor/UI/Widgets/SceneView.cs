//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="SceneView.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using ImGuiNET;
    using Alis.Editor.Utils;
    
    /// <summary>Render the core scene.</summary>
    public class SceneView : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "SceneView";

        /// <summary>Closes this instance.</summary>
        public override void Close()
        {
        }

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(650, 20), ImGuiCond.FirstUseEver);

            if (ImGui.Begin("Scene View"))
            {
                /*
                render.Clear();
                render.Draw(circle);
                render.Display();

                SFML.Graphics.Image renderToImage = render.Texture.CopyToImage();
                renderToImage.FlipHorizontally();

                image = SixLabors.ImageSharp.Image.LoadPixelData<Rgba32>(renderToImage.Pixels, 512, 512);
                imageSharpTexture = new Veldrid.ImageSharp.ImageSharpTexture(image, true);
                texx = imageSharpTexture.CreateDeviceTexture(graphicsDevice, graphicsDevice.ResourceFactory);

                intPtr = imGuiController.GetOrCreateImGuiBinding(graphicsDevice.ResourceFactory, texx);
                ImGui.Image(intPtr,
                    ImGui.GetContentRegionAvail(),
                    new System.Numerics.Vector2(1, 0),
                    new System.Numerics.Vector2(0, 1),
                    new System.Numerics.Vector4(1f),
                    new System.Numerics.Vector4(1f)
                    );
                */
            }

            ImGui.End();
        }

        /// <summary>Gets the name.</summary>
        /// <returns>Return name widget</returns>
        public override string GetName()
        {
            return Name;
        }

        /// <summary>Called when [load].</summary>
        public override void OnLoad()
        {
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
        }
    }
}
