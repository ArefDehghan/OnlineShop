using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Application
{
    public interface UnitOfWork
    {
        void Complete();
        Task CompleteAsync();
    }
}