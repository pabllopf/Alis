
using System;
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Data;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Render;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    /// The counter controller class
    /// </summary>
    /// <seealso cref="Component"/>
    public class CounterController : Component
    {
        /// <summary>
        /// Gets or sets the value of the counter
        /// </summary>
        public int Counter { get; set; }
        
        /// <summary>
        /// Increments this instance
        /// </summary>
        public void Increment()
        {
            Counter++;
        }
        
        /// <summary>
        /// Resets this instance
        /// </summary>
        public void Reset()
        {
            Counter = 0;
        }
        
        /// <summary>
        /// Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            return Counter.ToString();
        }

        /// <summary>
        /// Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressKey(SdlKeycode key)
        {
            if (key == SdlKeycode.SdlkUp)
            {
                Increment();
                GameObject.Get<AudioSource>().Play();
                Console.WriteLine("Value: " + Counter);
            }
        }
    }
}