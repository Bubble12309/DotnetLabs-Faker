using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class UShortGenerator : IGenerator
{
    Random random = new Random();
    public object Generate() => (ushort)random.Next(ushort.MinValue, ushort.MaxValue);
}
