﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Bakana.Core.Entities;
using Bakana.Core.Repositories;
using Bakana.ServiceModels.Steps;
using ServiceStack;

namespace Bakana.ServiceInterface.Steps
{
    public class StepService : Service
    {
        private readonly IBatchRepository batchRepository;
        private readonly IStepRepository stepRepository;

        public StepService(
            IBatchRepository batchRepository,
            IStepRepository stepRepository)
        {
            this.batchRepository = batchRepository;
            this.stepRepository = stepRepository;
        }
        
        public async Task<CreateStepResponse> Post(CreateStepRequest request)
        {
            if (!await batchRepository.DoesBatchExist(request.BatchId)) 
                throw Err.BatchNotFound(request.BatchId);

            if (await stepRepository.DoesStepExist(request.BatchId, request.StepName))
                throw Err.StepAlreadyExists(request.StepName);

            var step = request.ConvertTo<Step>();

            await stepRepository.Create(step);

            return new CreateStepResponse();
        }

        public async Task<GetStepResponse> Get(GetStepRequest request)
        {
            if (!await batchRepository.DoesBatchExist(request.BatchId)) 
                throw Err.BatchNotFound(request.BatchId);

            var step = await stepRepository.Get(request.BatchId, request.StepName);
            if (step == null) throw Err.StepNotFound(request.StepName);

            return step.ConvertTo<GetStepResponse>();
        }
        
        public async Task<GetAllStepsResponse> Get(GetAllStepsRequest request)
        {
            if (!await batchRepository.DoesBatchExist(request.BatchId)) 
                throw Err.BatchNotFound(request.BatchId);

            var steps = await stepRepository.GetAll(request.BatchId);

            return new GetAllStepsResponse
            {
                Steps = steps.ConvertTo<List<DomainModels.Step>>()
            };
        }

        public async Task<UpdateStepResponse> Put(UpdateStepRequest request)
        {
            if (!await batchRepository.DoesBatchExist(request.BatchId)) 
                throw Err.BatchNotFound(request.BatchId);

            var step = request.ConvertTo<Step>();

            var updated = await stepRepository.Update(step);
            if (!updated) throw Err.StepNotFound(request.StepName);

            return new UpdateStepResponse();
        }
        
        public async Task<DeleteStepResponse> Delete(DeleteStepRequest request)
        {
            if (!await batchRepository.DoesBatchExist(request.BatchId)) 
                throw Err.BatchNotFound(request.BatchId);

            var step = await stepRepository.Get(request.BatchId, request.StepName);
            if (step == null) throw Err.StepNotFound(request.StepName);

            await stepRepository.Delete(step.Id);

            return new DeleteStepResponse();
        }
    }
}
