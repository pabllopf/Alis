// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using Alis.Core.Aspect.Logging;

namespace Alis.Core.Audio.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
        {
            string fileName = Environment.CurrentDirectory + "/Assets/menu.wav";
            AudioSource audioSource = new AudioSource(new AudioClip(fileName, AudioBackendType.Os));

            while (true)
            {
                Console.WriteLine("Select backend audio system ('sfml' | 'os')");
                string os = Console.ReadLine();

                try
                {
                    switch (os)
                    {
                        case "sfml":
                            audioSource = new AudioSource(new AudioClip(fileName, AudioBackendType.Sfml));
                            break;
                        
                        case "sdl":
                            Init();
                            break;
                        
                        case "os":
                            audioSource = new AudioSource(new AudioClip(fileName, AudioBackendType.Os));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(ex);
                }


                Console.WriteLine("Write command 'play' | 'stop' | 'resume' | exit ");
                string command = Console.ReadLine();
                try
                {
                    switch (command)
                    {
                        case "play":
                            audioSource.Play();
                            break;
                        case "stop":
                            audioSource.Stop();
                            break;
                        case "resume":
                            audioSource.Resume();
                            break;
                    }

                    if (command == "exit")
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(ex);
                }
            }
        }
        
        /// <summary>
        /// Inits
        /// </summary>
        private static void Init()
        {
            //Initialize all SDL subsystems
            SDL.SDL_mixer.SDL_Init(SDL.SDL_mixer.SDL_INIT_AUDIO);
            
            //Initialize SDL_mixer
            if(SDL.SDL_mixer.Mix_OpenAudio( 22050, SDL.SDL_mixer.MIX_DEFAULT_FORMAT, 2, 4096 ) == -1 )
            {
                return;
            }
            
            //Load the background image
            //background = load_image( "background.png" );
    
            //Open the font
            //font = TTF_OpenFont( "lazy.ttf", 30 );
            
            //Load the music
            string fileName = Environment.CurrentDirectory + "/Assets/menu.wav";
            IntPtr music = SDL.SDL_mixer.Mix_LoadMUS( fileName );
            //IntPtr scratch = SDL.SDL_mixer.Mix_LoadWAV( "scratch.wav" );
            
            SDL.SDL_mixer.Mix_PlayMusic( music, -1 );
        }
    }
}