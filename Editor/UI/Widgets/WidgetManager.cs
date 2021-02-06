//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="WidgetManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System;
    using System.Collections.Generic;

    /// <summary>Widget Manager</summary>
    public class WidgetManager
    {
        /// <summary>The widget events</summary>
        private readonly Dictionary<EventType, Action<WidgetManager>> widgetEvents = new Dictionary<EventType, Action<WidgetManager>>()
        {
            { EventType.OpenConsole, ProcessOpenConsole },
            { EventType.CloseConsole, ProcessCloseConsole },
            { EventType.ExitEditor, ProcessExitEditor },
            { EventType.OpenCreateProject, ProcessOpenCreatorProject },
            { EventType.CloseCreateProject, ProcessCloseCreatorProject},
            { EventType.OpenProject, ProcessOpenProject},
        };

        /// <summary>The widgets</summary>
        private List<Widget> widgets = new List<Widget>();

        /// <summary>The pending events</summary>
        private Stack<EventType> pendingEvents = new Stack<EventType>();

        /// <summary>Initializes a new instance of the <see cref="WidgetManager" /> class.</summary>
        public WidgetManager(Info info)
        {
            EventHandler += ManageEventHandler;

            widgets.Add(new DockSpace(EventHandler));
            widgets.Add(new TopMenu(EventHandler, info));

            Console.Current = new Console(EventHandler);
            widgets.Add(Console.Current);
            
            widgets.Add(new ProjectManager(EventHandler, true));

            BottomMenu.Current = new BottomMenu(EventHandler);
            widgets.Add(BottomMenu.Current);

            widgets.Add(new Inspector());
            widgets.Add(new SceneView());
            widgets.Add(new AssetsManager());

            
            widgets.Add(new GameView(EventHandler));
        }

        /// <summary>Occurs when [event handler].</summary>
        public event EventHandler<EventType> EventHandler;

        /// <summary>Draws this instance.</summary>
        public void Update()
        {
            for (int i = 0; i < pendingEvents.Count; i++)
            {
                widgetEvents[pendingEvents.Pop()](this);
            }

            for (int i = 0; i < widgets.Count; i++)
            {
                widgets[i].Draw();
            }
        }

        /// <summary>Invokes the open console.</summary>
        /// <param name="obj">The object.</param>
        private static void ProcessOpenConsole(WidgetManager obj)
        {
            if (!obj.widgets.Exists(i => i.GetType() == typeof(Console)))
            {
                obj.widgets.Add(new Console(obj.EventHandler));
                System.Console.WriteLine("Process Open Console");
            }
        }

        /// <summary>Invokes the close console.</summary>
        /// <param name="obj">The object.</param>
        private static void ProcessCloseConsole(WidgetManager obj)
        {
            obj.widgets.RemoveAll(i => i.GetType() == typeof(Console));
            System.Console.WriteLine("Process Close Console");
        }

        /// <summary>Processes the exit editor.</summary>
        private static void ProcessExitEditor(WidgetManager obj) 
        {
            Environment.Exit(1);
            System.Console.WriteLine("Process Exit Editor");
        }

        /// <summary>Processes the creator project.</summary>
        /// <param name="obj">The object.</param>
        private static void ProcessCloseCreatorProject(WidgetManager obj)
        {
            obj.widgets.RemoveAll(i => i.GetType() == typeof(ProjectManager));
            System.Console.WriteLine("Process Creator Project");
        }

        /// <summary>Processes the open creator project.</summary>
        /// <param name="obj">The object.</param>
        private static void ProcessOpenCreatorProject(WidgetManager obj)
        {
            if (!obj.widgets.Exists(i => i.GetType() == typeof(ProjectManager)))
            {
                obj.widgets.Add(new ProjectManager(obj.EventHandler, false));
            }
        }

        /// <summary>Processes the open project.</summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="NotImplementedException"></exception>
        private static void ProcessOpenProject(WidgetManager obj)
        {
            if (!obj.widgets.Exists(i => i.GetType() == typeof(ProjectManager)))
            {
                obj.widgets.Add(new ProjectManager(obj.EventHandler, true));
            }
        }

        /// <summary>Manages the event handler.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void ManageEventHandler(object sender, EventType e)
        {
            pendingEvents.Push(e);
            System.Console.WriteLine("Generated New Event " + e.ToString());
        }
    }
}
