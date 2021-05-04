//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón </author>
// <copyright file="Main.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Example_Core
{
    using Alis.Core;
    using Alis.Core.SFML;
    using Alis.Tools;
    using System;

    public class Move : Component
    {
        private Keyboard upKey;
        private Keyboard downKey;
        private Transform transform;
        private float y0;
        private const float speed = 9.5f;

        public Keyboard UpKey { get => upKey; set => upKey = value; }
        public Keyboard DownKey { get => downKey; set => downKey = value; }

        public Move(Keyboard upKey, Keyboard downKey) 
        {
            this.upKey = upKey;
            this.downKey = downKey;
        }

        public override void Start()
        {
            Logger.Warning("START     __" + this.GameObject.Name);
            transform = GameObject.Transform;
            y0 = transform.Position.Y;
            Input.OnPressKey += Input_OnPressKey;
        }

        private void Input_OnPressKey(object sender, Keyboard key)
        {
            if (key.Equals(upKey))
            {
                transform.YPos -= speed;
            }

            if (key.Equals(downKey))
            {
                transform.YPos += speed;
            }
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
            transform.YPos = y0;
        }
    }
}