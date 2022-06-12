// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Program.cs
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

using System;
using System.Collections.Generic;
using System.Numerics;
using GameObject = Alis.Core.Entities.GameObject;
using Scene = Alis.Core.Entities.Scene;
using Sprite = Alis.Core.Components.Sprite;

namespace Alis.Sample.D2.GeometryDash
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
        public static void Main(string[] args)
        {
            VideoGame.Create()
                .Settings(setting => setting
                    .General(general => general
                        .Author("Pablo Perdomo Falcón & Diego")
                        .Name("Geometry Dash")
                        .Description("Arcade game based on the Geometry Dash game.")
                        .Build())
                    .Window(window => window
                        .Resolution(1920, 1080)
                        .ScreenMode(ScreenMode.FullScreen)
                        .Build())
                    .Debug(debug => debug
                        .ShowPhysicBorders(true)
                        .Build())
                    .Build())
                .Manager(sceneManager => sceneManager
                    ///////
                    /////// MENU SCENE
                    ///////
                    .Add<Scene>(scene => scene
                        .Name("Main Menu")
                        .Add<GameObject>(background => background
                            .Name("Background")
                            .Transform(transform => transform
                                .Position(-960, -540, 0)
                                .Scale(5, 5, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite(
                                $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/menu_blue.png",
                                -1))
                            .Add(new Animator(new List<Animation>
                            {
                                new Animation(new List<Texture>
                                {
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/menu_blue.png"),
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/menu_blue.png"),
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/menu_blue_1.png"),
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/menu_blue_1.png")
                                })
                                {
                                    Speed = 0.8f
                                }
                            })).Build())
                        .Add<GameObject>(title => title
                            .Name("Title")
                            .Transform(transform => transform
                                .Position(-610, -440, 0)
                                .Scale(2f, 2f, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite(
                                $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/title.png",
                                -1))
                            .Build())
                        .Add<GameObject>(camera => camera
                            .Name("Camera")
                            .Add(new Camera())
                            .Build())
                        .Add<GameObject>(soundtrack => soundtrack
                            .Name("Soundtrack")
                            .Add(new AudioSource($"{Environment.CurrentDirectory}/Assets/Music/soundtrack_menu.wav"))
                            .Build())
                        .Add<GameObject>(playButton => playButton
                            .Name("Play Button")
                            .Transform(transform => transform
                                .Position(-190, -135, 0)
                                .Scale(1.5f, 1.5f, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite(
                                $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_icon.png",
                                2))
                            .Add(new MainMenuController())
                            .Build())
                        .Add<GameObject>(playButton => playButton
                            .Name("Play Button Background")
                            .Transform(transform => transform
                                .Position(-190, -135, 0)
                                .Scale(1.5f, 1.5f, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite(
                                $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_1.png",
                                0))
                            .Add(new Animator(new List<Animation>
                            {
                                new Animation(new List<Texture>
                                {
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_1.png"),
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_1.png"),
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_2.png"),
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_2.png")
                                })
                                {
                                    Speed = 0.3f
                                }
                            })).Build())
                        .Add<GameObject>(optionsButton => optionsButton
                            .Name("Options")
                            .Transform(transform => transform
                                .Position(-475, -115, 0)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite(
                                $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/tools_1.png",
                                2))
                            .Build())
                        .Add<GameObject>(optionsButton => optionsButton
                            .Name("Options Background")
                            .Transform(transform => transform
                                .Position(-475, -115, 0)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite(
                                $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_1.png",
                                0))
                            .Add(new Animator(new List<Animation>
                            {
                                new Animation(new List<Texture>
                                {
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_1.png"),
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_1.png"),
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_2.png"),
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_2.png")
                                })
                                {
                                    Speed = 0.3f
                                }
                            })).Build())
                        .Add<GameObject>(moreGames => moreGames
                            .Name("More Games")
                            .Transform(transform => transform
                                .Position(225, -115, 0)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite(
                                $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/more_games.png",
                                2))
                            .Build())
                        .Add<GameObject>(moreGames => moreGames
                            .Name("More Games Background")
                            .Transform(transform => transform
                                .Position(225, -115, 0)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite(
                                $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_1.png",
                                0))
                            .Add(new Animator(new List<Animation>
                            {
                                new Animation(new List<Texture>
                                {
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_1.png"),
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_1.png"),
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_2.png"),
                                    new Texture(
                                        $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/play_big_2.png")
                                })
                                {
                                    Speed = 0.3f
                                }
                            })).Build())
                        .Build())

                    ////////
                    ///// GAME SCENE
                    ///////
                    .Add<Scene>(scene => scene
                        .Name("Game")
                        .Add<GameObject>(background => background
                            .Name("Background")
                            .Transform(transform => transform
                                .Position(-960, -540, 0)
                                .Scale(5, 5, 1)
                                .Rotation(0)
                                .Build())
                            /*.Add(new Sprite(
                                $"{Environment.CurrentDirectory}/Assets/Sprites/backgrounds/back.png", 
                                -1))*/
                            .Build())
                        .Add<GameObject>(camera => camera
                            .Name("Camera")
                            .Add(new Camera())
                            .Build())
                        .Add<GameObject>(soundtrack => soundtrack
                            .Name("Soundtrack")
                            .Add(new AudioSource(
                                $"{Environment.CurrentDirectory}/Assets/Music/soundtrack_level_2_press_start_full.wav"))
                            .Build())

                        // TopWall:
                        .Add<GameObject>(topWall => topWall
                            .Name("TopWall")
                            .Transform(transform => transform
                                .Position(-960, -540, 0)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new BoxCollider2D
                            {
                                Width = 1920.0f,
                                Height = 20.0f,
                                BodyType = BodyType.Static,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0f,
                                Restitution = 0f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())

                        // DownWall:
                        .Add<GameObject>(downWall => downWall
                            .Name("DownWall")
                            .Transform(transform => transform
                                .Position(-960, 520, 0)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new BoxCollider2D
                            {
                                Width = 1920.0f,
                                Height = 20.0f,
                                BodyType = BodyType.Static,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0f,
                                Restitution = 0f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())

                        // LeftWall:
                        .Add<GameObject>(leftWall => leftWall
                            .Name("LeftWall")
                            .Transform(transform => transform
                                .Position(-960, -540, 0)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new BoxCollider2D
                            {
                                Width = 20.0f,
                                Height = 1920.0f,
                                BodyType = BodyType.Static,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0f,
                                Restitution = 0f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())

                        // rightWall:
                        .Add<GameObject>(rightWall => rightWall
                            .Name("RightWall")
                            .Transform(transform => transform
                                .Position(940, -540, 0)
                                .Scale(1, 1, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new BoxCollider2D
                            {
                                Width = 20.0f,
                                Height = 1920.0f,
                                BodyType = BodyType.Static,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0f,
                                Restitution = 0f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())

                        // BALL:
                        .Add<GameObject>(ball => ball
                            .Name("Ball")
                            .Transform(transform => transform
                                .Position(-400.0f, 400.0f, 0)
                                .Scale(0.2f, 0.2f, 1)
                                .Rotation(90)
                                .Build())
                            .Add(new Sprite($"{Environment.CurrentDirectory}/Assets/Sprites/Players/player_diego.png",
                                2))
                            .Add(new BoxCollider2D
                            {
                                AutoTilling = true,
                                BodyType = BodyType.Dynamic,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                LinearVelocity = new Vector2(0, 0),
                                Friction = 0.0f,
                                Restitution = 0.0f,
                                FixedRotation = true,
                                GravityScale = 2.0f,
                                IsTrigger = false
                            })
                            .Add(new BallController())
                            .Build())

                        // Enemy
                        .Add<GameObject>(enemy => enemy
                            .Name("Enemy")
                            .Transform(transform => transform
                                .Position(0, 480, 0)
                                .Scale(0.1f, 0.08f, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite($"{Environment.CurrentDirectory}/Assets/Sprites/Enemies/enemy_1.png", 2))
                            .Add(new BoxCollider2D
                            {
                                AutoTilling = true,
                                BodyType = BodyType.Static,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0f,
                                Restitution = 0f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())
                        .Add<GameObject>(enemy => enemy
                            .Name("Enemy")
                            .Transform(transform => transform
                                .Position(50, 480, 0)
                                .Scale(0.1f, 0.08f, 1)
                                .Rotation(0)
                                .Build())
                            .Add(new Sprite($"{Environment.CurrentDirectory}/Assets/Sprites/Enemies/enemy_1.png", 2))
                            .Add(new BoxCollider2D
                            {
                                AutoTilling = true,
                                BodyType = BodyType.Static,
                                Density = 0.5f,
                                Rotation = 0.0f,
                                Mass = 10.0f,
                                RelativePosition = Vector2.Zero,
                                Friction = 0f,
                                Restitution = 0f,
                                FixedRotation = true,
                                GravityScale = 0.0f,
                                IsTrigger = false
                            })
                            .Build())
                        .Build())
                    .Build())
                .Run();
        }
    }
}