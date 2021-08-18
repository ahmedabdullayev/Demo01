using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Person>> GetAllAsync(bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable(); // same as above
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            query = query
                .Include(p => p.Contacts)
                .ThenInclude(c => c.ContactType);
            var res = await query.ToListAsync();

            if (res.Count > 0)
            {
                await RepoDbContext.Entry(res.First())
                    .Reference(x => x.PersonPicture).LoadAsync();
            }
            return res;
        }
        public Task DeleteAllByFirstNameAsync(string firstName)
        {
            throw new System.NotImplementedException();
        }
    }
}