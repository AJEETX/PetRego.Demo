using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetRego.Demo.Domain;
using PetRego.Demo.Model;

namespace PetRego.Demo.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class PetOwnerController : Controller
    {
        readonly IPetRegoService _petRegoService;
        public PetOwnerController(IPetRegoService petRegoService)
        {
            _petRegoService = petRegoService;
        }
        [HttpGet(Name = "GetPetOwners"), MapToApiVersion("1.0")]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<PetOwner> petOwners = _petRegoService.GetPetOwners();
            }
            catch (Exception)
            {

                throw;
            }
            
            return Ok();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
