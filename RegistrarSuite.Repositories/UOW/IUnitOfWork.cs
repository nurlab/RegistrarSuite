using System.Threading.Tasks;

namespace RegistrarSuite.Repositories.UOW
{
    public interface IUnitOfWork<T>
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
