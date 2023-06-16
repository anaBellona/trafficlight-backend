using TrafficLights.Models.Enums;

namespace TrafficLights.Models.Contracts
{
    public interface ITrafficLightState
    {
        void SetContext(ITrafficLightContext context);
        abstract IAsyncEnumerable<TrafficLightStateType> Handle();
        int MinimumDuration { get; }
        int MaximumDuration { get; }
    }
}
