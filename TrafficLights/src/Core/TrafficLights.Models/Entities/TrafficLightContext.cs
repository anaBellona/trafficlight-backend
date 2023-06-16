using TrafficLights.Models.Contracts;
using TrafficLights.Models.Enums;

namespace TrafficLights.Models.Entities
{
    public class TrafficLightContext : ITrafficLightContext
    {
        private ITrafficLightState _state = null;

        private readonly ITrafficLightStateFactory _stateFactory;
        public ITrafficLightState State => _state;

        public TrafficLightContext(ITrafficLightStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public async IAsyncEnumerable<TrafficLightStateType> Initialize(TrafficLightStateType initialStateType)
        {
            await foreach (var state in TransitionTo(initialStateType))
            {
                yield return state;
            }
        }

        public async IAsyncEnumerable<TrafficLightStateType> TransitionTo(TrafficLightStateType stateType)
        {
            _state = _stateFactory.Create(stateType);
            _state.SetContext(this);

            while (true)
            {
                await foreach (var nextStateType in _state.Handle())
                {
                    yield return nextStateType;

                    if (nextStateType != stateType)
                    {
                        stateType = nextStateType;
                        _state = _stateFactory.Create(stateType);
                        _state.SetContext(this);
                        break;
                    }
                }
            }
        }
    }
}
