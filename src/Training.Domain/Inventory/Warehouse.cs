namespace Training.Domain.Inventory;

/// <summary>
/// Represents a warehouse in the SellNet domain.
/// </summary>
public class Warehouse : Entity
{
    public Warehouse() { }

    /// <summary>
    /// Gets the name of the warehouse.
    /// </summary>
    public string Name { get; private set; } = string.Empty;
   
    /// <summary>
    /// Gets or sets the state where the warehouse is located.
    /// </summary>
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// Gets the city where the warehouse is located.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets the capacity of the warehouse.
    /// </summary>
    public int Capacity { get;  set; } = 0;

    /// <summary>
    /// Gets the maximum capacity of the warehouse.
    /// </summary>
    public int Max { get;  set; } = 0;

    /// <summary>
    /// Products stored in the warehouse.
    /// </summary>
    public ICollection<Product> Products { get;  set; } = new List<Product>();

    /// <summary>
    /// Creates a new instance of the Warehouse class.
    /// </summary>
    /// <param name="state"></param>
    /// <param name="city"></param>
    /// <returns></returns>
    public static Warehouse Create(string Name, int max, string state, string city, int capacity)
        => new()
        {
            Id = Guid.NewGuid(),
            Name = Name,
            Max = max,
            State = state,
            City = city,
            Capacity = capacity
        };

    public static Warehouse CreateWithId(Guid warehouseId, string name, int max,string state, string city, int capacity)
        => new()
        {
            Id = warehouseId,
            Name = name,
            Max = max,
            State = state,
            City = city,
            Capacity = capacity
        };
}
