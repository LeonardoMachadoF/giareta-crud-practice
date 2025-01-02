using giareta_crud.Models;
using giareta_crud.Repository;

namespace giareta_crud.Tests
{
    public class FakePersonRepository : IPersonRepository
    {
        private readonly List<PersonModel> _people = new();

        public Task CreatePerson(PersonModel person)
        {
            _people.Add(person);
            return Task.CompletedTask;
        }

        public Task DeletePerson(PersonModel person)
        {
            _people.Remove(person);
            return Task.CompletedTask;
        }

        public Task<List<PersonModel>> GetPeople()
        {
            return Task.FromResult(_people);
        }

        public Task<PersonModel> GetPersonById(Guid id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(person);
        }

        public Task UpdatePerson(PersonModel person)
        {
            var existingPerson = _people.FirstOrDefault(p => p.Id == person.Id);
            if(existingPerson != null)
            {
                existingPerson.ChangeName(person.Name);
            }
            return Task.CompletedTask;
        }
    }
}
