using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using University.DotnetLabs.Lab2.FakerLibrary;
namespace University.DotneLabs.Lab2.ConsoleSection;

internal class IntValueGenerator : Generator
{
    private int _value;
    public override object? Generate()
    {
        return _value;
    }

    public IntValueGenerator(int value = 0) {

        _value = value;
        GeneratingType = typeof(int);
    } 
}
