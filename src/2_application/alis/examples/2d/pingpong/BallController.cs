//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón </author>
// <copyright file="Main.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------

using System;
using Alis;

namespace PingPong
{
    /// <summary>Ball Controller</summary>
    internal class BallController : Component
    {
        /// <summary>The random</summary>
        private Random random;

        /// <summary>The transform</summary>
        private Transform transform;
        
        /// <summary>The x0</summary>
        private float x0;
        
        /// <summary>The y0</summary>
        private float y0;
        
        /// <summary>The racket1 pc</summary>
        private PointController racket1PC;

        /// <summary>The racket2 pc</summary>
        private PointController racket2PC;

        /// <summary>The angle</summary>
        private float angle;
        
        /// <summary>The speed</summary>
        private float speed = 10f;
        
        /// <summary>The h speed</summary>
        private float hSpeed;
        
        /// <summary>The v speed</summary>
        private float vSpeed;

        /// <summary>Initializes a new instance of the <see cref="BallController" /> class.</summary>
        public BallController() => random = new Random();

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            /*transform = GameObject.Transform;
            x0 = transform.Position.X;
            y0 = transform.Position.Y;
            racket1PC = SceneManager.Current.CurrentScene.Find("racket1").Get<PointController>();
            racket2PC = SceneManager.Current.CurrentScene.Find("racket2").Get<PointController>();
            ResetPosition();*/
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            //transform.XPos += hSpeed;
            //transform.YPos += vSpeed;
        }

        /// <summary>Degs to RAD.</summary>
        /// <param name="angle">The angle.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public double DegToRad(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        /// <summary>Called when [collion enter].</summary>
        /// <param name="collision">The collision.</param>
        public void OnCollionEnter(Component collision)
        {
            /*
            if (collision.GameObject.Name.Equals("topWall") || collision.GameObject.Name.Equals("bottomWall")) 
            {
                vSpeed = -vSpeed;
            }

            if (collision.GameObject.Name.Equals("racket1") || collision.GameObject.Name.Equals("racket2"))
            {
                hSpeed = -hSpeed;
            }

            if (collision.GameObject.Name.Equals("racket1Goal"))
            {
                ResetPosition();
                racket1PC.subtractPoint();
            }

            if (collision.GameObject.Name.Equals("racket2Goal"))
            {
                ResetPosition();
                racket2PC.subtractPoint();
            }*/
        }

        /// <summary>Resets the position.</summary>
        private void ResetPosition()
        {
            /*transform.XPos = x0;
            transform.YPos = y0;

            if (random.Next(2) == 0)
            {
                SetAngle(135 + (float)(90 * random.NextDouble()));
            }
            else 
            {
                SetAngle(-45 + (float)(90 * random.NextDouble()));
            }*/
        }

        /// <summary>Sets the angle.</summary>
        /// <param name="angle">The angle.</param>
        private void SetAngle(float angle) 
        {
            /*
            this.angle = angle;
            hSpeed = (float)(speed * Math.Cos(DegToRad(this.angle)));
            vSpeed = -(float)(speed * Math.Sin(DegToRad(this.angle)));
            */
        }
    }
}