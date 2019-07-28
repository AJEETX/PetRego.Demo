using Microsoft.AspNetCore.Mvc;
using PetRego.Demo.Domain;
using PetRego.Demo.V1.Data;
using PetRego.Demo.V1.Models;
using Swashbuckle.AspNetCore.Examples;

namespace PetRego.Demo.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class PetOwnersController : Controller
    {
        readonly IPetRegoService _petRegoService;
        readonly ILinkService<PetBasicData> _linkService;
        public PetOwnersController(IPetRegoService petRegoService, ILinkService<PetBasicData> linkService)
        {
            _petRegoService = petRegoService;
            _linkService = linkService;
        }
        [HttpGet("{id}", Name = "getPetOwner")]
        [SwaggerResponseExample(200, typeof(OwnerAndPetBasicData))]
        public IActionResult Get(int id)
        {
            try
            {
                PetOwner<PetBasicData> petOwner = _petRegoService.GetPetOwnerAndPet<PetBasicData>(1,id);
                if (petOwner == default(PetOwner<PetBasicData>)) return base.NotFound();
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
