using System.ComponentModel.DataAnnotations.Schema;

namespace DomainCascadeDelete.Domain;
public class Order : BaseEntity {
    public string Number { get; protected set; }


    private readonly List<OrderItem> _orderItems = new List<OrderItem>();
    public IReadOnlyCollection<OrderItem> Items => _orderItems;

    [NotMapped]
    public int Test { get; set; }

    public Order(string number) {
        Number = number;
    }
}