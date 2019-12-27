using System;
using System.Collections.Generic;
using System.Linq;
using WMKazakhstan.Models;
using WMKazakhstan.Services.Interfaces;

namespace WMKazakhstan.Services
{
    public class TrafficLightTimePredictor /*: IService*/
    {
        private readonly DigitPredictor digitPredictor = new DigitPredictor();

        private readonly List<TrafficLightDigits[]> prevDigits = new List<TrafficLightDigits[]>();

        public IEnumerable<TrafficLightDigits> Predict(TrafficLight trafficLight)
        {
            var possibleDigits = digitPredictor.Predict(trafficLight.Digits);

            var digits = PredictWithPrevDigits(possibleDigits);

            prevDigits.Add(GetPrevDigits(digits));

            return digits;
        }

        private IEnumerable<TrafficLightDigits> PredictWithPrevDigits(IEnumerable<TrafficLightDigits> possibleDigits)
        {
            if (prevDigits.Count == 0)
                return possibleDigits;

            var incrementedDigits = possibleDigits;

            for (var i = prevDigits.Count - 1; i >= 0; i--)
            {
                var hashSet = new HashSet<TrafficLightDigits>();

                foreach(var item in incrementedDigits)
                {
                    var low = item.IncrementLowLevel();

                    if (!hashSet.Contains(low))
                        hashSet.Add(low);

                    var hight = item.IncrementHightLevel();

                    if (!hashSet.Contains(hight))
                        hashSet.Add(hight);

                    var incremented = item.Increment();

                    if (!hashSet.Contains(incremented))
                        hashSet.Add(incremented);
                }

                var prev = prevDigits.ElementAt(i);

                incrementedDigits = prev.Intersect(hashSet);
            }

            return incrementedDigits;
        }

        private TrafficLightDigits[] GetPrevDigits(IEnumerable<TrafficLightDigits> digits)
        {
            var list = digits.ToArray();

            for(var i = 0; i < prevDigits.Count; i++)
            {
                list = prevDigits[i].Intersect(list.Select(x => x.Decrement()))
                    .ToArray();
            }

            return list;
        }
    }
}
