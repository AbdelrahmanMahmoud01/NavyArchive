using Application.Contracts;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OfficerRepository : IOfficerReposiotry
    {
        private readonly DataContext context;

        public OfficerRepository(DataContext context)
        {
            this.context = context;
        }

        private async Task Commit() => await context.SaveChangesAsync();

        public async Task<Officer> AddOfficerAsync(Officer officer)
        {
            await context.Officers.AddAsync(officer);
            await Commit();

            return officer;
        }

        public async Task<Officer> GetOfficerById(int? id)
        {
            Officer dtos = await context.Officers.Include(x=> x.Destination).FirstOrDefaultAsync(x=> x.Id == id);

            return dtos;
        }

        public async Task<IEnumerable<Officer>> GetOfficersListAsync()
        {
            List<Officer> allOfficers = new List<Officer>();
            allOfficers = await context.Officers.Include(x => x.Destination).AsNoTracking().ToListAsync();
            return allOfficers;
        }

        public async Task<int> UpdateOfficerAsync(Officer officer)
        {
            context.Update(officer);
            await Commit();
            return officer.Id;
        }

        public async Task DeleteOfficerAsync(Officer officer)
        {
            var query = await context.Officers
                    .Include(d => d.Destination).FirstOrDefaultAsync(o => o.Id == officer.Id);

            context.Officers.Remove(officer);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Officer>> GetDepartmentOfficers(int id)
        {

            var query = await Task.Run(() => context.Destinations.Where(s => s.Id == id)
                 .FirstOrDefault().Officers.Select(c => new Officer { Id = c.Id, Name = c.Name }).ToList());

            return query;
        }

    }
}
