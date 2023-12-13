using Microsoft.AspNetCore.Mvc;
using PersonsManagerApi.Controllers;
using PersonsManagerApi.Services.Interfaces;
using PersonsManagerApi.Data;
using PersonsManagerApi.Services;
using PersonsManagerApi.Models;

namespace PersonsManagerTests
{

    [TestClass]
    public class PersonsControllerTests
    {
        private IPersonsService? _personsService;
        private PersonsController? _controller;

        [TestInitialize]
        public void SetUp()
        {
            _personsService = new PersonsService();
            _controller = new PersonsController(_personsService);
            SeedData.DeleteAll();
            SeedData.GenerateSeedData();
        }

        [TestMethod]
        public async Task GetAllPersons_Success()
        {
            List<Person> persons = SeedData.Persons();
            var result = await _controller!.Get();
            var response = (PersonsResponse)((ObjectResult)result.Result!).Value!;
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccess);
            Assert.IsNotNull(result);
            Assert.AreEqual(persons.Count, response.Persons!.Count());
        }

        [TestMethod]
        public async Task GetPerson_Success()
        {
            var result = await _controller!.Get(1);
            var response = (PersonResponse)((ObjectResult)result.Result!).Value!;
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccess);
            Assert.AreEqual(1, response!.Person!.Id);
        }

        [TestMethod]
        public async Task CreatePerson_Success()
        {
            PersonCreationRequest request = new PersonCreationRequest()
            {
                Age = 1,
                FirstName = "Test",
                LastName = "Test",
            };
            var result = await _controller!.Post(request);
            var response = (PersonResponse)((ObjectResult)result.Result!).Value!;

            Assert.IsTrue(response.IsSuccess);
        }

        [TestMethod]
        public async Task UpdatePerson_Success()
        {
            List<Person> personsBefore = SeedData.Persons();
            Person personBefore = personsBefore.Find(x => x.Id == 1)!;

            PersonUpdateRequest request = new PersonUpdateRequest()
            {
                Id = 1,
                Age = 40,
                FirstName = "Kelly",
                LastName = "Pritts",
            };

            var result = await _controller!.Put(request);
            var response = (PersonResponse)((ObjectResult)result.Result!).Value!;
            Assert.IsTrue(response.IsSuccess);

            List<Person> personsAfter = SeedData.Persons();
            Person personAfter = personsAfter.Find(x => x.Id == 1)!;

            Assert.AreEqual(29, personBefore.Age);
            Assert.AreEqual(40, personAfter.Age);
        }

        [TestMethod]
        public async Task UpdatePerson_Fail_InvalidId()
        {

            PersonUpdateRequest request = new PersonUpdateRequest()
            {
                Id = 1001,
                Age = 40,
                FirstName = "test",
                LastName = "test",
            };

            var result = await _controller!.Put(request);
            var response = (PersonResponse)((ObjectResult)result.Result!).Value!;

            Assert.IsNotNull(response);
            Assert.IsFalse(response.IsSuccess);
            Assert.IsNull(response.Person);
        }

        [TestMethod]
        public async Task DeletePerson_Success()
        {
            var result = await _controller!.Delete(2);
            var response = (PersonResponse)((ObjectResult)result.Result!).Value!;
            Assert.IsTrue(response.IsSuccess);

            List<Person> personsAfter = SeedData.Persons();
            Person personAfter = personsAfter.Find(x => x.Id == 2)!;

            Assert.IsNull(personAfter);

        }

        [TestMethod]
        public async Task DeletePerson_ValidationError_InvalidId()
        {
            var result = await _controller!.Delete(-1);
            BadRequestObjectResult badRequestObjectResult = (BadRequestObjectResult)result!.Result!;
            int statusCode = (int)badRequestObjectResult.StatusCode!;
            Assert.AreEqual(400, statusCode);

        }

        [TestMethod]
        public async Task GetPerson_ValidationError_InvalidId()
        {
            var result = await _controller!.Get(-1);

            BadRequestObjectResult badRequestObjectResult = (BadRequestObjectResult)result!.Result!;
            int statusCode = (int)badRequestObjectResult.StatusCode!;
            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public async Task GetPerson_InvalidPerson()
        {
            var result = await _controller!.Get(1001);
            var response = (PersonResponse)((ObjectResult)result.Result!).Value!;

            Assert.IsNotNull(response);
            Assert.IsFalse(response.IsSuccess);
            Assert.IsNull(response.Person);

        }

        [TestMethod]
        public async Task DeletePerson_InvalidPerson()
        {
            var result = await _controller!.Delete(1001);

            var response = (PersonResponse)((ObjectResult)result.Result!).Value!;
            Assert.IsNotNull(response);
            Assert.IsFalse(response.IsSuccess);

        }
    }
}