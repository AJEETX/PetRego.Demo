using Microsoft.AspNetCore.Mvc;
using PetRego.Demo.Domain;
using PetRego.Demo.Helper;
using PetRego.Demo.Models.V1;
using PetRego.Demo.Models.V2;
using Swashbuckle.AspNetCore.Examples;

namespace PetRego.Demo.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    public class PetOwnersController : Controller
    {
        readonly IPetRegoService _petRegoService;
        readonly ILinkService _linkService;
        public PetOwnersController(IPetRegoService petRegoService,ILinkService linkService)
        {
            _petRegoService = petRegoService;
            _linkService = linkService;
        }

        [HttpGet("{id}", Name = "getPetOwnerAndFood")]
        [SwaggerResponseExample(200, typeof(Sample2Data))]
        public IActionResult GetOwnerPetFood(int id)
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
