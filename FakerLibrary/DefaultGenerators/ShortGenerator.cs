using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class ShortGenerator : IGenerator
{
    Random random = new Random();
    public object Generate() => (short) random.Next(short.MinValue, short.MaxValue);
}
