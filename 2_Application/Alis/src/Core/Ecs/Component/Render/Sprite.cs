// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sprite.cs
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

using System;
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The sprite class
    /// </summary>
    /// <seealso cref="AComponent" />
    /// <seealso cref="IHasBuilder{TOut}" />
    public class Sprite :
        AComponent,
        IHasBuilder<SpriteBuilder>
    {
        /// <summary>
        ///     The
        /// </summary>
        //private int h;

        /// <summary>
        ///     The rectangle
        /// </summary>
        private RectangleI rectangle;

        /// <summary>
        ///     The
        /// </summary>
        //private int w;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        public Sprite()
        {
            NameFile = "";
            Path = "";
            Depth = 0;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        /// <param name="nameFile">The name file</param>
        public Sprite(string nameFile)
        {
            NameFile = nameFile;
            Path = "";
            Depth = 0;
        }

        private Sprite(string nameFile, int depth)
        {
            NameFile = nameFile;
            Path = AssetManager.Find(nameFile);
            Depth = depth;
        }

        /// <summary>
        ///     The level
        /// </summary>
        [JsonPropertyName("_Depth_")]
        public int Depth { get; set; }

        /// <summary>
        ///     Gets or sets the value of the path
        /// </summary>
        [JsonIgnore]
        public string Path { get; set; }

        /// <summary>
        ///     Gets or sets the value of the name file
        /// </summary>
        [JsonPropertyName("_NameFile_")]
        public string NameFile { get; set; }

        /// <summary>
        ///     Gets or sets the value of the texture
        /// </summary>
        [JsonIgnore]
        public IntPtr Texture { get; set; }

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>
        [JsonPropertyName("_Size_")]
        public Vector2F Size { get; set; }

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The sprite builder</returns>
        public SpriteBuilder Builder() => new SpriteBuilder();

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void OnInit()
        {
            /*
            if (!string.IsNullOrEmpty(NameFile))
            {
                Path = AssetManager.Find(NameFile);

                Texture = Sdl.CreateTextureFromSurface(Context.GraphicManager.Renderer, Sdl.LoadBmp(Path));

                // get the size of sprite.Texture
                Sdl.QueryTexture(Texture, out _, out _, out int w, out int h);

                Size = new Vector2F(w, h);
            }*/
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void OnAwake()
        {
            Context.GraphicManager.Attach(this);
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
            //Sdl.QueryTexture(Texture, out _, out _, out w, out h);

            //new RectangleI((int) GameObject.Transform.Position.X, (int) GameObject.Transform.Position.Y, w, h);
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void OnExit()
        {
            Context.GraphicManager.UnAttach(this);
        }

        /// <summary>
        ///     Renders the renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="cameraPosition">The camera position</param>
        /// <param name="cameraResolution">The camera resolution</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        public void Render(IntPtr renderer, Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter)
        {
            Vector2F spritePosition = GameObject.Transform.Position;
            Vector2F spriteSize = Size;
            Vector2F spriteScale = GameObject.Transform.Scale;
            float spriteRotation = GameObject.Transform.Rotation;

            float spritePosX = spritePosition.X * pixelsPerMeter;
            float spritePosY = spritePosition.Y * pixelsPerMeter;

            int scaledWidth = (int) (spriteSize.X * spriteScale.X);
            int scaledHeight = (int) (spriteSize.Y * spriteScale.Y);

            int x = (int) (spritePosX - cameraPosition.X * pixelsPerMeter + cameraResolution.X / 2 - scaledWidth / 2);
            int y = (int) (spritePosY - cameraPosition.Y * pixelsPerMeter + cameraResolution.Y / 2 - scaledHeight / 2);

            rectangle = new RectangleI
            {
                X = x,
                Y = y,
                W = scaledWidth,
                H = scaledHeight
            };

            //Sdl.RenderCopyEx(renderer, Texture, IntPtr.Zero, ref rectangle, spriteRotation, IntPtr.Zero, RendererFlips.FlipVertical);
        }

        /// <summary>
        ///     Describes whether this instance is visible
        /// </summary>
        /// <param name="cameraPosition">The camera position</param>
        /// <param name="cameraResolution">The camera resolution</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        /// <returns>The bool</returns>
        public bool IsVisible(Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter)
        {
            Vector2F spritePosition = GameObject.Transform.Position;
            Vector2F spriteSize = Size;
            float spriteRotation = GameObject.Transform.Rotation;

            float spritePosX = spritePosition.X * pixelsPerMeter;
            float spritePosY = spritePosition.Y * pixelsPerMeter;

            float cameraLeft = cameraPosition.X * pixelsPerMeter - cameraResolution.X / 2;
            float cameraRight = cameraPosition.X * pixelsPerMeter + cameraResolution.X / 2;
            float cameraTop = cameraPosition.Y * pixelsPerMeter - cameraResolution.Y / 2;
            float cameraBottom = cameraPosition.Y * pixelsPerMeter + cameraResolution.Y / 2;

            // Calculate the bounding box of the rotated sprite
            float halfWidth = spriteSize.X / 2;
            float halfHeight = spriteSize.Y / 2;
            float cos = (float) Math.Cos(spriteRotation);
            float sin = (float) Math.Sin(spriteRotation);

            float[] cornersX = new float[4];
            float[] cornersY = new float[4];

            cornersX[0] = spritePosX + (-halfWidth * cos - -halfHeight * sin);
            cornersY[0] = spritePosY + (-halfWidth * sin + -halfHeight * cos);
            cornersX[1] = spritePosX + (halfWidth * cos - -halfHeight * sin);
            cornersY[1] = spritePosY + (halfWidth * sin + -halfHeight * cos);
            cornersX[2] = spritePosX + (halfWidth * cos - halfHeight * sin);
            cornersY[2] = spritePosY + (halfWidth * sin + halfHeight * cos);
            cornersX[3] = spritePosX + (-halfWidth * cos - halfHeight * sin);
            cornersY[3] = spritePosY + (-halfWidth * sin + halfHeight * cos);

            float spriteLeft = Min(cornersX);
            float spriteRight = Max(cornersX);
            float spriteTop = Min(cornersY);
            float spriteBottom = Max(cornersY);

            return (spriteRight > cameraLeft) && (spriteLeft < cameraRight) && (spriteBottom > cameraTop) && (spriteTop < cameraBottom);
        }

        /// <summary>
        ///     Mins the corners x
        /// </summary>
        /// <param name="cornersX">The corners</param>
        /// <returns>The min</returns>
        private float Min(float[] cornersX)
        {
            float min = cornersX[0];
            for (int i = 1; i < cornersX.Length; i++)
            {
                if (cornersX[i] < min)
                {
                    min = cornersX[i];
                }
            }

            return min;
        }

        /// <summary>
        ///     Maxes the corners x
        /// </summary>
        /// <param name="cornersX">The corners</param>
        /// <returns>The max</returns>
        private float Max(float[] cornersX)
        {
            float max = cornersX[0];
            for (int i = 1; i < cornersX.Length; i++)
            {
                if (cornersX[i] > max)
                {
                    max = cornersX[i];
                }
            }

            return max;
        }

        /// <summary>
        ///     Clones this instance
        /// </summary>
        /// <returns>The object</returns>
        public override object Clone() => new Sprite(NameFile, Depth);
    }
}