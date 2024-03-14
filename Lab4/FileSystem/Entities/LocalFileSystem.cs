using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;

public class LocalFileSystem : IFileSystem
{
    public CommandExecutionResult DeleteFile(string path)
    {
        if (!FileExists(path)) return new CommandExecutionResult.FileWasNotFound("File was not found");

        DeleteFile(path);
        return new CommandExecutionResult.Success();
    }

    public CommandExecutionResult MoveFile(string sourcePath, string destinationPath)
    {
        if (!this.FileExists(sourcePath))
        {
            return new CommandExecutionResult.FileWasNotFound("File was not found");
        }

        string? fileName = this.GetFileName(sourcePath);

        if (fileName is not null)
        {
            destinationPath = this.Combine(destinationPath, fileName);
        }

        if (this.FileExists(destinationPath))
        {
            return new CommandExecutionResult.FileIsAlreadyExist("File is already exists");
        }

        File.Move(sourcePath, destinationPath);
        return new CommandExecutionResult.Success();
    }

    public CommandExecutionResult CopyFile(string sourcePath, string destinationPath)
    {
        if (!this.FileExists(sourcePath))
        {
            return new CommandExecutionResult.FileWasNotFound("File was not found");
        }

        string? fileName = this.GetFileName(sourcePath);

        if (fileName is not null)
        {
            destinationPath = Combine(destinationPath, fileName);
        }

        if (FileExists(destinationPath))
        {
            return new CommandExecutionResult.FileIsAlreadyExist("File was not found");
        }

        CopyFile(sourcePath, destinationPath);
        return new CommandExecutionResult.Success();
    }

    public CommandExecutionResult RenameFile(string sourcePath, string newName)
    {
        if (!this.FileExists(sourcePath)) return new CommandExecutionResult.FileWasNotFound("File was not found");

        string? directory = Path.GetDirectoryName(sourcePath);
        if (directory is null) return new CommandExecutionResult.DirectoryWasNotFound("Directory was not found");
        string destinationPath = Path.Combine(directory, newName);
        File.Move(sourcePath, destinationPath);
        return new CommandExecutionResult.Success();
    }

    public string ReadFile(string path)
    {
        return File.ReadAllText(path);
    }

    public string GetFullPath(string path)
    {
        return Path.GetFullPath(path);
    }

    public string? GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }

    public string? GetFileName(string path)
    {
        return Path.GetFileName(path);
    }

    public string Combine(string path, string name)
    {
        return Path.Combine(path, name);
    }

    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public bool DirectoryExists(string path)
    {
        return Directory.Exists(path);
    }

    public bool IsPathRooted(string path)
    {
        return Path.IsPathRooted(path);
    }

    public IList<string> GetFiles(string directoryPath)
    {
        return Directory.GetFiles(directoryPath);
    }

    public IList<string> GetDirectories(string rootPath)
    {
        return Directory.GetDirectories(rootPath);
    }
}