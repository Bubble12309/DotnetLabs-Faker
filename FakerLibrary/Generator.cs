namespace University.DotnetLabs.Lab2.FakerLibrary;

public abstract class Generator
{
    public Type GeneratingType { get; protected set; } = typeof(object);
    public abstract object Generate();
}
