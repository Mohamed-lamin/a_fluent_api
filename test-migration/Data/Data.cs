namespace CreateAminimalAPI.Data;


public class User
{
    public int ID { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<Toy> Toys { get; set; } = new();


}

public class Toy
{
    public int ID { get; set; }

    public string Name { get; set; } = string.Empty;

    public User? User { get; set; }

    public int UserID { get; set; }
}

