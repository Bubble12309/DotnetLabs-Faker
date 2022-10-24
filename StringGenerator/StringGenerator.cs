using System.Text;
using University.DotnetLabs.Lab2.FakerLibrary;

namespace University.DotnetLabs.Lab2.StringGenerator;

public class StringGenerator : Generator
{
    private static char[] _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-=+~`'".ToCharArray();

    Random random = new Random();
    public override object? Generate()
    {
        var length = random.Next(1, 50);
        var builder = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            builder.Append(_chars[random.Next(_chars.Length)]);
        }
        return builder.ToString();
    }

    public StringGenerator() => GeneratingType = typeof(string);
}