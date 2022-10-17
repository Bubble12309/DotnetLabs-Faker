using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class IntGenerator : IGenerator
{
    Random random = new Random();
    public object Generate() => random.Next(int.MinValue, int.MaxValue);
}
