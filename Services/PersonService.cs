using giareta_crud.Data;
using giareta_crud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;

namespace giareta_crud.Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonContext _context; 
 
        public PersonService(PersonContext context)
        {
            _context = context;
        }
        public async Task<PersonModel> CreatePerson(string name)
        {
            var person = new PersonModel(name);
            await _context.AddAsync(person);
            await _context.SaveChangesAsync();

            return person;
        }

        public async Task<List<PersonModel>> GetPeople()
        {
            var people = await _context.People.ToListAsync();
            return people;

        }

        public async Task<PersonModel> GetPersonById(Guid id)
        {
            var person = await _context.People.FirstOrDefaultAsync(x => x.Id == id);

            return person;
        }

        public async Task UpdatePerson(PersonModel person, string newName)
        {
            person.ChangeName(newName);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePerson(PersonModel person)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
