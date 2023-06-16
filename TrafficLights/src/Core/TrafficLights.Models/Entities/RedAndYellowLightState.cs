﻿using TrafficLights.Models.Enums;

namespace TrafficLights.Models.Entities
{
    public class RedAndYellowLightState : TrafficLightState
    {
        public RedAndYellowLightState(int minDuration, int maxDuration) : base(minDuration, maxDuration)
        { }

        public override async IAsyncEnumerable<TrafficLightStateType> Handle()
        {
            await Task.Delay(MinimumDuration);

            yield return TrafficLightStateType.Green;
        }
    }
}
