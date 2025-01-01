using giareta_crud.Models;

namespace giareta_crud.Repository
{
    public interface IPersonRepository
    {
        Task<PersonModel> CreatePerson(PersonModel person);
        Task<List<PersonModel>> GetPeople();
        Task<PersonModel> GetPersonById(Guid id);
        Task UpdatePerson(PersonModel person);
        Task DeletePerson(PersonModel person);
    }

}
