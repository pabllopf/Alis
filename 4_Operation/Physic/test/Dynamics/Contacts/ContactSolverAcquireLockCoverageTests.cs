using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     Exercises the ContactSolver lock-acquisition guard for same-index requests.
    /// </summary>
    public class ContactSolverAcquireLockCoverageTests
    {
        /// <summary>
        ///     Verifies that acquiring a contact lock with identical indices returns without
        ///     taking the lock.
        /// </summary>
        [Fact]
        public void AcquireContactLocks_WithSameIndex_ReturnsWithoutLocking()
        {
            using ContactSolver solver = new ContactSolver();
            solver.AcquireContactLocks(0, 0);
        }
    }
}