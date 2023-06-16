using TrafficLights.Models.Enums;

namespace TrafficLights.Models.Contracts
{
    public interface ITrafficLightNotifierService
    {
        Task PublishLightChange(TrafficLightStateType stateType);
    }
}
