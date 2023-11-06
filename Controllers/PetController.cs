namespace PetShop.Controllers;
using Microsoft.AspNetCore.Mvc;
using PetShop.Model;

[ApiController]
[Route("[controller]")]
public class PetController: ControllerBase {

    private static List<Pet> pets = new List<Pet>();
    [HttpGet]
    public IActionResult GetPets() {

        return Ok(pets);
    }
}