using Domain.Entites;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IDepartmentRepository : IAsyncReposiotry<FileDestination>
    {
        Task<FileDestination> GetDestinationById(int id);

    }
}
