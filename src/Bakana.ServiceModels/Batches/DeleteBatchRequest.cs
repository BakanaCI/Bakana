﻿using System.Net;
using ServiceStack;

namespace Bakana.ServiceModels.Batches
{
    [Tag("Batch")]
    [Route("/batch/{BatchId}", HttpMethods.Delete, Summary = "Delete Batch")]
    [ApiResponse(HttpStatusCode.NotFound, "The Batch was not found")]
    public class DeleteBatchRequest : IReturn<DeleteBatchResponse>
    {
        [ApiMember(
            Description = "A system-generated identifier associated with the Batch",
            DataType = "string",
            ParameterType = "path",
            IsRequired = true)]
        public string BatchId { get; set; }
    }

    public class DeleteBatchResponse : IHasResponseStatus
    {
        public ResponseStatus ResponseStatus { get; set; }
    }
}