using System.IO;
using System;
using System.Collections.Generic;

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

enum AnimalType { Bear, Dragon, Tiger };

// approach #2
class Animals {
    static Dictionary<AnimalType, System.Type> registry = new Dictionary<AnimalType, System.Type>();
 
    static Animals() {
        registry[AnimalType.Bear] = typeof(Bear);
        registry[AnimalType.Dragon] = typeof(Dragon);
        registry[AnimalType.Tiger] = typeof(Tiger);
    }   
    
    public static Animal Make(AnimalType type) {
        System.Type t = registry[type];
        return (Animal) Activator.CreateInstance(t);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("from main");

        Animals.Make(AnimalType.Bear).Poke();
        Animals.Make(AnimalType.Dragon).Poke();
        Animals.Make(AnimalType.Tiger).Poke();
    }
}
