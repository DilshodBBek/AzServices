using Grpc.Core;
using Protos;
namespace ServiceCatalog.Infrastructure.ExternalServices
{
    public class IntegrationWithSPS :Integrator.IntegratorClient
    {
        public override Response GetStatus(Request request, CallOptions options)
        {
            return base.GetStatus(request, options);
        }
    }
}
