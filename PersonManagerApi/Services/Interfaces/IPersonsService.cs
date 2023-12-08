using PersonsManagerApi.Data;
using PersonsManagerApi.Models;

namespace PersonsManagerApi.Services.Interfaces
{
    public interface IPersonsService
    {
        public Task<PersonResponse> CreatePerson(PersonCreationRequest personCreationRequest);
        public Task<PersonResponse> UpdatePerson(PersonUpdateRequest personUpdateRequest);
        public Task<PersonsResponse> GetAllPersons();
        public Task<PersonResponse> GetPerson(int id);
        public Task<PersonResponse> DeletePerson(int id);
    }
}
