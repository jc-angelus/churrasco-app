using Churrasco.Infrastructure.Context;
using Churrasco.Infrastructure.Repositories.Interfaces.Generic;

namespace Churrasco.Infrastructure.Repositories.Generic
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: UnitOfWork
    /// </summary
    public class UnitOfWork : IUnitOfWork
    {
        public ChallengeContext Context { get; }

        public UnitOfWork(ChallengeContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
