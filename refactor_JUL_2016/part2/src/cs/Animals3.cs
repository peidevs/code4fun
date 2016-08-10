using System;
using System.Reflection;

abstract class Animal {
    abstract public Animal Poke();
    
    public Animal Poke(String s) {
        Console.WriteLine("TRACER Poked " + s);
        return this;
    }
}

class Bear : Animal {
    public override Animal Poke() { return base.Poke("the Bear"); }
}

class Dragon : Animal {
    public override Animal Poke() { return base.Poke("the Dragon"); }
}

class Tiger : Animal {
    public override Animal Poke() { return base.Poke("the Tiger"); }
}

enum AnimalType 
{ 
    [AssociatedType(typeof(Bear))]   Bear, 
    [AssociatedType(typeof(Dragon))] Dragon, 
    [AssociatedType(typeof(Tiger))]  Tiger 
};

static class MyExtensionMethods
{
    public static System.Type FindType(this AnimalType value)
    {
        System.Type type = null;

        string valueStr = value.ToString();
        FieldInfo fieldInfo = value.GetType().GetField(valueStr);
        AssociatedTypeAttribute[] attributes = (AssociatedTypeAttribute[])
            fieldInfo.GetCustomAttributes(typeof(AssociatedTypeAttribute), false);
        if (attributes != null && attributes.Length > 0)
        {
            type = attributes[0].type;
        }

        return type;
    }
}

class AssociatedTypeAttribute : Attribute
{
    private System.Type _type;

    public AssociatedTypeAttribute(System.Type type)
    {
        _type = type;
    }

    public System.Type type
    {
        get { return _type; }
    }
}

// approach #3
class Animals {
    public static Animal Make(AnimalType animalType) {
        System.Type t = animalType.FindType();
        Animal animal = (Animal) Activator.CreateInstance(t);
        return animal; 
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("from main");

        Animals.Make(AnimalType.Bear).Poke();
        Animals.Make(AnimalType.Dragon).Poke();
        Animals.Make(AnimalType.Bear).Poke();
    }
}
