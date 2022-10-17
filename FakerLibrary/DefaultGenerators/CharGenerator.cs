using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class CharGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => Convert.ToChar(random.Next(0, Convert.ToInt32(char.MaxValue)));
    public CharGenerator() => GeneratingType = typeof(char);
}
