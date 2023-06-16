using TrafficLights.Models.Entities;
using TrafficLights.Models.Enums;

public class GreenLightState : TrafficLightState
{
    public GreenLightState(int minDuration, int maxDuration) : base(minDuration, maxDuration) { }

    public override async IAsyncEnumerable<TrafficLightStateType> Handle()
    {
        await Task.Delay(MinimumDuration);

        yield return TrafficLightStateType.Yellow;
    }

    public void HastenTransition()
    {
        
    }
}