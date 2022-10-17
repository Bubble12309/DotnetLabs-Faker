using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class ShortGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => (short) random.Next(short.MinValue, short.MaxValue);
    public ShortGenerator() => GeneratingType = typeof(short);
}
