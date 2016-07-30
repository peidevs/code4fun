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

// approach #1
class Animals {
    static Dictionary<AnimalType, Func<Animal>> registry = new Dictionary<AnimalType, Func<Animal>>();
    
    static Animals() {
        registry[AnimalType.Bear] = () => { return new Bear(); };     
        registry[AnimalType.Dragon] = () => { return new Dragon(); };     
        registry[AnimalType.Tiger] = () => { return new Tiger(); };     
    }    
    
    public static Animal Make(AnimalType type) {
        Func<Animal> f = registry[type];
        Animal result = f();
        return result;
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
