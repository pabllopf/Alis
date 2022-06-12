// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PointController.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Sample.D2.PingPong
{
    /// <summary>
    ///     The point controller class
    /// </summary>
    /// <seealso cref="Component" />
    internal class PointController : Component
    {
        /// <summary>
        ///     The points
        /// </summary>
        private int points;

        /// <summary>
        ///     The racket name
        /// </summary>
        private string racketName;

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            /*points = 3;
            racketName = GameObject.Name;
            SceneManager.Current.CurrentScene.Find(racketName + "point3").Get<Sprite>().Image = "heart_1.png";
            SceneManager.Current.CurrentScene.Find(racketName + "point2").Get<Sprite>().Image = "heart_1.png";
            */
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        ///     Subtracts the point
        /// </summary>
        public void subtractPoint()
        {
            /*
            points--;
            Console.WriteLine("Puntos del jugador " + GameObject.Name + ":" + points);

            if (points == 2)
            {
                SceneManager.Current.CurrentScene.Find(racketName + "point3").Get<Sprite>().Image = "heart_0.png";
            }
            else if (points == 1) {
                SceneManager.Current.CurrentScene.Find(racketName + "point3").Get<Sprite>().Image = "heart_0.png";
                SceneManager.Current.CurrentScene.Find(racketName + "point2").Get<Sprite>().Image = "heart_0.png";
            } 
            else if (points == 0) {
                SceneManager.Load("Menu");
            }
            */
        }
    }
}