public abstract class Person
{
    public string Id { get; }
    public string Name { get; }

    protected Person(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public abstract void Treat();
}
