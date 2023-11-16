using ApiTemp.Contracts;
using ApiTemp.Models;

namespace ApiTemp.Repository
{
    public class ModelRepository : RepositoryBase<Model>, IModelRepository
    {
        public ModelRepository(ApiTempContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Model> GetModels(PagedParameters modelParameters)
        {
            return PagedList<Model>.ToPagedList(FindAll(),
                modelParameters.PageNumber,
                modelParameters.PageSize);
        }

        public Model GetModelById(Guid modelId)
        {
            return FindByCondition(mod => mod.ModelId.Equals(modelId))
                .DefaultIfEmpty(new Model())
                .FirstOrDefault();
        }

    }
}