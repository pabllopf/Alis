//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="WidgetManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Alis.Tools;

    /// <summary>Widget Manager</summary>
    public class WidgetManager
    {
        /// <summary>The widgets</summary>
        [NotNull]
        private List<Widget> widgets;

        /// <summary>The information</summary>
        [NotNull]
        private Info info;

        /// <summary>Initializes a new instance of the <see cref="WidgetManager" /> class.</summary>
        public WidgetManager(Info info)
        {
            widgets = new List<Widget>();

            widgets.Add(new DockSpace());
            widgets.Add(new Console());
          
            Logger.Info();
        }

        /// <summary>Draws this instance.</summary>
        public void Update()
        {
            for (int i = 0; i < widgets.Count; i++)
            {
                if (widgets[i] != null) 
                {
                    widgets[i].Draw();
                }
            }
        }
    }
}
