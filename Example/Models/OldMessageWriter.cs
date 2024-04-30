namespace Example.Models;

public class OldMessageWriter : IMessageWriter
{
    public void Write(string message)
    {
        Console.WriteLine($"MessageWriter.Write(Old: message: \"{message}\")");
    }
}