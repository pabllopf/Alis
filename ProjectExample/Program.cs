
using Alis.Tools;
using System;
using System.Collections.Generic;

namespace ProjectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Build();


            VideoGame.Start();



           
        }


        public static void Build() 
        {
            VideoGame game = new VideoGame(
                new ConfigGame("ExampleGame"),
                
                new Scene(
                    "MainMenu", 
                    
                    new GameObject(
                        "Player",
                        new AudioSource("Example.wav", true)
                    ),
                    
                    new GameObject("Camera")
                ),
                
                new Scene(
                    "PlayGame", 
                    new GameObject("Enemy")
                )
            );

            LocalData.Save<VideoGame>("Alis", game);
        }
    }
}
