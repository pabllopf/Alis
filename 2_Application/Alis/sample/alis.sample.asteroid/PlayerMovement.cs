using System;
        using System.Collections;
        using Alis.Core.Aspect.Data.Mapping;
        using Alis.Core.Aspect.Math;
        using Alis.Core.Aspect.Math.Vector;
        using Alis.Core.Ecs.Component;
        using Alis.Core.Ecs.Component.Collider;
        using Alis.Core.Ecs.Entity;
        using Alis.Core.Ecs.System.Manager.Input;
        using Alis.Core.Ecs.System.Manager.Time;

        namespace Alis.Sample.Asteroid
        {
            /// <summary>
            /// The player movement class
            /// </summary>
            /// <seealso cref="AComponent"/>
            public class PlayerMovement : AComponent
            {
                /// <summary>
                /// The box collider
                /// </summary>
                private BoxCollider boxCollider;


                /// <summary>
                /// The time manager
                /// </summary>
                private TimeManager timeManager;
                
                /// <summary>
                /// The vector
                /// </summary>
                Vector2F direction = new Vector2F(0,0);
                
                /// <summary>
                /// The acceleration
                /// </summary>
                public float acceleration = 2.0f;
                /// <summary>
                /// The angular speed
                /// </summary>
                public float angularSpeed = 20.0f;
        
                /// <summary>
                /// Ons the start
                /// </summary>
                public override void OnStart()
                {
                    boxCollider = this.GameObject.Get<BoxCollider>();
                    timeManager = this.GameObject.Context.TimeManager;
                }


               /// <summary>
               /// Ons the update
               /// </summary>
               public override void OnUpdate()
               {
                   float targetRotationDegrees = CalculateRotationInDegrees(direction.X, direction.Y);
                   Console.WriteLine($"targetRotationDegrees: {targetRotationDegrees} direction: {direction}");
                   boxCollider.Body.Rotation = targetRotationDegrees;
               }
               
             /// <summary>
             /// Calculates the rotation in degrees using the specified x
             /// </summary>
             /// <param name="x">The </param>
             /// <param name="y">The </param>
             /// <returns>The angle</returns>
             private float CalculateRotationInDegrees(float x, float y)
             {
                 float angle = 0.0f;
             
                 if (x == 0)
                 {
                     if (y > 0)
                     {
                         angle = 0.0f;
                     }
                     else if (y < 0)
                     {
                         angle = 180.0f;
                     }
                 }
                 else if (y == 0)
                 {
                     if (x > 0)
                     {
                         angle = 270.0f;
                     }
                     else if (x < 0)
                     {
                         angle = 90.0f;
                     }
                 }
                 else
                 {
                     if (x > 0 && y > 0)
                     {
                         angle = 315;
                         Console.WriteLine("angle: " + angle);
                     }
                     if (x < 0 && y > 0)
                     {
                         angle = 45;
                         Console.WriteLine("angle: " + angle);
                     }
                     if (x < 0 && y < 0)
                     {
                            angle = 135;
                         Console.WriteLine("angle: " + angle);
                     }
                     if (x > 0 && y < 0)
                     {
                         angle = 225;
                         Console.WriteLine("angle: " + angle);
                     }
                 }
             
                 return angle;
             }

                /// <summary>
                /// Ons the press down key using the specified key
                /// </summary>
                /// <param name="key">The key</param>
                public override void OnPressDownKey(KeyCodes key)
              {
                  if (key == KeyCodes.D)
                  {
                      direction.X = 1;
                  }
              
                  if (key == KeyCodes.A)
                  {
                      direction.X = -1;
                  }
                  
                  if (key == KeyCodes.W)
                  {
                      direction.Y = 1;
                  }
                  
                  if (key == KeyCodes.S)
                  {
                      direction.Y = -1;
                  }
                  
                  if (key == KeyCodes.A || key == KeyCodes.D || key == KeyCodes.W || key == KeyCodes.S)
                  {
                      this.boxCollider.Body.ApplyForce(direction * acceleration);
                  }
                  
              }

                /// <summary>
                /// Ons the press key using the specified key
                /// </summary>
                /// <param name="key">The key</param>
                public override void OnPressKey(KeyCodes key)
                {
        
                    if (key == KeyCodes.Space)
                    {
                        Console.WriteLine("shoot");
                    }
                }
        
                /// <summary>
                /// Ons the release key using the specified key
                /// </summary>
                /// <param name="key">The key</param>
                public override void OnReleaseKey(KeyCodes key)
                {
                }
            }
        }