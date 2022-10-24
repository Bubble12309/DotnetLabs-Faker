namespace University.DotnetLabs.Lab2.FakerLibrary.Exceptions;

public class NotInstanceableException : Exception
{
    public NotInstanceableException() : base() { }
    public NotInstanceableException(string message) : base(message) { }
}
