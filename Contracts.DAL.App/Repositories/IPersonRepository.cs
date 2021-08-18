using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain.App;

namespace Contracts.DAL.App.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        //ADD YOUR person custom method declarations here
        Task DeleteAllByFirstNameAsync(string firstName);
        
    }
}