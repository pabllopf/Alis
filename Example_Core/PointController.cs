//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón </author>
// <copyright file="Main.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Example_Core
{

    using Alis.Core;
    using Alis.Core.SFML;
    using System;

    internal class PointController : Component
    {

        private int points;
        private String racketName;

        public override void Start()
        {
            points = 3;
            racketName = GameObject.Name;
            SceneManager.Current.CurrentScene.Find(racketName + "point3").Get<Sprite>().Image = "heart_1.png";
            SceneManager.Current.CurrentScene.Find(racketName + "point2").Get<Sprite>().Image = "heart_1.png";
        }

        public override void Update()
        {
        }

        public void subtractPoint()
        {
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
        }
    }
}