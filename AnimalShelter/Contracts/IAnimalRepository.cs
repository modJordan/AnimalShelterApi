using AnimalShelter.Models;

namespace AnimalShelter.Contracts
{
    public interface IAnimalRepository : IRepositoryBase<Animal>
    {
        PagedList<Animal> GetAnimals(PagedParameters animalParameters);
        Animal GetAnimalById(Guid animalId);
    }
}