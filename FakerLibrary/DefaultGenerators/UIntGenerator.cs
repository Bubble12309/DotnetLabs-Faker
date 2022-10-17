using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class UIntGenerator : IGenerator
{
    Random random = new Random();
    public object Generate() => (uint) random.Next(0, int.MaxValue);
}