namespace API.Interfaces
{
    public interface IServiceHandler
    {
        void ChangeProvider(ITaskBookProvider provider);
        ITaskBookProvider GetProvider();
        string GetProviderName();
    }
}
