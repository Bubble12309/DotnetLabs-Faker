using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;
public sealed class ListGenerator : Generator
{
    private Faker _faker;
    Random _random = new Random();
    public override object? Generate()
    {
        Type[]? genericTypes = _faker.CurrentGenerics;
        Type genericType;
        if (genericTypes == null || genericTypes.Length == 0)
        {
            genericType = typeof(object);
        }
        else 
        {
            genericType = genericTypes[0];
        }
        int listSize = _random.Next(2, 20);
        IList list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(genericType));
        for (int i = 0; i < listSize; i++)
        {
            list.Add(_faker.Create(genericType));
        }
        return list;
    }

    public ListGenerator(Faker faker) 
    {
        GeneratingType = typeof(List<>);
        _faker = faker;
    } 
}
