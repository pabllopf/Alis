

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     Called for each fixture found in the query.
    ///     <returns>true: Continues the query, false: Terminate the query</returns>
    /// </summary>
    public delegate bool QueryReportFixtureDelegate(Fixture fixture);
}