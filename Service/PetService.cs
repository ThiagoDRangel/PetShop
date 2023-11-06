namespace PetShop.Service;
using PetShop.Model;

public class PetService: IPetService {

    private static List<Pet> pets = new List<Pet>();

    public List<Pet> GetPets() {

        return pets;
    }

    public Pet AddPet(Pet newPet) {

        newPet.Id = pets.Count + 1;
        pets.Add(newPet);
        return newPet;
    }

    public Pet UpdatePet(int PetId, Pet pet) {

        Pet findPet = pets.Find(pet => pet.Id == PetId)!;
        if (findPet == null) {
            throw new Exception("Pet not found");
        }
        else {
            findPet.Name = pet.Name;
            findPet.Breed = pet.Breed;
            findPet.Age = pet.Age;
            return findPet;
        }
    }

    public void DeletePet(int PetId) {
            
            Pet findPet = pets.Find(pet => pet.Id == PetId)!;
            if (findPet == null) {
                throw new Exception("Pet not found");
            }
            else {
                pets.Remove(findPet);
            }
    }
}