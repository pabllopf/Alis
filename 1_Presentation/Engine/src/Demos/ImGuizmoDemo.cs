// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuizmoDemo.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;

namespace Alis.App.Engine.Demos
{
    /// <summary>
    ///     The im guizmo demo class
    /// </summary>
    /// <seealso cref="IDemo" />
    public class ImGuizmoDemo : IDemo
    {
        /// <summary>
        ///     The camera projection
        /// </summary>
        private float[] cameraProjection = new float[16]
        {
            2.0f / 800.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 2.0f / 600.0f, 0.0f, 0.0f,
            0.0f, 0.0f, -1.0f, 0.0f,
            -1.0f, -1.0f, 0.0f, 1.0f
        };

        /// <summary>
        ///     The camera view
        /// </summary>
        private float[] cameraView = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
        };

        /// <summary>
        ///     The identity matrix
        /// </summary>
        private float[] identityMatrix = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
        };

        /// <summary>
        ///     The is open
        /// </summary>
        private bool isOpen;

        /// <summary>
        ///     The matrix
        /// </summary>
        private float[] matrix = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 2.0f, 1.0f
        };

        /// <summary>
        ///     The matrix rotation
        /// </summary>
        private float[] matrixRotation = new float[3];

        /// <summary>
        ///     The matrix scale
        /// </summary>
        private float[] matrixScale = new float[3];

        /// <summary>
        ///     The matrix translation
        /// </summary>
        private float[] matrixTranslation = new float[3];

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector3F rotation;

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector3F scale;

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector3F translation;

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
            SimpleSample();
        }

        /// <summary>
        ///     Simples the sample
        /// </summary>
        [Conditional("DEBUG")]
        private void SimpleSample()
        {
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4F(0.35f, 0.3f, 0.3f, 1.0f));


            if (ImGui.Begin("Gizmo", ref isOpen))
            {
                ImGuizMo.Enable(true);
                ImGuizMo.SetDrawList();

                ImGui.Text("ImGuizmo is a small library that allows you to manipulate 3D objects in the scene.");
                ImGui.Text("You can use it to move, rotate and scale objects in the scene.");

                ImGuizMo.DecomposeMatrixToComponents(ref matrix, ref matrixTranslation, ref matrixRotation, ref matrixScale);

                translation.X = matrixTranslation[0];
                translation.Y = matrixTranslation[1];
                translation.Z = matrixTranslation[2];

                rotation.X = matrixRotation[0];
                rotation.Y = matrixRotation[1];
                rotation.Z = matrixRotation[2];

                scale.X = matrixScale[0];
                scale.Y = matrixScale[1];
                scale.Z = matrixScale[2];

                ImGui.SliderFloat3("Translation", ref translation, -10.0f, 10.0f);
                ImGui.SliderFloat3("Rotation", ref rotation, -180.0f, 180.0f);
                ImGui.SliderFloat3("Scale", ref scale, 0.1f, 10.0f);

                matrixTranslation[0] = translation.X;
                matrixTranslation[1] = translation.Y;
                matrixTranslation[2] = translation.Z;

                matrixRotation[0] = rotation.X;
                matrixRotation[1] = rotation.Y;
                matrixRotation[2] = rotation.Z;

                matrixScale[0] = scale.X;
                matrixScale[1] = scale.Y;
                matrixScale[2] = scale.Z;

                ImGuizMo.RecomposeMatrixFromComponents(ref matrixTranslation, ref matrixRotation, ref matrixScale, ref matrix);

                ImGui.Text($"Translation: {translation}");
                ImGui.Text($"Rotation: {rotation}");
                ImGui.Text($"Scale: {scale}");

                ImGuizMo.SetOrthographic(false);
                ImGuizMo.SetRect(0, 0, ImGui.GetIo().DisplaySize.X, ImGui.GetIo().DisplaySize.Y);

                ImGuizMo.DrawGrid(ref cameraView, ref cameraProjection, ref identityMatrix, 10.0f);
                ImGuizMo.Manipulate(cameraView, cameraProjection, Operation.Translate | Operation.Rotate | Operation.Scale, Mode.Local, matrix);

                ImGuizMo.ViewManipulate(ref cameraView, 2.5f, new Vector2F(ImGui.GetWindowPos().X, ImGui.GetWindowPos().Y), new Vector2F(ImGui.GetWindowWidth(), ImGui.GetWindowHeight()), 0x10101010);
            }


            ImGui.End();
            ImGui.PopStyleColor();
        }
    }
}