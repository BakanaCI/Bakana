using System.Threading.Tasks;
using Bakana.Core.Entities;

namespace Bakana.Core.Repositories
{
    public interface IBatchRepository
    {
        Task CreateOrUpdate(Batch batch);
        Task Delete(string batchId);
        Task<Batch> Get(string batchId);
        Task CreateOrUpdateBatchArtifact(BatchArtifact artifact);
        Task CreateOrUpdateBatchVariable(BatchVariable variable);
        Task CreateOrUpdateBatchOption(BatchOption option);
    }
}