
using Alis.App.Engine.Core;
using Alis.Extension.Graphic.Ui.Controllers;

namespace Alis.App.Engine
{
    /// <summary>
    ///     The engine class
    /// </summary>
    public class Engine
    {
        private ImGuiControllerImplementGlfw imguiController;
        
        private SpaceWork spaceWork;
        
        /// <summary>
        ///     Starts this instance
        /// </summary>
        /// <returns>The int</returns>
        public void Run()
        {
            
            imguiController = new ImGuiControllerImplementGlfw(
                "Welcome to Alis Engine by @pabllopf",
                1024,
                768,
                0,
#if DEBUG
                true
#else
                    false
#endif
                
                );
            
            spaceWork = new SpaceWork(imguiController);
            
            imguiController.OnInit();
            imguiController.OnStart();
            
            spaceWork.Initialize();
            spaceWork.Start();
            
            while (imguiController.IsRunning)
            {
                imguiController.OnPollEvents();

                imguiController.OnStartFrame();
                
                imguiController.OnRenderFrame();
                
                spaceWork.Update();
                
                imguiController.OnEndFrame();
            }
            
            
            imguiController.OnExit();
        }
    }
}