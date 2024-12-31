using giareta_crud.Models;
using System.Reflection.Metadata;

namespace giareta_crud.Services
{
    public interface IPersonService
    {
        Task<PersonModel> CreatePerson(string name);
        Task<List<PersonModel>> GetPeople();
        Task<PersonModel> GetPersonById(Guid id);
        Task UpdatePerson(PersonModel person, string newName);
        Task DeletePerson(PersonModel id);
        
    }
}
