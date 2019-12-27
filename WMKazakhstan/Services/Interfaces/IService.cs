using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMKazakhstan.Models;

namespace WMKazakhstan.Services.Interfaces
{
    public interface IService
    {
        IEnumerable<TrafficLightDigits> Predict(TrafficLight trafficLight, IReadOnlyCollection<TrafficLightDigits[]> prevDigits);
    }
}
