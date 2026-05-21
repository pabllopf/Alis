// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodeDemo.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------


using System.Diagnostics;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Extras.Node;

namespace Alis.App.Engine.Demos
{
    /// <summary>
    ///     The im node demo class
    /// </summary>
    /// <seealso cref="IDemo" />
    public class ImNodeDemo : IDemo
    {
        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            DefaultDemo();
        }

        /// <summary>
        ///     Defaults the demo
        /// </summary>
        [Conditional("DEBUG")]
        private void DefaultDemo()
        {
            ImGui.Begin("simple node editor");

            ImNodes.BeginNodeEditor();
            ImNodes.BeginNode(1);

            ImNodes.BeginNodeTitleBar();
            ImGui.TextUnformatted("simple node :)");
            ImNodes.EndNodeTitleBar();

            ImNodes.BeginInputAttribute(2);
            ImGui.Text("input");
            ImNodes.EndInputAttribute();

            ImNodes.BeginOutputAttribute(3);
            ImGui.Indent(40);
            ImGui.Text("output");
            ImNodes.EndOutputAttribute();

            ImNodes.EndNode();
            ImNodes.EndNodeEditor();

            ImGui.End();
        }
    }
}