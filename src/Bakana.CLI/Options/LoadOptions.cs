using CommandLine;

namespace Bakana.Options
{
    [Verb("load", HelpText = "Loads a batch file")]
    public class LoadOptions
    {
        [Value(0, MetaName = "Batch filename",
        HelpText = "Name of batch file to be loaded. Can be Json or Yaml format.",
        Required = true)]
        public string FileName { get; set; }
        
        [Option('f', "format",
            HelpText = "Format of batch file. Can be Json or Yaml")]
        public BatchFileFormat? Format { get; set; }    
        
        [Option('s', "start",
            HelpText = "Auto starts the batch")]
        public bool Start { get; set; }    
        
        [Option('t', "track",
            HelpText = "Tracks and waits for batch completion. Should be combined with 's|start")]
        public bool Track { get; set; }    
    }
}