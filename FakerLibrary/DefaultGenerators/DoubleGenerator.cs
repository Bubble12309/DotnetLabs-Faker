using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class DoubleGenerator : IGenerator
{
    Random random = new Random();
    public object Generate() => random.NextDouble() * double.MaxValue;
}
