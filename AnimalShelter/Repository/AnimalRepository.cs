using AnimalShelter.Contracts;
using AnimalShelter.Models;

namespace AnimalShelter.Repository
{
    public class AnimalRepository : RepositoryBase<Animal>, IAnimalRepository
    {
        public AnimalRepository(AnimalShelterContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Animal> GetAnimals(PagedParameters animalParameters)
        {
            return PagedList<Animal>.ToPagedList(FindAll(),
                animalParameters.PageNumber,
                animalParameters.PageSize);
        }

        public Animal GetAnimalById(Guid animalId)
        {
            return FindByCondition(ani => ani.AnimalId.Equals(animalId))
                .DefaultIfEmpty(new Animal())
                .FirstOrDefault();
        }

    }
}