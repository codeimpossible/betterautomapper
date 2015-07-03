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