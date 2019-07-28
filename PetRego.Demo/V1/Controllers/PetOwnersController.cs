using Microsoft.AspNetCore.Mvc;
using PetRego.Demo.Domain;
using PetRego.Demo.V1.Data;
using PetRego.Demo.V1.Models;
using Swashbuckle.AspNetCore.Examples;
using System;

namespace PetRego.Demo.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class PetOwnersController : Controller
    {
        int version = 1;
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
                PetOwner<PetBasicData> petOwner = _petRegoService.GetPetOwnerAndPet<PetBasicData>(version, id);
                if (petOwner == default(PetOwner<PetBasicData>)) return base.NotFound();
                var response = _linkService.GetLink(petOwner);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);//Shout//yell//log;
            }
        }
        [HttpPost(Name = "AddPetOwner")]
        public IActionResult Post([FromBody] PetOwner<PetBasicData> inputModel)
        {
            if (inputModel == default(PetOwner<PetBasicData>)) return BadRequest();
            try
            {
                _petRegoService.AddPetOwner(version, inputModel);
            }
            catch (Exception)
            {
                return StatusCode(500);//Shout//yell//log;
            }
            return CreatedAtRoute("getPetOwner", new { id = inputModel.Id }, inputModel);
        }
        [HttpPut("{id}", Name = "UpdatePetOwner")]
        public IActionResult Update(int id, [FromBody]PetOwner<PetBasicData> inputModel)
        {
            //To-Do
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeletePetOwner")]
        public IActionResult Delete(int id)
        {
            //To-Do
            return NoContent();
        }
    }
}
