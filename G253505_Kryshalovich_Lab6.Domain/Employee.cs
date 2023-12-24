namespace G253505_Kryshalovich_Lab6.Domain;

public class Employee
{
    public string? Name { get; set; }
    public int Rating { get; set; }
    public bool WorkingAtTheMoment { get; set; }

    public Employee(){}
    
    public Employee(string name, int rating, bool workingAtTheMoment)
    {
        Name = name;
        Rating = rating;
        WorkingAtTheMoment = workingAtTheMoment;
    }
}