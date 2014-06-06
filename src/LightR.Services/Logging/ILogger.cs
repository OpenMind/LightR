namespace LightR.Services.Logging
{
    public interface ILogger
    {
        ILog Get(string name);
    }
}