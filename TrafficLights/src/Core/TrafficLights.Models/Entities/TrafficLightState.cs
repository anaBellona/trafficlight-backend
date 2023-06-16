using TrafficLights.Models.Contracts;
using TrafficLights.Models.Enums;

namespace TrafficLights.Models.Entities
{
    public abstract class TrafficLightState : ITrafficLightState
    {
        protected ITrafficLightContext _context;
        public int MinimumDuration { get; }
        public int MaximumDuration { get; }

        public TrafficLightState(int minDuration, int maxDuration)
        {
            MinimumDuration = minDuration;
            MaximumDuration = maxDuration;
        }

        public void SetContext(ITrafficLightContext context)
        {
            this._context = context;
        }

        public abstract IAsyncEnumerable<TrafficLightStateType> Handle();
    }
}
