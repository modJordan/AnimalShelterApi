using ApiTemp.Models;

namespace ApiTemp.Contracts
{
    public interface IModelRepository : IRepositoryBase<Model>
    {
        PagedList<Model> GetModels(PagedParameters modelParameters);
        Model GetModelById(Guid modelId);
    }
}