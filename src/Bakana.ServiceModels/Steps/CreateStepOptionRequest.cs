using System.Net;
using ServiceStack;

namespace Bakana.ServiceModels.Steps
{
    [Tag("Step")]
    [Route("/batch/{BatchId}/step/{StepName}/option", HttpMethods.Post, Summary = "Create new Step Option")]
    [ApiResponse(HttpStatusCode.NotFound, "The Batch or Step was not found")]
    [ApiResponse(HttpStatusCode.Conflict, "The Step Option already exists")]
    public class CreateStepOptionRequest : IReturn<CreateStepOptionResponse>
    {
        [ApiMember(
            Description = "A system-generated identifier associated with the Batch",
            DataType = "string",
            ParameterType = "path",
            IsRequired = true)]
        public string BatchId { get; set; }

        [ApiMember(
            Description = "A user-generated identifier associated with the Step",
            DataType = "string",
            ParameterType = "model",
            IsRequired = true)]
        public string StepName { get; set; }

        [ApiMember(
            Description = "A user-generated identifier associated with the Option",
            DataType = "string",
            ParameterType = "model",
            IsRequired = true)]
        public string OptionName { get; set; }

        [ApiMember(
            Description = "A description of the Option",
            DataType = "string",
            ParameterType = "model")]
        public string Description { get; set; }

        [ApiMember(
            Description = "The value assigned to the Option",
            DataType = "string",
            ParameterType = "model",
            IsRequired = true)]
        public string Value { get; set; }
    }

    public class CreateStepOptionResponse : IHasResponseStatus
    {
        public ResponseStatus ResponseStatus { get; set; }
    }
}