using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMKazakhstan.Models
{
    public struct TrafficLight
    {
        public Color Color { get; set; }

        public TrafficLightDigits Digits { get; set; }
    }
}
