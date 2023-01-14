namespace DomainCascadeDelete.Domain;
public interface IDomainEntity {
}
public interface IDatabaseEntity {
    int Id { get; }
}

public class BaseEntity : IDatabaseEntity {
    public int Id { get; protected set; }

    public DateTime CreatedTimestamp { get; private set; }

    public BaseEntity() {
        CreatedTimestamp = DateTime.UtcNow;
    }

}