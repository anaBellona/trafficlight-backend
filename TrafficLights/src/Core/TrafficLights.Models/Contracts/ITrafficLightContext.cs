using TrafficLights.Models.Enums;

namespace TrafficLights.Models.Contracts
{
    public interface ITrafficLightContext
    {
        IAsyncEnumerable<TrafficLightStateType> Initialize(TrafficLightStateType initialStateType);
        IAsyncEnumerable<TrafficLightStateType> TransitionTo(TrafficLightStateType stateType);
        ITrafficLightState State { get; }
    }
}
