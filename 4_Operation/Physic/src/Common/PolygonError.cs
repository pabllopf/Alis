

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     Specifies validation errors that can occur when creating or validating a polygon shape.
    /// </summary>
    /// <remarks>
    ///     <para>Polygons in the physics engine must meet specific requirements to ensure stable
    ///     collision detection and realistic behavior.</para>
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Error</term>
    ///             <description>Description</description>
    ///         </listheader>
    ///         <item>
    ///             <term><see cref="NoError"/></term>
    ///             <description>Polygon is valid</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="InvalidAmountOfVertices"/></term>
    ///             <description>Must have 3 to <c>Settings.MaxPolygonVertices</c> vertices</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="NotSimple"/></term>
    ///             <description>Edges must not self-intersect</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="NotCounterClockWise"/></term>
    ///             <description>Vertices must be ordered counter-clockwise</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="NotConvex"/></term>
    ///             <description>All interior angles must be 180° or less</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="AreaTooSmall"/></term>
    ///             <description>Polygon area must exceed minimum threshold</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="SideTooSmall"/></term>
    ///             <description>Each edge length must exceed minimum threshold</description>
    ///         </item>
    ///     </list>
    /// </remarks>
    public enum PolygonError
    {
        /// <summary>
        ///     There were no errors in the polygon
        /// </summary>
        NoError,

        /// <summary>
        ///     Polygon must have between 3 and Settings.MaxPolygonVertices vertices.
        /// </summary>
        InvalidAmountOfVertices,

        /// <summary>
        ///     Polygon must be simple. This means no overlapping edges.
        /// </summary>
        NotSimple,

        /// <summary>
        ///     Polygon must have a counter clockwise winding.
        /// </summary>
        NotCounterClockWise,

        /// <summary>
        ///     The polygon is concave, it needs to be convex.
        /// </summary>
        NotConvex,

        /// <summary>
        ///     Polygon area is too small.
        /// </summary>
        AreaTooSmall,

        /// <summary>
        ///     The polygon has a side that is too short.
        /// </summary>
        SideTooSmall
    }
}