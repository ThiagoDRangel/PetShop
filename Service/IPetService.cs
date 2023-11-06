namespace PetShop.Service;
using PetShop.Model;

public interface IPetService {

    List<Pet> GetPets();
    Pet AddPet(Pet newPet);

    Pet UpdatePet(int PetId, Pet pet);

    void DeletePet(int PetId);
}