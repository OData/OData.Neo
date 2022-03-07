//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

var adotNetClient = new ADotNetClient();

var githubPipeline = new GithubPipeline
{
    Name = "OData Neo Build",

    OnEvents = new Events
    {
        Push = new PushEvent
        {
            Branches = new string[] { "main" }
        },

        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "main" }
        }
    },

    Jobs = new Jobs
    {
        Build = new BuildJob
        {
            RunsOn = BuildMachines.Windows2022,
            
            Steps = new List<GithubTask>
            {
                new CheckoutTaskV2
                {
                    Name = "Checking out code"
                },

                new SetupDotNetTaskV1
                {
                    Name = "Setting up DotNet version",

                    TargetDotNetVersion = new TargetDotNetVersion
                    {
                        DotNetVersion = "7.0.100-preview.1.22110.4",
                        IncludePrerelease = true
                    }
                },

                new RestoreTask
                {
                    Name = "Restoring Nuget Packages"
                },

                new DotNetBuildTask
                {
                    Name = "Building Solution"
                },

                new TestTask
                {
                    Name = "Testing"
                }
            }
        }
    }
};


adotNetClient.SerializeAndWriteToFile(githubPipeline, "../../../../.github/workflows/dotnet.yml");