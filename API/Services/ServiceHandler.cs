using API.Interfaces;
using API.Providers;

namespace API.Services
{
    public class ServiceHandler : IServiceHandler
    {
        private ITaskBookProvider _provider = new TaskBookProviderDB();

        public void ChangeProvider(ITaskBookProvider provider)
        {
            _provider = provider;
        }

        public ITaskBookProvider GetProvider()
        {
            return _provider;
        }

        public string GetProviderName()
        {
            switch (_provider)
            {
                case TaskBookProviderDB: { return "sql"; break; }
                case TaskBookProviderXML: { return "xml"; break; }
                default: return "sql";
            }
        }
    }
}
