//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="SceneView.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Tools;
    using ImGuiNET;
    using SixLabors.ImageSharp.PixelFormats;
    using SixLabors.ImageSharp;
    using Veldrid.ImageSharp;
    using Veldrid;

    /// <summary>Render the core scene.</summary>
    public class SceneView : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "Scene";

        private VideoGame game;

        private Image<Rgba32> image;

        private ImageSharpTexture imageSharpTexture;

        private Texture texture;

        private ImGuiController imGuiController;

        private System.IntPtr intPtr;

        public SceneView() 
        {
            game = new VideoGame(
               new ConfigGame("ExampleGame"),

               new Scene(
                   "MainMenu",

                   new GameObject(
                       "Player",
                       new AudioSource("Example.wav", true)
                   ),

                   new GameObject("Camera")
               ),

               new Scene(
                   "PlayGame",
                   new GameObject("Enemy")
               )
           );

            Debug.Warning("Saved the game");
            LocalData.Save<VideoGame>("Alis", game);

            imGuiController = MainWindow.imGuiController;

            image = Image.LoadPixelData<Rgba32>(game.PreviewRender(), 512, 512);
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
                image = Image.LoadPixelData<Rgba32>(game.PreviewRender(), 512, 512);
                ImGui.Image(intPtr, ImGui.GetContentRegionAvail());
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
