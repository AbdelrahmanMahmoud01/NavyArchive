using Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IOfficerReposiotry
    {
        Task<IEnumerable<Officer>> GetOfficersListAsync();
        Task<Officer> GetOfficerById(int? id);
        Task<Officer> AddOfficerAsync(Officer officer);
        Task<int> UpdateOfficerAsync(Officer officer);
        Task DeleteOfficerAsync(Officer officer);
        Task<IEnumerable<Officer>> GetDepartmentOfficers(int id);

    }
}
