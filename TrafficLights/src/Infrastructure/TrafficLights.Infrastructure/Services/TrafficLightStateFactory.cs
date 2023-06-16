using Microsoft.Extensions.Configuration;
using TrafficLights.Models.Contracts;
using TrafficLights.Models.Entities;
using TrafficLights.Models.Enums;

namespace TrafficLights.Infrastructure.Services
{
    public class TrafficLightStateFactory : ITrafficLightStateFactory
    {
        private readonly IConfiguration _configuration;

        public TrafficLightStateFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ITrafficLightState Create(TrafficLightStateType stateType)
        {
            // Using configuration to get durations for states.
            var minDuration = int.Parse(_configuration.GetSection($"TrafficLightStateDurations:{stateType}:MinDuration").Value);
            var maxDuration = int.Parse(_configuration.GetSection($"TrafficLightStateDurations:{stateType}:MaxDuration").Value);

            switch (stateType)
            {
                case TrafficLightStateType.Red:
                    return new RedLightState(minDuration, maxDuration);
                case TrafficLightStateType.RedAndYellow:
                    return new RedAndYellowLightState(minDuration, maxDuration);
                case TrafficLightStateType.Yellow:
                    return new YellowLightState(minDuration, maxDuration);
                case TrafficLightStateType.Green:
                    return new GreenLightState(minDuration, maxDuration);
                default:
                    throw new ArgumentException($"Invalid state type: {stateType}");
            }
        }
    }
}
