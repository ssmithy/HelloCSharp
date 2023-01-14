namespace DomainCascadeDelete.Domain;
public class OrderItem : BaseEntity {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected OrderItem() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public OrderItem(Product product, int qty) {
        Product = product;
    }

    public Product Product { get; protected set; }
    public int ProductId { get; protected set; }
    public int Qty { get; protected set; }
}
