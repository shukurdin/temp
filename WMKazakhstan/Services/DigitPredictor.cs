using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMKazakhstan.Models;

namespace WMKazakhstan.Services
{
    public class DigitPredictor
    {
        public IEnumerable<TrafficLightDigits> Predict(TrafficLightDigits digit)
        {
            var lowLevel = digits.Where(x => x.PosiblyEqual(digit.LowLevel)).ToArray();
            var hightLevel = digits
                .Where(x => x.PosiblyEqual(digit.HightLevel) && !x.Equals(new Digit(0)));

            for(var i = 0; i < lowLevel.Length; i++)
                yield return new TrafficLightDigits(lowLevel[i]);

            foreach (var hight in hightLevel)
                for (var i = 0; i < lowLevel.Length; i++)
                    yield return new TrafficLightDigits(hight, lowLevel[i]);
        }
        
        private static HashSet<Digit> digits = new HashSet<Digit>
        {
            new Digit(0),
            new Digit(1),
            new Digit(2),
            new Digit(3),
            new Digit(4),
            new Digit(5),
            new Digit(6),
            new Digit(7),
            new Digit(8),
            new Digit(9)
        };
    }
}
