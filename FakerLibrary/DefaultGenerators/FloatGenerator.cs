using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class FloatGenerator : IGenerator
{
    Random random = new Random();
    public object Generate() => random.NextSingle() * float.MaxValue;
}
