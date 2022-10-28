using API.Interfaces;
using API.Providers;
using GraphQL;
using GraphQL.Types;

namespace API.GraphQL.Mutation
{
    public class ServiceMutation : ObjectGraphType
    {
        private TaskBookProviderDB providerDB = new TaskBookProviderDB();
        private TaskBookProviderXML providerXML = new TaskBookProviderXML();

        public ServiceMutation(IServiceHandler service)
        {
            Field<StringGraphType>()
                .Name("changeProvider")
                .Argument<NonNullGraphType<StringGraphType>>("provider")
                .Resolve(context =>
                {
                    var provider = context.GetArgument<string>("provider");
                    switch (provider)
                    {
                        case "xml": {
                                service.ChangeProvider(providerXML);
                                break;
                                };

                        case "sql": {
                                service.ChangeProvider(providerDB);
                                break;
                            };
                    }
                    
                    return provider;
                });
        }
    }
}
