using Example.Models;
using Flagsmith;

public class MyMessageFactory : IMessageFactory
{
    private IServiceProvider _serviceProvider;
    public MyMessageFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<IMessageWriter> GetMessageWriter()
    {
        var flagsmithClient = _serviceProvider.GetRequiredService<IFlagsmithClient>();
        Flagsmith.IFlags flags = await _serviceProvider.GetRequiredService<IFlagsmithClient>().GetEnvironmentFlags();
        if (await flags.IsFeatureEnabled("secret_button"))
        {
            return new NewMessageWriter();
        }
        return new OldMessageWriter();
    }
}

public interface IMessageFactory
{
    Task<IMessageWriter> GetMessageWriter();
}
