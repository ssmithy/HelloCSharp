namespace DomainCascadeDelete.Domain;
public class Product : BaseEntity {

    public Product(string name, string description) {
        Name = name;
        Description = description;
    }

    public string Name { get; protected set; }
    public string Description { get; protected set; }

}
