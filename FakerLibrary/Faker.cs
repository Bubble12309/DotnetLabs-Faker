using Microsoft.VisualBasic.FileIO;
using System.Reflection;
using University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;
using University.DotnetLabs.Lab2.FakerLibrary.Exceptions;

namespace University.DotnetLabs.Lab2.FakerLibrary;

public class Faker : IFaker
{
    public Dictionary<Type, Generator> Generators { get; } = new();
    protected MethodInfo _createMethodInfo = typeof(Faker).GetMethod("Create", new Type[0]);
    public ICollection<Exception> Exceptions { get; } = new LinkedList<Exception>();
    public T? Create<T>()
    {
        Type createdType = typeof(T);
        object createdObject;
        //------------------------------------------------If generator of T is registered--------------------------------
        bool result = Generators.TryGetValue(createdType, out Generator? generator);
        if (result)
        {
            if (generator == null)
            {
                return default;
            }
            else
            {
                return (T)generator.Generate();
            }
        }
        //-------------------------------------------------If generator of t isn't registered-----------------------------
        else
        {
            //------------------------------------------------Start constructor----------------------------------------------
            ConstructorInfo[] constructors = createdType.GetConstructors();
            IEnumerable<ConstructorInfo> publicConstructors = from constructor in constructors where constructor.IsPublic && !constructor.IsAbstract select constructor;
            if (publicConstructors.Count() == 0)
            {
                throw new NotInstanceableException("Class declares no public constructors");
            }
            Random random = new Random();
            ConstructorInfo selectedConstructor = publicConstructors.ElementAt<ConstructorInfo>(
                Index.FromStart(random.Next(publicConstructors.Count() - 1)));
            ParameterInfo[] parametersInfo = selectedConstructor.GetParameters();
            object[] parameters = new object[parametersInfo.Length];
            for (int i = 0; i < parametersInfo.Length; i++)
            {
                ParameterInfo parameterInfo = parametersInfo[i];
                Type parameterType = parameterInfo.ParameterType;
                if (parameterInfo.HasDefaultValue)
                {
                    parameters[i] = parameterInfo.DefaultValue;
                }
                else
                {
                    result = Generators.TryGetValue(parameterType, out generator);
                    if (result && generator != null)
                    {
                        parameters[i] = generator.Generate();
                    }
                    else
                    {
                        if (parameterType.IsValueType)
                        {
                            parameters[i] = Activator.CreateInstance(parameterType);
                        }
                        else
                        {
                            parameters[i] = null;
                        }
                    }
                }

            }
            //-----------------------------------------------------End constructor----------------------------------------------
            createdObject = selectedConstructor.Invoke(parameters);

            if (!createdType.IsValueType)
            {
                Generator referenceReturner = new ReferenceReturner(null, createdType);
                Generators.Remove(createdType);
                Generators.Add(createdType, referenceReturner);
            }
            try
            {
                //------------------------------------------------Start Fields & props----------------------------------------------
                FieldInfo[] publicFields = createdType.GetFields();
                IEnumerable<FieldInfo> nonReadOnlyFields = from publicField in publicFields where !publicField.IsInitOnly select publicField;
                PropertyInfo[] publicProperties = createdType.GetProperties();
                IEnumerable<PropertyInfo> writeableProperties = from publicProperty in publicProperties where publicProperty.CanWrite && (publicProperty.SetMethod != null) select publicProperty;
                //-----------------------------------Fields------------------------------------    
                foreach (FieldInfo fieldInfo in nonReadOnlyFields)
                {
                    Type fieldType = fieldInfo.FieldType;
                    //Console.WriteLine($"{fieldType.Name} field with name {fieldInfo.Name}");
                    result = Generators.TryGetValue(fieldType, out generator);
                    if (result)
                    {
                        if (generator == null)
                        {
                            fieldInfo.SetValue(createdObject, default);
                        }
                        else
                        {
                            fieldInfo.SetValue(createdObject, generator.Generate());
                        }
                    }
                    else
                    {
                        //try ro generate instance
                        MethodInfo recursiveMethod = _createMethodInfo.MakeGenericMethod(fieldType);
                        object? createdField = null;
                        try
                        {
                            createdField = recursiveMethod.Invoke(this, null);
                            if (!fieldType.IsValueType)
                            {
                                Generator referenceReturner = new ReferenceReturner(null, fieldType);
                                Generators.Add(fieldType, referenceReturner);
                            }
                        }
                        catch (Exception ex)
                        {
                            createdField = default;
                            Exceptions.Add(ex);
                        }
                        finally
                        {
                            fieldInfo.SetValue(createdObject, createdField);
                            if (!fieldType.IsValueType)
                            {
                                Generators.Remove(fieldType);
                            }
                        }
                    }
                }
                //-----------------------------------Props------------------------------------    
                foreach (PropertyInfo propertyInfo in writeableProperties)
                {
                    Type propertyType = propertyInfo.PropertyType;
                    result = Generators.TryGetValue(propertyType, out generator);
                    if (result)
                    {
                        if (generator == null)
                        {
                            propertyInfo.SetValue(createdObject, default);
                        }
                        else
                        {
                            propertyInfo.SetValue(createdObject, generator.Generate());
                        }
                    }
                    else
                    {
                        //try ro generate instance
                        MethodInfo recursiveMethod = _createMethodInfo.MakeGenericMethod(propertyType);
                        object? createdField = null;
                        try
                        {
                            createdField = recursiveMethod.Invoke(this, null);
                            if (!propertyType.IsValueType)
                            {
                                Generator referenceReturner = new ReferenceReturner(null, propertyType);
                                Generators.Add(propertyType, referenceReturner);
                            }
                        }
                        catch (Exception ex)
                        {
                            createdField = default;
                            Exceptions.Add(ex);
                        }
                        finally
                        {
                            propertyInfo.SetValue(createdObject, createdField);
                            if (!propertyType.IsValueType)
                            {
                                Generators.Remove(propertyType);
                            }
                        }
                    }
                }
            }
            finally
            {
                if (!createdType.IsValueType)
                {
                    Generators.Remove(createdType);
                }
            }
            //------------------------------------------------End Fields & props----------------------------------------------
            //-----------------------------------End If generator isn't registered---------------------------------------------
        }
        return (T) createdObject;
    }

    public Faker()
    {
        Generator[] generators = {
            new BoolGenerator(),
            new ByteGenerator(),
            new CharGenerator(),
            new DecimalGenerator(),
            new DoubleGenerator(),
            new FloatGenerator(),
            new IntGenerator(),
            new LongGenerator(),
            new SByteGenerator(),
            new ShortGenerator(),
            new UIntGenerator(),
            new ULongGenerator(),
            new UShortGenerator()
        };
        foreach (Generator generator in generators)
        {
            Generators.Add(generator.GeneratingType, generator);
        }
    }
}
