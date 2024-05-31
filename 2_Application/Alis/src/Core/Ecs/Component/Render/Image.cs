// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Image.cs
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
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.System;
using Alis.Core.Graphic.Sdl2;

namespace Alis.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The image class
    /// </summary>
    public class Image
    {
        public Image()
        {
            NameFile = string.Empty;
            Path = string.Empty;
            Size = new Vector2();
        }
        
        public Image(string nameFile)
        {
            NameFile = nameFile;
            Path = AssetManager.Find(nameFile);
            Load();
        }
        
        [JsonConstructor]
        public Image(string nameFile, Vector2 size)
        {
            NameFile = nameFile;
            Path = AssetManager.Find(nameFile);
            Size = size;
            Load();
        }
        
        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        [JsonIgnore]
        private Context Context => VideoGame.GetContext();
        
        /// <summary>
        ///     Gets or sets the value of the path
        /// </summary>
        [JsonIgnore]
        public string Path { get; set; }
        
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
        public Vector2 Size { get; set; }
        
        public void Load()
        {
            if (!string.IsNullOrEmpty(NameFile))
            {
                Path = AssetManager.Find(NameFile);
                
                Texture = Sdl.CreateTextureFromSurface(Context.GraphicManager.Renderer, Sdl.LoadBmp(Path));
                
                // get the size of sprite.Image.Texture
                Sdl.QueryTexture(Texture, out _, out _, out int w, out int h);
                
                Size = new Vector2(w, h);
            }
        }
    }
}