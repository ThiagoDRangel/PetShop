namespace PetShop.Controllers;
using Microsoft.AspNetCore.Mvc;
using PetShop.Model;
using PetShop.Service;

[ApiController]
[Route("[controller]")]
public class PetController: ControllerBase {

    private IPetService _service; // dependency inversion

    public PetController(IPetService service) {

        _service = service; // dependency injection
    }

    [HttpGet]
    public IActionResult GetPets() {

        return Ok(_service.GetPets());
    }

    [HttpPost]
    public IActionResult PostPet([FromBody] Pet newPet) {

        return Created("", _service.AddPet(newPet));
    }

    [HttpPut("{PetId}")]
    public IActionResult PutPet(int PetId, [FromBody] Pet pet) {

        try {
            return Ok(_service.UpdatePet(PetId, pet));
        }
        catch(Exception error) {
            return NotFound(new { message = error.Message });
        }
    }

    [HttpDelete("{PetId}")]
    public IActionResult DeletePet(int PetId) {
        
        try {
            _service.DeletePet(PetId);
            return NoContent();
        }
        catch(Exception error) {
            return NotFound(new { message = error.Message });
        }
    }
}