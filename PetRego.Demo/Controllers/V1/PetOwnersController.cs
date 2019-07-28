using Microsoft.AspNetCore.Mvc;
using PetRego.Demo.Domain;
using PetRego.Demo.Helper;
using PetRego.Demo.Models.V1;
using Swashbuckle.AspNetCore.Examples;

namespace PetRego.Demo.Controllers.V1
{
    [ApiVersion("1.0")]
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
        [HttpGet("{id}",Name = "getPetOwner")]
        [SwaggerResponseExample(200, typeof(Sample1Data))]
        public IActionResult GetOwnerPet(int id)
        {
            try
            {
                PetOwner<Pet> petOwner = _petRegoService.GetPetOwnerAndPet(id);
                if (petOwner == default(PetOwner<Pet>)) return base.NotFound();
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
