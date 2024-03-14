using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;

public interface IFileSystem
{
    CommandExecutionResult DeleteFile(string path);
    CommandExecutionResult MoveFile(string sourcePath, string destinationPath);
    CommandExecutionResult CopyFile(string sourcePath, string destinationPath);
    CommandExecutionResult RenameFile(string sourcePath, string newName);
    string ReadFile(string path);
    string GetFullPath(string path);
    string? GetDirectoryName(string path);
    string? GetFileName(string path);
    string Combine(string path, string name);
    bool FileExists(string path);
    bool DirectoryExists(string path);
    bool IsPathRooted(string path);
    IList<string> GetFiles(string directoryPath);
    IList<string> GetDirectories(string rootPath);
}