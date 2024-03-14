namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class Name
{
    public Name(string forename)
    {
        Forename = forename;
    }

    public string Forename { get; }

    public Name Clone()
    {
        return new Name(this.Forename);
    }
}