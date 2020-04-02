using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Bakana.Core.Entities;
using Bakana.Core.Extensions;
using ServiceStack.OrmLite;

namespace Bakana.Core.Repositories
{
    public static class BatchExtensions
    {
        internal static async Task CreateBatch(this IDbConnection db, Batch batch)
        {
            await db.SaveAsync(batch, true);

            await db.CreateOrUpdateBatchArtifacts(batch.InputArtifacts);
            await db.CreateOrUpdateBatchVariables(batch.Variables);
            await db.CreateOrUpdateBatchOptions(batch.Options);
            await db.CreateSteps(batch.Steps);
        }
        
        internal static async Task UpdateBatch(this IDbConnection db, Batch batch)
        {
            await db.UpdateAsync(batch);
        }

        internal static async Task<Batch> GetBatch(this IDbConnection db, string batchId)
        {
            var batch = await db.LoadSingleByIdAsync<Batch>(
                batchId, include: 
                new[] { nameof(Batch.Options), nameof(Batch.Variables) });
                
            batch.InputArtifacts = await db.LoadSelectAsync<BatchArtifact>(artifact => artifact.BatchId == batchId);
            batch.Steps = await db.GetAllSteps(batchId);

            return batch;
        }

        internal static async Task UpdateBatchState(this IDbConnection db, string batchId, BatchState state)
        {
            await db.UpdateOnlyAsync(() => new Batch { State = state }, where: p => p.Id == batchId);
        }
        
        internal static async Task CreateOrUpdateBatchOptions(this IDbConnection db, IEnumerable<BatchOption> options)
        {
            if (options == null) return;

            await options.Iter(db.CreateOrUpdateBatchOption);
        }

        internal static async Task<ulong> CreateOrUpdateBatchOption(this IDbConnection db, BatchOption option)
        {
            await db.SaveAsync(option, true);
            return option.Id;
        }
        
        internal static async Task<BatchOption> GetBatchOption(this IDbConnection db, ulong id)
        {
            return await db.LoadSingleByIdAsync<BatchOption>(id);
        }
        
        internal static async Task<List<BatchOption>> GetAllBatchOptions(this IDbConnection db, string batchId)
        {
            return await db.LoadSelectAsync<BatchOption>(c => c.BatchId == batchId);
        }

        internal static async Task<ulong> GetBatchOptionPkByOptionId(this IDbConnection db, string batchId, string optionId)
        {
            var q = db
                .From<BatchOption>()
                .Where(c => c.OptionId == optionId && c.BatchId == batchId)
                .Select(c => c.Id);

            return await db.ScalarAsync<ulong>(q);
        }

        internal static async Task CreateOrUpdateBatchVariables(this IDbConnection db, IEnumerable<BatchVariable> variables)
        {
            if (variables == null) return;

            await variables.Iter(db.CreateOrUpdateBatchVariable);
        }

        internal static async Task CreateOrUpdateBatchVariable(this IDbConnection db, BatchVariable variable)
        {
            await db.SaveAsync(variable, true);
        }
        
        internal static async Task<BatchVariable> GetBatchVariable(this IDbConnection db, ulong id)
        {
            return await db.LoadSingleByIdAsync<BatchVariable>(id);
        }
        
        internal static async Task<List<BatchVariable>> GetAllBatchVariables(this IDbConnection db, string batchId)
        {
            return await db.LoadSelectAsync<BatchVariable>(c => c.BatchId == batchId);
        }

        internal static async Task<ulong> GetBatchVariablePkByVariableId(this IDbConnection db, string batchId, string variableId)
        {
            var q = db
                .From<BatchVariable>()
                .Where(c => c.VariableId == variableId && c.BatchId == batchId)
                .Select(c => c.Id);

            return await db.ScalarAsync<ulong>(q);
        }
        
        internal static async Task CreateOrUpdateBatchArtifacts(this IDbConnection db, IEnumerable<BatchArtifact> artifacts)
        {
            if (artifacts == null) return;

            await artifacts.Iter(db.CreateOrUpdateBatchArtifact);
        }
        
        internal static async Task CreateOrUpdateBatchArtifact(this IDbConnection db, BatchArtifact artifact)
        {
            await db.SaveAsync(artifact, true);
        }
        
        internal static async Task UpdateBatchArtifact(this IDbConnection db, BatchArtifact artifact)
        {
            await db.UpdateAsync(artifact);
        }
        
        internal static async Task<ulong> GetBatchArtifactPkByArtifactId(this IDbConnection db, string batchId, string artifactId)
        {
            var q = db
                .From<BatchArtifact>()
                .Where(c => c.ArtifactId == artifactId && c.BatchId == batchId)
                .Select(c => c.Id);

            return await db.ScalarAsync<ulong>(q);
        }

        internal static async Task<BatchArtifact> GetBatchArtifact(this IDbConnection db, ulong id)
        {
            return await db.LoadSingleByIdAsync<BatchArtifact>(id);
        }
        
        internal static async Task<List<BatchArtifact>> GetAllBatchArtifacts(this IDbConnection db, string batchId)
        {
            return await db.LoadSelectAsync<BatchArtifact>(a => a.BatchId == batchId);
        }
        
        internal static async Task<ulong> CreateOrUpdateBatchArtifactOption(this IDbConnection db, BatchArtifactOption option)
        {
            await db.SaveAsync(option, true);
            
            return option.Id;
        }
        
        internal static async Task<BatchArtifactOption> GetBatchArtifactOption(this IDbConnection db, ulong id)
        {
            return await db.LoadSingleByIdAsync<BatchArtifactOption>(id);
        }
        
        internal static async Task<List<BatchArtifactOption>> GetAllBatchArtifactOptions(this IDbConnection db, ulong batchArtifactId)
        {
            return await db.LoadSelectAsync<BatchArtifactOption>(c => c.BatchArtifactId == batchArtifactId);
        }

        internal static async Task<ulong> GetBatchArtifactOptionPkByOptionId(this IDbConnection db, ulong batchArtifactId, string optionId)
        {
            var q = db
                .From<BatchArtifactOption>()
                .Where(c => c.OptionId == optionId && c.BatchArtifactId == batchArtifactId)
                .Select(c => c.Id);

            return await db.ScalarAsync<ulong>(q);
        }
    }
}