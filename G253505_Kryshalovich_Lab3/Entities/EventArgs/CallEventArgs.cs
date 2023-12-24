namespace G253505_Kryshalovich_Lab3.Entities.EventArgs;

public class CallEventArgs
{
    public string Message { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public int Cost { get; }
    public string ToTown { get; }
    
    public CallEventArgs(string message, string firstName,string lastName,int cost,string toTown)
    {
        Message = message;
        FirstName = firstName;
        LastName = lastName;
        Cost = cost;
        ToTown = toTown;
    }
}
