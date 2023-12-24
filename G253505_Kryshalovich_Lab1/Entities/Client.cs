namespace G253505_Kryshalovich_Lab1.Entities;

public class Client
{
    public Client(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}