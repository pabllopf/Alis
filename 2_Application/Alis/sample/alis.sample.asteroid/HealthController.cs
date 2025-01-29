// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HealthController.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;

namespace Alis.Sample.Asteroid
{
    public class HealthController : AComponent
    {
        public int health = 3;

        private string healthName = "Health.bmp";

        public override void OnStart()
        {
            CreateHealth();
        }

        private void CreateHealth()
        {
            GameObject subAsteroid = new GameObject();
            subAsteroid.Name = $"Health_{health}";
            subAsteroid.Tag = "UI";

            Transform parentTransform = new Transform();
            parentTransform.Position = new Vector2F(-12, 8);
            parentTransform.Rotation = 0.0f;
            parentTransform.Scale = new Vector2F(0.5f, 0.5f);

            subAsteroid.Transform = parentTransform;

            subAsteroid.Add(new Sprite().Builder()
                .SetTexture(healthName)
                .Depth(1)
                .Build());

            Context.SceneManager.CurrentScene.Add(subAsteroid);
        }

        public override void OnUpdate()
        {
        }
    }
}