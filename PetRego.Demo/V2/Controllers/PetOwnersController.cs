using Microsoft.AspNetCore.Mvc;
using PetRego.Demo.Domain;
using PetRego.Demo.V1.Models;
using PetRego.Demo.V2.Data;
using PetRego.Demo.V2.Models;
using Swashbuckle.AspNetCore.Examples;

namespace PetRego.Demo.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class PetOwnersController : Controller
    {
        readonly IPetRegoService _petRegoService;
        readonly ILinkService _linkService;
        public PetOwnersController(IPetRegoService petRegoService, ILinkService linkService)
        {
            _petRegoService = petRegoService;
            _linkService = linkService;
        }

        [HttpGet("{id}", Name = "getPetOwnerAndFood")]
        [SwaggerResponseExample(200, typeof(SampleData))]
        public IActionResult Get(int id)
        {
            try
            {
                var petOwner = _petRegoService.GetPetOwnerAndPetFoodDetail(id);
                if (petOwner == default(PetOwner<PetDetail>)) return base.NotFound();
                var response = _linkService.GetLink(petOwner);
                return Ok(response);
            }
            catch (System.Exception)
            {
                return StatusCode(500);//Shout//yell//log;
            }
        }
    }
}
