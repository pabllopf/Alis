//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón </author>
// <copyright file="Main.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------

using Alis;
using Alis.Core.Components;
using Alis.Core.Entities;
using Alis.Core.Input;
using Alis.Tools;

namespace PingPong
{
    /// <summary>
    /// The move class
    /// </summary>
    /// <seealso cref="Component"/>
    public class Move : Component
    {
        /// <summary>
        /// The up key
        /// </summary>
        private Keyboard upKey;
        /// <summary>
        /// The down key
        /// </summary>
        private Keyboard downKey;
        /// <summary>
        /// The transform
        /// </summary>
        private Transform transform;
        /// <summary>
        /// The 
        /// </summary>
        private float y0;
        /// <summary>
        /// The speed
        /// </summary>
        private const float speed = 9.5f;

        /// <summary>
        /// Gets or sets the value of the up key
        /// </summary>
        public Keyboard UpKey { get => upKey; set => upKey = value; }
        /// <summary>
        /// Gets or sets the value of the down key
        /// </summary>
        public Keyboard DownKey { get => downKey; set => downKey = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Move"/> class
        /// </summary>
        /// <param name="upKey">The up key</param>
        /// <param name="downKey">The down key</param>
        public Move(Keyboard upKey, Keyboard downKey) 
        {
            this.upKey = upKey;
            this.downKey = downKey;
        }

        /// <summary>
        /// Starts this instance
        /// </summary>
        public override void Start()
        {
            Logger.Warning("START     __" + GameObject.Name);
            /*transform = GameObject.Transform;
            y0 = transform.Position.Y;
            Input.OnPressKey += Input_OnPressKey;*/
        }

        /// <summary>
        /// Inputs the on press key using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="key">The key</param>
        private void Input_OnPressKey(object sender, Keyboard key)
        {
            /*
            if (key.Equals(upKey))
            {
                transform.YPos -= speed;
            }

            if (key.Equals(downKey))
            {
                transform.YPos += speed;
            }*/
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        /// Exits this instance
        /// </summary>
        public override void Exit()
        {
            //transform.YPos = y0;
        }
    }
}