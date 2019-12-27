using System.Collections.Generic;
using System.Linq;
using WMKazakhstan.Models;
using WMKazakhstan.Services;
using Xunit;

namespace UnitTests
{
    public class TrafficLightTimePredictorTests
    {
        [Fact]
        public void Test()
        {
            var predictor = new TrafficLightTimePredictor();

            var trafficLight5 = new TrafficLight
            {
                Color = Color.Green,
                Digits = new TrafficLightDigits(new Digit(0), new Digit("1101001"))
            };

            var trafficLight4 = new TrafficLight
            {
                Color = Color.Green,
                Digits = new TrafficLightDigits(new Digit(0), new Digit("0101000"))
            };

            var trafficLight3 = new TrafficLight
            {
                Color = Color.Green,
                Digits = new TrafficLightDigits(new Digit(0), new Digit("1001001"))
            };

            var trafficLight2 = new TrafficLight
            {
                Color = Color.Green,
                Digits = new TrafficLightDigits(new Digit(0), new Digit("0011101"))
            };

            var result5 = predictor.Predict(trafficLight5)
                .ToArray();

            var result4 = predictor.Predict(trafficLight4)
                .ToArray();

            var result3 = predictor.Predict(trafficLight3)
                .ToArray();

            var result2 = predictor.Predict(trafficLight2)
                .ToArray();
        }
    }
}
