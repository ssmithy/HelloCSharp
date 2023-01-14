using System.ComponentModel.DataAnnotations.Schema;

namespace DomainCascadeDelete.Domain;
public class Order : BaseEntity {
    public string Number { get; protected set; }


    private readonly List<OrderItem> orderItems = new List<OrderItem>();
    public IReadOnlyCollection<OrderItem> Items => orderItems;

    [NotMapped]
    public int Test { get; set; }
    protected Order() {
        orderItems = new List<OrderItem>();
        Number = string.Empty;
    }
    public Order(string number) {
        Number = number;
    }

    public void AddProduct(Product product) {
        orderItems.Add(new OrderItem(product, 1));
    }

    public void RemoveItem(OrderItem orderItem) {
        orderItems.Remove(orderItem);
    }
}