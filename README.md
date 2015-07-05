# Better Auto Mapper
---- 

A library to help you map one object, to another with as little code as possible.

## Examples

```csharp
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

var animal = new Animal { Name = "Fred", Limbs = 4 };
var cat = new BetterAutoMapper().Map<Animal, Cat>(animal);

Console.WriteLine(cat.Name) // <- "Fred"
```

## Features

 - [Case Insensitive Mapping](https://github.com/codeimpossible/betterautomapper/blob/master/BetterAutoMapper.Tests/PropertyCasing.cs). `someProperty` will map to `SomeProperty` or even `SomEpRopertY`
 - [Strict maps](https://github.com/codeimpossible/betterautomapper/blob/master/BetterAutoMapper.Tests/StrictMapping.cs). Want to know if you're losing data when mapping? We've got that.
 - [Property Transposing](https://github.com/codeimpossible/betterautomapper/blob/master/BetterAutoMapper.Tests/PropertyTransposing.cs). Want `FullName` to be `FirstName + " " + LastName`? That's easy. Want to transform data using some of your own code? Yep, totally do-able.
