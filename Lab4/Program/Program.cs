using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.DirectoryTreeConfigs.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileShow.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.TreeListShows;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Program;

public static class Program
{
    public static void Main()
    {
        var localFileSystem = new LocalFileSystem();
        DirectoryTreeConfig basedDirectoryTreeConfig = new DirectoryTreeConfigFactory().CreateConcreteDirectoryTreeConfig();
        var showFileStrategy = new ConsoleShowFile();
        var showTreeStrategy = new ConsoleShowTree();

        var state = new Context(localFileSystem, basedDirectoryTreeConfig, showFileStrategy, showTreeStrategy);

        ChainLinkBase chain = new ChainOfResponsibilityFactory().CreateChain();
        while (true)
        {
            string? requestString = Console.ReadLine();
            if (requestString is not null && requestString.ToUpperInvariant() == "Q")
            {
                Console.WriteLine("The program has completed its work");
                break;
            }

            if (requestString is not null)
            {
                {
                    string[] parts = requestString.Split();
                    var components = parts.Select(v => new RequestComponent(v)).ToList();
                    var request = new Request(components);

                    HandleResult result = chain.Handle(request);
                    if (result is HandleResult.Success success)
                    {
                        CommandExecutionResult executionResult = success.Command.Execute(state);

                        if (executionResult is CommandExecutionResult.Success)
                        {
                            Console.WriteLine("Command was successfully executed");
                        }
                        else if (executionResult is CommandExecutionResult.Fail fail)
                        {
                            Console.WriteLine(fail.ErrorMessage);
                        }
                    }
                }
            }
        }
    }
}