using API.Interfaces;
using API.Providers;

namespace API.Services
{
    public class ServiceHandler : IServiceHandler
    {
        private ITaskBookProvider _provider = new TaskBookProviderXML();

        public void ChangeProvider(ITaskBookProvider provider)
        {
            _provider = provider;
        }

        public ITaskBookProvider GetProvider()
        {
            return _provider;
        }
    }
}
