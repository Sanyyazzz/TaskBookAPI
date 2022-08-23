using API.Interfaces;
using API.Providers;
using GraphQL;
using GraphQL.Types;

namespace API.GraphQL.Mutation
{
    public class ServiceMutation : ObjectGraphType
    {
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
                                service.ChangeProvider(new TaskBookProviderXML());
                                break;
                                };

                        case "sql": {
                                service.ChangeProvider(new TaskBookProviderDB());
                                break;
                            };
                    }
                    
                    return provider;
                });
        }
    }
}
