using System;
using System.IO;
using System.Text.Json;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger.Entities;

public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public ResultType Log(string message)
    {
        LogMessageBuildingResult logMessageBuildingResult = new LogMessageBuilder()
            .SetDataTime(DateTime.Now)
            .SetMessage(message)
            .Build();
        if (logMessageBuildingResult is not LogMessageBuildingResult.Success successResult)
            return new ResultType.Fail();

        LogMessage logMessage = successResult.LogMessage;
        string json = JsonSerializer.Serialize(logMessage);
        File.AppendAllText(_filePath, json + Environment.NewLine);
        return new ResultType.Success();
    }
}