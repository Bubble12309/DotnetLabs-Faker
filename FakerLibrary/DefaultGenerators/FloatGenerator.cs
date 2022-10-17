using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class FloatGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => random.NextSingle() * float.MaxValue;
    public FloatGenerator() => GeneratingType = typeof(float);
}
