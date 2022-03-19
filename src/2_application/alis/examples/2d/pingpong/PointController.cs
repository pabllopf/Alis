//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón </author>
// <copyright file="Main.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------

using Alis;
using Alis.Core.Components;

namespace PingPong
{
    /// <summary>
    /// The point controller class
    /// </summary>
    /// <seealso cref="Component"/>
    internal class PointController : Component
    {

        /// <summary>
        /// The points
        /// </summary>
        private int points;
        /// <summary>
        /// The racket name
        /// </summary>
        private string racketName;

        /// <summary>
        /// Starts this instance
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
        /// Updates this instance
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        /// Subtracts the point
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