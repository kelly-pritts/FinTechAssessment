using PersonsManagerApi.Data;
using PersonsManagerApi.Models;

namespace PersonsManagerApi.Services.Interfaces
{
    //The expected input/output of this service when implemented by another class
    // actions: CRUD plus R+ to pull all the Persons (PEOPLE!)
    public interface IPersonsService
    {
        public Task<PersonResponse> CreatePerson(PersonCreationRequest personCreationRequest);
        public Task<PersonResponse> UpdatePerson(PersonUpdateRequest personUpdateRequest);
        public Task<PersonsResponse> GetAllPersons();
        public Task<PersonResponse> GetPerson(int id);
        public Task<PersonResponse> DeletePerson(int id);
    }
}
