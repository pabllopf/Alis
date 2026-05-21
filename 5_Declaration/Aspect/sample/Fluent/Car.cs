

using Alis.Core.Aspect.Fluent;

namespace Alis.Core.Aspect.Sample.Fluent
{
    /// <summary>
    ///     The car class
    /// </summary>
    /// <seealso cref="IHasBuilder{TOut}" />
    public class Car : IHasBuilder<CarBuilder>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Car" /> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="model">The model</param>
        /// <param name="color">The color</param>
        public Car(string name, string model, string color)
        {
            Name = name;
            Model = model;
            Color = color;
        }

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the value of the model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        ///     Gets or sets the value of the color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The car builder</returns>
        public CarBuilder Builder() => new CarBuilder();

        /// <summary>
        ///     Creates
        /// </summary>
        /// <returns>The car builder</returns>
        public static CarBuilder Create() => new CarBuilder();
    }
}