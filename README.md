# Better Auto Mapper
---- 

A library to help you map one object, to another with as little code as possible.

## Examples

```csharp
using System;
using BetterAutoMapper;

namespace MyProgram
{
    public class Animal
    {
        public string Name { get; set; }
        public int Limbs { get; set; }
    }

    public class Cat
    {
        public string Name { get; set; }
        public string Limbs { get; set; }
        public bool HasTail { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var animal = new Animal { Name = "Fred", Limbs = 4 };
            var cat = BAM.BOOM.Map<Animal, Cat>(animal);
            
            // you can also instantiate a BetterAutoMapper instance if you like
            var anotherCat = new BetterAutoMapper().Map<Animal, Cat>(animal);

            Console.WriteLine(cat.Name);
            Console.ReadLine();
        }
    }
}
```

## Features and Other Examples

 - [Case Insensitive Mapping](https://github.com/codeimpossible/betterautomapper/blob/master/BetterAutoMapper.Tests/PropertyCasing.cs). `someProperty` will map to `SomeProperty` or even `SomEpRopertY`
 - [Strict maps](https://github.com/codeimpossible/betterautomapper/blob/master/BetterAutoMapper.Tests/StrictMapping.cs). Want to know if you're losing data when mapping? We've got that.
 - [Property Transposing or Custom maps](https://github.com/codeimpossible/betterautomapper/blob/master/BetterAutoMapper.Tests/PropertyTransposing.cs). Want `FullName` to be `FirstName + " " + LastName`? That's easy. Want to transform data using some of your own code? Yep, totally do-able.


## Installation

Use Nuget! You can check out the [nuget page for more information](https://www.nuget.org/packages/BetterAutoMapper/).

```
PM> Install-Package BetterAutoMapper
```
