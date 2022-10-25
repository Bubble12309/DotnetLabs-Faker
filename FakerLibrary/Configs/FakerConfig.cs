using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace University.DotnetLabs.Lab2.FakerLibrary;
public class FakerConfig
{
    internal Dictionary<string, Generator> Generators { get; } = new();

    public bool Add<T, R>(Expression<Func<T, R>> expression, Generator generator)
    {
        MemberExpression member = (MemberExpression)expression.Body;
        return Generators.TryAdd(typeof(T).FullName + '.' + member.Member.Name.ToLower(), generator);
    }
}
