using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class BoolGenerator : IGenerator
{
    Random random = new Random();
    public object Generate() => random.Next(0, 1) == 1;
}
