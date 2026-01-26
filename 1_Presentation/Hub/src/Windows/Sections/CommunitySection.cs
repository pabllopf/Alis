// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CommunitySection.cs
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
using Alis.App.Hub.Core;
using Alis.App.Hub.Entity;
using Alis.App.Hub.Utils;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;

namespace Alis.App.Hub.Windows.Sections
{
    /// <summary>
    ///     The community section class
    /// </summary>
    /// <seealso cref="ASection" />
    public class CommunitySection : ASection
    {
        /// <summary>
        ///     The gallery
        /// </summary>
        private readonly Gallery gallery = new Gallery( );

        /// <summary>
        ///     Initializes a new instance of the <see cref="CommunitySection" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public CommunitySection(SpaceWork spaceWork) : base(spaceWork)
        {
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
        }

        /// <summary>
        ///     Ons the render
        /// </summary>
        public override void OnRender(float scaleFactor)
        {
            // Crear el menú de navegación horizontal
            if (ImGui.BeginMenuBar())
            {
                // Opción "Samples"
                if (ImGui.BeginMenu("Samples"))
                {
                    // Aquí agregas las acciones o la visualización de los recursos de la sección Samples
                    ImGui.EndMenu();
                }

                // Opción "Web"
                if (ImGui.BeginMenu("Web"))
                {
                    // Aquí agregas las acciones o la visualización de la sección Web
                    ImGui.EndMenu();
                }

                // Opción "Templates"
                if (ImGui.BeginMenu("Templates"))
                {
                    // Aquí agregas las acciones o la visualización de la sección Templates
                    ImGui.EndMenu();
                }

                ImGui.EndMenuBar();
            }

            // Espaciado entre el menú y la tabla
            ImGui.NewLine();

            // Crear la tabla para mostrar los recursos
            if (ImGui.BeginTable("ResourceTable", 4, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg))
            {
                // Definir las columnas de la tabla
                ImGui.TableSetupColumn("Image", ImGuiTableColumnFlags.WidthFixed, 100);
                ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("Description", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("Access", ImGuiTableColumnFlags.WidthFixed, 100);
                ImGui.TableHeadersRow();

                // Generar filas con los recursos (suponiendo que tienes una lista de recursos llamada 'Items')
                foreach (GalleryItem item in gallery.Items)
                {
                    ImGui.TableNextRow();

                    // Columna de la imagen
                    ImGui.TableSetColumnIndex(0);
                    
                    
                    
                    ImGui.Image(ImageLoader.LoadTextureFromFile(item.ImagePath), new Vector2F(100, 100));

                    // Columna del nombre
                    ImGui.TableSetColumnIndex(1);
                    ImGui.Text(item.Title);

                    // Columna de la descripción
                    ImGui.TableSetColumnIndex(2);
                    ImGui.Text(item.Description);

                    // Columna del botón para acceder al recurso web
                    ImGui.TableSetColumnIndex(3);
                    if (ImGui.Button("Open"))
                    {
                        // Aquí puedes implementar la acción para abrir el recurso web
                        Process.Start(new ProcessStartInfo(item.Url) {UseShellExecute = true});
                    }
                }

                ImGui.EndTable();
            }
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
        }
    }
}