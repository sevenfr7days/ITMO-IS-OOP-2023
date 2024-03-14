using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public interface IMessageBuilder
{
    public MessageBuilder SetTitle(string title);
    public MessageBuilder SetBody(string body);
    public MessageBuilder SetId(Id id);
    public MessageBuilder SetImportanceLevel(ImportanceLevel importanceLevel);
    public MessageBuildingResult Build();
}