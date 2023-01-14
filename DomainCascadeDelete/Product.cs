namespace DomainCascadeDelete.Domain;
public class Product : BaseEntity {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Product() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Product(string name, string description) {
        Name = name;
        Description = description;
    }

    public string Name { get; protected set; }
    public string Description { get; protected set; }

}
