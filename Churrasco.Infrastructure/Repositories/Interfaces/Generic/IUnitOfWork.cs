using Churrasco.Infrastructure.Context;

namespace Churrasco.Infrastructure.Repositories.Interfaces.Generic
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Interface: IUnitOfWork
    /// </summary
    public interface IUnitOfWork : IDisposable
    {
        ChallengeContext Context { get; }
        void Commit();
    }
}
