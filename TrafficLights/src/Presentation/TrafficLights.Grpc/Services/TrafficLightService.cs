using Grpc.Core;
using GrpcService.Server;

namespace TrafficLights.Grpc.Services
{
    public class TrafficLightService : TrafficLight.TrafficLightBase
    {
        private readonly ILogger<TrafficLightService> _logger;

        public TrafficLightService(ILogger<TrafficLightService> logger)
        {
            _logger = logger;
        }

        public override async Task SendMessage(
            IAsyncStreamReader<ClientToServerMessage> requestStream, 
            IServerStreamWriter<ServerToClientMessage> responseStream, 
            ServerCallContext context)
        {
            var clientToServer = ClientToServer(requestStream, context);
            var serverToClient = ServerToClient(responseStream, context);

            await Task.WhenAll(clientToServer, serverToClient);
        }

        private static async Task ServerToClient(IServerStreamWriter<ServerToClientMessage> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                await responseStream.WriteAsync(new ServerToClientMessage
                {
                    TrafficLightColor = ""
                });
            }
        }

        private async Task ClientToServer(IAsyncStreamReader<ClientToServerMessage> requestStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext() && !context.CancellationToken.IsCancellationRequested)
            {
                var message = requestStream.Current;
                _logger.LogInformation("The client said " + message.Isextended);
            }
        }
    }
}
