using TrafficLights.Models.Enums;

namespace TrafficLights.Models.Contracts
{
    public interface ITrafficLightStateFactory
    {
        ITrafficLightState Create(TrafficLightStateType stateType);
    }
}
