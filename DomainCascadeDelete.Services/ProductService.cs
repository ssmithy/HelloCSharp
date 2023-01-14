using DomainCascadeDelete.Domain;

namespace DomainCascadeDelete.Services; 
public interface IProductService {
    Task<IEnumerable<Product>> GetProducts();
}

public class Catalog : IProductService {

    public Task<IEnumerable<Product>> GetProducts() {
        throw new NotImplementedException();
    }
}
