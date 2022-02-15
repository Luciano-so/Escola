using System.Threading.Tasks;

namespace Escola.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
