namespace Bakana.TestData.IO
{
    public class JsonSamples
    {
        public static string FullyPopulatedBatch => @"
{
  ""Description"": ""First"",
  ""Options"": [
    {
      ""Name"": ""Debug"",
      ""Description"": ""Debug Mode"",
      ""Value"": ""True""
    }
  ],
  ""Variables"": [
    {
      ""Name"": ""Schedule"",
      ""Description"": ""Schedule start"",
      ""Value"": ""12:30:45"",
      ""Sensitive"": false
    }
  ],
  ""Artifacts"": [
    {
      ""Name"": ""Package"",
      ""Description"": ""First artifact"",
      ""FileName"": ""package.zip"",
      ""Options"": [
        {
          ""Name"": ""Extract"",
          ""Description"": ""Extract files"",
          ""Value"": ""True""
        }
      ]
    }
  ],
  ""Steps"": [
    {
      ""Name"": ""BuildStep"",
      ""Description"": ""Build Step"",
      ""Tags"": [
        ""Build""
      ],
      ""Requirements"": [
        ""Docker"",
        ""Build""
      ],
      ""Options"": [
        {
          ""Name"": ""BuildAlways"",
          ""Description"": ""Build Always"",
          ""Value"": ""True""
        }
      ],
      ""Variables"": [
        {
          ""Name"": ""SourcePath"",
          ""Description"": ""Path to Source code"",
          ""Value"": ""./src"",
          ""Sensitive"": false
        },
        {
          ""Name"": ""Profile"",
          ""Description"": ""Build Profile "",
          ""Value"": ""PRODUCTION"",
          ""Sensitive"": false
        }
      ],
      ""Artifacts"": [
        {
          ""OutputArtifact"": false,
          ""Name"": ""Source"",
          ""Description"": ""Source Code"",
          ""FileName"": ""Source.zip"",
          ""Options"": [
            {
              ""Name"": ""Extract"",
              ""Description"": ""Extract files"",
              ""Value"": ""True""
            }
          ]
        },
        {
          ""OutputArtifact"": true,
          ""Name"": ""Binaries"",
          ""Description"": ""Binaries"",
          ""FileName"": ""Build.zip"",
          ""Options"": [
            {
              ""Name"": ""Compress"",
              ""Description"": ""Compress files"",
              ""Value"": ""True""
            }
          ]
        }
      ],
      ""Commands"": [
        {
          ""Name"": ""RestoreCmd"",
          ""Description"": ""Dot Net Restore"",
          ""Run"": ""dot net restore"",
          ""Options"": [
            {
              ""Name"": ""CMDOPT1"",
              ""Description"": ""Optional1"",
              ""Value"": ""CMDOPT1VAL""
            },
            {
              ""Name"": ""CMDOPT2"",
              ""Description"": ""Optional2"",
              ""Value"": ""CMDOPT2VAL""
            }
          ],
          ""Variables"": [
            {
              ""Name"": ""DemoArg"",
              ""Description"": ""Demo Arg"",
              ""Value"": ""--demo"",
              ""Sensitive"": false
            },
            {
              ""Name"": ""HelpArg"",
              ""Description"": ""Help Arg"",
              ""Value"": ""--help"",
              ""Sensitive"": false
            }
          ]
        },
        {
          ""Name"": ""BuildCmd"",
          ""Description"": ""Dot Net Build"",
          ""Run"": ""dot net build"",
          ""Options"": [
            {
              ""Name"": ""Production"",
              ""Description"": ""Production Mode"",
              ""Value"": ""True""
            }
          ]
        }
      ]
    },
    {
      ""Name"": ""TestStep"",
      ""Description"": ""Test Step"",
      ""Dependencies"": [
        ""BuildStep""
      ],
      ""Tags"": [
        ""TEST""
      ],
      ""Requirements"": [
        ""Windows"",
        ""Database""
      ],
      ""Options"": [
        {
          ""Name"": ""BuildAlways"",
          ""Description"": ""Build Always"",
          ""Value"": ""True""
        }
      ],
      ""Variables"": [
        {
          ""Name"": ""TestPath"",
          ""Description"": ""Path to test project"",
          ""Value"": ""./tests"",
          ""Sensitive"": false
        },
        {
          ""Name"": ""TestFilter"",
          ""Description"": ""NUnit Test Filter"",
          ""Value"": ""--category = 'agency'"",
          ""Sensitive"": false
        }
      ],
      ""Artifacts"": [
        {
          ""OutputArtifact"": false,
          ""Name"": ""Source"",
          ""Description"": ""Source Code"",
          ""FileName"": ""Source.zip"",
          ""Options"": [
            {
              ""Name"": ""Extract"",
              ""Description"": ""Extract files"",
              ""Value"": ""True""
            }
          ]
        },
        {
          ""OutputArtifact"": true,
          ""Name"": ""Results"",
          ""Description"": ""Test Results"",
          ""FileName"": ""Results.zip""
        }
      ],
      ""Commands"": [
        {
          ""Name"": ""DeployCmd"",
          ""Description"": ""Deploy Command"",
          ""Run"": ""runner -deploy"",
          ""Variables"": [
            {
              ""Name"": ""ConnectionString"",
              ""Description"": ""Connection String"",
              ""Value"": ""localhost:8000"",
              ""Sensitive"": false
            }
          ]
        },
        {
          ""Name"": ""TestCmd"",
          ""Description"": ""Test Command"",
          ""Run"": ""runner -test"",
          ""Options"": [
            {
              ""Name"": ""Debug"",
              ""Description"": ""Debug Mode"",
              ""Value"": ""True""
            }
          ],
          ""Variables"": [
            {
              ""Name"": ""OverrideArg"",
              ""Description"": ""Override Arg"",
              ""Value"": ""--override"",
              ""Sensitive"": false
            },
            {
              ""Name"": ""OutArg"",
              ""Description"": ""Out Arg"",
              ""Value"": ""--out"",
              ""Sensitive"": false
            }
          ]
        }
      ]
    }
  ]
}
";
        
    }
}