using TrafficLights.Models.Enums;

namespace TrafficLights.Models.Entities
{
    public class YellowLightState : TrafficLightState
    {

        public YellowLightState(int minDuration, int maxDuration) : base(minDuration, maxDuration)
        {

        }

        public override async IAsyncEnumerable<TrafficLightStateType> Handle()
        {
            await Task.Delay(MinimumDuration);

            yield return TrafficLightStateType.Red;
        }
    }
}
