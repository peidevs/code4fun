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

class Animals {
    
    public static Animal Make(AnimalType type) {
        Animal result = null;

        switch (type)
        {
            case AnimalType.Bear:
                result = new Bear();
                break;            
            case AnimalType.Dragon:
                result = new Dragon();
                break;            
            default:
                result = new Tiger();
                break;            
        } 

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
