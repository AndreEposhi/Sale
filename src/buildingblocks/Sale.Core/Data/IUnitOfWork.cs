using System.Threading.Tasks;

namespace Sale.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}