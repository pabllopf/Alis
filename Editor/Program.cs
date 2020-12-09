using Alis.Core;
using Alis.Store;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using System;

namespace Editor
{
    class Program
    {
         // Initialization code. Don't use any Avalonia, third-party APIs or any
         // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
         // yet and stuff might break.
         public static void Main(string[] args)
         {

             //BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

             Core core = new Core();
             core.Start();

             SFML.Graphics.Image img;
             SFML.Graphics.RenderWindow render;

             while (core.IsRunning()) 
             {
                 render = core.Run();

                 img = render.Capture();

             }

            
         }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug()
                .UseReactiveUI();
    }
}
