namespace Example.Models;

public class NewMessageWriter : IMessageWriter
{
    public void Write(string message)
    {
        Console.WriteLine($"MessageWriter.Write(New: message: \"{message}\")");
    }
}