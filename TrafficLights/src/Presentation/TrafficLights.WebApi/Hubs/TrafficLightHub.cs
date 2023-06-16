using Microsoft.AspNetCore.SignalR;
using TrafficLights.Models.Contracts;
using TrafficLights.Models.Enums;

namespace TrafficLights.WebApi.Hubs
{
    public class TrafficLightHub : Hub, ITrafficLightHub
    {

        private readonly ITrafficLightContext _context;

        public TrafficLightHub(ITrafficLightContext context)
        {
            _context = context;
        }

        public async IAsyncEnumerable<string> StartTrafficLight(Start start)
        {
            if (start.Started)
            {
                await foreach (var state in _context.Initialize(TrafficLightStateType.Red))
                {
                    yield return state.ToString();
                    if (start.ExtensionRequested)
                    {
                       
                    }
                }
            }
            else
            {

            }
        }

        public async IAsyncEnumerable<bool> PushButtonEvent()
        {
          
            var currentState = _context.State;
            if (currentState is GreenLightState greenLightState)
            {
                greenLightState.HastenTransition();

                // Stream the updated state to clients
                yield return true;
            }
        }
    }

    public class Start
    {
        public bool Started { get; set; }
        public bool ExtensionRequested { get; set; }
    }
}
