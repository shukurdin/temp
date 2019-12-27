namespace WMKazakhstan.Models
{
    public struct TrafficLightDigits
    {
        public TrafficLightDigits(int hightLevel, int lowLevel) : this(new Digit(hightLevel), new Digit(lowLevel))
        {
        }

        public TrafficLightDigits(Digit lowLevel) : this(new Digit(0), lowLevel)
        {
        }

        public TrafficLightDigits(Digit hightLevel, Digit lowLevel)
        {
            LowLevel = lowLevel;
            HightLevel = hightLevel;
        }
        
        public Digit LowLevel { get; set; }

        public Digit HightLevel { get; set; }

        public override string ToString()
        {
            return HightLevel.Equals(Digit.Zero)
                ? LowLevel.ToString()
                : $"{HightLevel}{LowLevel}";
        }

        public TrafficLightDigits IncrementLowLevel()
        {
            return new TrafficLightDigits(HightLevel, LowLevel + 1);
        }

        public TrafficLightDigits IncrementHightLevel()
        {
            return new TrafficLightDigits(HightLevel + 1, LowLevel);
        }

        public TrafficLightDigits Increment()
        {
            if (HightLevel.ToNumber() == 9 && LowLevel.ToNumber() == 9)
                return this;

            if (LowLevel.ToNumber() == 9)
                return new TrafficLightDigits(HightLevel + 1, new Digit(0));

            return new TrafficLightDigits(HightLevel, LowLevel + 1);
        }

        public TrafficLightDigits Decrement()
        {
            if (HightLevel.ToNumber() == 0 && LowLevel.ToNumber() == 0)
                return this;

            if (LowLevel.ToNumber() == 0)
                return new TrafficLightDigits(HightLevel - 1, new Digit(9));

            return new TrafficLightDigits(HightLevel, LowLevel - 1);
        }
    }
}
