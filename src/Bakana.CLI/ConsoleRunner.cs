using System.Threading.Tasks;
using Bakana.Operations;
using Bakana.Options;
using CommandLine;

namespace Bakana
{
    public interface IConsoleRunner
    {
        Task<int> Run(string[] args);
    }

    public class ConsoleRunner : IConsoleRunner
    {
        private readonly IOperationFactory operationFactory;

        public ConsoleRunner(IOperationFactory operationFactory)
        {
            this.operationFactory = operationFactory;
        }

        public async Task<int> Run(string[] args)
        {
            var result = await Parser.Default
                .ParseArguments<InitOptions, InfoOptions, SetOptions, LoadOptions, BatchOptions, ProducerOptions, WorkerOptions>(args)
                .MapResult(
                    (InitOptions options) => operationFactory.Create<InitOptions>().Run(options), 
                    (InfoOptions options) => operationFactory.Create<InfoOptions>().Run(options), 
                    (SetOptions options) => operationFactory.Create<SetOptions>().Run(options),
                    (LoadOptions options) => operationFactory.Create<LoadOptions>().Run(options),
                    (BatchOptions options) => operationFactory.Create<BatchOptions>().Run(options),
                    (ProducerOptions options) => operationFactory.Create<ProducerOptions>().Run(options),
                    (WorkerOptions options) => operationFactory.Create<WorkerOptions>().Run(options),
                    errs => Task.FromResult(1));

            return result;
        }
    }
}