namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl viewport
    /// </summary>
    public struct MTLViewport
    {
        /// <summary>
        /// The origin
        /// </summary>
        public double originX;
        /// <summary>
        /// The origin
        /// </summary>
        public double originY;
        /// <summary>
        /// The width
        /// </summary>
        public double width;
        /// <summary>
        /// The height
        /// </summary>
        public double height;
        /// <summary>
        /// The znear
        /// </summary>
        public double znear;
        /// <summary>
        /// The zfar
        /// </summary>
        public double zfar;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLViewport"/> class
        /// </summary>
        /// <param name="originX">The origin</param>
        /// <param name="originY">The origin</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="znear">The znear</param>
        /// <param name="zfar">The zfar</param>
        public MTLViewport(double originX, double originY, double width, double height, double znear, double zfar)
        {
            this.originX = originX;
            this.originY = originY;
            this.width = width;
            this.height = height;
            this.znear = znear;
            this.zfar = zfar;
        }
    }
}