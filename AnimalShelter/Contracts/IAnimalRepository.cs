using AnimalShelter.Models;

namespace AnimalShelter.Contracts
{
    public interface IANimalRepository : IRepositoryBase<Animal>
    {
        PagedList<Animal> GetAnimals(PagedParameters animalParameters);
        Animal GetAnimalById(Guid animalId);
    }
}