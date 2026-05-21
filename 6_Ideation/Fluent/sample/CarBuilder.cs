

using Alis.Core.Aspect.Fluent.Words;

namespace Alis.Core.Aspect.Fluent.Sample
{
    /// <summary>
    ///     The sample builder class
    /// </summary>
    public class CarBuilder :
        IBuild<Car>,
        IWithName<CarBuilder, string>,
        IWithModel<CarBuilder, string>,
        IWithColor<CarBuilder, string>
    {
        /// <summary>
        ///     The car
        /// </summary>
        private readonly Car _car = new Car("default", "default", "default");

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The car</returns>
        public Car Build() => _car;

        /// <summary>
        ///     Adds the color using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The car builder</returns>
        public CarBuilder WithColor(string value)
        {
            _car.Color = value;
            return this;
        }

        /// <summary>
        ///     Adds the model using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The car builder</returns>
        public CarBuilder WithModel(string value)
        {
            _car.Model = value;
            return this;
        }

        /// <summary>
        ///     Adds the name using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The car builder</returns>
        public CarBuilder WithName(string value)
        {
            _car.Name = value;
            return this;
        }
    }
}
