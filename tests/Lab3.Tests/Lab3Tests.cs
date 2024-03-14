using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.ImportanceFilters;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messenger.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using NSubstitute;
using Xunit;
using ILogger = Itmo.ObjectOrientedProgramming.Lab3.Logger.Entities.ILogger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Lab3Tests
{
    private const int KOneFunctionCall = 1;

    [Fact]
    public void ReceiveMessage_ShouldBeReceived_WithoutFiltration()
    {
        var user = new User(new Id(1));
        var userRecipient = new UserRecipient(user);
        var topic = new Topic("Topic", userRecipient);
        MessageBuildingResult messageBuildingResult = new MessageBuilder().SetTitle("Title").SetBody("Body")
            .SetImportanceLevel(ImportanceLevel.Medium).SetId(new Id(1)).Build();

        Assert.IsType<MessageBuildingResult.Success>(messageBuildingResult);
        var successResult = (MessageBuildingResult.Success)messageBuildingResult;

        IMessage message = successResult.Message;
        topic.Send(message);
        Assert.Contains(user.UnreadMessages, m => m.Message == message);
    }

    [Fact]
    public void WriteMessage_ShouldBeSameWithExpected_WriteByMessenger()
    {
        var messenger = new ExternalMessenger();
        var messengerRecipient = new MessengerRecipient(messenger);
        var topic = new Topic("Topic", messengerRecipient);
        MessageBuildingResult messageBuildingResult = new MessageBuilder().SetTitle("Title").SetBody("Body")
            .SetImportanceLevel(ImportanceLevel.Medium).SetId(new Id(1)).Build();

        Assert.IsType<MessageBuildingResult.Success>(messageBuildingResult);
        var successResult = (MessageBuildingResult.Success)messageBuildingResult;

        IMessage message = successResult.Message;
        TextWriter originalConsoleOut = Console.Out;
        using var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        topic.Send(message);

        string expectedOutput = $"Messenger: {message.ConvertMessageToString()}\n";
        string actualOutput = consoleOutput.ToString();

        Assert.Equal(expectedOutput, actualOutput);

        Console.SetOut(originalConsoleOut);
    }

    [Fact]
    public void MarkAsRead_ShouldBeMarkedAsRead_OneTimeMarkAsRead()
    {
        var user = new User(new Id(1));
        var userRecipient = new UserRecipient(user);
        var topic = new Topic("Topic", userRecipient);

        MessageBuildingResult messageBuildingResult = new MessageBuilder().SetTitle("Title").SetBody("Body")
            .SetImportanceLevel(ImportanceLevel.Medium).SetId(new Id(1)).Build();

        Assert.IsType<MessageBuildingResult.Success>(messageBuildingResult);
        var successResult = (MessageBuildingResult.Success)messageBuildingResult;

        IMessage message = successResult.Message;
        topic.Send(message);
        IUserMessage userMessage = user.UnreadMessages.First();

        userRecipient.MarkAsRead(userMessage.Message.Id);

        Assert.True(userMessage.IsRead);
        Assert.DoesNotContain(user.UnreadMessages, m => m == userMessage);
        Assert.Contains(user.ReadMessages, m => m == userMessage);
    }

    [Fact]
    public void MarkAsRead_Fail_TwoTimesMarkAsRead()
    {
        var user = new User(new Id(1));
        var userRecipient = new UserRecipient(user);
        var topic = new Topic("Topic", userRecipient);

        MessageBuildingResult messageBuildingResult = new MessageBuilder().SetTitle("Title").SetBody("Body")
            .SetImportanceLevel(ImportanceLevel.Medium).SetId(new Id(1)).Build();

        Assert.IsType<MessageBuildingResult.Success>(messageBuildingResult);
        var successResult = (MessageBuildingResult.Success)messageBuildingResult;

        IMessage message = successResult.Message;
        topic.Send(message);
        IUserMessage userMessage = user.UnreadMessages.First();

        userRecipient.MarkAsRead(userMessage.Message.Id);
        ResultType resultType = userRecipient.MarkAsRead(userMessage.Message.Id);

        Assert.Equal(new ResultType.Fail(), resultType);
    }

    [Theory]
    [ClassData(typeof(Generator))]
    public void ReceiveMessage_ShouldNotReceive_WhenPriorityIsLow(ImportanceLevel filterLevel, ImportanceLevel messageLevel)
    {
        IUser userMock = Substitute.For<IUser>();
        var userRecipient = new UserRecipient(userMock);
        var userRecipientFilter = new ImportanceFilter(userRecipient, filterLevel);
        MessageBuildingResult messageBuildingResult = new MessageBuilder().SetTitle("Title").SetBody("Body")
            .SetImportanceLevel(messageLevel).SetId(new Id(1)).Build();

        Assert.IsType<MessageBuildingResult.Success>(messageBuildingResult);
        var successResult = (MessageBuildingResult.Success)messageBuildingResult;

        IMessage message = successResult.Message;
        var topic = new Topic("Topic", userRecipientFilter);

        topic.Send(message);
        userMock.DidNotReceive().ReceiveMessage(message);
    }

    [Fact]
    public void LogAndReceive_ShouldBeLoggedAndReceived_WithoutAnyConditions()
    {
        ILogger loggerMock = Substitute.For<ILogger>();
        IRecipient? recipientMock = Substitute.For<IRecipient>();
        var logger = new Logger.Entities.LoggingRecipient(loggerMock, recipientMock);
        IMessage? message = Substitute.For<IMessage>();

        logger.ReceiveMessage(message);

        loggerMock.Received(KOneFunctionCall).Log(message.ConvertMessageToString());
        recipientMock.Received(KOneFunctionCall).ReceiveMessage(message);
    }

    [Fact]
    public void WriteMessage_ShouldBeWrote_WithoutAnyConditions()
    {
        IExternalMessenger? messengerMock = Substitute.For<IExternalMessenger>();
        var message = new Message("title", "body", ImportanceLevel.Low, new Id(100));

        messengerMock.WriteMessage(message.ConvertMessageToString());

        messengerMock.Received(KOneFunctionCall)
            .WriteMessage(Arg.Is<string>(msg => msg == message.ConvertMessageToString()));
    }
}