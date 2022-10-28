using API.Interfaces;
using GraphQL.Types;

namespace API.GraphQL.Query
{
    public class ServiceQuery : ObjectGraphType
    {
        public ServiceQuery(IServiceHandler service)
        {
            Field<StringGraphType>()
                .Name("getProvider")
                .Resolve(context => service.GetProviderName());
        }
    }
}

