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

    [HttpPost]
    public IActionResult PostPet([FromBody] Pet newPet) {

        newPet.Id = pets.Count + 1;
        pets.Add(newPet);
        return Created("", newPet);
    }

    [HttpPut("{PetId}")]
    public IActionResult PutPet(int PetId, [FromBody] Pet pet) {

        Pet findPet = pets.Find(pet => pet.Id == PetId)!;
        if (findPet == null) {
            return NotFound(new { message = "Pet not found" });
        }
        else {
            findPet.Name = pet.Name;
            findPet.Breed = pet.Breed;
            findPet.Age = pet.Age;
            return Ok(findPet);
        }
    }
}