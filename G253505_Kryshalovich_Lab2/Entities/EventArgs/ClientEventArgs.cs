namespace G253505_Kryshalovich_Lab2.Entities.EventArgs;



public class ClientEventArgs
{
    public string Message { get; }
    public string FirstName { get; }
    public string LastName { get; }

    public ClientEventArgs(string message,string firstName,string lastName)
    {  
        Message = message;
        FirstName = firstName;
        LastName = lastName;
    }
}
