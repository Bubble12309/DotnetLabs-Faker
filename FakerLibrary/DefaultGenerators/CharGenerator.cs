using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class CharGenerator : IGenerator
{
    Random random = new Random();
    public object Generate() => Convert.ToChar(random.Next(0, Convert.ToInt32(char.MaxValue)));
}
