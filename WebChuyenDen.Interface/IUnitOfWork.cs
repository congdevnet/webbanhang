using System.Threading.Tasks;

namespace WebChuyenDen.Interface
{
    public interface IUnitOfWork
    {
        void Commit();

        Task CommitAnysc();
    }
}