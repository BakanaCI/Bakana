using System;
using System.Collections.Generic;
using Bakana.Core.Entities;

namespace Bakana.TestData.Entities
{
    public static class BatchVariables
    {
        public static BatchVariable Schedule => new BatchVariable
        {
            Name = "Schedule",
            Description = "Schedule start",
            Value = "12:30:45"
        };
        
        public static BatchVariable Environment => new BatchVariable
        {
            Name = "Environment",
            Description = "Deployment Environment",
            Value = "Production"
        };
    }
        
    public static class BatchOptions
    {
        public static BatchOption Debug => new BatchOption
        {
            Name = "Debug",
            Description = "Debug Mode",
            Value = "True"
        };
        
        public static BatchOption Log => new BatchOption
        {
            Name = "Log",
            Description = "Verbose Logging",
            Value = "True"
        };
    }
        
    public static class BatchArtifactOptions
    {
        public static BatchArtifactOption Extract => new BatchArtifactOption
        {
            Name = "Extract",
            Description = "Extract files",
            Value = "True"
        };
        
        public static BatchArtifactOption Compress => new BatchArtifactOption
        {
            Name = "Compress",
            Description = "Compress files",
            Value = "True"
        };
    }
        
    public static class BatchArtifacts
    {
        public static BatchArtifact Package => new BatchArtifact
        {
            Name = "Package",
            Description = "First artifact",
            FileName = "package.zip",
            Options = new List<BatchArtifactOption>
            {
                BatchArtifactOptions.Extract
            }
        };
        
        public static BatchArtifact DbBackup => new BatchArtifact
        {
            Name = "DbBackup",
            Description = "Database Backup",
            FileName = "db.zip",
            Options = new List<BatchArtifactOption>
            {
                BatchArtifactOptions.Extract
            }
        };
    }

    public static class Batches
    {
        public static Batch FullyPopulated => new Batch
        {
            Description = "First",
            ExpiresOn = DateTime.Now,
            Artifacts = new List<BatchArtifact>
            {
                BatchArtifacts.Package
            },
            Variables = new List<BatchVariable>
            {
                BatchVariables.Schedule
            },
            Options = new List<BatchOption>
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
