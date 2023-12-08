using PersonsManagerApi.Models;
using PersonsManagerApi.Data;
using PersonsManagerApi.Services.Interfaces;

namespace PersonsManagerApi.Services
{
  
    public class PersonsService: IPersonsService
    {
        public async Task<PersonResponse> CreatePerson(PersonCreationRequest personCreationRequest)
        {
            PersonResponse response = new PersonResponse()
            {
                IsSuccess = true,
                Message = "Success"
            };

            try
            {
                Person newPerson = new Person()
                {
                    Age =       personCreationRequest.Age,
                    FirstName = personCreationRequest.FirstName,
                    LastName =  personCreationRequest.LastName,
                   
                };

                Person newPersonWithId = SeedData.AddPerson(newPerson);

                response.Person = newPerson;
                await Task.CompletedTask; // await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
               
            }

            return response;
        }
        public async Task<PersonResponse> UpdatePerson(PersonUpdateRequest personUpdateRequest)
        {
            PersonResponse response = new PersonResponse()
            {
                IsSuccess = true,
                Message = "Success"
            };

            try
            {
                int index = SeedData.Persons().FindIndex(x => x.Id == personUpdateRequest.Id);
                if (index < 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid Person";
                }

                Person personToUpdate = new Person()
                {
                    Id = personUpdateRequest.Id,
                    Age = personUpdateRequest.Age,
                    FirstName = personUpdateRequest.FirstName,
                    LastName = personUpdateRequest.LastName,

                };

                response.Person = SeedData.UpdatePerson(index, personToUpdate);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }


            await Task.CompletedTask; // await _context.SaveChangesAsync();

            return response;
        }
        public async Task<PersonsResponse> GetAllPersons()
        {
            PersonsResponse response = new PersonsResponse()
            {
                IsSuccess = true,
                Message= "Success"
            };
            response.Persons = SeedData.Persons();

            await Task.CompletedTask; 

            return response;
        }
        public async Task<PersonResponse> GetPerson(int id)
        {
            PersonResponse response = new PersonResponse()
            {
                IsSuccess = true,
                Message = "Success"
            };
            try
            {
                response.Person = SeedData.Persons().Find(x => x.Id == id);
                if (response.Person == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid Person"; 
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            await Task.CompletedTask;

            return response;
        }
        public async Task<PersonResponse> DeletePerson(int id)
        {
            PersonResponse response = new PersonResponse()
            {
                IsSuccess = true,
                Message = "Success"
            };

            try
            {
                int index = SeedData.Persons().FindIndex(x => x.Id == id);
                if (index < 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid Person";
                    return response;
                }
                SeedData.DeletePerson(index);
                
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            await Task.CompletedTask; // await _context.SaveChangesAsync();

            return response;
        }
    }
}
