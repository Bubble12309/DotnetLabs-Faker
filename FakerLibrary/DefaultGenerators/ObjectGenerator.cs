using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class ObjectGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => new object();
}
