using System.Threading.Tasks;

namespace CounselingCenter.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}