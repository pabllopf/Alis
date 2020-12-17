namespace Alis.Editor
{
    using System;
    using ImGuiNET;
    using System.Linq;
    using Veldrid;
    using Veldrid.StartupUtilities;

    public class Program
    {
        private static Veldrid.Sdl2.Sdl2Window window;
        private static GraphicsDevice graphicsDevice;

        public static void Main(string[] args)
        {
            WindowCreateInfo windowCreateInfo = new WindowCreateInfo(
                x: 50,
                y: 50,
                windowWidth: 640,
                windowHeight: 480,
                windowInitialState: WindowState.Normal,
                windowTitle: "Alis-Editor"
                );

            GraphicsDeviceOptions graphicsDeviceOptions = new GraphicsDeviceOptions(
                debug: true,
                swapchainDepthFormat: null,
                syncToVerticalBlank: true
                );

            VeldridStartup.CreateWindowAndGraphicsDevice(
               windowCI: windowCreateInfo,
               deviceOptions: graphicsDeviceOptions,
               window: out window,
               gd: out graphicsDevice);

            CommandList commandList = graphicsDevice.ResourceFactory.CreateCommandList();

            ImGuiController imGuiController = new ImGuiController(
              gd: graphicsDevice,
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

            ImGuiIOPtr io = ImGui.GetIO();
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard | ImGuiConfigFlags.NavEnableGamepad | ImGuiConfigFlags.DockingEnable;



            /* TO CORE 

            SFML.Graphics.CircleShape circle = new SFML.Graphics.CircleShape(50);
            render = new SFML.Graphics.RenderTexture(256, 256);
            Veldrid.ImageSharp.ImageSharpTexture imageSharpTexture = new Veldrid.ImageSharp.ImageSharpTexture("C:/Users/wwwam/Desktop/Editor/Editor/resources/Example3.png");
            Veldrid.Texture texx = imageSharpTexture.CreateDeviceTexture(graphicsDevice, graphicsDevice.ResourceFactory);
            IntPtr intPtr = imGuiController.GetOrCreateImGuiBinding(graphicsDevice.ResourceFactory, texx);

            */
            MainWindow.LoadStyle();

            BottomMenu bottomMenu = new BottomMenu();
            Alis.Editor.Console console = new Alis.Editor.Console();

            while (window.Exists)
            {

                InputSnapshot snapshot = window.PumpEvents();

                if (!window.Exists)
                {
                    break;
                }

                imGuiController.Update(1.0f / 60.0f, snapshot);

                MainWindow.DockSpace();

                bottomMenu.Draw();
                console.Draw();

                ImGui.ShowDemoWindow();

                ImGui.Begin("Example");
                ImGui.Text("hola");
                if (ImGui.Button(Icon.ICON_FA_MUSIC + " Pull"))
                {
                }

                ImGui.End();

                /*BEST PART DONT DELETE THIS
                render.Clear();
                render.Draw(circle);
                render.Display();
                render.Texture.CopyToImage().SaveToFile("C:/Users/wwwam/Desktop/Editor/Editor/resources/Example3.png");
                imageSharpTexture = new Veldrid.ImageSharp.ImageSharpTexture("C:/Users/wwwam/Desktop/Editor/Editor/resources/Example3.png");
                intPtr = imGuiController.GetOrCreateImGuiBinding(graphicsDevice.ResourceFactory, texx);
                

                ImGui.Image(intPtr,
                    ImGui.GetContentRegionAvail(),
                    new System.Numerics.Vector2(1, 0),
                    new System.Numerics.Vector2(0, 1),
                    new System.Numerics.Vector4(1f),
                    new System.Numerics.Vector4(1f));

                ImGui.End();*/


                commandList.Begin();
                commandList.SetFramebuffer(graphicsDevice.MainSwapchain.Framebuffer);
                commandList.ClearColorTarget(0, new RgbaFloat(1f, 0.5f, 1f, 1f));
                imGuiController.Render(graphicsDevice, commandList);
                commandList.End();
                graphicsDevice.SubmitCommands(commandList);
                graphicsDevice.SwapBuffers(graphicsDevice.MainSwapchain);
            }

            graphicsDevice.WaitForIdle();
            imGuiController.Dispose();
            commandList.Dispose();
            graphicsDevice.Dispose();
        }
    }
}
