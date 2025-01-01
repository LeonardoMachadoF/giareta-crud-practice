using giareta_crud.Data;
using giareta_crud.Models;
using Microsoft.EntityFrameworkCore;

namespace giareta_crud.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _context;

        public PersonRepository(PersonContext context)
        {
            _context = context;
        }

        public async Task<PersonModel> CreatePerson(PersonModel person)
        {
            await _context.AddAsync(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<List<PersonModel>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<PersonModel> GetPersonById(Guid id)
        {
            return await _context.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdatePerson(PersonModel person)
        {
            _context.People.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePerson(PersonModel person)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }
    }

}
