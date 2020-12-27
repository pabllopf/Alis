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
        };

        /// <summary>The widgets</summary>
        private List<Widget> widgets = new List<Widget>();

        /// <summary>The pending events</summary>
        private Stack<EventType> pendingEvents = new Stack<EventType>();

        /// <summary>Initializes a new instance of the <see cref="WidgetManager" /> class.</summary>
        public WidgetManager()
        {
            EventHandler += ManageEventHandler;
            widgets.Add(new DockSpace(EventHandler));
            widgets.Add(new TopMenu(EventHandler));
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
