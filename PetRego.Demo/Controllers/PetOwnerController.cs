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
        readonly ILinkService _linkService;
        public PetOwnerController(IPetRegoService petRegoService,ILinkService linkService)
        {
            _petRegoService = petRegoService;
            _linkService = linkService;
        }
        [HttpGet(Name = "GetPetOwners"), MapToApiVersion("1.0")]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<PetOwner> petOwners = _petRegoService.GetPetOwners();
                var response = petOwners.Select(p => _linkService.GetLink(p));
                return Ok(response);
            }
            catch (System.Exception)
            {
                return StatusCode(500);//Shout//yell//log;
            }
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
