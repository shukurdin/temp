using System.Linq;
using WMKazakhstan.Models;
using WMKazakhstan.Services;
using Xunit;

namespace UnitTests
{
    public class DigitPredictorTests
    {
        [Fact]
        public void PredictPossibleDigits()
        {
            var predictor = new DigitPredictor();

            var trafficLightDigit = new TrafficLightDigits(new Digit(0), new Digit("0011101"));

            var result = predictor.Predict(trafficLightDigit)
                .ToArray();

            Assert.Contains(new TrafficLightDigits(0, 2), result);
            Assert.Contains(new TrafficLightDigits(0, 8), result);
            Assert.Contains(new TrafficLightDigits(8, 2), result);
            Assert.Contains(new TrafficLightDigits(8, 2), result);
        }
    }
}
