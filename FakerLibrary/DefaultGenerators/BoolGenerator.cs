using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class BoolGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => random.Next(0, 1) == 1;
    public BoolGenerator() => GeneratingType = typeof(bool);
}
