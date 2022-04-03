using Application.Contracts;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository :  BaseRepository<FileDestination> , IDepartmentRepository
    {
        private readonly DataContext context;

        public DepartmentRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<FileDestination> GetDestinationById(int id)
        {
            return await context.Destinations.Include(x=> x.Officers).FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}
