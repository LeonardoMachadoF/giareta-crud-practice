using giareta_crud.Data;
using giareta_crud.Models;
using giareta_crud.Repository;

namespace giareta_crud.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonModel> CreatePerson(string name)
        {
            var person = new PersonModel(name);
            return await _repository.CreatePerson(person);
        }

        public async Task<List<PersonModel>> GetPeople()
        {
            return await _repository.GetPeople();
        }

        public async Task<PersonModel> GetPersonById(Guid id)
        {
            return await _repository.GetPersonById(id);
        }

        public async Task UpdatePerson(PersonModel person, string newName)
        {
            person.ChangeName(newName);
            await _repository.UpdatePerson(person);
        }

        public async Task DeletePerson(PersonModel person)
        {
            await _repository.DeletePerson(person);
        }
    }

}
