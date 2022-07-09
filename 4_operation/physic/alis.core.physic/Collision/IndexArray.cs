using System;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// The index array
    /// </summary>
    public struct IndexArray
    {
        /// <summary>
        /// The 
        /// </summary>
        private Byte I0;

        /// <summary>
        /// The 
        /// </summary>
        private Byte I1;

        /// <summary>
        /// The 
        /// </summary>
        private Byte I2;

        /// <summary>
        /// The value
        /// </summary>
        public Byte this[int index]
        {
            get
            {
#if DEBUG
                Box2DXDebug.Assert(index >= 0 && index < 3);
#endif
                if (index == 0) return I0;
                if (index == 1) return I1;
                return I2;
            }
            set
            {
#if DEBUG
                Box2DXDebug.Assert(index >= 0 && index < 3);
#endif
                if (index == 0) I0 = value;
                else if (index == 1) I1 = value;
                else I2 = value;
            }
        }
    }
}