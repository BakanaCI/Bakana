using CommandLine;

namespace Bakana.Options
{
    [Verb("batch", HelpText = "Performs operations on the batch")]
    public class BatchOptions
    {
        [Value(0, MetaName = "Batch id",
        HelpText = "System-generated id provided by load operation",
        Required = true)]
        public string BatchId { get; set; }
        
        [Value(1, MetaName = "Operation",
            HelpText = "Operation to perform on the batch",
            Required = true)]
        public BatchOperation? Operation { get; set; }
        
        [Value(2, MetaName = "FileName",
            HelpText = "Name of file to upload or download. Required for upload & download operations.")]
        public string FileName { get; set; }
        
        [Option('n', "name",
            HelpText = "Name of file as referenced by artifacts")]
        public string Name { get; set; }    

        [Option('p', "path",
            HelpText = "Full download path")]
        public string Path { get; set; }
        
        [Option('i', "includeFilter",
            HelpText = "Comma separated list of tags names to determine list of tagged steps to include")]
        public string IncludeFilter { get; set; }    

        [Option('e', "excludeFilter",
            HelpText = "Comma separated list of tags names to determine list of tagged steps to exclude")]
        public string ExcludeFilter { get; set; }    
    }
}