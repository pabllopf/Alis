namespace Alis.Editor
{
    using System;
    using ImGuiNET;
    using System.Linq;
    using Veldrid;
    using Veldrid.StartupUtilities;
    using SixLabors.ImageSharp.PixelFormats;
    using System.Collections.Generic;

    public class Program
    {
        private static Veldrid.Sdl2.Sdl2Window window;
        private static GraphicsDevice graphicsDevice;

        private static  BottomMenu bottomMenu;
        private static TopMenu topMenu;

        private static Inspector inspector;
        private static AssetsManager assetsManager;

        private static System.Numerics.Vector3 _clearColor = new System.Numerics.Vector3(0.45f, 0.55f, 0.6f);

        private static ImGuiController imGuiController;

        private static SFML.Graphics.CircleShape circle;
        private static SFML.Graphics.RenderTexture render;

        private static Veldrid.Texture texx;

        private static Veldrid.ImageSharp.ImageSharpTexture imageSharpTexture;

        private static IntPtr intPtr;

        private static SixLabors.ImageSharp.Image<Rgba32> image;

        private static WidgetManager widget = new WidgetManager();

        public static void Main(string[] args)
        {
            WindowCreateInfo windowCreateInfo = new WindowCreateInfo(
                x: 50,
                y: 50,
                windowWidth: 1280,
                windowHeight: 640,
                windowInitialState: WindowState.Normal,
                windowTitle: "Alis-Editor"
                );

            GraphicsDeviceOptions graphicsDeviceOptions = new GraphicsDeviceOptions(
                debug: false,
                swapchainDepthFormat: null,
                syncToVerticalBlank: true
                );

            VeldridStartup.CreateWindowAndGraphicsDevice(
               windowCI: windowCreateInfo,
               deviceOptions: graphicsDeviceOptions,
               window: out window,
               gd: out graphicsDevice);

            CommandList commandList = graphicsDevice.ResourceFactory.CreateCommandList();

            imGuiController = new ImGuiController(
              gd: graphicsDevice,
              window,
              outputDescription: graphicsDevice.MainSwapchain.Framebuffer.OutputDescription,
              width: window.Width,
              height: window.Height
              );

            MemoryEditor memoryEditor = new MemoryEditor();
            Random random = new Random();
            byte[] memoryEditorData = Enumerable.Range(0, 1024).Select(i => (byte)random.Next(255)).ToArray();

            window.Resized += () =>
            {
                graphicsDevice.MainSwapchain.Resize((uint)window.Width, (uint)window.Height);
                imGuiController.WindowResized(window.Width, window.Height);
            };




            circle = new SFML.Graphics.CircleShape(50);
            render  = new SFML.Graphics.RenderTexture(512, 512);



            MainWindow.LoadStyle();

            bottomMenu = new BottomMenu();
            

            inspector = new Inspector();
            assetsManager = new AssetsManager();

            while (window.Exists)
            {

                InputSnapshot snapshot = window.PumpEvents();

                if (!window.Exists)
                {
                    break;
                }

                imGuiController.Update(1.0f / 60.0f, snapshot);

                widget.Update();

                SubmitNewUI();

                commandList.Begin();
                commandList.SetFramebuffer(graphicsDevice.MainSwapchain.Framebuffer);
                commandList.ClearColorTarget(0, new RgbaFloat(_clearColor.X, _clearColor.Y, _clearColor.Z, 1f));
                imGuiController.Render(graphicsDevice, commandList);
                commandList.End();
                graphicsDevice.SubmitCommands(commandList);
                graphicsDevice.SwapBuffers(graphicsDevice.MainSwapchain);
                imGuiController.SwapExtraWindows(graphicsDevice);
            }

            graphicsDevice.WaitForIdle();
            imGuiController.Dispose();
            commandList.Dispose();
            graphicsDevice.Dispose();
        }

        private unsafe static void SubmitNewUI()
        {
            bool _showDemoWindow = true;


            


            MainWindow.DockSpace();

            bottomMenu.Draw();
            
            inspector.Draw();
            assetsManager.Draw();

            ImGui.SetNextWindowPos(new System.Numerics.Vector2(650, 20), ImGuiCond.FirstUseEver);
            ImGui.ShowDemoWindow(ref _showDemoWindow);

            if (ImGui.Begin("Scene View"))
            {
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
            
            }

            ImGui.End();


        }
    }
}
