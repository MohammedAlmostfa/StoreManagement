namespace StoreManagement.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string? Phone { get; private set; }

    public string? Email { get; private set; }

    public string? Address { get; private set; }

    public bool IsActive { get; private set; }

    private Customer()
    {
    }

    public Customer(
        string name,
        string? phone = null,
        string? email = null,
        string? address = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Phone = phone;
        Email = email;
        Address = address;
        IsActive = true;
    }
}