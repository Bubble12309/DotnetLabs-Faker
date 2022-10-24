using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DotnetLabs.Lab2.FakerLibrary;

internal class ReferenceReturner : Generator
{
    private object? _ref;
    public override object? Generate()
    {
        return _ref;
    }

    public ReferenceReturner(object? reference, Type type)
    {
        _ref = reference;
        GeneratingType = type;
    }
}
