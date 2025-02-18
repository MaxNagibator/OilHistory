﻿namespace OilHistory.Web.Extensions.EndpointExtensions;

public interface IEndpointDefinition
{
    void DefineServices(IServiceCollection services);
    void DefineEndpoints(WebApplication app);
}
