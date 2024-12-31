using giareta_crud.Data;
using giareta_crud.Models;
using giareta_crud.Services;
using Microsoft.EntityFrameworkCore;

namespace giareta_crud.Routes
{
    public static class PersonRoute
    {
        public static void PersonRoutes(this WebApplication app)
        {
            var route = app.MapGroup("person");

            route.MapPost("", async (PersonRequest req, IPersonService personService) =>
            {
                var person = await personService.CreatePerson(req.name);

                return Results.Created($"/person/{person.Id}", person);
            });

            route.MapGet("", async ( IPersonService personService) =>
            {
                var people = await personService.GetPeople();
                
                return Results.Ok(people);
            });

            route.MapPut("{id:guid}", async (Guid Id, PersonRequest req, IPersonService personService) =>
            {
                var person = await personService.GetPersonById(Id);
                if(person == null)
                    return Results.NotFound();

                await personService.UpdatePerson(person, req.name);

                return Results.Ok(person);
            });

            route.MapDelete("{id:guid}", async (Guid Id, IPersonService personService) =>
            {
                var person = await personService.GetPersonById(Id);
                if(person == null)
                    return Results.NotFound();

                await personService.DeletePerson(person);

                return Results.Ok(person);
            });

        }
    }
}
