using System.Collections.Generic;
using Bakana.ServiceModels;

namespace Bakana.TestData.ServiceModels
{
    public static class BatchVariables
    {
        public static Variable Schedule => new Variable
        {
            VariableId = "Schedule",
            Description = "Schedule start",
            Value = "12:30:45"
        };
        
        public static Variable Environment => new Variable
        {
            VariableId = "Environment",
            Description = "Deployment Environment",
            Value = "Production"
        };
    }
        
    public static class BatchOptions
    {
        public static Option Debug => new Option
        {
            OptionId = "Debug",
            Description = "Debug Mode",
            Value = "True"
        };
        
        public static Option Log => new Option
        {
            OptionId = "Log",
            Description = "Verbose Logging",
            Value = "True"
        };
    }
        
    public static class BatchArtifactOptions
    {
        public static Option Extract => new Option
        {
            OptionId = "Extract",
            Description = "Extract files",
            Value = "True"
        };
        
        public static Option Compress => new Option
        {
            OptionId = "Compress",
            Description = "Compress files",
            Value = "True"
        };
    }
        
    public static class BatchArtifacts
    {
        public static BatchArtifact Package => new BatchArtifact
        {
            ArtifactId = "Package",
            Description = "First artifact",
            FileName = "package.zip",
            Options = new List<Option>
            {
                BatchArtifactOptions.Extract
            }
        };
        
        public static BatchArtifact DbBackup => new BatchArtifact
        {
            ArtifactId = "DbBackup",
            Description = "Database Backup",
            FileName = "db.zip",
            Options = new List<Option>
            {
                BatchArtifactOptions.Extract
            }
        };
    }

    public static class Batches
    {
        public static CreateBatchRequest FullyPopulated => new CreateBatchRequest
        {
            Description = "First",
            InputArtifacts = new List<BatchArtifact>
            {
                BatchArtifacts.Package
            },
            Variables = new List<Variable>
            {
                BatchVariables.Schedule
            },
            Options = new List<Option>
            {
                BatchOptions.Debug
            },
            Steps = new List<Step>
            {
                Steps.Build,
                Steps.Test
            }
        };
    }
}