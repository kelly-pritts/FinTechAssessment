using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using PersonsManagerApi.Models;
using PersonsManagerApi.Services;
using PersonsManagerApi.Services.Interfaces;

namespace PersonsManagerApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService _personsService;
       
        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> Get(int id) 
        {
            if (id < 0)
            {
                return BadRequest();
            }
            try
            {
               
                PersonResponse response = await _personsService.GetPerson(id);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpGet]
        public async Task<ActionResult<PersonsResponse>> Get()
        {    
            try
            {
                PersonsResponse response = await _personsService.GetAllPersons();
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpPost]
        public async Task<ActionResult<PersonResponse>> Post([FromBody] PersonCreationRequest newPerson)
        {
            if (newPerson == null)
            {
                return BadRequest();
            }
            try
            {
                PersonResponse response = await _personsService.CreatePerson(newPerson);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpPut]
        public async Task<ActionResult<PersonResponse>> Put([FromBody] PersonUpdateRequest personToUpdate)
        {
            if (personToUpdate == null)
            {
                return BadRequest();
            }
            try
            {
                PersonResponse response = await _personsService.UpdatePerson(personToUpdate);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonResponse>> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            try
            {

                PersonResponse response = await _personsService.DeletePerson(id);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
    }
}
